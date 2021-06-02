using System;
using System.Collections;
using UnityEngine;
using Zenject;

namespace Assets.Scripts
{
    class Player : IInitializable, IDisposable
    {
        private PlayerWeaponController _playerWeaponController;
        private MonoBehaviour _monoBehaviour;
        private IEnumerator _enumerator;
        public Player(PlayerWeaponController playerWeaponController)
        {
            _playerWeaponController = playerWeaponController;
        }

        public void Initialize()
        {
            Debug.Log("Player Initialize!");
        }

        public void ShootAt(IEnemy enemy)
        {
            _playerWeaponController.CurrentWeapon.ApplyDamage(enemy);
        }

        public void NextWeapon()
        {
            _playerWeaponController.Next();
            Debug.Log($"Current weapon: {_playerWeaponController.CurrentWeapon}");
        }

        public void PreviousWeapon()
        {
            _playerWeaponController.Previous();
            Debug.Log($"Current weapon: {_playerWeaponController.CurrentWeapon}");
        }

        public void ShootAt(MonoBehaviour monoBehaviour, IEnemy enemy)
        {
            _monoBehaviour = monoBehaviour;
            _enumerator = FireCoroutine(enemy);
            _monoBehaviour.StartCoroutine(_enumerator);
        }

        private IEnumerator FireCoroutine(IEnemy enemy)
        {
            while (true)
            {
                _playerWeaponController.CurrentWeapon.ApplyDamage(enemy);
                yield return new WaitForSeconds(0.5f);
            }
        }


        public void Dispose()
        {
            Debug.Log("Player Disposed!");
            if(_enumerator != null)
            {
                _monoBehaviour.StopCoroutine(_enumerator);
            }
        }
    }
}

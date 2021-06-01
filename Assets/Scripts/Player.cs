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
            _playerWeaponController.SetTarget(enemy);
        }

        public void SwitchWeapon(int delta)
        {
            _playerWeaponController.SetPlayerWeapon(delta);
        }

        public void ShootAt(MonoBehaviour monoBehaviour, IEnemy enemy)
        {
            _monoBehaviour = monoBehaviour;
            _enumerator = _playerWeaponController.SetTargetCoroutine(enemy);
            _monoBehaviour.StartCoroutine(_enumerator);
        }


        public void Dispose()
        {
            Debug.Log("Player Disposed!");
            _monoBehaviour.StopCoroutine(_enumerator);
        }
    }
}

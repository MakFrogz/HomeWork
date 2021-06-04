using Assets.Scripts.Services;
using System;
using System.Collections;
using UnityEngine;
using Zenject;

namespace Assets.Scripts
{
    class Player : IInitializable, IDisposable
    {
        private PlayerWeaponController _playerWeaponController;
        private ICoroutineService _coroutineService;
        private Coroutine _fireCoroutine;
        public Player(PlayerWeaponController playerWeaponController, ICoroutineService coroutineService)
        {
            _playerWeaponController = playerWeaponController;
            _coroutineService = coroutineService;
        }

        public void Initialize()
        {
            Debug.Log("Player Initialize!");
        }

        public void ShootAt(IEnemy enemy)
        {
            _fireCoroutine = _coroutineService.RunCoroutine(ShootWithDelay(2f, enemy));
        }

        private IEnumerator ShootWithDelay(float delay, IEnemy enemy)
        {
            yield return new WaitForSeconds(delay);
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

        public void Dispose()
        {
            Debug.Log("Player Disposed!");
            _coroutineService.EndCoroutine(_fireCoroutine);
        }
    }
}

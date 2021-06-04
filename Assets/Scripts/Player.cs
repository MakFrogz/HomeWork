using Assets.Scripts.Services;
using System;
using System.Collections;
using UnityEngine;
using Zenject;

namespace Assets.Scripts
{
    class Player : IInitializable, IDisposable
    {
        [Inject]
        private PlayerWeaponController _playerWeaponController;
        [Inject]
        private ICoroutineService _coroutineService;
        
        private Coroutine _fireCoroutine;
        private bool _isInCooldown;

        public void Initialize()
        {
            Debug.Log("Player Initialize!");
        }

        public void ShootAt(IEnemy enemy)
        {
            if(enemy == null)
            {
                Debug.LogWarning("I need a target!!!!");
                return;
            }

            if (_isInCooldown)
            {
                Debug.Log("Cooldown!");
                return;
            }
            _fireCoroutine = _coroutineService.RunCoroutine(Cooldown(_playerWeaponController.CurrentWeapon.ReloadTime, () => _isInCooldown = false));
            _playerWeaponController.CurrentWeapon.ApplyDamage(enemy);
            _isInCooldown = true;

        }

        private IEnumerator Cooldown(float cooldown, Action callback)
        {
            yield return new WaitForSeconds(cooldown);
            callback?.Invoke();
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
            if(_coroutineService != null && _fireCoroutine != null)
            {
                _coroutineService.EndCoroutine(_fireCoroutine);
            }
        }
    }
}

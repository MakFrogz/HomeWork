using System;
using UnityEngine;
using Zenject;

namespace Assets.Scripts
{
    class Player : IInitializable, IDisposable
    {
        [Inject]
        private PlayerWeaponController _playerWeaponController;
        private Coroutine _coroutine;

        public void ShootAt(IEnemy enemy)
        {
            _playerWeaponController.SetTarget(enemy);
        }

        public void SwitchWeapon(int delta)
        {
            _playerWeaponController.SetPlayerWeapon(delta);
        }

        public void ShootAtCoroutine(MonoBehaviour monoBehaviour, IEnemy enemy)
        {
            _coroutine = monoBehaviour.StartCoroutine(_playerWeaponController.SetTargetCoroutine(enemy));
        }

        public void Initialize()
        {
            throw new System.NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}

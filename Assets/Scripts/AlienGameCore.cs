using UnityEditor;
using UnityEngine;
using Zenject;
using System.Collections.Generic;

namespace Assets.Scripts
{
    class AlienGameCore
    {
        [Inject]
        private Player _player;
        [Inject]
        private IEnemy _alien;

        private MonoBehaviour _monoBehaviour;

        public void SetMonoBehaviour(MonoBehaviour monoBehaviour)
        {
            _monoBehaviour = monoBehaviour;
        }
        public void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                _player.ShootAt(_alien);
            }

            if (Input.GetKeyDown(KeyCode.C))
            {
                _player.ShootAtCoroutine(_monoBehaviour ,_alien);
            }


            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                _player.SwitchWeapon(-1);
            }

            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                _player.SwitchWeapon(1);
            }
        }

    }
}
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

        public void Update(MonoBehaviour monoBehaviour)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                _player.ShootAt(_alien);
            }

            if (Input.GetKeyDown(KeyCode.C))
            {
                _player.ShootAt(monoBehaviour ,_alien);
            }


            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                _player.PreviousWeapon();
            }

            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                _player.NextWeapon();
            }
        }

    }
}
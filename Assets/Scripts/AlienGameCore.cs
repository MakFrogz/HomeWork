using UnityEngine;
using Zenject;

namespace Assets.Scripts
{
    class AlienGameCore
    {
        [Inject]
        private Player _player;
        [Inject]
        private IEnemy _alien;

        public void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                _player.ShootAt(_alien);
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
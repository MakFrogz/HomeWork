using UnityEngine;
using Zenject;

namespace Assets.Scripts
{
    class Alien : IEnemy
    {
        private int _health = 100;
        private bool _alive = true;
        [Inject]
        private IArmor _lightArmor;
        public void TakeDamage(int damage)
        {
            if (!_alive)
            {
                Debug.LogError("Alien is dead!");
                return;
            }

            _health -= _lightArmor.AbsorbDamage(damage);
            _alive = _health > 0;
            Debug.Log($"Current health: {_health}. Alien took damage {damage}!");
            if (!_alive)
            {
                Debug.LogWarning("Alien is dead!");
            }
        }
    }
}

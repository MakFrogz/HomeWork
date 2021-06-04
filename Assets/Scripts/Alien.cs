using UnityEngine;
using Zenject;

namespace Assets.Scripts
{
    [CreateAssetMenu(fileName = "Alien", menuName = "Enemies/Alien")]
    class Alien : ScriptableObject, IEnemy
    {
        [Inject]
        private IArmor _lightArmor;

        [SerializeField]
        [Range(1,200)]
        private int _health = 100;

        public bool Alive { get; private set; } = true;
        public void TakeDamage(int damage)
        {
            if (!Alive)
            {
                Debug.LogError("Alien is dead!");
                return;
            }

            _health -= _lightArmor.AbsorbDamage(damage);
            Alive = _health > 0;
            Debug.Log($"Current health: {_health}. Alien took damage {damage}!");
            if (!Alive)
            {
                Debug.LogWarning("Alien is dead!");
            }
        }


        public class Factory : PlaceholderFactory<Alien>
        {

        }
    }
}

using UnityEngine;
using Zenject;

namespace Assets.Scripts
{
    [CreateAssetMenu(fileName = "Pistol", menuName = "Weapon/Pistol")]
    class Pistol : ScriptableObject, IWeapon
    {
        [Inject]
        private PistolBullet.Factory _factory;

        [SerializeField]
        [Range(1,50)]
        private int _damage = 15;
        
        public void ApplyDamage(IEnemy enemy)
        {
            PistolBullet pistolBullet = _factory.Create();
            pistolBullet.ApplyDamage(enemy, _damage);
        }
    }
}

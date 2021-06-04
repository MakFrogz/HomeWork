using UnityEngine;
using Zenject;
namespace Assets.Scripts
{
    [CreateAssetMenu(fileName = "Shotgun", menuName = "Weapon/Shotgun")]
    class Shotgun : ScriptableObject, IWeapon
    {
        [Inject]
        private ShotgunBullet.Factory _factory;

        [SerializeField]
        [Range(1,50)]
        private int _damage = 40;

        public void ApplyDamage(IEnemy enemy)
        {
            ShotgunBullet shotgunBullet = _factory.Create();
            shotgunBullet.ApplyDamage(enemy, _damage);
        }
    }
}

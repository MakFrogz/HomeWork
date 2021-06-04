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

        [SerializeField]
        [Range(0f, 2f)]
        private float _reloadTime;
        public float ReloadTime 
        { 
            get 
            { 
                return _reloadTime; 
            }
            
            private set
            {
                _reloadTime = value;
            }
        }

        public void ApplyDamage(IEnemy enemy)
        {
            ShotgunBullet shotgunBullet = _factory.Create();
            shotgunBullet.ApplyDamage(enemy, _damage);
        }
    }
}

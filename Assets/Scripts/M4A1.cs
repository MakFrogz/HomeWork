using UnityEngine;
using Zenject;
namespace Assets.Scripts
{
    [CreateAssetMenu(fileName = "M4A1", menuName = "Weapon/M4A1")]
    class M4A1 : ScriptableObject, IWeapon
    {
        [Inject]
        private M4A1Bullet.Factory _factory;

        [SerializeField]
        [Range(1, 50)]
        private int _damage = 25;

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
            M4A1Bullet m4a1Bullet = _factory.Create();
            m4a1Bullet.ApplyDamage(enemy, _damage);
        }
    }
}

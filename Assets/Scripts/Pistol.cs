

namespace Assets.Scripts
{
    class Pistol : IWeapon
    {
        private int _damage;
        public Pistol(int damage)
        {
            _damage = damage;
        }
        public void ApplyDamage(IEnemy enemy)
        {
            enemy.TakeDamage(_damage);
        }
    }
}


namespace Assets.Scripts
{
    class M4A1 : IWeapon
    {
        private int _damage;

        public M4A1(int damage)
        {
            _damage = damage;
        }

        public void ApplyDamage(IEnemy enemy)
        {
            enemy.TakeDamage(_damage);
        }
    }
}

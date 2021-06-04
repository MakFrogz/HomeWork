
namespace Assets.Scripts
{
    class Shotgun : IWeapon
    {
        private int _damage;

        public Shotgun (int damage)
        {
            _damage = damage;
        }
        public void ApplyDamage(IEnemy enemy)
        {
            enemy.TakeDamage(_damage);
        }
    }
}

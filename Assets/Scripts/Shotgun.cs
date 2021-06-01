using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

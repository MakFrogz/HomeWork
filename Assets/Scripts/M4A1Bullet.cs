using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zenject;

namespace Assets.Scripts
{
    class M4A1Bullet
    {
        public void ApplyDamage(IEnemy enemy, int damage)
        {
            enemy.TakeDamage(damage);
        }

        public class Factory : PlaceholderFactory<M4A1Bullet>
        {
        }
    }
}

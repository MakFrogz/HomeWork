using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zenject;
namespace Assets.Scripts
{
    class PistolBullet
    {

        public void ApplyDamage(IEnemy enemy, int damage)
        {
            enemy.TakeDamage(damage);
        }

        public class Factory : PlaceholderFactory<PistolBullet> 
        {
        }
    }
}

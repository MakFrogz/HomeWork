using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using Zenject;

namespace Assets.Scripts
{
    class ShotgunBullet
    {

        public void ApplyDamage(IEnemy enemy, int damage)
        {
            enemy.TakeDamage(damage);
        }

        public class Factory : PlaceholderFactory<ShotgunBullet> 
        {
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts
{
    class LightArmor : IArmor
    {
        private int _armor;
        public LightArmor(int armor)
        {
            _armor = armor;
        }
        public int AbsorbDamage(int damage)
        {
            return Mathf.Clamp(damage - _armor, 0 , 1000);
        }
    }
}

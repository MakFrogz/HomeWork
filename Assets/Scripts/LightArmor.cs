using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            return damage - _armor;
        }
    }
}

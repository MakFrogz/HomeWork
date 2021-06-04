using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts
{
    interface IWeapon
    {
        float ReloadTime { get; }
        void ApplyDamage(IEnemy enemy);
    }
}

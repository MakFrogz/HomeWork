using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts
{
    class PlayerWeaponController
    {
        private List<IWeapon> _weapons;
        public IWeapon CurrentWeapon { get; private set; }
        public PlayerWeaponController(List<IWeapon> weapons)
        {
            _weapons = weapons;
            CurrentWeapon = _weapons[0];
            Debug.Log($"Current weapon: {CurrentWeapon}");
        }

        public void Next()
        {
            int weaponIndex = _weapons.IndexOf(CurrentWeapon) + 1;
            if (weaponIndex > _weapons.Count - 1)
            {
                CurrentWeapon = _weapons[0];
                return;
            }
            CurrentWeapon = _weapons[weaponIndex];
        }

        public void Previous()
        {
            int weaponIndex = _weapons.IndexOf(CurrentWeapon) - 1;
            if (weaponIndex < 0)
            {
                CurrentWeapon = _weapons[_weapons.Count - 1];
                return;
            }
            CurrentWeapon = _weapons[weaponIndex];
        }
    }
}

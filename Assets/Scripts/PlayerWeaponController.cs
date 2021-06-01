using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts
{
    class PlayerWeaponController
    {
        private List<IWeapon> _weapons;
        private IWeapon _weapon;
        public PlayerWeaponController(List<IWeapon> weapons)
        {
            _weapons = weapons;
            _weapon = _weapons[0];
            Debug.Log($"Current weapon: {_weapon}");
        }

        public void SetTarget(IEnemy enemy)
        {
            _weapon.ApplyDamage(enemy);
        }

        public IEnumerator SetTargetCoroutine (IEnemy enemy)
        {
            while(true){
                yield return new WaitForSeconds(0.5f);
                _weapon.ApplyDamage(enemy);
            }
        }

        public void SetPlayerWeapon(int delta)
        {
            int weaponIndex = _weapons.IndexOf(_weapon) + delta;
            if (weaponIndex < 0)
            {
                _weapon = _weapons[_weapons.Count - 1];
            }

            else if (weaponIndex > _weapons.Count - 1)
            {
                _weapon = _weapons[0];
            }
            else
            {
                _weapon = _weapons[weaponIndex];
            }
            Debug.Log($"Current weapon: {_weapon}");
        }
    }
}

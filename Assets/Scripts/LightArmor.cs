using UnityEngine;

namespace Assets.Scripts
{
    [CreateAssetMenu(fileName = "Light_Armor", menuName = "Armors/Light Armor")]
    class LightArmor : ScriptableObject, IArmor
    {
        [SerializeField]
        [Range(0,20)]
        private int _armor = 5;
        
        public int AbsorbDamage(int damage)
        {
            return Mathf.Clamp(damage - _armor, 0 , 1000);
        }
    }
}

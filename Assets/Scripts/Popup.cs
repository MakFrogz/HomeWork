using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using Zenject;
namespace Assets.Scripts
{
    class Popup : MonoBehaviour
    {
        public class Factory : PlaceholderFactory<string, Vector3,Popup>
        {
        }

        [Inject]
        private void Construct(string name, Vector3 position)
        {
            gameObject.name = name;
            transform.position = position;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using Zenject;
namespace Assets.Scripts
{
    class ClickHandler : MonoBehaviour
    {

        [Inject]
        private Popup.Factory _popupFactory;

        public void CreatePopup()
        {
            Vector3 randomPosition = new Vector3(UnityEngine.Random.Range(0, 1000), UnityEngine.Random.Range(0, 1000), UnityEngine.Random.Range(0, 1000));
            _popupFactory.Create("I am pop-up", randomPosition);
        }
    }
}

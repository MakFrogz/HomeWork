using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Assets.Scripts
{
    public class AppCore : MonoBehaviour
    {
        [Inject]
        private AlienGameCore _gameCore;

        private void Start()
        {
            _gameCore.SetMonoBehaviour(this);
        }

        void Update()
        {
            _gameCore.Update();
        }
    }

}

using UnityEngine;
using Zenject;

namespace Assets.Scripts
{
    public class AppCore : MonoBehaviour
    {
        [Inject]
        private AlienGameCore _gameCore;

        void Update()
        {
            _gameCore.Update();
        }
    }

}

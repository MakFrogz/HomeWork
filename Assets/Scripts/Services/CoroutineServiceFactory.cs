using UnityEngine;
using Zenject;

namespace Assets.Scripts.Services
{
    class CoroutineServiceFactory : IFactory<ICoroutineService>
    {
        public ICoroutineService Create()
        {
            GameObject gameObject = new GameObject("Coroutine Service Holder");
            Object.DontDestroyOnLoad(gameObject);
            return gameObject.AddComponent<CoroutineService>();
        }
    }
}

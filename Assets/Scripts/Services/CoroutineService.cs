using System.Collections;
using UnityEngine;
namespace Assets.Scripts.Services
{
    class CoroutineService : MonoBehaviour, ICoroutineService
    {

        public Coroutine RunCoroutine(IEnumerator enumerator)
        {
            return StartCoroutine(enumerator);
        }

        public void EndCoroutine(Coroutine enumerator)
        {
            StopCoroutine(enumerator);
        }
    }
}

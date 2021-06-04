using System.Collections;
using UnityEngine;
namespace Assets.Scripts.Services
{
    interface ICoroutineService
    {
        Coroutine RunCoroutine(IEnumerator enumerator);
        void EndCoroutine(Coroutine enumerator);
    }
}

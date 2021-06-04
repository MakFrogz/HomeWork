using Assets.Scripts.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zenject;

namespace Assets.Scripts.Installers
{
    class ProjectInstaller : MonoInstaller
    {

        public override void InstallBindings()
        {
            Container
                .Bind<ICoroutineService>()
                .FromFactory<CoroutineServiceFactory>();

        }
    }
}

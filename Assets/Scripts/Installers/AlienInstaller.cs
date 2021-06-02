using UnityEngine;
using Zenject;

namespace Assets.Scripts
{
    class AlienInstaller : MonoInstaller
    {
        [Header("Weapons Damage")]
        [Space]
        [Range(0,50)]
        [SerializeField] 
        private int _shotgunDamage;

        [Range(0, 50)]
        [SerializeField] 
        private int _pistolDamage;

        [Range(0, 50)]
        [SerializeField] 
        private int _m4a1Damage;

        [Header("Armors value")]

        [Range(0, 50)]
        [SerializeField] 
        private int _lightArmor;

        public override void InstallBindings()
        {
            Container
                .BindInterfacesAndSelfTo<Player>()
                .AsSingle();

            Container
                .Bind<PlayerWeaponController>()
                .To<PlayerWeaponController>()
                .AsSingle();

            Container
                .Bind<AlienGameCore>()
                .To<AlienGameCore>()
                .AsSingle()
                .NonLazy();

            Container
                .Bind<IEnemy>()
                .To<Alien>()
                .AsSingle();

            Container
                .Bind<IWeapon>()
                .To<Shotgun>()
                .FromInstance(new Shotgun(_shotgunDamage))
                .AsSingle();

            Container
                .Bind<IWeapon>()
                .To<M4A1>()
                .FromInstance(new M4A1(_m4a1Damage))
                .AsSingle();

            Container
                .Bind<IWeapon>()
                .To<Pistol>()
                .FromInstance(new Pistol(_pistolDamage))
                .AsSingle();

            Container
                .Bind<IArmor>()
                .To<LightArmor>()
                .FromInstance(new LightArmor(_lightArmor))
                .AsSingle();

        }
    }
}

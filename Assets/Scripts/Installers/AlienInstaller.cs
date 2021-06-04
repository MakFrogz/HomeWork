using Assets.Scripts.Services;
using UnityEngine;
using Zenject;

namespace Assets.Scripts
{
    class AlienInstaller : MonoInstaller
    {
        [Header("Weapons Damage")]
        [Space]
        [SerializeField]
        private Shotgun _shotgun;

        [SerializeField] 
        private Pistol _pistol;

        [SerializeField] 
        private M4A1 _m4a1;

        [Header("Armors value")]
        [Space]
        [SerializeField] 
        private LightArmor _lightArmor;

        [Header("Enemies Settings")]
        [SerializeField]
        private Alien _alien;

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
                .BindInterfacesAndSelfTo<AlienGameCore>()
                .AsSingle()
                .NonLazy();

            Container
                .BindFactory<ShotgunBullet, ShotgunBullet.Factory>();

            Container
                .BindFactory<PistolBullet, PistolBullet.Factory>();

            Container
                .BindFactory<M4A1Bullet, M4A1Bullet.Factory>();

            Container
                .BindFactory<Alien, Alien.Factory>();

            Container
                .Bind<IEnemy>()
                .To<Alien>()
                .FromScriptableObject(_alien)
                .AsSingle();

            Container
                .Bind<IWeapon>()
                .To<Shotgun>()
                .FromScriptableObject(_shotgun)
                .AsSingle();

            Container
                .Bind<IWeapon>()
                .To<M4A1>()
                .FromScriptableObject(_m4a1)
                .AsSingle();

            Container
                .Bind<IWeapon>()
                .To<Pistol>()
                .FromScriptableObject(_pistol)
                .AsSingle();

            Container
                .Bind<IArmor>()
                .To<LightArmor>()
                .FromScriptableObject(_lightArmor)
                .AsSingle();

        }
    }
}

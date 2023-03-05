using System;
using UnityEngine;

namespace Zenject.SpaceFighter
{
    // Main installer for our game
    public class GameInstaller : MonoInstaller
    {
        [Inject]
        Settings _settings = null;

        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<EnemySpawner>().AsSingle();

            Container.BindFactory<float, float, EnemyFacade, EnemyFacade.Factory>()
                .FromPoolableMemoryPool<float, float, EnemyFacade, EnemyFacadePool>(poolBinder => poolBinder
                    .WithInitialSize(5)
                    .FromSubContainerResolve()
                    .ByNewPrefabInstaller<EnemyInstaller>(_settings.EnemyFacadePrefab)
                    .UnderTransformGroup("Enemies"));

            Container.BindFactory<float, float, BulletTypes, Bullet, Bullet.Factory>()
                .FromPoolableMemoryPool<float, float, BulletTypes, Bullet, BulletPool>(poolBinder => poolBinder
                    .WithInitialSize(20)
                    .FromComponentInNewPrefab(_settings.BulletPrefab)
                    .UnderTransformGroup("Bullets"));

            Container.Bind<LevelBoundary>().AsSingle();

            Container.BindFactory<Explosion, Explosion.Factory>()
                // We could just use FromMonoPoolableMemoryPool here instead, but
                // for IL2CPP to work we need our pool class to be used explicitly here
                .FromPoolableMemoryPool<Explosion, ExplosionPool>(poolBinder => poolBinder
                    // Spawn 4 right off the bat so that we don't incur spikes at runtime
                    .WithInitialSize(4)
                    .FromComponentInNewPrefab(_settings.ExplosionPrefab)
                    .UnderTransformGroup("Explosions"));

            Container.Bind<AudioPlayer>().AsSingle();

            Container.BindInterfacesTo<GameRestartHandler>().AsSingle();

            Container.Bind<EnemyRegistry>().AsSingle();

            GameSignalsInstaller.Install(Container);
        }

        [Serializable]
        public class Settings
        {
            public GameObject EnemyFacadePrefab;
            public GameObject BulletPrefab;
            public GameObject ExplosionPrefab;
        }

        // We could just use FromMonoPoolableMemoryPool above, but we have to use these instead
        // for IL2CPP to work
        class EnemyFacadePool : MonoPoolableMemoryPool<float, float, IMemoryPool, EnemyFacade>
        {
        }

        class BulletPool : MonoPoolableMemoryPool<float, float, BulletTypes, IMemoryPool, Bullet>
        {
        }

        class ExplosionPool : MonoPoolableMemoryPool<IMemoryPool, Explosion>
        {
        }
    }
}

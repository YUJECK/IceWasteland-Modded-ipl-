using IceWasteland;
using IceWasteland.AICore;
using IceWasteland.Player;
using UnityEngine;
using Zenject;

public sealed class LocationInstaller : MonoInstaller
{
    [SerializeField] private Transform startPoint;

    public override void InstallBindings()
    {
        BindInputService();
        
        Container
            .BindInterfacesTo<Inventory>()
            .FromInstance(new Inventory())
            .AsSingle()
            .NonLazy();

        BindPlayer();
        BindHUD();
        BindPointTargets();
    }

    private void BindPointTargets()
    {
        PointTarget[] pointTargets = FindObjectsOfType<PointTarget>();

        Container
            .Bind<PointTarget[]>()
            .FromInstance(pointTargets)
            .AsSingle();
    }

    private void BindInputService()
    {
        Container.BindInterfacesTo<InputService>().AsSingle().NonLazy();
    }

    private void BindPlayer()
    {
        Object playerPrefab = Resources.Load(AssetsPath.PLAYER);

        PlayerProvider player = Container
            .InstantiatePrefabForComponent<PlayerProvider>(playerPrefab, startPoint.position, Quaternion.identity, null);

        Container
            .Bind<PlayerProvider>()
            .FromInstance(player)
            .AsSingle();
        Container
            .Bind<PlayerTarget>()
            .FromInstance(player.Target)
            .AsSingle();
    }

    private void BindHUD()
    {
        Object hudPrefab = Resources.Load(AssetsPath.HUD);
        Container.InstantiatePrefab(hudPrefab, startPoint.position, Quaternion.identity, null);
    }
}
using Assets.InternalAssets.Scripts.Other.Player;
using IceWasteland;
using UnityEngine;
using Zenject;

public sealed class LocationInstaller : MonoInstaller
{
    [SerializeField] private Transform startPoint;

    public override void InstallBindings()
    {
        BindInputService();
        BindPlayer();
        BindHUD();
    }

    private void BindInputService()
    {
        Container.BindInterfacesTo<InputService>().AsSingle().NonLazy();
    }

    private void BindPlayer()
    {
        Object playerPrefab = Resources.Load(AssetsPath.Player);

        GameObject player = Container.InstantiatePrefab(playerPrefab, startPoint.position, Quaternion.identity, null);
        Container.Bind<PlayerProvider>().FromInstance(player.GetComponent<PlayerProvider>()).AsSingle().NonLazy();
    }

    private void BindHUD()
    {
        Object hudPrefab = Resources.Load(AssetsPath.HUD);
        GameObject hud = Container.InstantiatePrefab(hudPrefab, startPoint.position, Quaternion.identity, null);
    }
}
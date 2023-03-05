using IceWasteland.Player;
using UnityEngine;
using Zenject;

public sealed class LocationInstaller : MonoInstaller
{
    [SerializeField] private GameObject playerPrefab;
    [SerializeField] private Transform startPoint;

    public override void InstallBindings()
    {
        BindInputService();
        BindPlayer();
    }

    private void BindInputService()
    {
        Container.BindInterfacesTo<InputService>().AsSingle().NonLazy();
    }

    private void BindPlayer()
    {
        GameObject player = Container.InstantiatePrefab(playerPrefab, startPoint.position, Quaternion.identity, null);
        Container.Bind<PlayerMovable>().FromInstance(player.GetComponent<PlayerMovable>()).AsSingle().NonLazy();
    }
}
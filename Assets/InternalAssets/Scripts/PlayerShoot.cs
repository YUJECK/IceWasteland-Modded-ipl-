using IceWasteland.Services;
using UnityEngine;
using Zenject;

namespace IceWasteland.Player
{
    public class PlayerShoot : MonoBehaviour
    {
        [SerializeField] private GameObject bullet;
        [SerializeField] private Transform firePoint;

        private IInputService inputService;

        [Inject]
        private void Construct(IInputService inputService)
        {
            this.inputService = inputService;
            this.inputService.OnShootKeyDown += Shoot;
        }

        private void Shoot() => Instantiate(bullet, firePoint.position, firePoint.rotation);
    }
}
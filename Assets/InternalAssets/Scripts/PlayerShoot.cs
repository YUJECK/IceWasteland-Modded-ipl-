using IceWasteland.Services;
using UnityEngine;
using Zenject;

namespace IceWasteland.Player
{
    public class PlayerShoot : MonoBehaviour
    {
        [SerializeField] private GameObject bullet;
        [SerializeField] private Transform firePoint;

        private IInputService _inputService;

        [Inject]
        private void Construct(IInputService inputService)
        {
            this._inputService = inputService;
            this._inputService.OnShootKeyDown += Shoot;
        }

        private void Shoot() => Instantiate(bullet, firePoint.position, firePoint.rotation);
    }
}
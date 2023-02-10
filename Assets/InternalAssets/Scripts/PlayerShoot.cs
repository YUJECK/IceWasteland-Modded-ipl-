using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    [SerializeField] private GameObject bullet;
    [SerializeField] private Transform firePoint;

    private void Update()
    {
        if(Input.GetMouseButtonDown(0))
            Shoot();
    }

    private void Shoot() => Instantiate(bullet, firePoint.position, firePoint.rotation);
}
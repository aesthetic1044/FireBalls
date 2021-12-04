using System;
using UnityEngine;

public class Cannon : MonoBehaviour
{
    [SerializeField] private Transform _shootPoint;
    [SerializeField] private Bullet _bulletPrefab;
    
    [Header("Stats")]
    [SerializeField] private float _fireRate;
    [SerializeField] private float _bulletSpeed;

    private float _timeFromLastShot;

    private void Update()
    {
        _timeFromLastShot += Time.deltaTime;

        if (Input.GetMouseButton(0))
        {
            if (_timeFromLastShot > _fireRate)
            {
                Shoot();
                _timeFromLastShot = 0;
            }
        }
    }

    private void Shoot()
    {
        Bullet instance = Instantiate(_bulletPrefab, _shootPoint.position, Quaternion.identity);
        instance.SetBullet(_shootPoint.forward, _bulletSpeed);
    } 
}

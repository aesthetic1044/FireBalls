using System;
using UnityEngine;

public class Cannon : MonoBehaviour
{
    [SerializeField] private Transform _shootPoint;
    [SerializeField] private Bullet _bulletPrefab;
    [SerializeField] private float _fireRate;

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
        Instantiate(_bulletPrefab, _shootPoint.position, Quaternion.identity);
    } 
}

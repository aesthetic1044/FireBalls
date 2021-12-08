using UnityEngine;
using DG.Tweening;

namespace KA
{
    public class Cannon : MonoBehaviour
    {
        [SerializeField] private Transform _shootPoint;
        [SerializeField] private Bullet _bulletPrefab;
    
        [Header("Stats")]
        [Range(0f, 1f)][SerializeField] private float _fireRate;
        [Range(0f, 500f)][SerializeField] private float _bulletSpeed;
        [Range(0f, 10f)][SerializeField] private float _recoilPower;

        private float _timeFromLastShot;

        private void Update()
        {
            _timeFromLastShot += Time.deltaTime;

            if (Input.GetMouseButton(0))
            {
                if (_timeFromLastShot > _fireRate)
                {
                    Shoot();
                
                    transform.DOMoveZ(transform.position.z - _recoilPower, _fireRate * 0.5f).SetLoops(2, LoopType.Yoyo);
                
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
}



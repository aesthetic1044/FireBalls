using UnityEngine;

namespace KA
{
    public class Bullet : MonoBehaviour
    {
        private float _speed;
    
        private const float BOUNCE_FORCE = 150;
        private const float BOUNCE_RADIUS = 120;

        private Vector3 _moveDirection;

        public void SetBullet(Vector3 direction, float speed)
        {
            _moveDirection = direction;
            _speed = speed;
        }

        private void Update() => transform.Translate(_moveDirection * _speed * Time.deltaTime);

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.TryGetComponent(out Ring ring))
            {
                ring.Destroy();
                Destroy(gameObject);
            }

            if (other.gameObject.TryGetComponent(out Obstacle obstacle))
            {
                BounceAtPlayerFace();
            }
        }

        private void BounceAtPlayerFace()
        {
            _moveDirection = Vector3.back;
        
            Rigidbody rb = GetComponent<Rigidbody>();
            rb.isKinematic = false;
            rb.AddExplosionForce(BOUNCE_FORCE, transform.position + new Vector3(0f, -1, 1), BOUNCE_RADIUS);
        }
    }
}


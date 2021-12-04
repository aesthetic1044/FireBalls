using System;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private float _speed;

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
    }
}

using System;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(MeshRenderer))]
public class Ring : MonoBehaviour
{
    [SerializeField] private ParticleSystem _destroyVFX;

    private MeshRenderer _meshRenderer;
    
    public event UnityAction<Ring> _onDestroy;

    public void SetColor(Color newColor) => _meshRenderer.material.color = newColor;
    
    private void Awake() => _meshRenderer = GetComponent<MeshRenderer>();
    
    public void Destroy()
    {
        _onDestroy?.Invoke(this);

        SpawnRingVFX();
        
        Destroy(gameObject);
    }

    private void SpawnRingVFX() => Instantiate(_destroyVFX, transform.position, _destroyVFX.transform.rotation);
}

using UnityEngine;
using UnityEngine.Events;

public class Ring : MonoBehaviour
{
    public event UnityAction<Ring> _onDestroy;
    
    public void Destroy()
    {
        _onDestroy?.Invoke(this);
        Destroy(gameObject);
    }
}

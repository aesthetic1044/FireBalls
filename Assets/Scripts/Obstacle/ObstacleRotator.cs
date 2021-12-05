using System;
using UnityEngine;
using DG.Tweening;

public class ObstacleRotator : MonoBehaviour
{
    [SerializeField] private float _duration;
    private void Start()
    {
        Vector3 endValue = new Vector3(0f, 360f, 0f);
        transform.DORotate(endValue, _duration, RotateMode.FastBeyond360).SetLoops(-1, LoopType.Yoyo);
    }
}

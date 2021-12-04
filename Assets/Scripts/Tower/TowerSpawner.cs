using System;
using System.Collections.Generic;
using UnityEngine;

public class TowerSpawner : MonoBehaviour
{
    [SerializeField] private float _towerSize;
    [SerializeField] private Ring _ringPrefab;
    [SerializeField] private Transform _spawnPoint;

    private List<Ring> _allRings = new List<Ring>();

    private void Start()
    {
        SpawnRings();
    }

    public List<Ring> SpawnRings()
    {
        Transform currentPoint = _spawnPoint;
        
        for (int i = 0; i < _towerSize; i++)
        {
            Ring newRing = SpawnRing(currentPoint);
            _allRings.Add(newRing);
            currentPoint = newRing.transform;
        }

        return _allRings;
    }

    private Ring SpawnRing(Transform currentSpawnPoint)
    {
        return Instantiate(_ringPrefab, GetSpawnPoint(currentSpawnPoint), Quaternion.identity, _spawnPoint);
    }

    private Vector3 GetSpawnPoint(Transform currentRing)
    {
        float newYPos = currentRing.position.y + currentRing.localScale.y / 2 + _ringPrefab.transform.localScale.y / 2;
        return new Vector3(_spawnPoint.position.x, newYPos, _spawnPoint.position.z);
    }
}

using System.Collections.Generic;
using UnityEngine;

namespace KA
{
    public class TowerSpawner : MonoBehaviour
    {
        [SerializeField] private float _towerSize;
        [SerializeField] private Ring _ringPrefab;
        [SerializeField] private Transform _spawnPoint;
        [SerializeField] private Color[] _colors;

        private List<Ring> _allRings = new List<Ring>();

        public static float OFF_SET = 1.7f;

        public List<Ring> SpawnRings()
        {
            Transform currentPoint = _spawnPoint;
        
            for (int i = 0; i < _towerSize; i++)
            {
                Ring newRing = SpawnRing(currentPoint);
            
                int randomIndex = Random.Range(0, _colors.Length);
                newRing.SetColor(_colors[randomIndex]);
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
            float newYPos = currentRing.position.y + currentRing.localScale.y / 2 + _ringPrefab.transform.localScale.y / 2 + OFF_SET;
            return new Vector3(_spawnPoint.position.x, newYPos, _spawnPoint.position.z);
        }
    }   
}



using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(TowerSpawner))]
public class Tower : MonoBehaviour
{
   private TowerSpawner _towerSpawner;

   private List<Ring> _rings = new List<Ring>();
   
   public event UnityAction<int> towerUpdated;

   private void Awake()
   {
      _towerSpawner = GetComponent<TowerSpawner>();
      _rings = _towerSpawner.SpawnRings();
   }

   private void Start()
   {
      foreach (var ring in _rings)
         ring._onDestroy += OnBulletHit;
      
      towerUpdated?.Invoke(_rings.Count);
   }

   private void OnBulletHit(Ring destroyedRing)
   {
      destroyedRing._onDestroy -= OnBulletHit;

      _rings.Remove(destroyedRing);

      foreach (var ring in _rings)
      {
         float newYPos = ring.transform.position.y - ring.transform.localScale.y;
         ring.transform.position = new Vector3(ring.transform.position.x, newYPos, ring.transform.position.z);
      }
      
      towerUpdated?.Invoke(_rings.Count);
   }
}

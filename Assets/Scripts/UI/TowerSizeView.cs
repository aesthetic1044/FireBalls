using TMPro;
using UnityEngine;

namespace KA
{
    [RequireComponent(typeof(TextMeshProUGUI))]
    public class TowerSizeView : MonoBehaviour
    {
        [SerializeField] private Tower _tower;
    
        private TextMeshProUGUI _towerSizeText;

        private void Awake() => _towerSizeText = GetComponent<TextMeshProUGUI>();
    
        private void OnEnable() => _tower.towerUpdated += OnTowerUpdated;
    
        private void OnDisable() => _tower.towerUpdated -= OnTowerUpdated;
    
        private void OnTowerUpdated(int newSize) => _towerSizeText.text = newSize.ToString();
    }
}



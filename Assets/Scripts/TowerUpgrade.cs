using UnityEngine;

public class TowerUpgrade : MonoBehaviour
{
    [SerializeField] private int _cost = 10;

    [SerializeField] private float _reloadTimeDecrease = 0.3f;

    [SerializeField] private Tower _tower;

    [SerializeField] private IntVariable _coins;
    
    public void Upgrade()
    {
        // var gold = GameManager.Instance.Gold;
        var gold = _coins.Value;
        if (gold < _cost) return;
        
        // GameManager.Instance.SpendGold(_cost);
        _coins.Value -= _cost;
        _tower.LevelUp(_reloadTimeDecrease);
        
        if (_tower.HasNextLevel) return;
        gameObject.SetActive(false);
    }
}

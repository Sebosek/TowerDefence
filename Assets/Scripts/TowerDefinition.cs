using UnityEngine;

public class TowerDefinition : MonoBehaviour
{
    [SerializeField] private GameObject _tower;
    
    [SerializeField] private Sprite _sprite;
    
    [SerializeField] private int _price;
    
    public GameObject Tower => _tower;

    public Sprite Sprite => _sprite;
    
    public int Price => _price;
}

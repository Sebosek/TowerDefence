using UnityEngine;
using UnityEngine.UI;

public class TowerClickHandler : MonoBehaviour
{
    [SerializeField] private TowerDefinition _definition;
    
    // [SerializeField] private IntVariable _coins;
    //
    // [SerializeField] private Image _image;
    //
    // [SerializeField] private Color _notEnoughtGold = new(1, 1, 1, 0.5f);
    //
    // [SerializeField] private Color _enoughtGolor = new(1, 1, 1, 1);
    //
    // private Color _color = new(1, 1, 1, 1);

    // protected void Update()
    // {
    //     var gold = _coins.Value;
    //     // _color = gold < _definition.Price ? _notEnoughtGold : _enoughtGolor;
    //     // _color = GameManager.Instance.Gold < _definition.Price ? _notEnoughtGold : _enoughtGolor;
    // }
    //
    // protected void FixedUpdate()
    // {
    //     _image.color = _color;
    // }

    public void HandleClick()
    {
        TowerBuilder.Instance.PutTower(_definition);
    }
}

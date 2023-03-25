using TMPro;
using UnityEngine;

public class CoinsCounter : MonoBehaviour
{
    [SerializeField] private IntVariable _coins;
    
    [SerializeField] private TMP_Text _label;

    protected void Update()
    {
        _label.text = _coins.Value.ToString("0000");
    }
}

using UnityEngine;

public class LivesMeter : MonoBehaviour
{
    [SerializeField] private IntVariable _lives;

    [SerializeField] private RectTransform _hearts;

    protected void Update()
    {
        const float WIDTH = 75f;

        _hearts.sizeDelta = new Vector2(_lives.Value * WIDTH, _hearts.sizeDelta.y);
    }
}

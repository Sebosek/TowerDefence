using System.Collections.Generic;
using System.Linq;

using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class TowerBuilder : MonoBehaviour
{
    private const string EMPTY_SPACE = "Empty";

    private const string OCCUPY_SPACE = "Occupy";
    
    public static TowerBuilder Instance { get; private set; }

    [SerializeField] private SpriteRenderer _renderer;

    [SerializeField] private IntVariable _coins;

    private TowerDefinition _tower;

    private Color _color;

    private readonly List<GameObject> _towers = new();
    
    private readonly List<Collider2D> _places = new();

    protected void Awake()
    {
        var go = gameObject;
        var count = FindObjectsOfType<TowerBuilder>().Length;
        if (count <= 1)
        {
            DontDestroyOnLoad(go);

            var colliders = GameObject
                .FindGameObjectsWithTag(EMPTY_SPACE)
                .Select(s => s.GetComponent<Collider2D>());
            
            _places.AddRange(colliders);
            Instance = this;
            return;
        }
        
        go.SetActive(false);
        Destroy(go);
    }

    protected void Update()
    {
        const int RIGHT = (int)MouseButton.Right;
        const int LEFT = (int)MouseButton.Left;
        
        if (_tower is null) return;
        
        if (Input.GetMouseButton(RIGHT))
        {
            DisableDrag();
            return;
        }
        
        var position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        var hit = Physics2D.Raycast(position, Vector2.zero);
        if (hit is { collider: {} col })
        {
            if (col.CompareTag(EMPTY_SPACE) && Input.GetMouseButton(LEFT))
            {
                BuildTower(hit);
            }

            if (col.CompareTag(EMPTY_SPACE))
            {
                _color = new Color(0.235f, 0.902f, 0.235f, 0.9f);
            }
            
            if (col.CompareTag(OCCUPY_SPACE))
            {
                _color = new Color(0.902f, 0.235f, 0.47f, 0.9f);
            }
        }
        else
        {
            _color = new Color(1f, 1f, 1f, 0.9f);
        }
    }

    protected void FixedUpdate()
    {
        if (_tower is null) return;

        _renderer.color = _color;
        var position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = new Vector2(position.x, position.y);
    }

    public void PutTower(TowerDefinition def)
    {
        var gold = _coins.Value;
        if (gold < def.Price) return;
        
        _tower = def;
        
        _renderer.sprite = def.Sprite;
        _renderer.enabled = true;
    }
    
    public void DestroyAllTowers()
    {
        foreach (var tower in _towers)
        {
            Destroy(tower);
        }
        
        _places.ToList().ForEach(p => p.tag = EMPTY_SPACE);
        _towers.Clear();
    }

    private void BuildTower(RaycastHit2D hit)
    {
        if (EventSystem.current.IsPointerOverGameObject() || _tower is null) return;
        
        var created = Instantiate(_tower.Tower, hit.transform.position, Quaternion.identity);
        hit.transform.tag = OCCUPY_SPACE;
        
        _coins.Value -= _tower.Price;
        RegisterTower(created);
        DisableDrag();
    }

    private void RegisterTower(GameObject created)
    {
        _towers.Add(created);
    }

    private void DisableDrag()
    {
        _renderer.enabled = false;
        _tower = null;
    }
}

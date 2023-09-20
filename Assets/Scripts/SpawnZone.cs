using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class SpawnZone : MonoBehaviour
{
    private Vector2 _leftCorner;
    private Vector2 _rightCorner;
    private Vector2 _center;

    private BoxCollider2D _boxCollider;

    public Vector2 LeftCorner => _leftCorner;
    public Vector2 RightCorner => _rightCorner;
    public Vector2 Center => _center;

    private void Awake()
    {
        _boxCollider = GetComponent<BoxCollider2D>();
        Initialize();
    }

    private void Initialize()
    {
        _leftCorner = new Vector2(_boxCollider.bounds.center.x - _boxCollider.bounds.extents.x,
                                  _boxCollider.bounds.center.y + _boxCollider.bounds.extents.y);

        _rightCorner = new Vector2(_boxCollider.bounds.center.x + _boxCollider.bounds.extents.x,
                                   _boxCollider.bounds.center.y - _boxCollider.bounds.extents.y);

        _center = _boxCollider.bounds.center;
    }

}

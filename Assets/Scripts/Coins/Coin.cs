using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Coin : MonoBehaviour
{
    public Vector2 Position { get => transform.position; set => transform.position = value; }
    protected float Value;

    public void Initialize(float value)
    {
        Value = value;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        PickingCoin();
    }

    protected abstract void PickingCoin();
}

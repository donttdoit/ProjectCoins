using System;
using UnityEngine;

public interface IMover
{
    public Transform Transform { get; }
    public Rigidbody2D RigidBody { get; }
    public Collider2D Collider { get; }
    public float Speed { get; }

    public event Action MouseOverMover;
    public event Action MouseExitMover;
}

using System;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _rigidbody2D;
    private void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Player"))
        {
            _rigidbody2D.linearVelocity = -_rigidbody2D.linearVelocity;
        }
    }

    public void FreezeEnemy(bool freeze)
    {
        _rigidbody2D.linearVelocity = Vector2.zero;
    }

    
}

using System;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private int damage = 30;
    [SerializeField] private int hitsToDeath = 2;
    [SerializeField] private Animator animator;
    [SerializeField] private Rigidbody2D _rigidbody2D;
    private void Start()
    {
        animator = GetComponent<Animator>();
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")) {
            GameEvents.OnEnemyHit?.Invoke(damage);
        }
        else
        {
            _rigidbody2D.linearVelocity = -_rigidbody2D.linearVelocity;
        }
        hitsToDeath--;
        animator.SetTrigger("gotHit");
        animator.SetInteger("hits", hitsToDeath);
        if (hitsToDeath == 0) {
            _rigidbody2D.linearVelocity = Vector2.zero;
            Destroy(gameObject, 0.75f);
        }
    }
}

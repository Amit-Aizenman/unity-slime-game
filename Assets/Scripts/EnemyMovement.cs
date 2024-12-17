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

    private void Update()
    {
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player") {
            GameEvents.OnEnemyHit?.Invoke(damage);
        }
        else
        {
            Debug.Log("hit something");
        }
        hitsToDeath--;
        animator.SetTrigger("gotHit");
        animator.SetInteger("hits", hitsToDeath);
        if (hitsToDeath == 0) {
            Destroy(gameObject, 0.75f);
        }
    }
}

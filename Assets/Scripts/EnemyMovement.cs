using System;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private int damage = 30;
    [SerializeField] private int hitsToDeath = 2;
    private Animator animator;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player") {
            GameEvents.OnEnemyHit?.Invoke(damage);
        }
        hitsToDeath--;
        if (hitsToDeath == 0) {
            Destroy(gameObject);
        }
    }
}

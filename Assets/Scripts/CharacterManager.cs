using System;
using UnityEngine;

public class CharacterManager : MonoBehaviour
{
    [SerializeField] int initialHealth = 100;
    [SerializeField] Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }
    private void OnEnable()
    {
        GameEvents.OnEnemyHit += EnemyHit;
    }

    private void OnDisable()
    {
        GameEvents.OnEnemyHit -= EnemyHit;
    }
    
    private void EnemyHit(int damage)
    {
        Debug.Log("hittt");
        initialHealth -= damage;
        animator.SetInteger("life", initialHealth );
        if (initialHealth > 0)
        {
            animator.SetTrigger("hit");
        }
        else
        {
            GameEvents.characterDead?.Invoke(true);
            Destroy(gameObject, 0.75f);
        }
    }
}

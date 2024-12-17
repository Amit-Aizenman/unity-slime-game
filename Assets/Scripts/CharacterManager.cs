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
        GameEvents.ResetHealth += ResetPlayerHealth;
        GameEvents.KillPlayer += PlayerDeath;
    }

    private void OnDisable()
    {
        GameEvents.OnEnemyHit -= EnemyHit;
        GameEvents.ResetHealth -= ResetPlayerHealth;
        GameEvents.KillPlayer -= PlayerDeath;


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
            PlayerDeath(true);
        }
    }
    
    private void ResetPlayerHealth(Boolean resetHealth)
    {
        initialHealth = 100;
    }

    private void PlayerDeath(Boolean death)
    {
        initialHealth = 0;
        animator.SetInteger("life", initialHealth );
        GameEvents.CharacterDead?.Invoke(true);
        Destroy(gameObject, 0.75f);
    }
}

using System;
using UnityEngine;

public class CharacterManager : MonoBehaviour
{
    [SerializeField] int initialHealth = 100;

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
        initialHealth -= damage;
        if (initialHealth <= 0)
        {
            Destroy(gameObject);
        }
    }
}

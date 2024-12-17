using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    [SerializeField] private int damage = 30;
    [SerializeField] private int hitsToDeath = 2;
    [SerializeField] private Animator animator;
    void Start()
    { 
        animator = GetComponent<Animator>();
    }
    private void OnEnable()
    {
        GameEvents.DestroyEnemiesReset += DestroyEnemy;
    }

    private void OnDisable()
    {
        GameEvents.DestroyEnemiesReset -= DestroyEnemy;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")) {
            GameEvents.OnEnemyHit?.Invoke(damage);
        }
        hitsToDeath--;
        animator.SetTrigger("gotHit");
        animator.SetInteger("hits", hitsToDeath);
        if (hitsToDeath == 0)
        {
            DestroyEnemy(false);
        }
    }
    private void DestroyEnemy(bool obj)
    {        
        animator.SetInteger("hits", 0);
        this.GetComponent<EnemyMovement>().FreezeEnemy(true);
        Destroy(gameObject, 0.75f);
    }

}

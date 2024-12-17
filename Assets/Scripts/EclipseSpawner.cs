using UnityEngine;

public class EclipseSpawner : MonoBehaviour
{
    [SerializeField] private GameObject enemyPrefab;
    private Vector2 initialPosition;

    private float _timeSinceLastInterval;

    void Start()
    {
        initialPosition = transform.position;
    }

    private void OnEnable()
    {
        GameEvents.waveStarted += InitiateWave;
    }

    private void OnDisable()
    {
        GameEvents.OnEnemyHit -= InitiateWave;
    }

    void Update()
    {
    }

    private void InitiateWave(int enemiesToSpawn)
    {
        for (int i = 0; i < enemiesToSpawn; i++)
        {
            var enemy = Instantiate(enemyPrefab, initialPosition, Quaternion.Euler(0, 0, 0));
            var enemyRigidBody2d = enemy.gameObject.GetComponent<Rigidbody2D>();
            if (i == 0)
            {
                enemyRigidBody2d.linearVelocity = Vector2.right;
            }

            if (i == 1)
            {
                enemyRigidBody2d.linearVelocity = Vector2.left;
            }

            if (i == 2)
            {
                enemyRigidBody2d.linearVelocity = Vector2.down;
            }

            if (i == 3)
            {
                enemyRigidBody2d.linearVelocity = Vector2.up;
            }
        }
    }
}

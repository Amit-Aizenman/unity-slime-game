using UnityEngine;

public class EclipseSpawner : MonoBehaviour
{
    [SerializeField] private GameObject enemyPrefab;
    private Vector2 _initialPosition;
    private float _timeSinceLastInterval;
    [SerializeField] private GameObject character;
    [SerializeField] private float enemyVelocity = 3f;

    void Start()
    {
        _initialPosition = transform.position;
    }

    private void OnEnable()
    {
        GameEvents.WaveStarted += InitiateWave;
    }

    private void OnDisable()
    {
        GameEvents.WaveStarted -= InitiateWave;
    }

    private void InitiateWave(int enemiesToSpawn)
    {
        if (character is not null)
        {
            float startingAngle = Vector2.Angle(Vector2.right, new Vector2(character.transform.position.x,
                                      character.transform.position.y) - _initialPosition) + Random.Range(-15f, 15f);
            for (int i = 0; i < enemiesToSpawn; i++)
            {
                var enemy = Instantiate(enemyPrefab, _initialPosition, Quaternion.Euler(0, 0, 0));
                var enemyRigidBody2d = enemy.gameObject.GetComponent<Rigidbody2D>();
                float enemyAngleRadians = (startingAngle + (float)i * 360 / enemiesToSpawn) * Mathf.Deg2Rad;
                enemyRigidBody2d.linearVelocity = new Vector2(Mathf.Cos(enemyAngleRadians), Mathf.Sin(enemyAngleRadians))
                                                  * enemyVelocity;
            }
        }
        else
        {
            Debug.LogError("Character is not assigned in EclipseSpawner!");
        }
    }
}

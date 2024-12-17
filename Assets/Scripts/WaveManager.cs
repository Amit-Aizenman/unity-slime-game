using System;
using UnityEngine;

public class WaveManager : MonoBehaviour
{
    public static int SpawnInterval = 5; 
    public static int EnemiesToSpawn = 4;
    [SerializeField] private float duration = 30;
    public static WaveManager Instance;
    private Boolean _playerIsDead = false;
    private float _timeSinceLastInterval;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    private void OnEnable()
    {
        GameEvents.CharacterDead += playerDead;
        GameEvents.ResetConfigurations += ConfigurationReset;
    }

    private void OnDisable()
    {
        GameEvents.CharacterDead -= playerDead;
        GameEvents.ResetConfigurations -= ConfigurationReset;

    }
    void Update()
    {
        if (_timeSinceLastInterval > SpawnInterval && _playerIsDead == false)
        {
            GameEvents.WaveStarted?.Invoke(EnemiesToSpawn);
            _timeSinceLastInterval = 0;
        }
        
        if (duration <= 0)
        {
            EnemiesToSpawn += 2;
            if (SpawnInterval > 2)
            {
                SpawnInterval--;
            }
            duration = 30;

        }
        duration -= Time.deltaTime;
        _timeSinceLastInterval += Time.deltaTime;
    }

    private void playerDead(Boolean isDead)
    {
        _playerIsDead = isDead;
    }
    
    private void ConfigurationReset(bool reset)
    {
        SpawnInterval = 5;
        EnemiesToSpawn = 4;
    }
}

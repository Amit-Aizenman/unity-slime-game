using System;
using UnityEngine;

public class WaveManager : MonoBehaviour
{
    [SerializeField] public static int spawnInterval = 5; 
    [SerializeField] public static int enemiesToSpawn = 4;
    [SerializeField] public static int duration = 60;
    public static WaveManager Instance;
    private Boolean _playerIsDead = false;
    private float _timeSinceLastInterval;


    // Awake happens when the object is created, before Start
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

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    private void OnEnable()
    {
        GameEvents.characterDead += playerDead;
    }

    private void OnDisable()
    {
        GameEvents.characterDead -= playerDead;
    }
    void Update()
    {
        if (_timeSinceLastInterval > spawnInterval && _playerIsDead == false)
        {
            GameEvents.waveStarted?.Invoke(enemiesToSpawn);
            _timeSinceLastInterval = 0;
        }
        _timeSinceLastInterval += Time.deltaTime;
    }

    private void playerDead(Boolean isDead)
    {
        _playerIsDead = isDead;
    }
}

using UnityEngine;

public class WaveManager : MonoBehaviour
{
    [SerializeField] public static int spawnInterval = 5; 
    [SerializeField] public static int enemiesToSpawn = 4;
    [SerializeField] public static int duration = 60;
    public static WaveManager Instance;
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

    // Update is called once per frame
    void Update()
    {
        if (_timeSinceLastInterval > spawnInterval)
        {
            GameEvents.waveStarted?.Invoke(enemiesToSpawn);
            _timeSinceLastInterval = 0;
        }
        _timeSinceLastInterval += Time.deltaTime;
    }
}

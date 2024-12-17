using System;
using UnityEngine;

public class CheatCodeManager : MonoBehaviour
{
    public static CheatCodeManager Instance;
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
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
            // 1 - Reset Player Health
        {
            Debug.Log("Resetting player health");
            GameEvents.ResetHealth?.Invoke(true);
        }
        
        if (Input.GetKeyDown(KeyCode.Alpha2))
            // 2 - reset wave configurations
        {
            Debug.Log("Resetting wave configurations");
            GameEvents.ResetConfigurations?.Invoke(true);
        }
        
        if (Input.GetKeyDown(KeyCode.Alpha3))
            // 3 - destroy all enemies
        {
            Debug.Log("Destroying all enemies");
            GameEvents.DestroyEnemies?.Invoke(true);
        }
        
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            // 4 - instant player death
            Debug.Log("Killing the player");
            GameEvents.KillPlayer?.Invoke(true);
        }
    }
}

using UnityEngine;
using System;

public class GameEvents : MonoBehaviour
{
    public static Action<int> OnEnemyHit;
    public static Action<int> WaveStarted;
    public static Action<Boolean> CharacterDead;
    public static Action<Boolean> ResetHealth;
    public static Action<Boolean> ResetConfigurations;
    public static Action<Boolean> DestroyEnemies;
    public static Action<Boolean> KillPlayer;

}

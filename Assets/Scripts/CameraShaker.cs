using DG.Tweening;
using UnityEngine;
using Vector3 = System.Numerics.Vector3;

public class CameraShaker : MonoBehaviour
{
    private void OnEnable()
    {
        GameEvents.WaveStarted += Shake;
    }

    private void OnDisable()
    {
        GameEvents.WaveStarted -= Shake;
    }

    private void Shake(int enemies)
    {
        transform.DOShakePosition(0.5f,0.5f);
    }
}
using DG.Tweening;
using UnityEngine;

public class EclipseMovementTweener : MonoBehaviour
{
    private Vector3 _startScale;
    [SerializeField] private float delay;
    void Start()
    {
        _startScale = transform.localScale;
        delay = Random.Range(1f, 1.5f);
        transform.DOScale(new Vector3(0,0,0), 0);
        transform.DOScale(_startScale, 1.5f).SetDelay(delay);
        transform.DORotate(new Vector3(0,0,1080f),1.5f, RotateMode.FastBeyond360).SetDelay(delay);
    }
}

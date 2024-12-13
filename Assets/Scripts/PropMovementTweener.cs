using DG.Tweening;
using UnityEngine;

public class PropMovementTweener : MonoBehaviour
{
    private Vector3 startScale;
    [SerializeField] float delay;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        startScale = transform.localScale;
        delay = Random.Range(1f, 1.5f);
        transform.DOScale(new Vector3(0,0,0), 0);
        transform.DOScale(startScale, 1.5f).SetDelay(delay);
        transform.DORotate(new Vector3(0,0,1080f),1.5f, RotateMode.FastBeyond360).SetDelay(delay);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

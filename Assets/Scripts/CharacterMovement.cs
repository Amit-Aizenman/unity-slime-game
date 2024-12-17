using System;
using TreeEditor;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    [SerializeField] private int maxSpeed = 5;
    [SerializeField] private float force = 1000;
    [SerializeField] Animator animator;
    private Rigidbody2D _rigidbody2D;
    private float _horizontalMovement;
    private float _verticalMovement;
    
    
    private void OnEnable()
    {
        GameEvents.CharacterDead += FreezeCharacter;
    }

    private void OnDisable()
    {
        GameEvents.CharacterDead -= FreezeCharacter;
    }

    void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        _horizontalMovement = Input.GetAxis("Horizontal");
        _verticalMovement = Input.GetAxis("Vertical");
        animator.SetFloat("speed", _rigidbody2D.linearVelocity.magnitude);
    }

    private void FixedUpdate()
    {
        if (_rigidbody2D.linearVelocity.magnitude < maxSpeed)
        {
            _rigidbody2D.AddForce(Vector2.right * (_horizontalMovement * Time.fixedDeltaTime * force));
            _rigidbody2D.AddForce(Vector2.up * (_verticalMovement * Time.fixedDeltaTime * force));
        }
    }
    
    private void FreezeCharacter(bool obj)
    {
        force = 0;
        _rigidbody2D.linearVelocity = Vector2.zero;
    }
}

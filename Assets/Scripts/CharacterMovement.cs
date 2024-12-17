using System;
using TreeEditor;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    [SerializeField] private int maxSpeed = 5;
    [SerializeField] private float force = 1000;
    [SerializeField] Rigidbody2D _rigidbody2D;
    private float _horizontalMovement;
    private float _verticalMovement;
    [SerializeField] Animator animator;
    
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

    public Vector2 GetPosition()
    {
        return new Vector2(_rigidbody2D.position.x, _rigidbody2D.position.y);
    }
}

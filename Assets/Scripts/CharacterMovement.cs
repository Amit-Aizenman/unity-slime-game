using System;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    [SerializeField] int maxSpeed = 100;
    [SerializeField] private float force = 1000;
    private Rigidbody2D _rigidbody2D;
    private float _horizontalMovement;
    private float _verticalMovement;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        _horizontalMovement = Input.GetAxis("Horizontal");
        _verticalMovement = Input.GetAxis("Vertical");
    }

    private void FixedUpdate()
    {
        if (_rigidbody2D.linearVelocity.magnitude < maxSpeed)
        {
            _rigidbody2D.AddForce(Vector2.right * (_horizontalMovement * Time.fixedDeltaTime * force));
            _rigidbody2D.AddForce(Vector2.up * (_verticalMovement * Time.fixedDeltaTime * force));
        }
    }
}

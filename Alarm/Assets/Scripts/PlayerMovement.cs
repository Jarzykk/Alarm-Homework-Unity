using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _movementSpeed;

    private Rigidbody2D _rigidBody;
    private Vector2 _moveVelocity;

    private void Start()
    {
        _rigidBody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        Vector2 moveInput = new Vector2(Input.GetAxis("Horizontal"), 0);
        _moveVelocity = moveInput * _movementSpeed;
    }

    private void FixedUpdate()
    {
        _rigidBody.position += _moveVelocity * Time.deltaTime;
    }
}

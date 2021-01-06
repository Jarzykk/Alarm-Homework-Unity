using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
    [SerializeField] private float _movementSpeed;

    private Rigidbody2D _rb;
    private Vector2 _moveVelocity;

    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        Vector2 moveInput = new Vector2(Input.GetAxis("Horizontal"), 0);
        _moveVelocity = moveInput * _movementSpeed;
    }

    private void FixedUpdate()
    {
        _rb.position += _moveVelocity * Time.deltaTime;
    }
}

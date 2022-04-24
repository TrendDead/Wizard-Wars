using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMevement : MonoBehaviour
{
    [SerializeField] private float _speedMovement;

    [Header("Jump")]
    [SerializeField] private float _jumpForce;
    [SerializeField] private float _fallMultiplier;
    [SerializeField] private float _lowJumpMultiplier;

    private Rigidbody2D _rb2d;
    private Vector2 _targetVelocity;

    private bool _grounded;
    private RaycastHit2D[] _hitBuffer = new RaycastHit2D[16];
    private float _shellRadius = 0.3f;


    private void Awake()
    {
        _rb2d = GetComponent<Rigidbody2D>();
    }
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }
    }
    private void FixedUpdate()
    {
        _targetVelocity = new Vector2(Input.GetAxis("Horizontal"), 0);
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))
        {
            Move();
        }

        if (_rb2d.velocity.y < 0)
        {
            _rb2d.velocity += Vector2.up * Physics2D.gravity.y * (_fallMultiplier - 1) * Time.deltaTime;
            if (_rb2d.velocity.y < -_fallMultiplier * 2) 
                _rb2d.velocity = new Vector2(_rb2d.velocity.x, -_fallMultiplier * 2);
        } else
            if (_rb2d.velocity.y > 0 && !Input.GetKey(KeyCode.Space))
        {
            _rb2d.velocity += Vector2.up * Physics2D.gravity.y * (_lowJumpMultiplier - 1) * Time.deltaTime;
        }
    }

    private void Move()
    {
        _rb2d.position = _rb2d.position + (_targetVelocity * _speedMovement * Time.deltaTime);
    }   

    private void Jump()
    {
        int count = _rb2d.Cast(_rb2d.position, _hitBuffer, _shellRadius);
        var timeWait = new WaitForEndOfFrame();
        if (count > 0)
        {
            _rb2d.velocity += new Vector2(0, _jumpForce);
        }
    }
}

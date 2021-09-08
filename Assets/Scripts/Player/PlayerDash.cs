using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDash : MonoBehaviour
{
    [SerializeField] private float _waitForSeconds;
    [SerializeField] private float _dashForce;
    [SerializeField] private float _rechargeTime;

    private Vector2 _targetVelocity;
    private Rigidbody2D _rb2d;
    private float _rb2dGravity;
    private bool _dashCapability;

    private ParticleSystem _particleSystemDash;

    private void Awake()
    {
        _rb2d = GetComponent<Rigidbody2D>();
        _rb2dGravity = _rb2d.gravityScale;
        _dashCapability = true;
        _particleSystemDash = GetComponentInChildren<ParticleSystem>();
    }

    private void Update()
    {
        _targetVelocity = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        if (Input.GetKeyDown(KeyCode.LeftShift) && _dashCapability)
            StartCoroutine(Dash());
    }

    private IEnumerator Dash()
    {
        // Можно ли заменить сей ifы математикой?
        int targetVelocityX = 0;
        if (_targetVelocity.x > 0)
            targetVelocityX = 1;
        else if (_targetVelocity.x < 0)
            targetVelocityX = -1;

        int targetVelocityY = 0;
        if (_targetVelocity.y > 0)
            targetVelocityY = 1;
        else if (_targetVelocity.y < 0)
            targetVelocityY = -1;

        var WhaitSecond = new WaitForSeconds(_waitForSeconds);
        var WhaitSecondBetweenDash = new WaitForSeconds(_rechargeTime);
        _particleSystemDash.Play();
        _dashCapability = false;
        _rb2d.gravityScale = 0;
        _rb2d.velocity = new Vector2(targetVelocityX * _dashForce, targetVelocityY * _dashForce);
        yield return WhaitSecond;
        _rb2d.velocity = Vector2.zero;
        _rb2d.gravityScale = _rb2dGravity;
        _particleSystemDash.Stop();
        yield return WhaitSecondBetweenDash;
        _dashCapability = true;
    }
}

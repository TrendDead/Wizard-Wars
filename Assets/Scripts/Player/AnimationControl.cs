using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationControl : MonoBehaviour
{
    private Animator _animator;
    private Rigidbody2D _rb2d;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _rb2d = GetComponentInParent<Rigidbody2D>();
    }

    void Update()
    {
        _animator.SetFloat("Speed", Mathf.Abs(Input.GetAxis("Horizontal")));
        if (_rb2d.velocity.y > 0)
            _animator.SetBool("IsJumping", true);
        else
        if (_rb2d.velocity.y < 0)
        {
            _animator.SetBool("IsJumping", false);
            _animator.SetBool("IsFalling", true);
        }
        else
        {
            _animator.SetBool("IsJumping", false);
            _animator.SetBool("IsFalling", false);
        }
        if (Input.GetKeyDown(KeyCode.K))
        {
            _animator.SetBool("IsHit", true);
            StartCoroutine(TestTime());
        }
    }

    private IEnumerator TestTime()
    {
        yield return new WaitForSeconds(0.5f);
        _animator.SetBool("IsHit", false);
    }
}

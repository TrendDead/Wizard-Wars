using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Поворот игрока
/// </summary>
public class PlayerRotation : MonoBehaviour
{
    private Camera _cam;

    [Header("Rotation Dash Effect")]
    private ParticleSystem _ps;
    private ParticleSystemRenderer _psr;
    private SpriteRenderer _spriteRend;

    private float _inputX;
    private Sprite _sprite;

    private Transform _playerTransform;
    void Awake()
    {
        _cam = Camera.main;
        _playerTransform = GetComponent<Transform>();
        
        _spriteRend = GetComponentInChildren<SpriteRenderer>();
        _ps = GetComponentInChildren<ParticleSystem>();
        _psr = GetComponentInChildren<ParticleSystemRenderer>();

        StartCoroutine(SetSprite());
    }


    void Update()
    {
        Vector2 mousePos = _cam.ScreenToWorldPoint(Input.mousePosition);
        Vector2 diffNormal = new Vector2(mousePos.x - _playerTransform.position.x, mousePos.y - _playerTransform.position.y).normalized;

        if (diffNormal.x > 0)
        {
            _playerTransform.rotation = Quaternion.Euler(0, 0, 0);
            _psr.flip = Vector3.zero;
        }
        else
        {
            _playerTransform.rotation = Quaternion.Euler(0, 180, 0);
            _psr.flip = Vector3.right;
        }
    }

    private IEnumerator SetSprite()
    {
        yield return new WaitForSeconds(0.5f);
        _sprite = _spriteRend.sprite;
        _ps.textureSheetAnimation.AddSprite(_sprite);
    }
}

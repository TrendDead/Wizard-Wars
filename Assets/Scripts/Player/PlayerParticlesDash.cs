using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerParticlesDash : MonoBehaviour
{
    private ParticleSystem _ps;
    private Sprite _sprite;
    private ParticleSystemRenderer _psr;
    private float _inputX;
    private void Start()
    {
        _psr = GetComponent<ParticleSystemRenderer>();
        StartCoroutine(GetComponents());
    }

    private void Update()
    {
        _inputX = Input.GetAxis("Horizontal");

        if (_inputX < 0)
            _psr.flip = Vector3.right;
        else
            if (_inputX > 0)
                _psr.flip = Vector3.zero;
    }

    private IEnumerator GetComponents()
    {
        yield return new WaitForSeconds(0.5f);
        _ps = GetComponent<ParticleSystem>();
        _sprite = GetComponentInParent<SpriteRenderer>().sprite;
        _ps.textureSheetAnimation.AddSprite(_sprite);
    }
}

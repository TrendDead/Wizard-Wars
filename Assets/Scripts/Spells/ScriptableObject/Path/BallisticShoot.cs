using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Abillitys/Path/Ballistic Shoot", order = 51)]

class BallisticShoot : Path
{
    [SerializeField] private float _angleInDegrees;

    private Camera _cam;
    private Rigidbody2D _rb2d;


    public override void Shoot(Spell spell, float speedSpell, Transform positionFrom, float lifeTimeSpell)
    {
        float g = Physics2D.gravity.y;
        positionFrom.localEulerAngles = new Vector3(_angleInDegrees, 0f, 0f);

        _cam = Camera.main;
        Vector3 mousePos = _cam.ScreenToWorldPoint(Input.mousePosition);

        Vector3 fromTo = mousePos - positionFrom.position;

        float x = new Vector3(fromTo.x, 0f, fromTo.z).magnitude;
        float y = fromTo.y;

        float angleInRadians = _angleInDegrees * Mathf.PI / 180;

        float v2 = (g * x * x) / (2 * (y - Mathf.Tan(angleInRadians) * x) * Mathf.Pow(Mathf.Cos(angleInRadians), 2));
        float v = Mathf.Sqrt(Mathf.Abs(v2));

        Debug.Log(v);
        Debug.Log(positionFrom.forward);
        spell = Instantiate(spell, positionFrom.position, Quaternion.identity);
        _rb2d = spell.GetComponent<Rigidbody2D>();
        _rb2d.velocity = positionFrom.forward * v;
    }
}


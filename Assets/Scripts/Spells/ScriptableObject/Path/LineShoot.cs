using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Abillitys/Path/Line Shoot", order = 51)]
public class LineShoot : Path
{
    private Camera _cam;
    private Rigidbody2D _rb2d;

    public override void Shoot(Spell spell, float speedSpell, Transform positionFrom, float lifeTimeSpell)
    {
        _cam = Camera.main;
        Vector3 mousePos = _cam.ScreenToWorldPoint(Input.mousePosition);
        mousePos = (mousePos - positionFrom.position).normalized;
        spell = Instantiate(spell, positionFrom.position, Quaternion.identity);
        spell.LifeTimeSpell = lifeTimeSpell;
        _rb2d = spell.GetComponent<Rigidbody2D>();
        _rb2d.gravityScale = 0;
        _rb2d.velocity = new Vector3(mousePos.x, mousePos.y, 0f) * speedSpell;
    }
}

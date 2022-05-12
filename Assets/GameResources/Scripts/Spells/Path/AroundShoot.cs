using UnityEngine;

/// <summary>
/// Спел вокруг игрока
/// </summary>
public class AroundShoot : Path
{


    public override void Shoot(Spell spell, float _speedSpell, Transform positionFrom, float lifeTimeSpell)
    {
        spell.LifeTimeSpell = lifeTimeSpell;
        Instantiate(spell, positionFrom.position, Quaternion.identity, positionFrom);
    }

}

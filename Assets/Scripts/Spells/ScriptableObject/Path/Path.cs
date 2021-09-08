using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Path : ScriptableObject
{
    public abstract void Shoot(Spell spell, float _speedSpell, Transform positionFrom, float lifeTimeSpell);
}

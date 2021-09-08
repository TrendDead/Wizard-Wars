using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Abillitys/New Abillity", order = 51)]
public class Ability : ScriptableObject
{
    [SerializeField] private string _name;
    [SerializeField] private int _costMana;
    [SerializeField] private float _rechargeTime;
    [SerializeField] private float _speedSpell;
    [SerializeField] private float _lifeTimeSpell;
    [SerializeField] private Path _path;
    [SerializeField] private Spell _spell;
    [SerializeField] private Sprite _abilityIcon;
    //[SerializeField] private List<Effect> _effects;

    public float RechargeTime => _rechargeTime;

    public void Shoot(Transform positionFrom)
    {
        _path.Shoot(_spell, _speedSpell, positionFrom, _lifeTimeSpell);
    }


}

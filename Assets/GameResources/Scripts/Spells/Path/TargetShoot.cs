using UnityEngine;
using DG.Tweening;

/// <summary>
/// Выстрел следующий за целью
/// </summary>
public class TargetShoot : Path
{
    private const float MAXTIME = 11;

    [SerializeField]
    private Transform _target;
    [SerializeField]
    private float _timeMove = 2;

    private Tweener _tween;
    private Spell _spell;
    private Vector3 _targetLastPosition;

    private void Start()
    {
        _spell = GetComponent<Spell>();
        Debug.Log(MAXTIME - _timeMove);
        _tween = transform.DOMove(_target.position, MAXTIME - _timeMove).SetAutoKill(false);
        _targetLastPosition = _target.position;
        transform.parent = null;
        _spell.StartTimerLife();
    }

    private void Update()
    {
        if(_targetLastPosition != _target.position)
        {
            _tween.ChangeEndValue(_target.position, true).Restart();
            _targetLastPosition = _target.position;
        }
    }

    public override void Shoot(Spell spell, float _speedSpell, Transform positionFrom, float lifeTimeSpell)
    {
        Vector2 ray = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        RaycastHit2D hit2D = Physics2D.Raycast(ray, Vector2.zero);

        if (hit2D.transform != null)
        {
            if (hit2D.transform.TryGetComponent(out Collider2D collider))
            {
                _target = collider.transform;
                _timeMove = _speedSpell;
                spell.LifeTimeSpell = lifeTimeSpell;
                Instantiate(spell, positionFrom.position, Quaternion.identity, positionFrom);
            }
        }
    }

}

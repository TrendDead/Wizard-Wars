using UnityEngine;

/// <summary>
/// Баллистический путь полета спела
/// </summary>
class BallisticShoot : Path
{
    [SerializeField]
    private float _power = 2.5f;

    private LineRenderer _lr;
    private Rigidbody2D _rb;
    private Spell _spell;
    private Vector2 _dragSatatPos;
    private bool _isStartShoot = true;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        _lr = GetComponent<LineRenderer>();
        _rb.simulated = false;
    }

    private void Start()
    {
        _spell = GetComponent<Spell>();
    }

    private void LateUpdate()
    {
        if (Input.GetMouseButton(0) && _isStartShoot)
        {
            _dragSatatPos = new Vector2(gameObject.transform.position.x, gameObject.transform.position.y);
            Vector2 dragEndPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 velocity = (dragEndPos - _dragSatatPos) * _power;
            velocity = new Vector2(Mathf.Clamp(velocity.x, -10f, 10f), velocity.y);

            Vector2[] trajectory = Plot(_rb, (Vector2)transform.position, velocity, 500);

            _lr.positionCount = trajectory.Length;

            Vector3[] positions = new Vector3[trajectory.Length];

            for (int i = 0; i < trajectory.Length; i++)
            {
                positions[i] = trajectory[i];
            }
            _lr.SetPositions(positions);
        }

        if (Input.GetMouseButtonUp(0) && _isStartShoot)
        {
            _rb.simulated = true;

            _spell.StartTimerLife();

            Vector2 dragEndPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 velocity = (dragEndPos - _dragSatatPos) * _power;
            velocity = new Vector2(Mathf.Clamp(velocity.x, -10f, 10f), velocity.y);
            transform.parent = null;
            _rb.velocity = velocity;
            _lr.positionCount = 0;
            _isStartShoot = false;
            GetComponent<Spell>().StartSpellTimer();
        }
    }

    private Vector2[] Plot(Rigidbody2D rb, Vector2 pos, Vector2 velocity, int steps)
    {
        Vector2[] results = new Vector2[steps];

        float timeStep = Time.fixedDeltaTime / Physics2D.velocityIterations;
        Vector2 gravityAccel = Physics2D.gravity * rb.gravityScale * timeStep * timeStep;

        float drag = 1f - timeStep * rb.drag;
        Vector2 moveStep = velocity * timeStep;

        for (int i = 0; i < steps; i++)
        {
            moveStep += gravityAccel;
            moveStep *= drag;
            pos += moveStep;
            results[i] = pos;
        }

        return results;
    }

    public override void Shoot(Spell spell, float speedSpell, Transform positionFrom, float lifeTimeSpell)
    {
        spell.LifeTimeSpell = lifeTimeSpell;
        _power = speedSpell;
        _isStartShoot = true;
        Instantiate(spell, positionFrom.position, Quaternion.identity, positionFrom);
    }
}


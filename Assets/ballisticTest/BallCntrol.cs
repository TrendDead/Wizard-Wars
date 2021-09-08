using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallCntrol : MonoBehaviour
{
    [SerializeField] private float _power;

    private Rigidbody2D _rb;
    private LineRenderer _lr;

    private Vector2 _dragSatatPos;

    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _lr = GetComponent<LineRenderer>();
    }

    public void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            _dragSatatPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }

        if(Input.GetMouseButton(0))
        {
            Vector2 dragEndPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 velocity = (dragEndPos - _dragSatatPos) * _power;
            velocity = new Vector2(Mathf.Clamp(velocity.x, -10f, 10f),velocity.y);

            Vector2[] trajectory = Plot(_rb, (Vector2)transform.position, velocity, 500);

            _lr.positionCount = trajectory.Length;

            Vector3[] positions = new Vector3[trajectory.Length];

            for (int i = 0; i < trajectory.Length; i++)
            {
                positions[i] = trajectory[i];
            }
            _lr.SetPositions(positions);
        }

        if (Input.GetMouseButtonUp(0))
        {
            Vector2 dragEndPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 velocity = (dragEndPos - _dragSatatPos) * _power;
            velocity = new Vector2(Mathf.Clamp(velocity.x, -10f, 10f),velocity.y);

            _rb.velocity = velocity;
            _lr.positionCount = 0;
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
}

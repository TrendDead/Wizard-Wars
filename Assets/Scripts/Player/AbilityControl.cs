using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityControl : MonoBehaviour
{
    [SerializeField] private Ability _mainAbillity;
    [SerializeField] private Transform _plauerTrans;

    private bool _canShoot;

    private void Start()
    {
        _canShoot = true;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) && _canShoot)
        {
            _canShoot = false;
            Shoot();
        }
    }

    private void Shoot()
    {
        _mainAbillity.Shoot(_plauerTrans);
        StartCoroutine(RechargeTime());
    }

    private IEnumerator RechargeTime()
    {
        yield return new WaitForSeconds(_mainAbillity.RechargeTime);
        _canShoot = true;
    }
}

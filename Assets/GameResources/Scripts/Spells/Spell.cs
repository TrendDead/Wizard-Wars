using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Компонент летящей способности
/// </summary>
[RequireComponent(typeof(Rigidbody2D))]
public class Spell : MonoBehaviour
{
    [SerializeField] private ParticleSystem _ps;
    [SerializeField] private List<Effect> _effects;
    //[SerializeField] private ParticleSystem _psDeath;

    private Rigidbody2D _rb2d;

    //[HideInInspector] 
    public float LifeTimeSpell;
    
    private void OnEnable()
    {
        _rb2d = GetComponent<Rigidbody2D>();
        //_ps.Play();
    }


    private void Update()
    {
        /*
        LifeTimeSpell -= Time.deltaTime;
        if (LifeTimeSpell <= 0)
            Destroy(gameObject);
        */
    }
    /// <summary>
    /// Старт таймера жизни спела
    /// </summary>
    /// <returns></returns>
    public void StartTimerLife()
    {
        StartCoroutine(StartSpellTimer());
    }
    public IEnumerator StartSpellTimer()
    {
        yield return new WaitForSeconds(LifeTimeSpell);
        Destroy(gameObject);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        UseSpell();
    }

    private void UseEffect()
    {
        foreach (var effect in _effects)
        {
            effect.Abillity();
        }
    }

    private void UseSpell()
    {
        //_ps.Stop();
        //UseEffect();
        Destroy(gameObject);
    }

}

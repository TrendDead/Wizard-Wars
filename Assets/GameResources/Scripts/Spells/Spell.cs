using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Компонент летящей способности
/// </summary>
public class Spell : MonoBehaviour
{
    [SerializeField] private ParticleSystem _ps;
    [SerializeField] private List<Effect> _effects;
    //[SerializeField] private ParticleSystem _psDeath;

    //[HideInInspector] 
    public float LifeTimeSpell;
    
    private void OnEnable()
    {
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

    private void OnCollisionEnter2D(Collision2D collision)
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

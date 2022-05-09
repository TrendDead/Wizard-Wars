using UnityEngine;

/// <summary>
/// Абстрактый класс пути полета спела
/// </summary>
public abstract class Path : MonoBehaviour
{
    /// <summary>
    /// Выстрел спелом
    /// </summary>
    /// <param name="spell">Префаб спела</param>
    /// <param name="_speedSpell"></param>
    /// <param name="positionFrom">Позиция откуда будет вылетать спел</param>
    /// <param name="lifeTimeSpell"></param>
    public abstract void Shoot(Spell spell, float _speedSpell, Transform positionFrom, float lifeTimeSpell);
}

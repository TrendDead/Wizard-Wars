using UnityEngine;

/// <summary>
/// ���������� ����� ���� ������ �����
/// </summary>
public abstract class Path : MonoBehaviour
{
    /// <summary>
    /// ������� ������
    /// </summary>
    /// <param name="spell">������ �����</param>
    /// <param name="_speedSpell"></param>
    /// <param name="positionFrom">������� ������ ����� �������� ����</param>
    /// <param name="lifeTimeSpell"></param>
    public abstract void Shoot(Spell spell, float _speedSpell, Transform positionFrom, float lifeTimeSpell);
}

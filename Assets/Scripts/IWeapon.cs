using UnityEngine;

public interface IWeapon {
    void Hit (Vector3 originPosition, Vector3 targetPosition, double attackPower);
    double GetEffectiveAttackPower (double attackPower);
}
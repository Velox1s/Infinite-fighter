using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour, IHealthState, IHurtable {

    private double currentHP;

    [SerializeField]
    private double maxHP;

    [SerializeField]
    private double attackPower;

    [SerializeField]
    private ScriptableObject weaponObject;
    
    private void Start () {
        ResetHP();
    }

    private void Update () {
        if (Input.GetMouseButtonDown(0)) {
            var mouseWorldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            HitTowards(mouseWorldPosition);
        }
    }

    public double GetHP () {
        return currentHP;
    }

    public double GetMaxHP () {
        return maxHP;
    }

    public void TakeDamage (double damage) {
        currentHP -= damage;
    }

    public double GetAttackPower () {
        return attackPower;
    }

    public void IncreaseAttackPower(double increase) {
        attackPower += increase;
    }

    private void ResetHP () {
        currentHP = maxHP;
    }

    private void HitTowards (Vector3 hitPosition) {
        var weapon = weaponObject as IWeapon;
        if (weapon == null) {
            Debug.LogError("Cringe architecture");
        }

        weapon.Hit(transform.position, hitPosition, attackPower);
    }
}

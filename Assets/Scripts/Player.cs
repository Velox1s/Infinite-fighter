using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour, IHealthState, IHurtable {
    private double currentHP;
    private double maxHP;

    public double GetHP () {
        return currentHP;
    }

    public double GetMaxHP () {
        return maxHP;
    }

    public void TakeDamage (double damage) {
        currentHP -= damage;
    }
}

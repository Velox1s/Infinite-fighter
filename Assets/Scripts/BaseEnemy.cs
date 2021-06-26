using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class BaseEnemy : MonoBehaviour, IHealthState, IHurtable
{
    protected Rigidbody2D rb2d;
    protected EnemyStats stats;
    protected double currentHP;

    private void Update () {
        var playerPosition = FindObjectOfType<Player>().transform.position;
        rb2d.AddForce((playerPosition - transform.position).normalized * (float) stats.Speed, ForceMode2D.Force);
    }

    private void OnCollisionEnter2D (Collision2D collision) {
        var player = collision.collider.GetComponent<Player>();

        if (player != null) {
            ((IHurtable) player).TakeDamage(stats.AttackPower);
        }
    }

    public double GetHP () {
        return currentHP;
    }

    public double GetMaxHP () {
        return stats.MaxHP;
    }

    public void TakeDamage (double damage) {
        currentHP -= damage;
        
        if (currentHP < 0) {
            Destroy(gameObject);
        }
    }
}

public struct EnemyStats {
    public double MaxHP;
    public double Speed;
    public double AttackPower;

    public EnemyStats(double maxHP = 5f, double speed = 1f, double attackPower = 1f) {
        MaxHP = maxHP;
        Speed = speed;
        AttackPower = attackPower;
    }
}
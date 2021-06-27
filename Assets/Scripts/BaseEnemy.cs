using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class BaseEnemy : MonoBehaviour, IHealthState, IHurtable
{
    protected Rigidbody2D rb2d;
    protected EnemyStats stats;
    protected double currentHP;

    protected Player player;

    private void Start () {
        rb2d = GetComponent<Rigidbody2D>();
        player = FindObjectOfType<Player>();
    }

    private void Update () {
        var playerPosition = player.transform.position;

        if ((playerPosition - transform.position).magnitude < 10f) {
            rb2d.AddForce((playerPosition - transform.position).normalized * (float) stats.Speed, ForceMode2D.Force);
        }
    }

    private void OnCollisionEnter2D (Collision2D collision) {
        var player = collision.collider.GetComponent<Player>();

        if (player != null) {
            Debug.Log($"Attack power is {stats.AttackPower}");
            ((IHurtable) player).TakeDamage(stats.AttackPower);
        }
    }

    public void SetStats (EnemyStats newStats) {
        stats = newStats;
        ResetHP();

        transform.localScale = new Vector3((float)stats.MaxHP/100, (float) stats.MaxHP / 100f);
    }

    private void ResetHP () {
        currentHP = stats.MaxHP;
    }

    public double GetHP () {
        return currentHP;
    }

    public double GetMaxHP () {
        return stats.MaxHP;
    }

    public void TakeDamage (double damage) {
        currentHP -= damage;
        
        if (currentHP <= 0) {
            Die();
        }
    }

    private void Die () {
        player.IncreaseAttackPower(stats.AttackPower);
        Destroy(gameObject);
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
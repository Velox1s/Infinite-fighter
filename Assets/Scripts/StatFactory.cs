using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatFactory : MonoBehaviour {
    private static StatFactory instance;

    private StatFactory () { }
    
    public static StatFactory getInstance() {
        if (instance == null) {
            instance = new StatFactory();
        }
        return instance;
    }

    public static EnemyStats GenerateEnemyStats(float x) {
        EnemyStats es = new EnemyStats();
        es.MaxHP = calculateMaxHP(x);
        es.AttackPower = calculateAttackPower(x);
        es.Speed = calculateSpeed(x);
        return es;
    }

    // range 0 - 40
    private static float linearFunction(float x) {
        return x / 2;
    }
    
    // range 40 - inf
    private static float exponentialFunction(float x) {
        return x * x / 50 + Mathf.Sin(2 * x) - 10;
    }

    private static float calculateMaxHP (float x) {
        float randomX = Random.Range(x - 10f, x + 10f);

        if (x < 40) {
            return 5f * linearFunction(randomX);
        }
        return 5f * exponentialFunction(randomX);
    }

    private static float calculateSpeed (float x) {
        float randomX = Random.Range(x - 10f, x + 10f);

        if (x < 40) {
            return 0.2f * linearFunction(randomX);
        }
        return 0.2f * exponentialFunction(randomX);
    }

    private static float calculateAttackPower (float x) {
        float randomX = Random.Range(x - 10f, x + 10f);

        if (x < 40) {
            return 0.5f * linearFunction(randomX);
        }
        return 0.5f * exponentialFunction(randomX);
    }
}

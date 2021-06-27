using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicEnemySpawner : MonoBehaviour {

    [SerializeField]
    private GameObject enemyPrefab;

    [SerializeField]
    private float spawnTime = 3f;

    [SerializeField]
    private double averageSpawnDistance = 5f;

    private void Start () {
        StartCoroutine(Spawn());
    }
    
    private IEnumerator Spawn() {
        while (true) {
            var spawnPosition = GetRandomSpawnPosition(averageSpawnDistance);

            var enemyObject = Instantiate(enemyPrefab);
            enemyObject.transform.position = spawnPosition;

            yield return new WaitForSeconds(spawnTime);
        }
    }

    private Vector2 GetRandomSpawnPosition (double averageSpawnDistance) {
        var distance = NormalDistributionRandom(averageSpawnDistance, 1f);
        var angle = UnityEngine.Random.value * Mathf.PI * 2f;

        return new Vector2(Mathf.Cos(angle), Mathf.Sin(angle)) * (float)distance;
    }

    private double NormalDistributionRandom(double mean, double standardDeviation) {
        double u1 = 1.0 - UnityEngine.Random.value; //uniform(0,1] random doubles
        double u2 = 1.0 - UnityEngine.Random.value;
        double randStdNormal = Math.Sqrt(-2.0 * Math.Log(u1)) * Math.Sin(2.0 * Math.PI * u2); //random normal(0,1)
        double randNormal = mean + standardDeviation * randStdNormal; //random normal(mean,stdDev^2)
        return randNormal;
    }
}

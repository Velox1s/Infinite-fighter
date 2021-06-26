using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HPBarRenderer : MonoBehaviour {
    [SerializeField]
    private MonoBehaviour healthStateHolder;

    private IHealthState healthState;

    private void Start () {
        if (healthStateHolder is IHealthState) {
            healthState = healthStateHolder as IHealthState;
        }
        else {
            Debug.LogError("Fatal Error - Holder does not implement IHealthState");
        }
    }

    private void Update () {
        // Draw
    }
}

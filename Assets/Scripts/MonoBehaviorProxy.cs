using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonoBehaviorProxy : MonoBehaviour {

    public static GameObject Instantiate (GameObject prefab) {
        return Object.Instantiate(prefab) as GameObject;
    }

    private static MonoBehaviorProxy instance;

    private void Start () {
        if (instance != this) {
            Destroy(gameObject);
        }
    }
}

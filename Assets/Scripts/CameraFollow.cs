using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

    [SerializeField]
    private GameObject followObject;

    private void LateUpdate () {
        var newPos = followObject.transform.position;
        transform.position = new Vector3(newPos.x, newPos.y, -10);
    }
}

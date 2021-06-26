using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

[CreateAssetMenu(fileName = "SliceWeapon", menuName = "ScriptableObjects/SliceWeapon")]
public class SliceWeapon : ScriptableObject, IWeapon {

    [SerializeField]
    private GameObject slicePrefab;

    [SerializeField]
    private double radius;

    public double GetEffectiveAttackPower (double attackPower) {
        return attackPower;
    }

    public void Hit (Vector3 originPosition, Vector3 targetPosition, double attackPower) {
        var sliceObject = Instantiate(slicePrefab);
        sliceObject.transform.position = originPosition;
        sliceObject.transform.rotation = Quaternion.LookRotation(Vector3.forward, targetPosition - originPosition);

        var weaponInstance = sliceObject.GetComponent<SliceWeaponInstance>();

        if (weaponInstance == null) {
            Debug.LogError("No SliceWeaponInstance");
            return;
        }

        weaponInstance.Setup(attackPower, radius);
    }
}
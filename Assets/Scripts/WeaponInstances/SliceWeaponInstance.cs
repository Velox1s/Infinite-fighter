using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SliceWeaponInstance : MonoBehaviour {

    [SerializeField]
    private LayerMask hitMask;

    [SerializeField]
    private float lifetime;

    private double damage;
    private double radius;

    public void Setup (double damage, double radius) {
        this.damage = damage;
        this.radius = radius;
    }

    private void Start () {
        var hits = Physics2D.OverlapCircleAll(transform.position, (float)radius, hitMask);

        foreach(Collider2D hitCollider in hits) {
            var hitObject = hitCollider.gameObject;
            IHurtable hurtable = hitObject.GetComponent<IHurtable>();

            if (hurtable != null) {
                hurtable.TakeDamage(damage);
            }
        }

        Destroy(gameObject, lifetime);
    }
}

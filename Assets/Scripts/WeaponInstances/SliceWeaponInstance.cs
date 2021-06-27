using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SliceWeaponInstance : MonoBehaviour {

    private static int raycastHalfCount = 10;

    [SerializeField]
    private LayerMask hitMask;

    [SerializeField]
    private float lifetime;

    private double damage;
    private float radius;
    private Vector2 direction;
    private float arcInDegrees;

    private IEnumerable<Vector2> arcDirections;

    public void Setup (double damage, float radius, Vector2 direction, float arcInDegrees) {
        this.damage = damage;
        this.radius = radius;
        this.direction = direction;
        this.arcInDegrees = arcInDegrees;
    }

    private void Start () {
        var hits = new HashSet<Collider2D>();

        arcDirections = GenerateDirectionsFromArc(direction, arcInDegrees);
        foreach (Vector2 direction in arcDirections) {
            var hitArray = Physics2D.RaycastAll(transform.position, direction, radius, hitMask);
            
            foreach(RaycastHit2D hit in hitArray) {
                hits.Add(hit.collider);
            }

            Debug.Log($"{hitArray.Length} hits");
        }
        Debug.Log($"Set has {hits.Count} hits");

        foreach(Collider2D hitCollider in hits) {
            Debug.Log(hitCollider.gameObject.name);

            var hitObject = hitCollider.gameObject;
            IHurtable hurtable = hitObject.GetComponent<BaseEnemy>();

            if (hurtable != null) {
                hurtable.TakeDamage(damage);
            }
        }

        Destroy(gameObject, lifetime);
    }

    private IEnumerable<Vector2> GenerateDirectionsFromArc (Vector2 mainDirection, float arcInDegrees) {
        var directions = new List<Vector2>();

        var mainAngle = Mathf.Atan2(mainDirection.y, mainDirection.x);
        var arc = arcInDegrees * Mathf.Deg2Rad;

        for (int i = -raycastHalfCount; i <= raycastHalfCount; i++) {
            var angle = mainAngle + ((float) i / raycastHalfCount) * arc / 2f; ;
            directions.Add(new Vector2(Mathf.Cos(angle), Mathf.Sin(angle)));
        }

        return directions;
    }

    private void OnDrawGizmos () {
        foreach(Vector2 direction in arcDirections) {
            Gizmos.DrawLine(transform.position, (Vector2)transform.position + direction * radius);
        }
    }
}

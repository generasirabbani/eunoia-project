using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public float damage = 1;
    public float knockbackForce = 15f;
    public float moveSpeed = 500f;

    public DetectionZone detectionZone;

    Rigidbody2D rb;

    DamageableCharacter damageableCharacter;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        damageableCharacter = GetComponent<DamageableCharacter>();
    }
    void FixedUpdate()
    {
        if (damageableCharacter.Targetable && detectionZone.detectedObjs.Count > 0)
        {
            // Calculate direction to target object
            Vector2 direction = (detectionZone.detectedObjs[0].transform.position - transform.position).normalized;

            // Move towards detected object
            rb.AddForce(direction * moveSpeed * Time.fixedDeltaTime);
        }
    }
    void OnCollisionEnter2D(Collision2D col)
    {
        Collider2D collider = col.collider;
        IDamageable damageable = col.collider.GetComponent<IDamageable>();

        if(damageable != null)
        {
            Vector2 direction = (collider.transform.position - transform.position).normalized;
            Vector2 knockback = direction * knockbackForce;

            damageable.OnHit(damage, knockback);
        }
    }
}

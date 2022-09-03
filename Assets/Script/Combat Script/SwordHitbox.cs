using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordHitbox : MonoBehaviour
{
    public float swordDamage = 1f;

    public float knockbackForce = 15f;

    public Collider2D swordCollider;

    private void Start()
    {
        if(swordCollider == null)
        {
            Debug.LogWarning("Sword Collider not set");
        }
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        IDamageable damageableObject = collider.GetComponent<IDamageable>();

        if(damageableObject != null)
        {
            Vector3 parentPosition = transform.parent.position;

            Vector2 direction = (collider.transform.position - parentPosition).normalized;
            Vector2 knockback = direction * knockbackForce;

            damageableObject.OnHit(swordDamage, knockback);
        }
    }
}

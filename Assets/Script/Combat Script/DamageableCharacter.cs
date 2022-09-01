using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageableCharacter : MonoBehaviour, IDamageable
{
    Rigidbody2D rb;
    Animator animator;
    Collider2D physicsCollider;

    public float Health
    {
        set
        {
            if (value < _health)
            {
                animator.SetTrigger("Hurt");
            }

            _health = value;

            if (_health <= 0)
            {
                Die();
            }
        }
        get
        {
            return _health;
        }
    }

    public bool Targetable
    {
        get { return _targetable; }
        set
        {
            _targetable = value;

            physicsCollider.enabled = value;
        }
    }

    public float _health = 3;
    public bool _targetable = true;


    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        physicsCollider = GetComponent<Collider2D>();
    }

    void FixedUpdate()
    {
        
    }
    void Die()
    {
        animator.SetBool("isDead", true);
    }

    public void OnHit(float damage, Vector2 knockback)
    {
        Health -= damage;
        rb.AddForce(knockback);
    }

    public void OnHit(float damage)
    {
        Health -= damage;
    }
    public void OnObjectDestroyed()
    {
        Destroy(gameObject);
    }
}

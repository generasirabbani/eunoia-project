using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DamageableCharacter : MonoBehaviour, IDamageable
{
    public GameObject healthText;
    public bool disableSimulation = false;
    public bool canTurnInvincible = false;
    public float invincibilityTime = 0.3f;

    Animator animator;
    Rigidbody2D rb;
    Collider2D physicsCollider;

    private float invincibleTimeElapsed = 0f;
    public float Health
    {
        set
        {
            if (value < _health)
            {
                animator.SetTrigger("Hurt");
                RectTransform textTransform = Instantiate(healthText).GetComponent<RectTransform>();
                textTransform.transform.position = Camera.main.WorldToScreenPoint(gameObject.transform.position);

                Canvas canvas = GameObject.FindObjectOfType<Canvas>();
                textTransform.SetParent(canvas.transform);
            }

            _health = value;

            if (_health <= 0)
            {
                animator.SetBool("isDead", true);
                Targetable = false;
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

            if(disableSimulation)
            {
                rb.simulated = false;
            }
            physicsCollider.enabled = value;
        }
    }

    public bool Invincible { get
        {
            return _invincible;
        }
        set
        {
            _invincible = value;

            if(_invincible == true)
            {
                invincibleTimeElapsed = 0f;
            }
        }
    }

    public float _health = 3;
    public bool _targetable = true;
    public bool _invincible = false;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        physicsCollider = GetComponent<Collider2D>();
    }

    public void OnHit(float damage, Vector2 knockback)
    {
        if(!Invincible)
        {
            Health -= damage;

            // Apply force to the enemy
            rb.AddForce(knockback, ForceMode2D.Impulse);

            if(canTurnInvincible)
            {
                // Activate invincibility and timer
                Invincible = true;
            }
        }
        
    }

    public void OnHit(float damage)
    {
        if(!Invincible)
        {
            Health -= damage;

            if (canTurnInvincible)
            {
                // Activate invincibility and timer
                Invincible = true;
            }
        }
    }
    public void OnObjectDestroyed()
    {
        Destroy(gameObject);
    }

    public void FixedUpdate()
    {
        if(Invincible)
        {
            invincibleTimeElapsed += Time.deltaTime;

            if(invincibleTimeElapsed > invincibilityTime)
            {
                Invincible = false;
            }
        }
    }
}

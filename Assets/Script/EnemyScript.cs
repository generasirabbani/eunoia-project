using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EnemyState
{
    idle,
    walk,
    attack,
    stagger
}
public class EnemyScript : MonoBehaviour
{
    public EnemyState currentState;
    public int maxHealth = 200;
    public string enemyName;
    public int baseAttack;
    public float moveSpeed = 1.5f;

    public Animator animator;
    
    int currentHealth;
    
    Vector2 movement;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
    }

    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Speed", movement.sqrMagnitude);
    }
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        animator.SetTrigger("Hurt");

        if(currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        animator.SetBool("isDead", true);
    }

    public void RemoveEnemy()
    {
        Destroy(gameObject);
    }

    public void OnCollisionEnter2D(Collision2D col)
    {
        
    }
}

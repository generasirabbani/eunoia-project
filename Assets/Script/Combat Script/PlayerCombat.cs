using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    public GameObject upHitbox;
    public GameObject downHitbox;
    public GameObject leftHitbox;
    public GameObject rightHitbox;
    Animator animator;
    Collider2D upCollider;
    Collider2D downCollider;
    Collider2D leftCollider;
    Collider2D rightCollider;

    public float attackRange = 0.5f;
    public int attackDamage = 40;

    public float attackRate = 2f;
    float nextAttackTime = 0f;

    Vector2 knockback;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        upCollider = upHitbox.GetComponent<Collider2D>();
        downCollider = downHitbox.GetComponent<Collider2D>();
        leftCollider = leftHitbox.GetComponent<Collider2D>();
        rightCollider = rightHitbox.GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.time>= nextAttackTime)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Attack();
                nextAttackTime = Time.time + 1f / attackRate;
            }
        }
    }
    void Attack()
    {
        animator.SetTrigger("swordAttack");
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        IDamageable damageableObject = collider.GetComponent<IDamageable>();
        if(damageableObject != null)
        {
            damageableObject.OnHit(attackDamage, knockback);
        }
    }
}

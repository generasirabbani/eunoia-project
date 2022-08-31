using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PlayerState
{
    idle,
    walk,
    attack,
    interact,
    stagger
}
public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;

    Vector2 movement;

    private float MoveX;
    private float MoveY;
    private Vector3 lastMoveDir;

    public Rigidbody2D rb;
    public Animator animator;
    public LayerMask layerMask;
    public PlayerState currentState;

    public int maxHealth = 1000;

    int currentHealth;

    private void Start()
    {
        currentHealth = maxHealth;
    }
    // Update is called once per frame
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Speed", movement.sqrMagnitude);

        Move();
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }

    private void Move()
    {
        MoveX = 0f;
        MoveY = 0f;

        if (Input.GetKey(KeyCode.W))
        {
            MoveY = +1f;
        }
        if (Input.GetKey(KeyCode.A))
        {
            MoveX = -1f;
        }
        if (Input.GetKey(KeyCode.S))
        {
            MoveY = -1f;
        }
        if (Input.GetKey(KeyCode.D))
        {
            MoveX = +1f;
        }

        bool isIdle = MoveX == 0 && MoveY == 0;
        if (isIdle)
        {
            // Play idle animation with the lastMoveDir so that the idle animation plays in the right rotation (left, right, up, down)
        }
        else
        {
            Vector3 moveDir = new Vector3(MoveX, MoveY).normalized;

            if (TryMove(moveDir, moveSpeed * Time.deltaTime))
            {
                // Play walking
                animator.SetFloat("Horizontal", movement.x);
                animator.SetFloat("Vertical", movement.y);
                animator.SetFloat("Speed", movement.sqrMagnitude);
            }
            else
            {
                // Play idle
                animator.SetFloat("Speed", 0);
            }
        }
    }

    private bool CanMove(Vector3 dir, float distance)
    {
        return Physics2D.Raycast(transform.position, dir, distance, layerMask).collider == null;
    }

    private bool TryMove(Vector3 baseMoveDir, float distance)
    {
        Vector3 moveDir = baseMoveDir;

        bool canMove = CanMove(moveDir, distance);
        if (!canMove)
        {
            // Cannot move diagonally
            moveDir = new Vector3(baseMoveDir.x, 0f).normalized;
            canMove = moveDir.x != 0f && CanMove(moveDir, distance);
            if (!canMove)
            {
                // Cannot move horizontally
                moveDir = new Vector3(0f, baseMoveDir.y).normalized;
                canMove = moveDir.y != 0f && CanMove(moveDir, distance);
            }
        }

        if (canMove)
        {
            lastMoveDir = moveDir;
            // Play walking animation with the moveDir so that the idle animation plays in the right rotation (left, right, up, down)
            // storeLastDirection(new Vector3(MoveX, MoveY));

            animator.SetFloat("LastMoveVertical", lastMoveDir.y);
            animator.SetFloat("LastMoveHorizontal", lastMoveDir.x);
            transform.position += moveDir * distance;
            return true;
        }
        else
        {
            return false;
        }
    }
    public void Knock(float knockTime)
    {
        StartCoroutine(KnockCo(knockTime));
    }
    private IEnumerator KnockCo(float knockTime)
    {
        if (rb != null);
        {
            yield return new WaitForSeconds(knockTime);
            rb.velocity = Vector2.zero;
            currentState = PlayerState.idle;
            rb.velocity = Vector2.zero;
        }
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        animator.SetTrigger("Hurt");

        if (currentHealth <= 0)
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
}

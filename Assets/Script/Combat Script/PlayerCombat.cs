using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    Animator animator;

    public float attackRate = 2f;
    float nextAttackTime = 0f;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.time>= nextAttackTime)
        {
            if (Input.GetKeyDown(KeyCode.Mouse1))
            {
                animator.SetTrigger("swordAttack");
                nextAttackTime = Time.time + 1f / attackRate;
            }
        }
    }
}

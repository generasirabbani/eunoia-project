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
    public LayerMask playerLayers;
    
    public float damage = 1;
    public void Knock(Rigidbody2D myRigidbody, float knockTime)
    {
        StartCoroutine(KnockCo(myRigidbody, knockTime));
    }
    private IEnumerator KnockCo(Rigidbody2D myRigidbody, float knockTime)
    {
        if (myRigidbody != null);
        {
            yield return new WaitForSeconds(knockTime);
            myRigidbody.velocity = Vector2.zero;
            currentState = EnemyState.idle;
            myRigidbody.velocity = Vector2.zero;
        }
    }
    private void OnCollisionEnter2D(Collision2D col)
    {
        IDamageable damageable = col.collider.GetComponent<IDamageable>();

        if(damageable != null)
        {
            damageable.OnHit(damage);
        }
    }
}

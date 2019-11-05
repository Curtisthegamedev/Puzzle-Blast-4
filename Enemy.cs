using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float rateOfThrowing = 5;
    public float lastBulletSpawnTime;
    private float throwForce = 50;
    private float timer = 0;
    public bool walking = true; 
    public Animator EnemiesAnim; 
    public Vector2 leftVel;
    public Vector2 rightVel;
    public Rigidbody2D throwable;
    public Transform throwspawn;
    public bool isFacingRight = true;
    public Rigidbody2D rb;

    public void Movement()
    {
        if(walking)
        {
            if(EnemiesAnim)
            {
                EnemiesAnim.SetBool("Jump", false);
            }

            if (isFacingRight)
            {
                rb.MovePosition(rb.position + leftVel * Time.fixedDeltaTime);
            }
            if (!isFacingRight)
            {
                rb.MovePosition(rb.position + rightVel * Time.fixedDeltaTime);
            }
        }
        else if(EnemiesAnim)
        {
            EnemiesAnim.SetBool("Jump", true); 
        }
        
    }

    public IEnumerator waitAndIdleOrWalk()
    {
        yield return new WaitForSeconds(3); 
        if(walking)
        {
            walking = false; 
        }
        else
        {
            walking = true; 
        }
        StartCoroutine(waitAndIdleOrWalk()); 
    }
    public void Flip()
    {
        isFacingRight = !isFacingRight;
        transform.Rotate(0f, 180f, 0f);
        timer = 0; 
    }
    
    public void Attack()
    {
        Debug.Log(throwspawn); 
        if(throwspawn && throwable)
        {
            Debug.Log("throw"); 
            Rigidbody2D temp = Instantiate(throwable, throwspawn.position, throwspawn.rotation);
            Physics2D.IgnoreCollision(GetComponent<Collider2D>(), temp.GetComponent<Collider2D>(), true);
                if (isFacingRight)
                {
                    Debug.Log("isfaceingright");
                    temp.AddForce(-throwspawn.right * throwForce, ForceMode2D.Impulse);
                    lastBulletSpawnTime = Time.time;
                }
                else if (!isFacingRight)
                {
                    Debug.Log("notfaceingright");
                    temp.transform.Rotate(0, 180, 0);
                    temp.AddForce(throwspawn.right * throwForce, ForceMode2D.Impulse);
                    lastBulletSpawnTime = Time.time;
                }
            
            
        }
    }
}

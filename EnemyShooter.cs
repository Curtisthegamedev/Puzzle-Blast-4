using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooter : Enemy
{
    private void Update()
    {
        //Movement();
        if (ThrowBool.isInRange)
        {
            //enemy attacks after a set amout of seconds
            if (Time.time > lastBulletSpawnTime + rateOfThrowing)
            {
                Attack();
            }
        }
    }

    public void OnCollisionEnter2D(Collision2D c)
    {
        if (c.gameObject.tag != "Ground")
        {
            Flip();
        }
    }
}

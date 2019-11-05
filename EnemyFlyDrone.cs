using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//INHERITS FROM ENEMY 
public class EnemyFlyDrone : Enemy
{
    [SerializeField] GameObject RedLaser; 
    private Transform targetPlayer;
    private bool isMoveing;
    void Start()
    {
        targetPlayer = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        walking = true; 
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Ground" || collision.gameObject.tag == "Wall")
        {
            Flip(); 
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "TriggerDirSwitch")
        {
            Flip();
        }
    }

    private IEnumerator WaitAndToggleLaserlight()
    {
        if(RedLaser.activeInHierarchy)
        {
            yield return new WaitForSeconds(3.5f);
            RedLaser.SetActive(false);
        }
        else if(!RedLaser.activeInHierarchy)
        {
            yield return new WaitForSeconds(3.5f); 
            RedLaser.SetActive(true); 
        }
    }
    // Update is called once per frame
    void Update()
    {
        Movement();
        StartCoroutine(WaitAndToggleLaserlight()); 

        if(Input.GetKeyDown(KeyCode.E))
        {
            Flip(); 
        }
    }
}

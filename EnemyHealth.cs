using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    //enemys int health value 
    private int health;
    //this is the enemy's health bar
    [SerializeField] RectTransform MushroomHealthBar;
    //this variable is used to set the size of the health bar. 
    private int scale;
    [SerializeField] GameObject gem; 
    [SerializeField] ParticleSystem enemyMonsterParticles;
    [SerializeField] Transform spotOne, spotTwo, SpotThree; 

    private void Start()
    {
        health = 5; 

        if(MushroomHealthBar)
        {
            //set the scale size of the health bar to go down when health is taken away
            scale = (int)MushroomHealthBar.sizeDelta.x / health; 
        }
    }

    private void OnCollisionEnter2D(Collision2D c)
    {
        //if the enemy collides with the sword, laserBolt or something with a death tag 
        //they take verying levels of damage.
        if(c.gameObject.tag == "SwordWeapon")
        {
            health -= 1; 
        }
        if(c.gameObject.tag == "LaserBolt")
        {
            Debug.Log("laserdetected"); 
            health -= 3; 
        }
        if(c.gameObject.tag == "Death")
        {
            health = 0; 
        }
        
        //chnages the healthbar size dependin on the scale variable and health variable
        MushroomHealthBar.sizeDelta = new Vector2(health * scale, MushroomHealthBar.sizeDelta.y); 
    }

    private void Update()
    {
        //kill the enemy is their health is zero. 
        if (health <= 0)
        {
            if(enemyMonsterParticles)
            {
                Instantiate(enemyMonsterParticles, transform.position, transform.rotation);
                Instantiate(gem, spotOne.position, spotOne.rotation);
                Instantiate(gem, spotTwo.position, spotTwo.rotation);
                Instantiate(gem, SpotThree.position, SpotThree.rotation);
                Destroy(gameObject);
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D c)
    {
        Debug.Log(c.gameObject); 
        //if the enemy collides with the ball they lose health 
        if (c.gameObject.tag == "SwordWeapon")
        {
            health -= 1;
        }
        if (c.gameObject.tag == "LaserBolt")
        {
            health -= 3;
        }

        //chnages the healthbar size dependin on the scale variable and health variable
        MushroomHealthBar.sizeDelta = new Vector2(health * scale, MushroomHealthBar.sizeDelta.y);
    }
}

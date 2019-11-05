using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartingQuestionBlocks : MonoBehaviour
{
    [SerializeField] GameObject laserGun, Sword, BlockMan;
    [SerializeField] Transform powerUpTransformSpawn;
    public static bool playerOpenedAStartingBox = false; 
    float randomizedNumber; 

    private void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.CompareTag("Player") && !playerOpenedAStartingBox)
        {
            randomizedNumber = Random.Range(0, 2); 
            if(randomizedNumber == 0)
            { 
                Instantiate(Sword, powerUpTransformSpawn.position, powerUpTransformSpawn.rotation);
                playerOpenedAStartingBox = true;
                Destroy(this.gameObject); 
            }
            else if(randomizedNumber == 1)
            {
                Instantiate(laserGun, powerUpTransformSpawn.position, powerUpTransformSpawn.rotation);
                playerOpenedAStartingBox = true;
                Destroy(this.gameObject); 
            }
        }
        else if(col.gameObject.CompareTag("Player") && playerOpenedAStartingBox)
        {
            Instantiate(BlockMan, powerUpTransformSpawn.position, powerUpTransformSpawn.rotation);
            Destroy(this.gameObject); 
        }
    }
}

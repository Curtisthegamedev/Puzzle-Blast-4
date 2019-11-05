using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    private GameObject Player;
    private BoxCollider2D PlayerCollider;
    [SerializeField] PhysicsMaterial2D MovingPlatformMat; 

    private void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        PlayerCollider = Player.GetComponent<BoxCollider2D>(); 
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            PlayerCollider.sharedMaterial = MovingPlatformMat; 
        }
    }
}

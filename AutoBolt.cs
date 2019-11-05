using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoBolt : MonoBehaviour
{
    private Rigidbody2D rb;
    private float speed = 20f;

    // Update is called once per frame
    private void Start()
    {
        rb = this.gameObject.GetComponent<Rigidbody2D>(); 
        rb.velocity = -transform.right * speed; 
    }
}

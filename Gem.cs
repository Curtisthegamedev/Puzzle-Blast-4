using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gem : MonoBehaviour
{
    public int _points;
    private Rigidbody2D rb;
    private float speed = 0.3f;
    private bool hasTumbled = false;

    private void Awake()
    {
        rb = this.gameObject.GetComponent<Rigidbody2D>(); 
    }
    //private IEnumerator Tumble()
    //{
     //   rb.AddForce(transform.right * speed);
      //  yield return new WaitForSeconds(0.1f);
       // rb.velocity = Vector2.zero;
        //hasTumbled = true; 
    //}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Gem" && !hasTumbled)
        {
      //      StartCoroutine(Tumble()); 
        }
    }

    public void Start()
    {
        Points = 100; 
    }
    public int Points
    {
        get { return _points; }
        set { _points = value; }
    }
}

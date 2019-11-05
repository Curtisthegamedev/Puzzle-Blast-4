using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 

public class Health : MonoBehaviour
{
    //sets variables eqaul to game objects attached in unity. I placed different heart images of a heart depleting here. 
    [SerializeField] GameObject heart;
    [SerializeField] GameObject heart1;
    [SerializeField] GameObject heart2;
    //creats player life variable. Is static so I can use this variable in another script.  
    public static int life;

    void Start()
    {
        //sets all parts of health active at the start.  
        life = 3;
        heart.gameObject.SetActive(true);
        heart1.gameObject.SetActive(true);
        heart2.gameObject.SetActive(true);
    }

    void Update()
    {
        if (life > 3)
        {
            life = 3;
        }
        else if (life < 0)
        {
            Debug.LogError("MAJOR ERROR IN HEALTH SCRIPT"); 
        }


        switch (life)
        {
            //these case statements erase a heart image causeing the heart in game to empty every time life goes down one. 
            case 3:
                heart.gameObject.SetActive(true);
                heart1.gameObject.SetActive(true);
                heart2.gameObject.SetActive(true);
                break;
            case 2:
                heart.gameObject.SetActive(true);
                heart1.gameObject.SetActive(true);
                heart2.gameObject.SetActive(false);
                break;
            case 1:
                heart.gameObject.SetActive(true);
                heart1.gameObject.SetActive(false);
                heart2.gameObject.SetActive(false);
                break;
            case 0:
                heart.gameObject.SetActive(false);
                heart1.gameObject.SetActive(false);
                heart2.gameObject.SetActive(false);
                SceneManager.LoadScene("GameOver");
                break;
        }
    }
}

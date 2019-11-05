using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 

public class EndLevel : MonoBehaviour
{
    //if player touches the totem then they win. 
    private void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.tag == "Player")
        {
            SceneManager.LoadScene("WinLevelOne"); 
        }
    }
}

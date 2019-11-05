using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 

public class timedLevel : MonoBehaviour
{
    private IEnumerator EndLevelTimer()
    {
        yield return new WaitForSeconds(50);
        SceneManager.LoadScene("LevelTwoWin"); 
    }

    private void Start()
    {
        StartCoroutine(EndLevelTimer()); 
    }
}

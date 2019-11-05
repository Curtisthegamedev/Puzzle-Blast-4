using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleDestroyTrigger : MonoBehaviour
{
    [SerializeField] GameObject puzzleBoard;
    [SerializeField] int timeTillDestruction; 

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            StartCoroutine(WaitAndDestroyPuzzle()); 
        }
    }

    private IEnumerator WaitAndDestroyPuzzle()
    {
        yield return new WaitForSeconds(timeTillDestruction);
        Destroy(puzzleBoard);
    }
}

using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Fragger : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Win"))
        {
            SceneManager.LoadScene("WWCD");
        } 

        if (col.CompareTag("Win2"))
        {
            SceneManager.LoadScene("WWCD2");
        } 
    }

}
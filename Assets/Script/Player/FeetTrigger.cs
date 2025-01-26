using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FeetTrigger : MonoBehaviour
{

    private PlayerMove playerMove;

    private void Start()
    {
        playerMove = GetComponentInParent<PlayerMove>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("BubbleNormal"))
        {
            playerMove.AutoJump();
            Audio.Instance.Jumpingu();
            
        }


        if (collision.CompareTag("BubbleBuff"))
        {
            playerMove.AutoJumpBuff();
        }

        if (collision.CompareTag("BubbleZonk"))
        {
            playerMove.AutoJumpZonk();
        }

        if (collision.CompareTag("Dead"))
        {
            playerMove.Dead();
            
        }

        if (collision.CompareTag("Finish"))
        {
            SceneManager.LoadScene("Finish");
        }

        if (collision.CompareTag("Finish2"))
        {
            SceneManager.LoadScene("Finish2");
        }
    }
}
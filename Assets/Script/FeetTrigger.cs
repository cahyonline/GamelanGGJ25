using UnityEngine;

public class FeetTrigger : MonoBehaviour
{

    private PlayerMove playerMove;

    private void Start()
    {
        playerMove = GetComponentInParent<PlayerMove>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Kontol"))
        {
            playerMove.AutoJump();
        }


        if (collision.CompareTag("KontolBuff"))
        {
            playerMove.AutoJumpBuff();
            //Destroy (GameObject.FindWithTag("KontolBuff"));
        }

        if (collision.CompareTag("Dead"))
        {
            playerMove.Dead();
        }
    }
}
using UnityEngine;

public class HeadTrigger : MonoBehaviour
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
            StartCoroutine(DisableGroundCollider(collision.gameObject));
        }
    }
}
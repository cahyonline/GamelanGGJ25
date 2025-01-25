using UnityEngine;
using System.Collections;

public class PlayerMove : MonoBehaviour
{
    public AwanController awanController;
    public float KecepatanJatuh;
    public float moveSpeed = 5f;
    public float autoJumpForce = 5f;

    public float autoJumpForceBuff = 12f;

    private Rigidbody2D rb;
    private bool isFacingRight = true;

    public GameObject headTrigger; 
    public GameObject feetTrigger; 

    private float minX = -2.658f; // Batas minimum x
    private float maxX = 2.423f; // Batas maksimum x

    public GameObject playerCamera;
    public float spinSpeed = 360f;
    public float deathDuration = 2f;
    private bool isDead = false;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        
        float moveInput = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(moveInput * moveSpeed, rb.velocity.y);

        float clampedX = Mathf.Clamp(transform.position.x, minX, maxX);
        transform.position = new Vector3(clampedX, transform.position.y, transform.position.z);

        if (moveInput > 0 && !isFacingRight)
        {
            Flip();
        }
        else if (moveInput < 0 && isFacingRight)
        {
            Flip();
        }

        if (isDead)
        {
            transform.Rotate(Vector2.up, spinSpeed * Time.deltaTime);
        }
    }

    public void AutoJump()
    {
        rb.velocity = new Vector2(rb.velocity.x, autoJumpForce);
    }

    public void AutoJumpBuff()
    {
        rb.velocity = new Vector2(rb.velocity.x, autoJumpForceBuff);
    }

    private IEnumerator DisableGroundCollider(GameObject ground)
    {
        Collider2D groundCollider = ground.GetComponent<Collider2D>();
        if (groundCollider != null)
        {
            groundCollider.enabled = false;
            yield return new WaitForSeconds(1f);
            groundCollider.enabled = true;
        }
    }

    private void Flip()
    {
        isFacingRight = !isFacingRight;
        Vector3 scaler = transform.localScale;
        scaler.x *= -1;
        transform.localScale = scaler;
    }

    public void Dead()
    {
        if (isDead) return;
        isDead = true;

        if (rb != null)
        {
            rb.velocity = Vector2.up;
            rb.isKinematic = true;
        }

        StartCoroutine(DeathSequence());
    }

    private System.Collections.IEnumerator DeathSequence()
    {
        yield return new WaitForSeconds(deathDuration);
        if (playerCamera != null)
        {
            playerCamera.SetActive(false);
        }

        gameObject.SetActive(false);
    }

    private void OnTriggerEnter2D (Collider2D collision)
    {
        if (collision.CompareTag("AwanKanan"))
        {
            awanController = collision.GetComponent<AwanController>();
            awanController.DeteksiKanan();
            
        }

        else if (collision.CompareTag("AwanKiri"))
        {
            awanController = collision.GetComponent<AwanController>();
            awanController.DeteksiKiri();
            
        }
    }
}

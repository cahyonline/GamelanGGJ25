using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    public Animator animator; // Drag Animator here
    public float jumpForce = 10f; // Set your jump force
    private Rigidbody2D rb; // Assuming you use Rigidbody2D

    private bool isJumping = false;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            // Jump();
        }

        float verticalVelocity = rb.velocity.y;

        if (verticalVelocity > 0.1f && !isJumping)
        {
            isJumping = true;

            // Restart animasi lompat
            animator.Play("JumpUp"); // Nama animasi "JumpUp"
            animator.SetBool("isJumping", true);
            animator.SetBool("isFalling", false);
        }
        else if (verticalVelocity < -0.1f) // Cek apakah pemain sedang jatuh
        {
            isJumping = false;
            animator.SetBool("isJumping", false);
            animator.SetBool("isFalling", true);
        }
        else if (Mathf.Abs(verticalVelocity) < 0.1f && isJumping) // Cek apakah sudah di tanah
        {
            isJumping = false;
            animator.SetBool("isJumping", false);
            animator.SetBool("isFalling", false);
        }

    }

    // private void Jump()
    // {
    //     rb.velocity = new Vector2(rb.velocity.x, jumpForce);
    //     animator.ResetTrigger("JumpTrigger");
    //     animator.SetTrigger("JumpTrigger");
    // }
}

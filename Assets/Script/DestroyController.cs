using UnityEngine;

public class DestroyController : MonoBehaviour
{
    public Animator animator; // Animator untuk platform

    private bool isDestroying = false; // Mencegah penghancuran berulang

    public float DestroyTime;
    public float speed = 2; // Kecepatan pergerakan horizontal

    public enum PiliihanArah
    {
        Kanan,
        Kiri
    }

    public PiliihanArah arah;

    void Update()
    {
        if (arah == PiliihanArah.Kanan)
        {
            keKanan();
        }

        else
        {
            KeKiri();
        }
    }

    public void keKanan()
    {
        Vector3 pos = transform.position;
        pos.x -= speed * Time.deltaTime;
        transform.position = pos;
    }

    public void KeKiri()
    {
        Vector3 pos = transform.position;
        pos.x -= speed * Time.deltaTime;
        transform.position = pos;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Sikil") && !isDestroying)
        {
            isDestroying = true; // Mencegah animasi diputar ulang
            animator.SetBool("isDestroy", true); // Memutar animasi penghancuran

            // Tunggu hingga animasi selesai, lalu hancurkan
            StartCoroutine(DestroyAfterAnimation());
        }
    }

    private System.Collections.IEnumerator DestroyAfterAnimation()
    {
        // Tunggu hingga animasi selesai
        yield return new WaitForSeconds(animator.GetCurrentAnimatorStateInfo(0).length);

        // Hancurkan platform
        Destroy(gameObject);
    }
}

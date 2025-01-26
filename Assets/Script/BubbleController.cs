using UnityEngine;
using System.Collections;

public class BubbleController : MonoBehaviour
{

    public float destroyTime = 2f;
   
    public Animator animator; // Animator untuk platform

    private bool isDestroying = false; // Mencegah penghancuran berulang
    public bool isMove = true; // Mengatur apakah objek bergerak atau tidak
    public float speed = 2f; // Kecepatan pergerakan horizontal
    public float batasKanan = 0.4f; // Batas kanan sumbu X
    public float batasKiri = -2f; // Batas kiri sumbu X

    private bool movingRight = true; // Menentukan arah pergerakan (kanan atau kiri)

    void Update()
    {
        if (!isMove) return; // Jika tidak bergerak, hentikan logika di sini

        // Pergerakan bolak-balik pada sumbu X
        if (movingRight)
        {
            transform.position += Vector3.right * speed * Time.deltaTime; // Bergerak ke kanan

            if (transform.position.x >= batasKanan)
            {
                movingRight = false; // Ubah arah ke kiri
            }
        }
        else
        {
            transform.position += Vector3.left * speed * Time.deltaTime; // Bergerak ke kiri

            if (transform.position.x <= batasKiri)
            {
                movingRight = true; // Ubah arah ke kanan
            }
        }
}

  private void OnTriggerEnter2D(Collider2D collision)
{
    if (collision.CompareTag("Sikil") && !isDestroying)
    {
        isDestroying = true; // Mencegah animasi diputar ulang

        
        animator.SetTrigger("isDestroy"); // Memutar animasi penghancuran

        // Jalankan Coroutine untuk menghancurkan objek setelah animasi selesai
        StartCoroutine(DestroyAfterAnimation());
    }
}

private IEnumerator DestroyAfterAnimation()
{
    // Dapatkan informasi tentang animasi yang sedang diputar
    AnimatorStateInfo animationState = animator.GetCurrentAnimatorStateInfo(0);

    // Tunggu durasi animasi selesai
    yield return new WaitForSeconds(animationState.length);

    // Hancurkan game object
    Destroy(this.gameObject);
}

}

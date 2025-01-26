using System.Collections;
using UnityEngine;

public class WinPanel : MonoBehaviour
{
    public float WinPanelTime;
    public GameObject winPanel; // Referensi ke panel Win

    void Start()
    {
        // Pastikan panel Win dimatikan saat game mulai
        winPanel.SetActive(false);

        // Jalankan Coroutine untuk menampilkan panel setelah 16 detik
        StartCoroutine(ShowWinPanelAfterDelay(WinPanelTime));
    }

    IEnumerator ShowWinPanelAfterDelay(float delay)
    {
        // Tunggu selama `delay` detik
        yield return new WaitForSeconds(delay);

        // Aktifkan panel Win
        winPanel.SetActive(true);
    }
}

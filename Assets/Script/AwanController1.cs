using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class AwanController : MonoBehaviour
{
    public float BatasAwanKanan;
    public float BatasAwanKiri;
    public GameObject awanDisplay;

    public enum PiliihanArah
    {
        Kanan, Kiri
    }

    public float DestroyTime;
    public float speed = 2; // Kecepatan pergerakan horizontal
    public float verticalAmplitude = 1f; // Amplitudo (jarak naik-turun)
    public float verticalSpeed = 1f; // Kecepatan naik-turun pada sumbu Y

    public PiliihanArah arah;

    private float initialY; // Menyimpan posisi Y awal

    public bool CekKanan = false;
    public bool CekKiri;

    void Start()
    {
        // Simpan posisi Y awal
        initialY = awanDisplay.transform.position.y;
    }

    void Update()
    {
        if (CekKanan)
        {
            keKanan();

            if (awanDisplay.transform.position.x >= BatasAwanKanan)
            {
                CekKanan = false;
            } 
        }

        else if (CekKiri)   
        {
            keKiri();

            if (awanDisplay.transform.position.x <= BatasAwanKiri)
            {
                CekKiri = false;
            } 
        }
    }

    public void DeteksiKanan()
    {
        CekKanan = true;
    }

    public void DeteksiKiri()
    {
        CekKiri = true;
    }

    public async Task keKanan()
    {

        Vector3 pos = awanDisplay.transform.position;
        pos.x += speed * Time.deltaTime;
        awanDisplay.transform.position = pos;

        
    }

    public void keKiri()
    {


        Vector3 pos = awanDisplay.transform.position;
        pos.x -= speed * Time.deltaTime;
        awanDisplay.transform.position = pos;

        
    }

    public void GerakanVertikal()
    {
        // Perhitungan naik-turun dengan fungsi sinusoidal
        float yOffset = Mathf.Sin(Time.time * verticalSpeed) * verticalAmplitude;
        awanDisplay.transform.position = new Vector3(transform.position.x, initialY + yOffset, transform.position.z);
        Destroy(awanDisplay.gameObject, DestroyTime);
    }
}

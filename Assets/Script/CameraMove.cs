    using UnityEngine;

public class CameraMove : MonoBehaviour
{
    public Transform player; // Referensi posisi player
    public float smoothSpeed = 0.125f; // Kecepatan smoothing
    public float offsetY = 2f; // Jarak kamera dari player pada sumbu Y

    private float previousPlayerY; // Menyimpan posisi Y player sebelumnya

    private void Start()
    {
        if (player != null);
       
    }
    
    private void LateUpdate()
    {
        if (player != null)
        {
            float fixedX = transform.position.x;
            float fixedZ = transform.position.z; 

            if (player.position.y > previousPlayerY)
            {
                float targetY = player.position.y + offsetY;
                float smoothedY = Mathf.Lerp(transform.position.y, targetY, smoothSpeed);
                transform.position = new Vector3(fixedX, smoothedY, fixedZ);
            }

            previousPlayerY = player.position.y;
        }
    }
}

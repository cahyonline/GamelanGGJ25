using UnityEngine;

public class BackgroundFollow : MonoBehaviour
{
    public Transform player; 
    public float smoothSpeed = 0.1f; 
    public float triggerHeight = 15f; 

    private float initialY; 

    private void Start()
    {
        // Simpan posisi awal background
        initialY = transform.position.y;
    }

    private void LateUpdate()
    {
        if (player != null)
        {
            
            if (player.position.y >= triggerHeight)
            {
                // Hitung target posisi background
                float targetY = initialY + (player.position.y - triggerHeight);

                // Lerp untuk perpindahan yang mulus
                float smoothedY = Mathf.Lerp(transform.position.y, targetY, smoothSpeed);

                // Update posisi background
                transform.position = new Vector3(transform.position.x, smoothedY, transform.position.z);
            }
        }
    }
}

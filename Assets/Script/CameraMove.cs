    using UnityEngine;

public class CameraMove : MonoBehaviour
{
    public Transform player; // Referensi posisi player
    
    public float batasKamera = 1f;
    private void Start()
    {
        
       
    }
    
    private void LateUpdate()
    {
        if (player.transform.position.y >= batasKamera)
        {
             Vector3 cameraPosition = transform.position;
            cameraPosition.y = 42.9f;
        }

        
    }
}

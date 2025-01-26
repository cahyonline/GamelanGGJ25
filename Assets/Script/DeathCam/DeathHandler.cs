using UnityEngine;
using Cinemachine;

public class DeathHandler : MonoBehaviour
{
    public CinemachineVirtualCamera cinemachineCamera;
    public Transform gameOverTarget;

    private bool isPlayerDead = false;

    void Update()
    {
        if (isPlayerDead)
        {
            cinemachineCamera.Follow = gameOverTarget;
            cinemachineCamera.LookAt = gameOverTarget;
        }
    }
    public void OnPlayerDeath()
    {
        isPlayerDead = true;
        if (gameObject != null)
        {
            Destroy(gameObject);
        }
    }
}

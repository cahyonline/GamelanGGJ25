using UnityEngine;

public class RandomMoveCloudUI : MonoBehaviour
{
    public RectTransform cloud; 
    public Vector2 moveRange = new Vector2(50, 50); 
    public float moveSpeed = 100*2f; 
    public float idleTime = 0.5f; 

    private Vector2 startPosition;
    private Vector2 targetPosition;
    private float timer;

    void Start()
    {
        if (cloud != null)
        {
            startPosition = cloud.anchoredPosition; 
            SetNewTargetPosition(); 
        }
    }

    void Update()
    {
        if (cloud != null)
        {
            cloud.anchoredPosition = Vector2.MoveTowards(cloud.anchoredPosition, targetPosition, moveSpeed * Time.deltaTime);

            if (Vector2.Distance(cloud.anchoredPosition, targetPosition) < 0.1f)
            {
                timer += Time.deltaTime;
                if (timer >= idleTime)
                {
                    SetNewTargetPosition();
                    timer = 0;
                }
            }
        }
    }

    private void SetNewTargetPosition()
    {
        float randomX = Random.Range(-moveRange.x, moveRange.x);
        float randomY = Random.Range(-moveRange.y, moveRange.y);
        targetPosition = startPosition + new Vector2(randomX, randomY);
    }
}

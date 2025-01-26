using UnityEngine;

public class MoveCloudUI : MonoBehaviour
{
    public RectTransform cloud;
    public Vector2 startPosition = new Vector2(-890, -783);
    public Vector2 targetPosition = new Vector2(-351, -1028);
    public float speed = 90f;

    void Start()
    {
        if (cloud != null)
        {
            cloud.anchoredPosition = startPosition;
        }
    }

    void Update()
    {
        if (cloud != null)
        {
            cloud.anchoredPosition = Vector2.MoveTowards(cloud.anchoredPosition, targetPosition, speed * 2* Time.deltaTime);
        }
    }
}

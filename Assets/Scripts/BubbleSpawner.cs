using UnityEngine;

public class BubbleSpawner : MonoBehaviour
{
  
    [SerializeField] private GameObject bubble;
    // [SerializeField] private int bubbleCount = 5;
    [SerializeField, Range(0, 1)] private float bubbleScale;
    [SerializeField] private GameObject submarine;
    [SerializeField, Range(-100, 100)] private float bubbleOffsetX;
    [SerializeField, Range(-100, 100)] private float bubbleOffsetY;
    [SerializeField, Range(-100, 100)] private float bubbleOffsetZ;
    [SerializeField, Range(-10, 10)] private float bubbleRotateX;
    [SerializeField, Range(-10, 10)] private float bubbleRotateY;
    [SerializeField, Range(-10, 10)] private float bubbleRotateZ;


    // private GameObject[] bubbles = new GameObject[5];
    private Vector3 bubbleOffset;
    private Vector3 bubbleRotate;
    private GameObject trailBubble;


    void Start()
    {
        GenerateTrail();
    }

    void Update()
    {
        RotateTrail();
    }

   

    void RotateTrail()
    {
        bubbleOffset = new Vector3(bubbleOffsetX, bubbleOffsetY, bubbleOffsetZ);
        bubbleRotate = new Vector3(bubbleRotateX, bubbleRotateY, bubbleRotateZ);

        trailBubble.transform.localScale = new Vector3(bubbleScale, bubbleScale, bubbleScale);
        var position = submarine.transform.position;
        trailBubble.transform.position = position + bubbleOffset;
        trailBubble.transform.Rotate(bubbleRotate);
    }

    void GenerateTrail()
    {
        bubbleOffset = new Vector3(bubbleOffsetX, bubbleOffsetY, bubbleOffsetZ);
        trailBubble = Instantiate(bubble, transform);
        trailBubble.name = $"Bubbles";
        trailBubble.transform.localScale = new Vector3(bubbleScale, bubbleScale, bubbleScale);
        trailBubble.transform.SetPositionAndRotation(submarine.transform.position, Quaternion.identity);
    }
}
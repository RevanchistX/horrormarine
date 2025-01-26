using System.Collections.Generic;
using UnityEngine;

public class BubbleSpawner : MonoBehaviour
{
    [SerializeField] private GameObject bubble;
    [SerializeField] private GameObject bubble2;

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
    private float timer;
    public List<GameObject> bubbles = new();
    private bool shoulWork = false;

    void Start()
    {
        timer = 0;
        GenerateTrail();
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.T)) shoulWork = true;
        if (shoulWork) SpawnTimer();
        // UpdateBubbleScale(bubbleScale);
        RotateTrail();
    }

    private void SpawnTimer()
    {
        timer++;
        if (!(timer > 200)) return;
        timer = 0;
        GenerateBabble();
        // var rb = babbl.AddComponent<Rigidbody>();
        // rb.useGravity = false;
    }

    private void GenerateBabble()
    {
        print(submarine.transform.forward);
        var babbl = Instantiate(bubble2,
            submarine.transform.position + new Vector3(Random.Range(-1000, 0), Random.Range(-20, 20), 0),
            Quaternion.identity);
        babbl.transform.localScale = new Vector3(0.005f, 0.005f, 0.005f);
        babbl.name = $"Bubble to consume";
        var colider = babbl.AddComponent<BoxCollider>();
        colider.isTrigger = true;
        bubbles.Add(babbl);
    }

    public void UpdateBubbleScale(float value)
    {
        trailBubble.transform.localScale = new Vector3(value, value, value);
    }


    public void SetHidden()
    {
        trailBubble.SetActive(false);
    }

    public void SetVisible()
    {
        trailBubble.SetActive(true);
    }

    public void UpdateTrailRotation(Vector3 vector)
    {
        bubbleRotateX = vector.x;
        bubbleRotateY = vector.y;
        bubbleRotateZ = vector.z;
    }

    public void RotateTrail()
    {
        bubbleOffset = new Vector3(bubbleOffsetX, bubbleOffsetY, bubbleOffsetZ);
        bubbleRotate = new Vector3(bubbleRotateX, bubbleRotateY, bubbleRotateZ);
        trailBubble.transform.position = submarine.transform.position + bubbleOffset;
        trailBubble.transform.Rotate(bubbleRotate);
    }

    void GenerateTrail()
    {
        bubbleOffset = new Vector3(bubbleOffsetX, bubbleOffsetY, bubbleOffsetZ);
        trailBubble = Instantiate(bubble, submarine.transform);
        trailBubble.name = $"Bubbles";
        trailBubble.transform.localScale = new Vector3(bubbleScale, bubbleScale, bubbleScale);
        trailBubble.transform.SetPositionAndRotation(submarine.transform.position, Quaternion.identity);
    }
}
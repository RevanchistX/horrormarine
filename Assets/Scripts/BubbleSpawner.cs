using System;
using UnityEngine;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;

public class BubbleSpawner : MonoBehaviour
{
    [SerializeField] private GameObject bubble;
    [SerializeField] private int bubbleCount = 5;
    [SerializeField, Range(0, 1)] private float bubbleScale;
    [SerializeField] private GameObject submarine;
    [SerializeField, Range(-100, 100)] private float bubbleOffsetX;
    [SerializeField, Range(-100, 100)] private float bubbleOffsetY;
    [SerializeField, Range(-100, 100)] private float bubbleOffsetZ;
    [SerializeField, Range(-10, 10)] private float bubbleRotateX;
    [SerializeField, Range(-10, 10)] private float bubbleRotateY;
    [SerializeField, Range(-10, 10)] private float bubbleRotateZ;


    private GameObject[] bubbles = new GameObject[5];
    private Vector3 bubbleOffset;
    private Vector3 bubbleRotate;

    void Start()
    {
        bubbleOffset = new Vector3(bubbleOffsetX, bubbleOffsetY, bubbleOffsetZ);
        for (var i = 0; i < bubbleCount; i++)
        {
            // Debug.Log(bubbleCount);
            var bub = Instantiate(bubble, transform);
            bub.name = $"Bubbles {i}";
            bub.transform.localScale = new Vector3(bubbleScale, bubbleScale, bubbleScale);
            bubbles[i] = bub;
            bub.transform.SetPositionAndRotation(submarine.transform.position, Quaternion.identity);
        }
    }

    void Update()
    {
        bubbleOffset = new Vector3(bubbleOffsetX, bubbleOffsetY, bubbleOffsetZ);
        bubbleRotate = new Vector3(bubbleRotateX, bubbleRotateY, bubbleRotateZ);
        foreach (var bub in bubbles)
        {
            bub.transform.localScale = new Vector3(bubbleScale, bubbleScale, bubbleScale);
            // print(submarineOffset);
            // var moveDirection = new Vector3(Random.Range(-10, 11), 5, Random.Range(-10, 11));
            // var vectorToMove = submarine.transform.position + moveDirection;
            // var rotation = Quaternion.Lerp(submarine.transform.rotation, )
            var position = submarine.transform.position;
            bub.transform.position = position + bubbleOffset;
            bub.transform.Rotate(bubbleRotate);
            // bub.transform.eulerAngles = submarineRotate;
            // bub.transform.Rotate(submarine.transform.position + submarineRotate);
            // bub.transform.RotateAround(bub.transform.position, bub.transform.right,
            // 100 * Time.deltaTime);
            // bub.transform.SetPositionAndRotation(vectorToMove, Quaternion.identity);
        }
    }
}
using System;
using UnityEngine;

public class BubbleSpawner : MonoBehaviour
{
    [SerializeField] private GameObject bubble;
    [SerializeField] private int bubbleCount = 5;
    [SerializeField] private GameObject submarine;

    private GameObject[] bubbles = new GameObject[5];

    void Start()
    {
       
        for (var i = 0; i < bubbleCount; i++)
        {
            // Debug.Log(bubbleCount);
            var bub = Instantiate(bubble, transform);
            bub.name = $"Bubbles {i}";
            bubbles[i] = bub;
            bub.transform.SetPositionAndRotation(submarine.transform.position, Quaternion.identity);
        }
    }

    void Update()
    {
    }
}
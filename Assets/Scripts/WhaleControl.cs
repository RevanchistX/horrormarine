using System;
using UnityEngine;

public class WhaleControl : MonoBehaviour
{
    [SerializeField] private bool intro;
    [SerializeField] private bool gameplay;
    [SerializeField] private GameObject submarine;
    [SerializeField, Range(-100, 100)] private float x;
    [SerializeField, Range(-100, 100)] private float y;
    [SerializeField, Range(-100, 100)] private float z;

    private void Start()
    {
        if (intro) Intro();
        transform.position = new Vector3(x, y, z);
    }

    private void Update()
    {
        transform.position = new Vector3(x, y, z);
    }

    private void Intro()
    {
        transform.position = new Vector3(60, 25, 16);
        transform.rotation.Set(0, 40, 0, 0);
    }
}
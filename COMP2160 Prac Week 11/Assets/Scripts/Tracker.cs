using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tracker : MonoBehaviour
{
    [SerializeField] private Transform ball;
    private Transform balls;
    void Start()
    {
        balls = ball;
    }

    void Update()
    {
        transform.position = balls.position;
    }
}

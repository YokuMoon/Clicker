using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveMoney : MonoBehaviour
{
    public float translateSpeed = 2;
    private float rotationSpeed = 360f/10f;
    private int rotate = 0;
    private float x = 0f;
    private int y = 1;

    void Start()
    {
        rotate = Random.Range(0,2) == 0 ? -1 : 1;
        x = Random.Range(-0.7f, 0.7f);
    }

    void Update()
    {
        transform.Translate(new Vector3 (x, y, 0) * translateSpeed * Time.deltaTime, Space.World);
        if (y == 1) {
            transform.Rotate(new Vector3(0, 0, rotate), rotationSpeed * Time.deltaTime);
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("LevelIndicator")) {
            x = 0f;
            y = -1;
        }
    }
}

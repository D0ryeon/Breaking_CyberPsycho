using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    [SerializeField] [RangeAttribute (1f, 1000f)] float speed = 1f;
    public Rigidbody2D rd;
    float randomX, randomY;

    void Start()
    {
        rd = GetComponent<Rigidbody2D>();

        randomX = 0f;
        randomY = 1f;

        Vector2 dir = new Vector2(randomX, randomY).normalized;

        rd.AddForce (dir*speed);
    }
}

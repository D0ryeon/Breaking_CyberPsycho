using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.U2D;

public class BallController : MonoBehaviour
{
    [SerializeField][RangeAttribute(1f, 1000f)] float speed = 1f;
    [SerializeField][RangeAttribute(0.5f, 5f)] float size = 1f;
    bool starts = Input.GetMouseButton(0);
    public Rigidbody2D rd;

    float randomX, randomY;

    void Start()
    {
        rd = GetComponent<Rigidbody2D>();

        randomX = 0f;
        randomY = 1f;
        Starball();
    }

    void Update()
    {
        transform.localScale = new Vector3(size, size);
        if (starts) { Starball(); }
    }

    public void Starball()
    {
        Vector2 dir = new Vector2(randomX, randomY).normalized;

        rd.AddForce(dir * speed);
    }
}

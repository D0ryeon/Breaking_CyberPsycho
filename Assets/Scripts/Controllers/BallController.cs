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
    bool starts;
    public Rigidbody2D rd;
    public GameObject paddle;
    bool startgame =false;

    float randomX, randomY;

    void Start()
    {
        rd = GetComponent<Rigidbody2D>();

        randomX = 0f;
        randomY = 1f;
        
        //Starball();
    }

    void Update()
    {
        float pos = 0f;
        transform.localScale = new Vector3(size, size);
        if(startgame==false)
        {
            pos = (paddle.transform.localPosition.x * 1.5f);

            transform.localPosition =new Vector3( paddle.transform.localPosition.x+pos,0f,0f);
        }
    }

    public void Starball()
    {
        startgame= true;
        Vector2 dir = new Vector2(randomX, randomY).normalized;
        rd.AddForce(dir * speed);
    }
}

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
    public Rigidbody2D rd;
    public GameObject paddle;
    public GameObject startGame;
    bool starts = false;

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
        if(startGame.active)
        {
            starts = false;
            pos = (paddle.transform.localPosition.x * 1.5f);

            transform.localPosition =new Vector3( paddle.transform.localPosition.x+pos,0f,0f);
        }
        else
        {
            Starball();
        }
    }

    public void Starball()
    {
        if(!starts)
        {
            rd.velocity = Vector3.zero;
            starts = true;
            Vector2 vector2 = new Vector2(randomX, randomY);
            vector2 = vector2.normalized;
            rd.AddForce(vector2 * speed);
        }
    }
}

using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.U2D;

public class BallController : MonoBehaviour
{
    [SerializeField][RangeAttribute(1f, 3000f)] float speed = 10f;
    [SerializeField][RangeAttribute(0.5f, 5f)] float size = 1f;
    public Rigidbody2D rd;
    public GameObject paddle;
    public GameObject startGame;
    const float C_Radian = 180f;
    bool starts = false;
    private List<float> exclusionList = new List<float>() { 0f }; //제외할 값

    float randomX, randomY;
    Vector2 Allspeed;

    void Start()
    {
        rd = GetComponent<Rigidbody2D>();

        randomX = GenerateRandomNumber(-0.4f, 0.4f);
        randomY = 1f;

        //Starball();
    }

    void Update()
    {
        float pos = 0f;
        transform.localScale = new Vector3(size, size);
        if (startGame.active)
        {
            starts = false;
            pos = (paddle.transform.localPosition.x * 1.5f);

            transform.localPosition = new Vector3(paddle.transform.localPosition.x + pos, 0f, 0f);
        }
        else
        {
            Starball();
        }
    }

    public void Starball()
    {
        if (!starts)
        {
            //Time.timeScale = 1f;
            rd.velocity = Vector3.zero;
            starts = true;
            Vector2 vector2 = new Vector2(randomX, randomY);
            rd.velocity = vector2 * speed;
            Allspeed = rd.velocity;
            //vector2 = vector2.normalized;

            //rd.AddForce(vector2 * speed );
        }
        else
        {
            //rd.velocity= Allspeed;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("TopWall"))
        {
            Vector3 tmp = transform.eulerAngles;
            tmp.z = C_Radian - tmp.z;
            transform.eulerAngles = tmp;
        }
        else if (collision.collider.CompareTag("Wall"))
        {
            Vector3 tmp = transform.eulerAngles;
            tmp.z = (C_Radian * 2) - tmp.z;
            transform.eulerAngles = tmp;
        }
    }

    private float GenerateRandomNumber(float min, float max)
    {
        float randomValue = Random.Range(min, max);
        while (exclusionList.Contains(randomValue))
        {
            randomValue = Random.Range(min, max);
        }
        return randomValue;
    }
}

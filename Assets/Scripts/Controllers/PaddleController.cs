using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleController : MonoBehaviour
{
    public Rigidbody2D rb;
    private float horizontal;
    //private float vertical;
    public float speed = 100f;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxis("Horizontal");
        Vector2 move = new Vector2(horizontal, 0);
        Vector2 pos = rb.position;
        Vector2 movePos = pos + (move * speed * Time.deltaTime);
        rb.MovePosition(movePos);
    }

    public float[] arrAngles =
                 { -75, -60, -45, -30, -15, 0, 15, 30, 45, 60, 75 };
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Ball"))
        {
            int r = Random.Range(0, arrAngles.Length);
            Vector3 tmp = collision.transform.eulerAngles;
            tmp.z = arrAngles[r];
            collision.transform.eulerAngles = tmp;
        }
    }
}

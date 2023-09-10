using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleController : MonoBehaviour
{
    public Rigidbody2D rb;
    private float horizontal;
    //private float vertical;
    [SerializeField][RangeAttribute(50f, 1000f)] float speed = 100f;
    [SerializeField][RangeAttribute(0.5f, 10f)] float size = 3f;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        transform.localScale = new Vector3(3f, 0.3f);
    }

    // Update is called once per frame
    void Update()
    {
        transform.localScale = new Vector3(size, 0.3f);
        horizontal = Input.GetAxis("Horizontal");
        Vector2 move = new Vector2(horizontal, 0);
        Vector2 pos = rb.position;
        rb.velocity = pos + (move * speed * Time.deltaTime);
        rb.MovePosition(rb.velocity);
    }

    void FixedUpdate()
    {

    }
}
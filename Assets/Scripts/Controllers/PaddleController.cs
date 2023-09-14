using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using static UnityEditor.PlayerSettings;

public class PaddleController : MonoBehaviour
{

    public Rigidbody2D rb;
    private float horizontal;
    //private float vertical;
    //[SerializeField][RangeAttribute(50f, 1000f)] float speed = 100f;
    [SerializeField][RangeAttribute(0.5f, 10f)] float size = 3f;
    [SerializeField][RangeAttribute(1f, 10f)] public float life = 3f;
    public float[] arrAngles =
                 { -75, -60, -45, -30, -15, 0, 15, 30, 45, 60, 75 };
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        //transform.localScale = new Vector3(3f, 0.3f);
    }

    // Update is called once per frame
    void Update()
    {

        //transform.localScale = new Vector3(size, 0.3f);
        //키보드로 움직이기////
        //rb.velocity = Vector3.zero;
        //horizontal = Input.GetAxis("Horizontal");
        //Vector2 move = new Vector2(horizontal, 0);
        //Vector2 pos = rb.position;
        //rb.velocity = pos + (move * speed );
        //rb.MovePosition(rb.velocity);
        //rb.velocity = Vector3.zero;
        ////////////////////////////////
        Vector2 pos = Mouse.current.position.ReadValue();
        pos = Camera.main.ScreenToWorldPoint(pos);
        pos= new Vector2(Mathf.Clamp(pos.x, -7.5f, 7.5f), -4);
        transform.position = pos;
    }

    public void removeLife()
    {
        life--;
        Debug.Log(life);
    }

    void FixedUpdate()
    {

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Ball"))
        {
            int r = Random.Range(0, arrAngles.Length);
            Vector3 tmp = collision.transform.eulerAngles;
            tmp.z = arrAngles[r];
            collision.transform.eulerAngles = tmp;
            SoundManager.Instance.BallBounceSound();
        }
    }
}
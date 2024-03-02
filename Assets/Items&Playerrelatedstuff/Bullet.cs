using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    Rigidbody2D rb;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = transform.right *speed;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log(collision.collider.name);
        Destroy(gameObject);
    }
}

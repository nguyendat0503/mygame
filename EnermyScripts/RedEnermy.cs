using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedEnermy : MonoBehaviour
{
    public float speed;
    public float Rotate;
    Rigidbody2D rb;

    public float HP;
    [SerializeField]
    private GameObject Explosion;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        speed += PenguinControl.instance.score / 75;
        if (speed > 8)
        {
            speed = 8;
        }
    }
    void FixedUpdate()
    {
        if (HP < 1)
        {
            Vector3 temp = transform.position;
            Instantiate(Explosion, temp, Quaternion.identity);
            Destroy(gameObject);
        }
        transform.Rotate(0, 0, Rotate*Time.deltaTime);
        rb.velocity = new Vector3(-speed, rb.velocity.y, 0);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Left")
        {
            Destroy(gameObject);
        }
        if (collision.tag == "BlueBullet")
        {
            HP -= PenguinControl.instance.power;
        }
        if (collision.tag == "Explosion")
        {
            HP -= 5;
        }
        if (collision.tag == "Missile")
        {
            HP -= 3;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Penguin")
        {
            Vector3 temp = transform.position;
            Instantiate(Explosion, temp, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}

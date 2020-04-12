using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class  GoldenEnermy : MonoBehaviour
{
    public float speed;
    public float Rotate;
    Rigidbody2D rb;
    private PolygonCollider2D Poli2D;

    public float HP;
    [SerializeField]
    private GameObject Explosion,Coin,BigCoin;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        speed += PenguinControl.instance.score / 100;
        if (speed > 6)
        {
            speed = 6;
        }
        Poli2D = GetComponent<PolygonCollider2D>();
    }
    void FixedUpdate()
    {
        if (HP < 1)
        {
            Vector3 temp = transform.position;
            Instantiate(Explosion, temp, Quaternion.identity);
            Instantiate(BigCoin, temp, Quaternion.identity);
            Destroy(gameObject);
        }
        transform.Rotate(0, 0, Rotate * Time.deltaTime);
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
            Vector3 temp = transform.position;
            Instantiate(Coin, temp, Quaternion.identity);
        }
        if (collision.tag == "Explosion")
        {
            HP -= 5;
            Vector3 temp = transform.position;
            Instantiate(BigCoin, temp, Quaternion.identity);
        }
        if (collision.tag == "Missile")
        {
            HP -= 4;
            Vector3 temp = transform.position;
            Instantiate(BigCoin, temp, Quaternion.identity);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "BubbleBullet"|| collision.gameObject.tag == "Penguin")
        {
            Vector3 temp = transform.position;
            Instantiate(BigCoin, temp, Quaternion.identity);
            speed = 0;
            rb.gravityScale = -0.5f;
            Poli2D.isTrigger = true;
            Rotate = Random.Range(100, 250);
            Destroy(gameObject, 5);
        }
        if (collision.gameObject.tag == "Penguin")
        {
            HP -= 10;
        }
    }
}

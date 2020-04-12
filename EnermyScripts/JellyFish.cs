using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JellyFish : MonoBehaviour
{
    public float Maxspeed;
    public float MinSpeed;
    public float HP;
    private float Rotate;
    private bool alive = true;
    private int spaw = 0;
    float speed;

    private Animator anim;
    private Rigidbody2D myBody;
    private PolygonCollider2D Poli2D;

    [SerializeField]
    private GameObject GetRedBullet, GetBubbleBullet,GetMissile, Coin,PowerUp,Heart;
    private void Awake()
    {
        HP += PenguinControl.instance.score / 100;
        Maxspeed += PenguinControl.instance.score / 100;
        if (Maxspeed > 6)
        {
            Maxspeed = 6;
        }
        speed = Random.Range(-Maxspeed, -MinSpeed);
        myBody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        Poli2D = GetComponent<PolygonCollider2D>();
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        transform.Rotate(0, 0, Rotate * Time.deltaTime);
        if (alive == true)
        {
            myBody.velocity = new Vector2(speed, myBody.velocity.y);
        }
        else
        {
            Move();
        }
        if (HP < 1)
        {
            anim.SetTrigger("Die");
            spaw += 1;
            myBody.gravityScale = 1;
            speed = 2;
        }
        if (spaw == 1)
        {
            int x = Random.Range(1, 25);
            if (x == 3)
            {
                Vector3 temp = transform.position;
                Instantiate(GetRedBullet, temp, Quaternion.identity);
            }
            if (x == 5)
            {
                Vector3 temp = transform.position;
                Instantiate(GetBubbleBullet, temp, Quaternion.identity);
            }
            if (x == 7)
            {
                Vector3 temp = transform.position;
                Instantiate(GetMissile, temp, Quaternion.identity);
            }
            if (x == 9)
            {
                Vector3 temp = transform.position;
                Instantiate(PowerUp, temp, Quaternion.identity);
            }
            if (x == 11)
            {
                Vector3 temp = transform.position;
                Instantiate(Heart, temp, Quaternion.identity);
            }
            if (12 < x)
            {
                Vector3 temp = transform.position;
                Instantiate(Coin, temp, Quaternion.identity);
            }
        }
    }
    void Move()
    {
        Vector3 temp = transform.position;
        temp.x -= speed * Time.deltaTime;
        transform.position = temp;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Left")
        {
            Destroy(gameObject);
        }
        if (collision.tag == "BlueBullet")
        {
            HP -= PenguinControl.instance.power*0.5f;
        }
        if (collision.tag == "Explosion")
        {
            HP -= 8;
            speed -=speed/2 ;
            Rotate = Random.Range(100, 200);
        }
        if (collision.tag == "Missile")
        {
            HP -= 2;
            if (HP < 1)
            {
                Destroy(gameObject);
            }
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Rock" || collision.gameObject.tag == "Bottom")
        {
            anim.SetTrigger("Die");
            myBody.gravityScale = 1;
            speed = 2;
            alive = false;
            Rotate = 0;
            Destroy(gameObject, 2);
        }
        if (collision.gameObject.tag == "Penguin")
        {
            Poli2D.isTrigger = true;
            anim.SetTrigger("Die");
            myBody.gravityScale = 1;
            speed = -speed / 3;
            Destroy(gameObject, 2);
        }
        if (collision.gameObject.tag == "BubbleBullet")
        {
            myBody.gravityScale = -1;
            speed = 0;
            Poli2D.isTrigger = true;
            Rotate = Random.Range(75, 200);
            Destroy(gameObject, 5);
        }
    }
}

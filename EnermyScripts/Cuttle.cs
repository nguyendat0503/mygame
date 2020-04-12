using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cuttle : MonoBehaviour
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
    [SerializeField]
    private AudioSource audioSource;
    [SerializeField]
    private AudioClip Hit;
    private void Awake()
    {
        HP += PenguinControl.instance.score / 200;
        Maxspeed += PenguinControl.instance.score/50;
        if (Maxspeed > 10)
        {
            Maxspeed = 10;
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
            int x = Random.Range(1, 100);
            if (x == 10)
            {
                Vector3 temp = transform.position;
                Instantiate(GetRedBullet, temp, Quaternion.identity);
            }
            if (x == 15)
            {
                Vector3 temp = transform.position;
                Instantiate(GetBubbleBullet, temp, Quaternion.identity);
            }
            if (x == 20)
            {
                Vector3 temp = transform.position;
                Instantiate(GetMissile, temp, Quaternion.identity);
            }
            if (x == 25)
            {
                Vector3 temp = transform.position;
                Instantiate(PowerUp, temp, Quaternion.identity);
            }
            if (x == 30)
            {
                Vector3 temp = transform.position;
                Instantiate(Heart, temp, Quaternion.identity);
            }
            if (50 < x)
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
            HP -= PenguinControl.instance.power;
        }
        if (collision.tag == "Explosion")
        {
            HP -= 4;
            speed = Random.Range(1, 3);
            Rotate = Random.Range(300, 900);
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
        if(collision.gameObject.tag == "Penguin")
        {
            Poli2D.isTrigger = true;
            anim.SetTrigger("Die");
            myBody.gravityScale = 1;
            speed = Random.Range(2,3);
            Rotate = Random.Range(200, 500);
            Destroy(gameObject, 2);
        }
        if (collision.gameObject.tag == "JellyFish")
        {
            anim.SetTrigger("Die");
            myBody.gravityScale = 1;
            speed = Random.Range(2, 3);
            Rotate = Random.Range(200, 500);
            audioSource.PlayOneShot(Hit);
        }
        if (collision.gameObject.tag == "BubbleBullet")
        {
            myBody.gravityScale = -1;
            speed = 0;
            Poli2D.isTrigger = true;
            Rotate = Random.Range(200, 400);
            Destroy(gameObject, 5);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleBullet : MonoBehaviour
{
    public float speed;
    private Rigidbody2D myBody;

    private void Awake()
    {
        myBody = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        myBody.velocity = new Vector2(speed, myBody.velocity.y);
        transform.localScale = transform.localScale + new Vector3(0.1f * Time.deltaTime, 0.1f * Time.deltaTime, 0);
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Right")
        {
            Destroy(gameObject);
        }
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Top")
        {
            Destroy(gameObject,10);
        }
        if (collision.gameObject.tag == "BubbleBullet" || collision.gameObject.tag == "Cuttle" || collision.gameObject.tag == "JellyFish" || collision.gameObject.tag == "Star" || collision.gameObject.tag == "Rock")
        {
            Destroy(gameObject, 10);
        }
    }
}

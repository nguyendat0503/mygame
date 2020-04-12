using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetBullet : MonoBehaviour
{
    public float speed;

    void Update()
    {
        Move();
    }
    void Move()
    {
        Vector3 temp = transform.position;
        temp.x -= speed * Time.deltaTime;
        transform.position = temp;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Left"|| collision.tag == "Penguin")
        {
            Destroy(gameObject);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueBullet : MonoBehaviour
{
    public float speed;
    private Rigidbody2D myBody;
    [SerializeField]
    private GameObject Explosion;

    private void Awake()
    {
        myBody = GetComponent<Rigidbody2D>();
        myBody.velocity = new Vector2(speed, myBody.velocity.y);
    }
    IEnumerator Exp()
    {
        Vector3 temp = transform.position;
        Instantiate(Explosion, temp, Quaternion.identity);
        yield return new WaitForSeconds(0);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Cuttle" || collision.tag == "JellyFish" || collision.tag == "Star" || collision.tag == "Rock" || collision.tag == "RedEnermy")
        {
            StartCoroutine(Exp());
            Destroy(gameObject);
        }
        if (collision.tag == "Right" || collision.tag == "Bottom")
        {
            Destroy(gameObject);
        }
    }
}

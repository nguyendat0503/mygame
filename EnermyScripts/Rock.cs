using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rock : MonoBehaviour
{
    public float speed;
    public float min;
    public float max;
    public float y;
   
    // Start is called before the first frame update
    void Start()
    {
        float x = Random.Range(min, max);
        transform.localScale = new Vector3(x, x, 0);
        transform.position = transform.position - new Vector3(0,y*(2-2*x), 0);
    }

    // Update is called once per frame
    void Update()
    {
        RockMove();
    }
    void RockMove()
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
    }
}

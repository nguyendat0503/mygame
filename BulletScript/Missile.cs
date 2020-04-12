using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Missile : MonoBehaviour
{


	public float speed = 5;
	public float rotatingSpeed = 200;
	private GameObject target;

	Rigidbody2D rb;

	[SerializeField]
	private GameObject Explosion;
    void Awake()
	{
		speed += PenguinControl.instance.score / 50;
		if (speed > 11)
		{
			speed = 11;
		}
	}
	// Use this for initialization
	void Start()
	{
		rb = GetComponent<Rigidbody2D>();
	}

	// Update is called once per frame
	void FixedUpdate()
	{
		if (target == null)
		{
			rb.velocity = new Vector2(speed, rb.velocity.y);
		}
		if (target == null)
		{
			target = GameObject.FindGameObjectWithTag("RedEnermy");
		}
		if (target == null)
		{
			target = GameObject.FindGameObjectWithTag("Cuttle");
		}
		if (target == null)
		{
			target = GameObject.FindGameObjectWithTag("Star");
		}
		if (target == null)
		{
			target = GameObject.FindGameObjectWithTag("JellyFish");
		}
		Vector2 point2Target = (Vector2)transform.position - (Vector2)target.transform.position;

		point2Target.Normalize();

		float value = Vector3.Cross(point2Target, transform.right).z;

		rb.angularVelocity = rotatingSpeed * value;

		rb.velocity = transform.right * speed;
	}
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Cuttle" || collision.tag == "JellyFish" || collision.tag == "Star" || collision.tag == "Rock"|| collision.tag == "Bottom" || collision.tag == "RedEnermy")
        {
			Vector3 temp = transform.position;
			Instantiate(Explosion, temp, Quaternion.identity);
			Destroy(gameObject);
        }
    }
}

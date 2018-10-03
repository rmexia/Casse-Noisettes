using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallRebound : MonoBehaviour {
	
	public Rigidbody rb;
	public float speed;
	public Vector3 previousVelocity;
	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnCollisionEnter(Collision collision) 
	{
		Debug.Log ("Collision with " + collision.gameObject.tag);
		if (collision.gameObject.tag == "Player")
		{
			Debug.Log ("Oui");
			ManageCollisionWithPlayer (collision);
			previousVelocity = new Vector3 (rb.velocity.x, rb.velocity.y, rb.velocity.z);
		}
		else if (collision.gameObject.tag == "VerticalCollider") 
		{
			rb.velocity = new Vector3 (-previousVelocity.x, previousVelocity.y, previousVelocity.z);
			previousVelocity = new Vector3 (rb.velocity.x, rb.velocity.y, rb.velocity.z);
			Brick brick = collision.gameObject.GetComponentInParent<Brick> ();
			if (brick) 
			{
				brick.TakeDamage ();
			}
		}
		else if (collision.gameObject.tag == "HorizontalCollider") 
		{
			rb.velocity = new Vector3 (previousVelocity.x, -previousVelocity.y, previousVelocity.z);
			previousVelocity = new Vector3 (rb.velocity.x, rb.velocity.y, rb.velocity.z);
			Debug.Log (previousVelocity);
			Brick brick = collision.gameObject.GetComponentInParent<Brick> ();
			if (brick) 
			{
				brick.TakeDamage ();
			}
		}
	}

	void ManageCollisionWithPlayer(Collision collision)
	{
		
		float relativeX = this.transform.position.x - collision.gameObject.transform.position.x;
		float scaledRelativeX = relativeX / (collision.gameObject.transform.lossyScale.x / 2);
		if (scaledRelativeX < -0.9f) 
		{
			scaledRelativeX = -0.9f;
		} 
		else if (scaledRelativeX > 0.9f) 
		{
			scaledRelativeX = 0.9f;
		}
		rb.velocity = new Vector3 (scaledRelativeX * speed, (1 - Mathf.Abs(scaledRelativeX)) * speed, rb.velocity.z * speed);
		Debug.Log (scaledRelativeX);
	}
}

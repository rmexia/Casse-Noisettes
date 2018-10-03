using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallRebound : MonoBehaviour {
	
	public Rigidbody rb;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody>();
		rb.velocity = new Vector3 (0.45f, - 0.45f, 0);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnCollisionEnter(Collision collision) 
	{
		if (collision.gameObject.tag == "Player")
		{
			ManageCollisionWithPlayer (collision);
		}
		else if (collision.gameObject.tag == "VerticalCollider") 
		{
			rb.velocity = new Vector3 (-rb.velocity.x, rb.velocity.y, rb.velocity.z);
		}
		else if (collision.gameObject.tag == "HorizontalCollider") 
		{
			rb.velocity = new Vector3 (rb.velocity.x, -rb.velocity.y, rb.velocity.z);
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
		rb.velocity = new Vector3 (scaledRelativeX, 1 - Mathf.Abs(scaledRelativeX), rb.velocity.z);
		Debug.Log ("velocity " + rb.velocity);
	}
}

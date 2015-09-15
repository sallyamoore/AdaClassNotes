using UnityEngine;
using System.Collections;
using System;

public class Ball : PhysicalObject 
{
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		//Handle Edge collision to avoid physics bugs for slow or fast moving objects.
		EdgeCollider2D edge = GameObject.Find("SceneController").GetComponent<EdgeCollider2D>();

		if(this.Left <= edge.bounds.min.x)
		{
			this.GetComponent<Rigidbody2D>().velocity = new Vector2(Math.Abs(this.GetComponent<Rigidbody2D>().velocity.x), this.GetComponent<Rigidbody2D>().velocity.y);
		}
		else if(this.Right >= edge.bounds.max.x)
		{
			this.GetComponent<Rigidbody2D>().velocity = new Vector2(-Math.Abs(this.GetComponent<Rigidbody2D>().velocity.x), this.GetComponent<Rigidbody2D>().velocity.y);
		}

		if(this.Bottom <= edge.bounds.min.y)
		{
			Destroy(this.gameObject);
        }
		else if(this.Top >= edge.bounds.max.y)
		{
			this.GetComponent<Rigidbody2D>().velocity = new Vector2(this.GetComponent<Rigidbody2D>().velocity.x, -Math.Abs (this.GetComponent<Rigidbody2D>().velocity.y));
        }

		this.PreviousVelocity = this.Velocity;
	}
}

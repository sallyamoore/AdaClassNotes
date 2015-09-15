using UnityEngine;
using System.Collections;
using System.Linq;

public class SimpleBrick : PhysicalObject 
{
	/// <summary>
	/// Handles the collision for this brick instance.
	/// </summary>
	/// <param name="collider">The colliding object.</param>
	void OnCollisionEnter2D(Collision2D collider)
	{
		// Only react if the colliding object is a ball.
		if(collider.gameObject.tag == "Ball")
		{
			Destroy(this.gameObject); //Destroys itself.
        }
	}
}

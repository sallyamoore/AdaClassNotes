using UnityEngine;
using System.Collections;
using System.Linq;

public class Brick : PhysicalObject 
{	
    // Use this for initialization
    void Start () {
        
    }
    
    // Update is called once per frame
	void Update () {
		
	}

	/// <summary>
	/// Handles the collision for this brick instance.
	/// </summary>
	/// <param name="collider">The colliding object.</param>
	void OnCollisionEnter2D(Collision2D collider)
	{
		// Only react if the colliding object is a ball.
		if(collider.gameObject.tag == "Ball")
		{
			var physicalCollider = collider.gameObject.GetComponent<PhysicalObject>();
			var contact = collider.contacts.First();
			var side = PhysicsHelpers.SideOfCollision(contact.point, this.gameObject);
			if(side == PhysicsHelpers.Side.Top || side == PhysicsHelpers.Side.Bottom)
			{
				//Negate Y
				physicalCollider.Velocity = new Vector2(physicalCollider.PreviousVelocity.x, -physicalCollider.PreviousVelocity.y); 
            }
            else if(side == PhysicsHelpers.Side.Left || side == PhysicsHelpers.Side.Right)
			{
				//Negate X
				physicalCollider.Velocity = new Vector2(-physicalCollider.PreviousVelocity.x, physicalCollider.PreviousVelocity.y); 
            }

			Destroy(this.gameObject); //Destroys itself.
        }
	}
}

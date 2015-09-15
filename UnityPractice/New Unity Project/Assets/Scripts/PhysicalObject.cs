using UnityEngine;
using System.Collections;
using System;

public class PhysicalObject : MonoBehaviour 
{
    /// <summary>
    /// Gets the left of the object.
    /// </summary>
    /// <value>The left.</value>
    public float Left 
    {
        get 
        {
            return this.GetComponent<Collider2D>().bounds.min.x;
        }
    }
    
	/// <summary>
	/// Gets the right of the object.
	/// </summary>
	/// <value>The right.</value>
    public float Right 
    {
        get 
        {
            return this.GetComponent<Collider2D>().bounds.max.x;
        }
    }
    
	/// <summary>
	/// Gets the center of the object.
	/// </summary>
	/// <value>The center.</value>
    public Vector3 Center 
    {
        get 
        {
            return this.GetComponent<Collider2D>().bounds.center;
        }
    }
    
	/// <summary>
	/// Gets the bottom of the object.
	/// </summary>
	/// <value>The bottom.</value>
    public float Bottom 
    {
        get 
        {
            return this.GetComponent<Collider2D>().bounds.min.y;
        }
    }
    
	/// <summary>
	/// Gets the top of the object.
	/// </summary>
	/// <value>The top.</value>
    public float Top 
    {
        get 
        {
            return this.GetComponent<Collider2D>().bounds.max.y;
        }
    }
    
	/// <summary>
	/// Gets the width of the object.
	/// </summary>
	/// <value>The width.</value>
    public float Width 
    {
        get 
        {
            return this.GetComponent<Collider2D>().bounds.size.x;
        }
    }
    
	/// <summary>
	/// Gets the height of the object.
	/// </summary>
	/// <value>The height.</value>
    public float Height 
    {
        get 
        {
            return this.GetComponent<Collider2D>().bounds.size.y;
        }
    }

	/// <summary>
	/// Gets or sets the position of the object.
	/// </summary>
	/// <value>The position.</value>
	public Vector2 Position
	{
		get
		{
			return this.transform.position;
		}
		set
		{
			this.transform.position = value;
		}
	}

	/// <summary>
	/// Gets or sets the velocity of the object.
	/// </summary>
	/// <value>The velocity.</value>
	public Vector2 Velocity
	{
		get
		{
			return this.GetComponent<Rigidbody2D>().velocity;
		}
		set
		{
			this.GetComponent<Rigidbody2D>().velocity = value;
		}
	}

	/// <summary>
	/// Gets or sets the previous velocity of the object.
	/// </summary>
	/// <value>The previous velocity.</value>
	public Vector2 PreviousVelocity
	{
		get;
		set;
	}
}

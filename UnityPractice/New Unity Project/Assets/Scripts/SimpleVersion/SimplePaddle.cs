using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class SimplePaddle : PhysicalObject
{	
	// Update is called once per frame
	void Update()
	{
		if (this.IsMouseMoving()) 
		{
			//Handle controls different for mouse.
			Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

			//Lock x to collider
			EdgeCollider2D edge = GameObject.Find("SceneController").GetComponent<EdgeCollider2D>();
			mousePosition.x = Mathf.Max(mousePosition.x, edge.bounds.min.x + (this.Center.x - this.Left));
			mousePosition.x = Mathf.Min(mousePosition.x, edge.bounds.max.x - (this.Right - this.Center.x));

			this.transform.position = new Vector3(mousePosition.x, 
			                                      this.transform.position.y, 
			                                      this.transform.position.z);
		}
	}

	/// <summary>
	/// Determines whether the mouse is moving.
	/// </summary>
	/// <returns><c>true</c> if the mouse is moving; otherwise, <c>false</c>.</returns>
	private bool IsMouseMoving()
	{
		return (Input.GetAxis("Mouse X") != 0.0f || Input.GetAxis("Mouse Y") != 0.0f);
	}
}
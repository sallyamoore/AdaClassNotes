using UnityEngine;
using System.Collections;
using System;

public class SimpleBall : PhysicalObject 
{	
	// Update is called once per frame
	void Update () 
	{
		//Handle Edge collision to avoid physics bugs for slow or fast moving objects.
		EdgeCollider2D edge = GameObject.Find("SceneController").GetComponent<EdgeCollider2D>();

		if(this.Bottom <= edge.bounds.min.y)
		{
			Destroy(this.gameObject);
        }
	}
}

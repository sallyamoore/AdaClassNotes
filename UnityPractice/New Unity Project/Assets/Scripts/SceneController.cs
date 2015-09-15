using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class SceneController : MonoBehaviour 
{
	public GameObject Brick;
	public GameObject Ball;
	public Text Message;
	
	// Use this for initialization
	void Start () 
	{
		CreateEdgeBoundary();

		//Create level
		LoadLevel(@"Levels/Smile");

		CreateBall();
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(GameObject.FindGameObjectsWithTag("Brick").Length == 0)
		{
			this.Message.text = "You Win!";
			this.Message.gameObject.SetActive(true);
			Invoke("GotoMenu", 3);
		}

		if(GameObject.FindGameObjectsWithTag("Ball").Length == 0)
		{
			this.Message.text = "You Lose!";
			this.Message.gameObject.SetActive(true);
			Invoke("GotoMenu", 3);
		}
	}

	/// <summary>
	/// Creates the edge collider boundary from the camera view.
	/// </summary>
	private void CreateEdgeBoundary()
	{
		List<Vector2> newVertices = new List<Vector2>();
		EdgeCollider2D edgeCollider = this.GetComponent<EdgeCollider2D>();
		
		//Get the boundaries of the camera
		float camDistance = Vector3.Distance(this.transform.position, Camera.main.transform.position);
		Vector2 bottomLeft = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, camDistance));
		Vector2 topRight = Camera.main.ViewportToWorldPoint(new Vector3(1, 1, camDistance));
		Globals.WorldBottonLeft = bottomLeft;
		Globals.WorldTopRight = topRight;
		
		//Set these to the new vertices for the Edge Collider
		newVertices.Add (new Vector2(bottomLeft.x, bottomLeft.y)); // Sets the start point
		newVertices.Add (new Vector2(bottomLeft.x, topRight.y)); // Creates the Top Side
		newVertices.Add (new Vector2(topRight.x, topRight.y)); // Creates the Right Side
		newVertices.Add (new Vector2(topRight.x, bottomLeft.y)); // Creates the Bottom Side
		newVertices.Add (new Vector2(bottomLeft.x, bottomLeft.y)); //Creates the Left Side
		
		//Update the edge collider
		edgeCollider.points = newVertices.ToArray();
	}

	/// <summary>
	/// Creates a new ball.
	/// </summary>
	private void CreateBall()
	{		
		//Access it's Ball Prefab and instantiate a new ball
		GameObject ball = Instantiate(this.Ball) as GameObject;
		ball.transform.position = new Vector3 (0.0f, -3.21f, 0.0f); //Hard-coded start position. (ICKY!!!)
		ball.GetComponent<Rigidbody2D>().velocity = new Vector2(-2.0f, 2.0f);
		ball.GetComponent<PhysicalObject>().PreviousVelocity = ball.GetComponent<Rigidbody2D>().velocity;
	}

	/// <summary>
	/// Creates the brick layout from a file.
	/// </summary>
	/// <param name="filename">The level filename.</param>
	public void LoadLevel (string filename)
	{
		TextAsset level = Resources.Load<TextAsset>(filename);
		using (TextReader reader = new StreamReader(new MemoryStream(level.bytes)))
		{
			int y = 0;
			string row = reader.ReadLine();
			while (row != null) 
			{
				for (int x = 0; x < row.Length; ++x) 
				{
					//Read the file and place bricks accordingly use the brick mapping in Globals.
					if (row[x] != ' ') 
					{
						//Map it.
						string file;
						if (Globals.BrickMapping.TryGetValue(row[x], out file)) 
						{
							//Creates a new brick prefab instance and adjusts the location based on the world boundaries
							GameObject brick = (GameObject)Instantiate(this.Brick, new Vector3(Globals.WorldBottonLeft.x + x * this.Brick.GetComponent<Renderer>().bounds.size.x, 
							                                                                     Globals.WorldTopRight.y - y * this.Brick.GetComponent<Renderer>().bounds.size.y), Quaternion.identity);
							SpriteRenderer renderer = brick.GetComponent<SpriteRenderer>();

							//Set the image to render on the sprite.
							Sprite brickSprite = Resources.Load<Sprite>(Path.Combine(@"Images/Sprites/Bricks", file));
							renderer.sprite = brickSprite;
						}
					}
				}
				
				row = reader.ReadLine ();
				++y;
			}
		}
	}

	private void GotoMenu()
	{
		Application.LoadLevel("Menu");
	}
}


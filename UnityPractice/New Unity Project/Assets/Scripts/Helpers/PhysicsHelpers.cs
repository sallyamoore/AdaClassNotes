using UnityEngine;
using System.Collections;
using System;

/// <summary>
/// Some helper functions for handling Physics on our own.
/// </summary>
public static class PhysicsHelpers
{	
	/// <summary>
	/// Used for determining a point in a line ignoring some precision
	/// </summary>
	const float EPSILON = 0.05f;
	
	/// <summary>
	/// Determines if a point exists within a line segment.
	/// </summary>
	/// <param name="p0">The first point on the line</param>
	/// <param name="p1">The second point on the line</param>
	/// <param name="point">The point we are checking is on the line.</param>
	/// <returns>True if the point exists on the line.</returns>
	private static bool IsPointOnLine(Vector2 p0, Vector2 p1, Vector2 point)
	{
		if(p0.x - EPSILON <= point.x && point.x <= p1.x + EPSILON &&
		   p0.y - EPSILON <= point.y && point.y <= p1.y + EPSILON)
		{
			return true;
		}
		
		return false;
	}

	/// <summary>
	/// Gets the side at which a collision occured
	/// </summary>
	/// <returns>The side of the collision.</returns>
	/// <param name="intersection">Intersection.</param>
	/// <param name="gameObject">Game object.</param>
	public static Side SideOfCollision(Vector2 intersection, GameObject gameObject)
	{
		var physicalObject = gameObject.GetComponent<PhysicalObject>();
		Vector2 p0, p1;

		//Check Top
		p0 = new Vector2(physicalObject.Left, physicalObject.Top);
		p1 = new Vector2(physicalObject.Right, physicalObject.Top);
		
		if(IsPointOnLine(p0, p1, intersection))
		{
			return Side.Top;
		}

		//Check Bottom
		p0 = new Vector2(physicalObject.Left, physicalObject.Bottom);
		p1 = new Vector2(physicalObject.Right, physicalObject.Bottom);
		
		if(IsPointOnLine(p0, p1, intersection))
		{
			return Side.Bottom;
		}

		//Check Left
		p0 = new Vector2(physicalObject.Left, physicalObject.Bottom);
		p1 = new Vector2(physicalObject.Left, physicalObject.Top);

		if(IsPointOnLine(p0, p1, intersection))
		{
			return Side.Left;
		}

		//Check Right
		p0 = new Vector2(physicalObject.Right, physicalObject.Bottom);
		p1 = new Vector2(physicalObject.Right, physicalObject.Top);
		
		if(IsPointOnLine(p0, p1, intersection))
		{
			return Side.Right;
		}

		return Side.None;
	}

	/// <summary>
	/// Enumeration of the sides of an object.
	/// </summary>
	public enum Side
	{
		None,
		Left,
		Top,
		Right,
		Bottom
	}
}

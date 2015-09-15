using System;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Globals used by the project. 
/// Static ensures they remain throughout the life of the game.
/// </summary>
public static class Globals
{
	/// <summary>
	/// The brick mapping of symbol to file name.
	/// </summary>
	public static Dictionary<char, string> BrickMapping = new Dictionary<char, string> 
	{
		{'B', "blue_brick"},
		{'R', "red_brick"},
		{'G', "green_brick"},
		{'Y', "yellow_brick"},
		{'P', "purple_brick"},
		{'W', "white_brick"}
	};

	/// <summary>
	/// The world top right.
	/// </summary>
	public static Vector2 WorldTopRight;

	/// <summary>
	/// The world botton left.
	/// </summary>
	public static Vector2 WorldBottonLeft;

	/// <summary>
	/// The speed modifier.
	/// </summary>
	public const float SpeedModifier = 4.0f;
}

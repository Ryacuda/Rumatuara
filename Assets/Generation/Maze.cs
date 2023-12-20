using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Maze
{
	public List<Room> rooms;

	public Maze(Vector2Int maze_dimensions)
	{
		rooms = new List<Room>(maze_dimensions.x * maze_dimensions.y);

		// create rooms
		for(int x = 0;  x < maze_dimensions.x; x++)
		{
			for(int y = 0; y < maze_dimensions.y; y++)
			{
				rooms.Add(new Room(new Vector2Int(x, y)));
			}
		}

		// define adjacency
		foreach(Room r1 in rooms)
		{
			foreach(Room r2 in rooms)
			{
				if(Vector2Int.Distance(r1.position, r2.position) == 1)
				{
					r1.AddAdjacentRoom(r2);
					r2.AddAdjacentRoom(r1);
				}
			}
		}
	}

	public Room FindRoomAt(Vector2Int location)
	{
		foreach(Room r in rooms)
		{
			if (r.position == location)
			{
				return r;
			}
		}

		return null;
	}

	// Find the first room not in the maze, but with an adjacent room in the maze
	public Room FindFirstCandidate()
	{
		foreach (Room r1 in rooms)
		{
			if (!r1.in_maze)
			{
				return r1;
			}
		}

		return null;
	}
}

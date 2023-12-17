using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class MazeGenerator
{
	private MazeGenerator()
	{
	}

	// Generate a maze using Wilson's algorithm
	public static Maze WilsonMaze(Vector2Int size, Vector2Int initial_room)
	{
		Maze m = new Maze(size);

		// initialize the starting room
		Room r = m.FindRoomAt(initial_room);
		if(r != null)
		{
			r.in_maze = true;
		}
		else
		{
			Debug.Log("Starting room not in the maze layout...");
		}

		Room RW_start = m.FindFirstCandidate();
		while( RW_start != null )
		{
			// loop erased random walk
			LoopErasedRandomWalk( RW_start );

			RW_start = m.FindFirstCandidate();
		}

		return m;
	}

	private static void LoopErasedRandomWalk(Room start)
	{
		List<Room> walk = new List<Room> { start };

		// add rooms until we connect back to the maze
		while(!walk.Last().in_maze) 
		{
			// get random adjacent room
			Room next_room = walk.Last().connected_rooms.ElementAt(Random.Range(0, walk.Last().connected_rooms.Count)).Key;

			walk.Add(next_room);
		}

		List<Room> loop_erased_walk = new List<Room>();

		// erase loops
		for(int i = 0; i < walk.Count; i++)
		{
			loop_erased_walk.Add(walk[i]);

			int j = walk.FindLastIndex(other => other == walk[i]);

			if( i != j )
			{   // erase the rooms between the indices
				i = j;
			}
		}

		Debug.Log("Random walk length : " +walk.Count);
		Debug.Log("Loop erased random walk length : " + loop_erased_walk.Count);

		// connect the rooms
		for(int i = 0; i < loop_erased_walk.Count -1; i++)
		{
			loop_erased_walk[i].in_maze = true;

			loop_erased_walk[i].ConnectTo(loop_erased_walk[i + 1]);
			loop_erased_walk[i + 1].ConnectTo(loop_erased_walk[i]);
		}
	}

}

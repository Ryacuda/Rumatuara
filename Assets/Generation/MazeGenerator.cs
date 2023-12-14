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
	public static List<Room> WilsonMaze(Vector2Int size, Vector2Int initial_room)
	{
		List<Room> room_list = new List<Room>();

        if (initial_room.x > size.x || initial_room.x < 0
		   || initial_room.y > size.y || initial_room.y < 0)
		{   // initial room is outside of the maze :(
			return room_list;
		}

		room_list.Add(new Room(initial_room));

		
		// select new starting point
		Room start_room = GetNewStart(ref room_list, ref size);
		
		Debug.Log("1.");
        
		List<Vector2Int> random_walk = RandomWalk(ref room_list, ref size, ref start_room);
        /*
        Debug.Log("2.");

        EraseLoops(random_walk);

        Debug.Log("3.");

        foreach (Vector2Int p in random_walk)
		{
			room_list.Add(new Room(p));
		}
		*/
        return room_list;
	}

    private static Room GetNewStart(ref List<Room> room_list, ref Vector2Int size)
	{
        for (int x = 0; x < size.x; x++)
        {
            for (int y = 0; y < size.y; y++)
            {
				Vector2Int p = new Vector2Int(x, y);

                foreach (Room r in room_list)
                {
                    if (Vector2Int.Distance(p, r.position) == 1)
                    {   // found the starting room !
						Room start = new Room(p);

						start.connected_rooms.Add(r);
						r.connected_rooms.Add(start);
						
						return start;
                    }
                }
            }
        }

		return new Room(new Vector2Int(0,0));
    }

	private static List<Vector2Int> RandomWalk(ref List<Room> room_list, ref Vector2Int size, ref Room start)
	{
		List<Vector2Int> room_walk = new List<Vector2Int>();
		room_walk.Add(start.position);

		Vector2Int pos = start.position;
		bool stop_loop = false;
		while(!stop_loop)
		{
            room_walk.Add(pos);

            // walk to next pos
            Vector2Int next_pos = pos + GetNewMove(ref size);
			while(next_pos.x > size.x || next_pos.x < 0
				|| next_pos.y > size.y || next_pos.y < 0)
			{
				next_pos = pos + GetNewMove(ref size);
			}

			pos = next_pos;

			Debug.Log(pos);
            Debug.Log(next_pos);

            stop_loop = true;

			/*

            // check if the last element is next to the maze
			foreach(Room r in room_list)
			{
				Debug.Log(Vector2Int.Distance(next_pos, r.position));
				if(Vector2Int.Distance(next_pos, r.position) == 1)
				{
					stop_loop = true;
					break;
				}
			}*/
        }

		return room_walk;
    }

	private static void EraseLoops(List<Vector2Int> random_walk)
	{
		for(int i = 0; i < random_walk.Count; i++)
		{
			int last_i = random_walk.FindLastIndex(i+1, random_walk.Count - (i+1) ,p => p.Equals(random_walk[i]));

			if(last_i != -1)
			{
				random_walk.RemoveRange(i, last_i - i);
			}
		}
	}

	private static Vector2Int GetNewMove(ref Vector2Int size)
	{
        int coord_rand = Random.Range(0, 2);
        int diff_rand = Random.Range(0, 2) * 2 - 1;
        
		if (coord_rand == 0)
        {
            return new Vector2Int(diff_rand, 0);
        }
        else
        {
            return new Vector2Int(0, diff_rand);
        }
    }
}

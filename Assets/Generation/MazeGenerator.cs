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
	public static Room WilsonMaze(Vector2Int size, Vector2Int initial_room)
	{
		if(initial_room.x > size.x || initial_room.x < 0
		   || initial_room.y > size.y || initial_room.y < 0)
		{   // initial room is outside of the maze :(
			return new Room(initial_room);
		}

		List< List<Room> > room_grid = new List<List<Room>>();
		for(int x = 0; x < size.x; x++)
		{
			room_grid.Add(new List<Room>());

			for(int y = 0; y < size.y; y++)
			{
				room_grid[x].Add(new Room(new Vector2Int(x, y)));
			}
		}

		room_grid[initial_room.x][initial_room.y].in_maze = true;


		Room s = GetNewRandomwalkStart(ref room_grid);

		List<Room> connection_candidates = new List<Room>();

        for (int dx = -1; dx <= 1; dx++)
        {
            for (int dy = -1; dy <= 1; dy++)
            {
                int nx = s.position.x + dx;
                int ny = s.position.y + dy;

                if(Mathf.Abs(dx + dy) != 1
                  || (nx > room_grid.Count || nx < 0 || ny > room_grid[0].Count || ny < 0))
                {
                    continue;
                }

				if (room_grid[nx][ny].in_maze)
				{
					connection_candidates.Add(room_grid[nx][ny]);
				}
            }
        }

		int i = Random.Range(0, connection_candidates.Count);
		connection_candidates[i].connected_rooms.Add(s);
		s.connected_rooms.Add(connection_candidates[i]);

        return new Room(initial_room);
	}

	private static Room GetNewRandomwalkStart(ref List<List<Room>> room_grid)
	{
		List<Room> candidates = new List<Room>();
        for (int x = 0; x < room_grid.Count; x++)
        {
            for (int y = 0; y < room_grid[0].Count; y++)
            {
				if (room_grid[x][y].in_maze)
				{
					continue;
				}

				bool is_candidate = false;
				// check if a neighbouring room is in the maze or not
                for(int dx = -1; dx <= 1; dx++)
				{
					for(int dy = -1; dy <= 1; dy++)
					{
						int nx = x + dx;
						int ny = y + dy;

						// check only the direct neighbours
						if(Mathf.Abs( dx + dy) != 1
						  || (nx > room_grid.Count || nx < 0 || ny > room_grid[0].Count || ny < 0 ) )
						{
							continue;
						}

						is_candidate = is_candidate || room_grid[nx][ny].in_maze;
					}
				}

                if (is_candidate)
                {
					candidates.Add(room_grid[x][y]);
                }
            }
        }

		return candidates[Random.Range(0, candidates.Count)];
    }
}

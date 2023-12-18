using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mazevizualizer : MonoBehaviour
{
	[SerializeField] Vector2Int maze_size;
	[SerializeField] Vector2Int starting_room;
	[SerializeField] private bool giz = false;

    Maze m;
	

	// Start is called before the first frame update
	void Start()
	{
		m = MazeGenerator.WilsonMaze(maze_size, starting_room);
	}

	// Update is called once per frame
	void Update()
	{
		
	}

	private void OnDrawGizmos()
	{
		if (giz)
		{
			foreach (Room r in m.rooms)
			{
				Gizmos.DrawCube(new Vector3(r.position.x, r.position.y, 0), 0.75f * Vector3.one);
				
				foreach(KeyValuePair<Room, bool> pair in r.connected_rooms)
				{
					if (pair.Value)
					{
						Gizmos.DrawLine(new Vector3(r.position.x, r.position.y,0), new Vector3(pair.Key.position.x, pair.Key.position.y, 0));
					}
				}
			}
		}
	}
}
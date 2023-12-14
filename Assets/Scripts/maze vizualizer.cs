using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mazevizualizer : MonoBehaviour
{
	List<Room> rooms;
	private bool giz = false;

	// Start is called before the first frame update
	void Start()
	{
		giz = true;
		rooms = MazeGenerator.WilsonMaze(new Vector2Int(5,5), new Vector2Int(2,2));
	}

	// Update is called once per frame
	void Update()
	{
		
	}

	private void OnDrawGizmos()
	{
		if (giz)
		{
			foreach (Room r in rooms)
			{
				Gizmos.DrawCube(new Vector3(r.position.x, r.position.y, 0), new Vector3(1,1,1));
			}
		}
	}
}
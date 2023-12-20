using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mazevizualizer : MonoBehaviour
{
    [SerializeField] Material mat;
    [SerializeField] float maze_wall_height;
	[SerializeField] Vector2Int maze_size;
	[SerializeField] Vector2Int starting_room;
	[SerializeField] private bool giz = false;

    Maze m;
	

	// Start is called before the first frame update
	void Start()
	{
		m = MazeGenerator.WilsonMaze(maze_size, starting_room);

        CreateMesh();
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
                        Gizmos.DrawCube(new Vector3(r.position.x, r.position.y, 0)/2 + new Vector3(pair.Key.position.x, pair.Key.position.y, 0)/2, 0.75f * Vector3.one);
                    }
				}
			}
		}
	}

	private void CreateMesh()
	{
        Vector3[] vertices = new Vector3[(maze_size.x + 1) * (maze_size.y + 1) * 2];
        int[] triangles = new int[maze_size.y * maze_size.x * 18];

        // floor
        int v_ind = 0;
        for (int i = 0; i <= maze_size.x; i++)
        {
            for (int j = 0; j <= maze_size.y; j++)
            {
                vertices[v_ind++] = new Vector3(i, 0, j);
            }
        }

        // ceiling
        for (int i = 0; i <= maze_size.x; i++)
        {
            for (int j = 0; j <= maze_size.y; j++)
            {
                vertices[v_ind++] = new Vector3(i, maze_wall_height, j);
            }
        }

        // floor and ceiling
        for (int i = 0; i < maze_size.x; i++)
        {
            for (int j = 0; j < maze_size.y; j++)
            {
                int v0 = i * (maze_size.y + 1) + j;               //   v2 --- v3
                int v1 = i * (maze_size.y + 1) + j + 1;           //   |  \    |
                int v2 = (i + 1) * (maze_size.y + 1) + j;         //   |    \  |
                int v3 = (i + 1) * (maze_size.y + 1) + j + 1;     //   v0 --- v1

                int ind = (i * maze_size.y + j) * 18;

                // double faced floor
                triangles[ind] = v0;
                triangles[ind + 1] = v1;
                triangles[ind + 2] = v2;

                triangles[ind + 3] = v1;
                triangles[ind + 4] = v3;
                triangles[ind + 5] = v2;

                triangles[ind + 6] = v0;
                triangles[ind + 7] = v2;
                triangles[ind + 8] = v1;

                triangles[ind + 9] = v1;
                triangles[ind + 10] = v2;
                triangles[ind + 11] = v3;

                // ceiling
                int vert_offset = (maze_size.x + 1) * (maze_size.y + 1);

                triangles[ind + 12] = vert_offset + v0;
                triangles[ind + 13] = vert_offset + v2;
                triangles[ind + 14] = vert_offset + v1;

                triangles[ind + 15] = vert_offset + v1;
                triangles[ind + 16] = vert_offset + v2;
                triangles[ind + 17] = vert_offset + v3;
            }
        }

        Mesh mesh = new Mesh();

        mesh.vertices = vertices;
        mesh.triangles = triangles;

        MeshFilter mf = gameObject.AddComponent<MeshFilter>();
        MeshRenderer mr = gameObject.AddComponent<MeshRenderer>();

        mf.mesh = mesh;
        mr.material = mat;
    }
}
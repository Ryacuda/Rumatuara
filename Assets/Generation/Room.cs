using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room
{
    public Vector2Int position;
    public HashSet<Room> connected_rooms;
    public bool in_maze;

    public Room(Vector2Int pos)
    {
        position = pos;
        connected_rooms = new HashSet<Room>();
    }

}

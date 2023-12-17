using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room
{
	public Vector2Int position;
	public Dictionary<Room, bool> connected_rooms;      // in the dictionary means adjacent, true means connected
	public bool in_maze;

	public Room(Vector2Int pos)
	{
		position = pos;
		connected_rooms = new Dictionary<Room, bool>();
		in_maze = false;
	}

	// returns whether or not the room is connect to the one passed as parameter
	public bool IsConnectedTo(Room room)
	{
		bool connected;
		

		if(connected_rooms.TryGetValue(room, out connected))
		{
			return connected;
		}
		else
		{
			return false;
		}
	}

	public bool IsAdjacentTo(Room room)
	{
		return connected_rooms.ContainsKey(room);
	}

	// connects two rooms if they're adjacent
	public void ConnectTo(Room room)
	{
		if(connected_rooms.ContainsKey(room))
		{
			connected_rooms[room] = true;
		}
	}

	public void AddAdjacentRoom(Room room)
	{
		if (!connected_rooms.ContainsKey(room))
		{
			connected_rooms.Add(room, false);
		}
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Direction
{
	Right, DownRight, DownLeft, Left, UpLeft, UpRight
}

[System.Serializable]
public class GridNode
{
	private IntVector2 m_pos;
	private float m_height;

	public IntVector2 Pos { get { return m_pos; } }
	public float Height { get { return m_height; } }

	public Vector3 WorldPosition { get { return new Vector3(m_pos.x * GameController.Instance.GridData.CellWidth + (m_pos.y % 2)GameController.Instance.GridData.CellHeight/4, m_pos.y * GameController.Instance.GridData.CellHeight * 3 / 4); } }
}

public class Grid : MonoBehaviour
{
	void Start ()
	{
		
	}

	void Update ()
	{
		
	}
}

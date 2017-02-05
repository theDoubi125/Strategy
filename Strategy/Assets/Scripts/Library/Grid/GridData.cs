using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

[System.Serializable]
public class IntVector3
{
    public int x, y, z;

    public IntVector3(int x, int y, int z)
    {
        this.x = x;
        this.y = y;
        this.z = z;
    }

    public IntVector3(Vector3 pos)
    {
        x = Mathf.RoundToInt(pos.x);
        y = Mathf.RoundToInt(pos.y);
        z = Mathf.RoundToInt(pos.z);
    }

    public static IntVector3 operator+(IntVector3 A, IntVector3 B)
    {
        return new IntVector3(A.x + B.x, A.y + B.y, A.z + B.z);
    }

    public static implicit operator Vector3(IntVector3 pos)
    {
        if (pos == null)
            throw new Exception("Cannot cast a null IntVector3 into Vector3");
        return new Vector3(pos.x, pos.y, pos.z);
    }
}

[System.Serializable]
public class IntVector2
{
	public int x, y;

	public IntVector2(int x, int y)
	{
		this.x = x;
		this.y = y;
	}

	public IntVector2(Vector2 pos)
	{
		x = Mathf.RoundToInt(pos.x);
		y = Mathf.RoundToInt(pos.y);
	}

	public static IntVector2 operator+(IntVector2 A, IntVector2 B)
	{
		return new IntVector2(A.x + B.x, A.y + B.y);
	}

	public static implicit operator Vector2(IntVector2 pos)
	{
		if (pos == null)
			throw new Exception("Cannot cast a null IntVector2 into Vector2");
		return new Vector2(pos.x, pos.y);
    }

    public override bool Equals(object obj)
    {
        return x == (obj as IntVector2).x && y == (obj as IntVector2).y;
    }

    public static bool operator==(IntVector2 A, IntVector2 B)
    {
        if(ReferenceEquals(A, B))
            return true;
        if (ReferenceEquals(A, null) || ReferenceEquals(B, null))
            return false;
        return A.x == B.x && A.y == B.y;
    }

    public static bool operator!=(IntVector2 A, IntVector2 B)
    {
        if(ReferenceEquals(A, B))
            return false;
        if (ReferenceEquals(A, null) || ReferenceEquals(B, null))
            return true;
        return A.x != B.x || A.y != B.y;
    }

    public override int GetHashCode()
    {
        return x.GetHashCode() ^ y.GetHashCode();
    }
}

[System.Serializable]
public class IV2
{
    public int x, y;

    public IV2(int x, int y)
    {
        this.x = x;
        this.y = y;
    }
}

[CreateAssetMenu(fileName="GridData", menuName="Global/GridData", order=1000)]
public class GridData : ScriptableObject
{
    [SerializeField]
    private float m_cellSize;

    public float CellSize { get { return m_cellSize; } }
	public float CellWidth { get { return Mathf.Sqrt(3) / 2 * CellHeight; } }
	public float CellHeight { get { return CellSize * 2; } }
}

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

[CreateAssetMenu(fileName="GridData", menuName="Global/GridData", order=1000)]
public class GridData : ScriptableObject
{
    [SerializeField]
    private Vector3 m_cellSize;
    public Vector3 CellSize { get { return m_cellSize; } }
}

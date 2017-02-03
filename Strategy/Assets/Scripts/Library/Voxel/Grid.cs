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
    public GridNode(IntVector2 pos, float height)
    {
        m_pos = pos;
        m_height = height;
    }

    [SerializeField]
    private IntVector2 m_pos;
    [SerializeField]
	private float m_height;

	public IntVector2 Pos { get { return m_pos; } }
	public float Height { get { return m_height; } }

    public Vector3 WorldPosition
    {
        get
        {
            float x = GameController.Instance.GridData.CellWidth * (m_pos.x + (float)m_pos.y / 2);
            float z = m_pos.y * GameController.Instance.GridData.CellHeight * 3 / 4;
            return new Vector3(x, Height, z);
        }
    }

    public static IntVector2 getCellFromWorldPos(Vector3 pos)
    {
        float w = GameController.Instance.GridData.CellWidth;
        float h = GameController.Instance.GridData.CellHeight;
        return new IntVector2(Mathf.RoundToInt(pos.x/w - 2 * pos.z / (3 * h)), Mathf.RoundToInt(4 * pos.z / (3 * h)));
    }
}

public class Grid : MonoBehaviour
{
    private Dictionary<IntVector2, CellRenderer> m_cells = new Dictionary<IntVector2, CellRenderer>();

    [SerializeField]
    private GameObject m_cellPrefab = null;

    [SerializeField]
    private IntVector2 m_min = new IntVector2(0, 0);
    [SerializeField]
    private IntVector2 m_max = new IntVector2(0, 0);

	void Start ()
	{
        for (int i = m_min.x; i <= m_max.x; i++)
        {
            for (int j = m_min.y; j <= m_max.y; j++)
            {
                IntVector2 pos = new IntVector2(i, j);
                CellRenderer cell = GameObject.Instantiate<GameObject>(m_cellPrefab).GetComponent<CellRenderer>();
                cell.Init(new GridNode(pos, 0));
                cell.transform.parent = transform;
                m_cells[pos] = cell;
            }
        }
	}

	void Update ()
	{
		
	}
}

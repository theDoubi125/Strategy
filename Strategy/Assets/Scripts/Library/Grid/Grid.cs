using System;
using System.Collections.Generic;
using UnityEngine;

public enum Direction
{
	Right, DownRight, DownLeft, Left, UpLeft, UpRight
}

[System.Serializable]
public class GridLink
{
    [SerializeField]
    private IntVector2 m_target;
    [SerializeField]
    private IntVector2 m_origin;
    [SerializeField]
    private Direction m_direction;

    private Grid m_grid;

    private static IntVector2[] m_directionVectors = new IntVector2[] { 
        new IntVector2(1, 0),
        new IntVector2(1, -1),
        new IntVector2(0, -1),
        new IntVector2(-1, 0),
        new IntVector2(-1, 1),
        new IntVector2(0, 1),
    };

    public static IntVector2 GetDirectionVector(Direction direction)
    {
        return m_directionVectors[(int)direction];
    }

    public GridLink(Grid grid, IntVector2 origin, IntVector2 target, Direction direction)
    {
        m_grid = grid;
        m_origin = origin;
        m_target = target;
        m_direction = direction;
    }

    public IntVector2 Target { get { return m_target; } }

    public IntVector2 Origin { get { return m_origin; } }

    public Direction Direction { get { return m_direction; } }
}

[System.Serializable]
public class GridNode
{
    [SerializeField]
    private IntVector2 m_pos;
    [SerializeField]
    private float m_height;
    [SerializeField]
    private GridLink[] m_links;

    private Grid m_grid;

    private CellRenderer m_cellRenderer;

    public GridNode(Grid grid, IntVector2 pos, float height, CellRenderer renderer)
    {
        m_grid = grid;
        m_pos = pos;
        m_height = height;
        m_cellRenderer = renderer;
        m_links = new GridLink[Enum.GetValues(typeof(Direction)).Length];
    }

    public GridNode(Grid grid, IntVector2 pos, float height, CellRenderer renderer, GridLink[] links)
    {
        m_grid = grid;
        m_pos = pos;
        m_height = height;
        m_links = links;
        m_cellRenderer = renderer;
    }

	public IntVector2 Pos { get { return m_pos; } }
	public float Height { get { return m_height; } }

    public CellRenderer Renderer { get { return m_cellRenderer; } }

    public GridLink GetLink(Direction direction)
    {
        return m_links[(int)direction];
    }

    public void SetLink(GridLink link)
    {
        m_links[(int)link.Direction] = link;
    }

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
        return new IntVector2(Mathf.RoundToInt(pos.x * w / 3 - 2 * pos.z / (3 * h)), Mathf.RoundToInt(4 * pos.z / (3 * h)));
    }
}

public class Grid : MonoBehaviour
{
    private Dictionary<IntVector2, GridNode> m_gridNodes = new Dictionary<IntVector2, GridNode>();

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
                GridNode node = new GridNode(this, pos, 0, cell);
                cell.Init(node);
                cell.transform.parent = transform;
                m_gridNodes[pos] = node;
            }
        }
        for (int i = m_min.x; i <= m_max.x; i++)
        {
            for (int j = m_min.y; j <= m_max.y; j++)
            {
                foreach (Direction dir in Enum.GetValues(typeof(Direction)))
                {
                    IntVector2 pos = new IntVector2(i, j);
                    IntVector2 targetPos = pos + GridLink.GetDirectionVector(dir);
                    if (m_gridNodes.ContainsKey(targetPos))
                    {
                        m_gridNodes[targetPos].SetLink(new GridLink(this, pos, targetPos, dir));
                    }
                }
            }
        }
	}

    public GridNode GetCell(IntVector2 pos)
    {
        if (m_gridNodes.ContainsKey(pos))
            return m_gridNodes[pos];
        return null;
    }

	void Update ()
	{
		
	}
}

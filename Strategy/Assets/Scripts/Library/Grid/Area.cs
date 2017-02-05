using System;
using System.Collections.Generic;
using UnityEngine;

public interface AreaComputer
{
    bool IsCellValid(GridNode cell);

    List<GridNode> Area { get; }
}

public class ListAreaComputer : AreaComputer
{
    private List<GridNode> m_nodes;
    private Dictionary<IntVector2, GridNode> m_nodeDictionary = new Dictionary<IntVector2, GridNode>();

    public ListAreaComputer(List<GridNode> nodes)
    {
        m_nodes = nodes;
        foreach (GridNode node in nodes)
        {
            m_nodeDictionary[node.Pos] = node;
        }
    }

    public bool IsCellValid(GridNode cell)
    {
        return m_nodeDictionary.ContainsKey(cell.Pos);
    }

    public List<GridNode> Area { get { return m_nodes; } }
}


public class RadiusAreaComputer : AreaComputer
{
    private GridNode m_center;
    private float m_radius;

    public RadiusAreaComputer(GridNode center, float radius)
    {
        m_center = center;
        m_radius = radius;
    }

    public bool IsCellValid(GridNode cell)
    {
        return Vector3.Distance(m_center.WorldPosition, cell.WorldPosition) < m_radius;
    }

    public List<GridNode> Area 
   {
        get
        { 
            List<GridNode> result = new List<GridNode>();
            result.Add(m_center);
            for (int i = 0; i < 3; i++)
            {

            }

            return result;
        }
    }
}
using System;
using UnityEngine;
using System.Collections.Generic;

public class CellRenderer : MonoBehaviour
{
    [SerializeField]
    private GridNode m_node = null;

    public GridNode GridNode { get { return m_node; } }

    [SerializeField]
    private Material m_material = null;

    private Mesh m_mesh;

    public void Start()
    {
        Init(m_node);
    }

    public void Update()
    {
        
    }

    public void Init(GridNode node)
    {
        m_node = node;
        transform.position = m_node.WorldPosition;
        List<Vector3> vertices = new List<Vector3>();
        List<Vector2> uvs = new List<Vector2>();
        vertices.Add(Vector3.zero);
        uvs.Add(new Vector2(0, 0));
        for(int i=0; i<6; i++)
        {
            vertices.Add(new Vector3(Mathf.Cos((i + 1.0f/2) * Mathf.PI / 3), 0, Mathf.Sin((i + 1.0f/2) * Mathf.PI / 3)));
            uvs.Add(new Vector2(1, 1));
        }

        int[] triangles = new int[]
            {
                1, 0, 2,
                2, 0, 3,
                3, 0, 4,
                4, 0, 5,
                5, 0, 6,
                6, 0, 1
            };
        m_mesh = new Mesh();
        m_mesh.SetVertices(vertices);
        m_mesh.SetTriangles(triangles, 0);
        m_mesh.SetUVs(0, uvs);
        MeshFilter filter = GetComponent<MeshFilter>();
        if (filter == null)
            filter = gameObject.AddComponent<MeshFilter>();
        filter.mesh = m_mesh;

        MeshRenderer renderer = gameObject.GetComponent<MeshRenderer>();
        if (renderer == null)
            renderer = gameObject.AddComponent<MeshRenderer>();

        renderer.material = m_material;
    }
}
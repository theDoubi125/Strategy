using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private IntVector2 m_cursorSelection;
    private Camera m_camera;

	void Start ()
    {
        m_camera = GetComponent<Camera>();
        Dictionary<IntVector2, int> test = new Dictionary<IntVector2, int>();
        IntVector2 a = new IntVector2(0, 0);
        test[a] = 0;
        Debug.Log(test[a]);
	}
	
	void Update ()
    {
        Ray ray = m_camera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            m_cursorSelection = GridNode.getCellFromWorldPos(hit.point);
        }
	}

    void OnDrawGizmos()
    {
        if (m_cursorSelection != null && GameController.Instance != null)
        {
            GridNode selectedCell = GameController.Instance.Grid.GetCell(m_cursorSelection);
            if (selectedCell != null)
            {
                AreaComputer areaComputer = new RadiusAreaComputer(selectedCell, 3);
                Gizmos.color = Color.red;
                foreach (GridNode node in areaComputer.Area)
                {
                    if (node != null)
                        Gizmos.DrawSphere(node.WorldPosition, 1);
                }
                Gizmos.color = Color.blue;
                Gizmos.DrawCube(selectedCell.WorldPosition, new Vector3(1, 1, 1));
            }
        }
    }
}

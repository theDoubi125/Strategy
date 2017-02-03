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
        if(m_cursorSelection != null)
            Gizmos.DrawCube(new GridNode(m_cursorSelection, 0).WorldPosition, new Vector3(1, 1, 1));
    }
}

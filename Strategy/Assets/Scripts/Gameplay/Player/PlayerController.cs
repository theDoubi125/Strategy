using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private IntVector3 m_cursorSelection;
    private Camera m_camera;

	void Start ()
    {
        m_camera = GetComponent<Camera>();
	}
	
	void Update ()
    {
        Ray ray = m_camera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if(Physics.Raycast(ray, out hit))
            m_cursorSelection = new IntVector3(hit.point);
	}

    void OnDrawGizmos()
    {
        if(m_cursorSelection != null)
            Gizmos.DrawCube(m_cursorSelection, new Vector3(1, 1, 1));
    }
}

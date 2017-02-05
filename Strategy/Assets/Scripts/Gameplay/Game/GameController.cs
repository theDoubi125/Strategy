using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class GameController : MonoBehaviour
{
    private static GameController m_instance = null;
    public static GameController Instance
    {
        get
        {
            if (m_instance == null)
            {
                m_instance = Transform.FindObjectOfType<GameController>();
                if (m_instance == null)
                {
                    GameObject gameObject = new GameObject("Game Controller");
                    m_instance = gameObject.AddComponent<GameController>();
                }
            }
            return m_instance;
        }
    }

	public GridData GridData { get; private set; }
    public Grid Grid { get; private set; }

	void Awake()
    {
        GridData = Resources.Load<GridData>("Global/GridData");
        Grid = GetComponent<Grid>();
	}
	
	void Update ()
    {
		
	}
}

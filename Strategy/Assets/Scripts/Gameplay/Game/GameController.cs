using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class GameController : MonoBehaviour
{
    public static GameController Instance { get; private set;}

    private GridData m_gridData;

	void Start ()
    {
        Instance = this;
        m_gridData = Resources.Load<GridData>("Global/GridData");
	}
	
	void Update ()
    {
		
	}
}

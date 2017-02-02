using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class GameController : MonoBehaviour
{
    public static GameController Instance { get; private set;}

	public GridData GridData { get; private set; }

	void Awake()
    {
        Instance = this;
        GridData = Resources.Load<GridData>("Global/GridData");
	}
	
	void Update ()
    {
		
	}
}

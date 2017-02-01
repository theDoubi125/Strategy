using UnityEngine;
using System.Collections;
using UnityEditor;

[CustomEditor(typeof(StateMachine))]
public class StateMachineEditor : Editor {

	public override void OnInspectorGUI()
	{
		base.DrawDefaultInspector();

	}
}


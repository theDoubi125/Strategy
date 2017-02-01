using UnityEngine;
using System.Collections;
using UnityEditor;

[CustomEditor(typeof(StateMachine))]
public class StateMachineEditor : Editor 
{
    public override void OnInspectorGUI()
    {
        StateMachine machine = (StateMachine)target;

        base.DrawDefaultInspector();

        EditorGUILayout.ObjectField(machine.CurrentState, typeof(State));
    }
}
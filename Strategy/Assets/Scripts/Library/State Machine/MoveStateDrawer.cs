using UnityEngine;
using UnityEditor;
using System.Collections;

[CustomPropertyDrawer (typeof (State))]
public class MoveStateDrawer : PropertyDrawer {

	public override void OnGUI (Rect position, SerializedProperty property, GUIContent label)
	{
        EditorGUI.BeginProperty (position, label, property);

        //position = EditorGUI.PrefixLabel (position, GUIUtility.GetControlID (FocusType.Passive), new GUIContent(label.text));


        var indent = EditorGUI.indentLevel;
        EditorGUI.indentLevel = 0;

        EditorGUI.PropertyField(position, property);
        //base.OnGUI(amountRect, property, label);
		//EditorGUI.IntField(amountRect, 0);
		//EditorGUI.indentLevel = indent;

		EditorGUI.EndProperty ();
	}
}
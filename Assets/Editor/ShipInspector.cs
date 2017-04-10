using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(Ship))]
public class ShipInspector : Editor {

	const int STAT_POOL = 100;

	public override void OnInspectorGUI ()
	{
		Ship myShip = (Ship)target;

		//basic info on the ship
		EditorGUILayout.LabelField ("Basic Ship Info:");
		EditorGUILayout.BeginVertical ("Box");
		myShip.hitPoints = EditorGUILayout.IntField (new GUIContent("Hit Points", "How much damage can the ship take?"), Mathf.Max(0, myShip.hitPoints));
		EditorGUILayout.IntSlider (new GUIContent("Stat Points Avaliable:", "There are 100 total points, 30 are alwasys being used. NOT ADJUSTABLE"),STAT_POOL - (myShip.agility + myShip.attack + myShip.armor), 30, 100);
		myShip.armor = EditorGUILayout.IntSlider (new GUIContent("Armor", "How strong is the hull, cannot drop below 10."), myShip.armor, 10, STAT_POOL - (myShip.agility + myShip.attack));
		myShip.attack = EditorGUILayout.IntSlider (new GUIContent("Attack", "How powerful are the weapons, cannot drop below 10."), myShip.attack, 10, STAT_POOL - (myShip.agility + myShip.armor));
		myShip.agility = EditorGUILayout.IntSlider (new GUIContent("Agility", "How fast is the ship, cannot drop below 10."), myShip.agility, 10, STAT_POOL - (myShip.armor + myShip.attack));
		EditorGUILayout.EndVertical ();

		//weapon info
		EditorGUILayout.BeginVertical("Box");
		serializedObject.Update();
		SerializedProperty myGuns = serializedObject.FindProperty ("shipGuns");
		EditorGUILayout.PropertyField (myGuns, new GUIContent ("Weapons on the ship: ", "Types are: Cannon, Plasma, Machine-Gun, Flamethrower"), true);
		serializedObject.ApplyModifiedProperties ();
		EditorGUILayout.EndVertical ();

		//crew info
		EditorGUILayout.BeginVertical("Box");
		serializedObject.Update();
		SerializedProperty myCrew = serializedObject.FindProperty ("crewMembers");
		EditorGUILayout.PropertyField (myCrew, new GUIContent ("Crew Members: ", ""), true);
		serializedObject.ApplyModifiedProperties ();
		EditorGUILayout.EndVertical ();

		//original
		//base.OnInspectorGUI ();
	}

}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditorInternal;
using UnityEngine;

public class BezierEditorSpawner : EditorWindow
{
    string namebz = "";
    int objID = 0;
    Material mat;
    GameObject[] points = new GameObject[] {};
    
    private BezierList pointslist;

    private SerializedObject objSO=null;
    private ReorderableList listRE=null;
    

    [MenuItem("Tools/Bezier Generator")]
    public static void ShowWindow()
    {
        GetWindow(typeof(BezierEditorSpawner));
    }

    private void OnEnable()
    {
        pointslist = FindObjectOfType<BezierList>();
        if (pointslist)
        {
            objSO = new SerializedObject(pointslist);
            if (objSO.FindProperty("points") == null)
            {
                Debug.Log("nulnulnulnul");
            }
            listRE = new ReorderableList(objSO, objSO.FindProperty("points"), true, true, true, true);
            listRE.drawHeaderCallback = (rect) => EditorGUI.LabelField(rect, "Game Objects");
            listRE.drawElementCallback = (Rect rect, int index, bool isActive, bool isFocused) =>
            {
                rect.y += 2f;
                rect.height = EditorGUIUtility.singleLineHeight;

                GUIContent objectlabel = new GUIContent($"GameObject {index}");
                EditorGUI.PropertyField(rect, listRE.serializedProperty.GetArrayElementAtIndex(index), objectlabel);
            };
        }
    }

    private void OnInspectorUpdate()
    {
        Repaint();
    }

    private void OnGUI()
    {
        GUILayout.Label("Spaw Bezier Spline", EditorStyles.boldLabel);
        
        
        namebz = EditorGUILayout.TextField("Name", namebz);
        objID = EditorGUILayout.IntField("ID", objID);
        mat = (Material)EditorGUILayout.ObjectField("Material", mat, typeof(Material));
        
        if (objSO == null)
        {
            Debug.Log("can't find a list");
        }

        else if (objSO!=null)
        {
            objSO.Update();
            listRE.DoList(new Rect(0f, 100f, 400f, 500f));
            objSO.ApplyModifiedProperties();
        }
        
        GUILayout.Space(listRE.GetHeight()+30f);
        GUILayout.Space(10f);
    }
}

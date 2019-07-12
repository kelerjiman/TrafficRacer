using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
[CustomEditor(typeof(SignBehavior))]
public class SignBehaviorEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        SignBehavior script = (SignBehavior)target;
        string Slabel = "Type Of Sign ";
        script.SIndex = EditorGUILayout.Popup(Slabel, script.SIndex, script.SType);
    }
}

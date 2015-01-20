using UnityEngine;
using UnityEditor;
using System.Collections;

[CustomEditor(typeof(Weapon))]
public class WeaponTester : Editor 
{
    private Weapon weapon;
    public override void OnInspectorGUI()
    {
        base.DrawDefaultInspector();

        //if (GUILayout.Button("StandardWand"))
        //{

        //}

        //if (GUILayout.Button("WoodWand"))
        //{

        //}

        //if (GUILayout.Button("SilverWand"))
        //{

        //}

        //if (GUILayout.Button("GoldWand"))
        //{

        //}

    }
}

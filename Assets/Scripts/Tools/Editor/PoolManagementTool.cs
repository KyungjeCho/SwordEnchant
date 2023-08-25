using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityObject = UnityEngine.Object;
using SwordEnchant.Util;
using SwordEnchant.Managers;

public class PoolManagementTool : EditorWindow
{
    public int uiWidthXLarge = 450;
    public int uiWidthLarge = 300;
    public int uiWidthMiddle = 200;
    public int uiWidthSmall = 150;
    private int selection = 0;
    private string keyString = string.Empty;

    private Vector2 SP1 = Vector2.zero;
    private Vector2 SP2 = Vector2.zero;

    private static Dictionary<string, Pool> pool = new Dictionary<string, Pool>();

    [MenuItem("Tools/Pool Management")]
    static void Init()
    {
        pool = PoolManager.Instance.Pool;

        PoolManagementTool window = GetWindow<PoolManagementTool>(false, "Pool Management Tool");
        window.Show();
    }

    private void OnGUI()
    {
        if (pool == null)
        {
            return;
        }

        EditorGUILayout.BeginVertical();
        {
            EditorGUILayout.BeginHorizontal();
            {
                EditorHelper.EditorToolListLayer(ref SP1, pool, ref selection, uiWidthLarge);
                SP2 = EditorGUILayout.BeginScrollView(SP2);
                {
                    EditorGUILayout.Separator();
                    //EditorGUILayout.LabelField("ID", selection.ToString(), )
                }
                EditorGUILayout.EndScrollView();

            }
            EditorGUILayout.EndHorizontal();
        }
        EditorGUILayout.EndVertical();
    }
}

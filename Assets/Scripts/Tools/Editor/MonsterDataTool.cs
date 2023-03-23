using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityObject = UnityEngine.Object;
using SwordEnchant.Data;

public class MonsterDataTool : EditorWindow
{
    public int uiWidthXLarge = 450;
    public int uiWidthLarge = 300;
    public int uiWidthMiddle = 200;
    public int uiWidthSmall = 150;

    private Vector2 SP1 = Vector2.zero;
    private Vector2 SP2 = Vector2.zero;

    private GameObject monsterDataSource = null;

    private static MonsterData monsterData;
    
    [MenuItem("Tools/Monster Data")]
    static void Init()
    {
        // 데이터 로드

        // 윈도우 생성
        MonsterDataTool window = GetWindow<MonsterDataTool>(false, "Monster Data Tool");
        window.Show();
    }

    private void OnGUI() 
    {
        // 데이터 예외처리

        EditorGUILayout.BeginVertical();
        {
            

        }
        EditorGUILayout.EndVertical();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityObject = UnityEngine.Object;
using SwordEnchant.Data;
using System.Text;

public class MonsterDataTool : EditorWindow
{
    public int uiWidthXLarge = 450;
    public int uiWidthLarge = 300;
    public int uiWidthMiddle = 200;
    public int uiWidthSmall = 150;
    private int selection = 0;

    private Vector2 SP1 = Vector2.zero;
    private Vector2 SP2 = Vector2.zero;

    private GameObject monsterDataSource = null;

    private static MonsterData monsterData;
    
    [MenuItem("Tools/Monster Data")]
    static void Init()
    {
        // 데이터 로드
        monsterData = ScriptableObject.CreateInstance<MonsterData>();
        monsterData.LoadData();

        // 윈도우 생성
        MonsterDataTool window = GetWindow<MonsterDataTool>(false, "Monster Data Tool");
        window.Show();
    }

    private void OnGUI() 
    {
        // 데이터 예외처리
        if (monsterData == null)
        {
            return;
        }

        EditorGUILayout.BeginVertical();
        {
            UnityObject source = monsterDataSource;
            EditorHelper.EditorToolTopLayer(monsterData, ref selection, ref source, this.uiWidthMiddle);
            monsterDataSource = (GameObject)source;

            EditorGUILayout.BeginHorizontal();
            {
                EditorHelper.EditorToolListLayer(ref SP1, monsterData, ref selection, ref source, uiWidthLarge);
                monsterDataSource = (GameObject)source;
                SP2 = EditorGUILayout.BeginScrollView(this.SP2);
                {
                    if (monsterData.GetDataCount() > 0)
                    {
                        EditorGUILayout.BeginVertical();
                        {
                            EditorGUILayout.Separator();
                            EditorGUILayout.LabelField("ID", selection.ToString(), GUILayout.Width(uiWidthLarge));
                            monsterData.names[selection] = EditorGUILayout.TextField("이름", monsterData.names[selection], GUILayout.Width(uiWidthXLarge));

                            EditorGUILayout.Separator();

                            if (monsterDataSource == null && monsterData.monsterClips[selection].monsterName != string.Empty)
                            {
                                monsterData.monsterClips[selection].PreLoad();
                                monsterDataSource = Resources.Load(monsterData.monsterClips[selection].monsterPath + monsterData.monsterClips[selection].monsterName) as GameObject;
                            }
                            // 몬스터 프리펩

                            // 몬스터 기본 스텟
                            monsterData.monsterClips[selection].health = EditorGUILayout.FloatField("Health", monsterData.monsterClips[selection].health, GUILayout.Width(uiWidthXLarge));
                            monsterData.monsterClips[selection].speed = EditorGUILayout.FloatField("Speed", monsterData.monsterClips[selection].speed, GUILayout.Width(uiWidthXLarge));
                            monsterData.monsterClips[selection].damage = EditorGUILayout.FloatField("Damage", monsterData.monsterClips[selection].damage, GUILayout.Width(uiWidthXLarge));
                            monsterData.monsterClips[selection].defence = EditorGUILayout.FloatField("Defence", monsterData.monsterClips[selection].defence, GUILayout.Width(uiWidthXLarge));
                            monsterData.monsterClips[selection].size = EditorGUILayout.FloatField("Size", monsterData.monsterClips[selection].size, GUILayout.Width(uiWidthXLarge));

                        }
                        EditorGUILayout.EndVertical();
                    }
                }
                EditorGUILayout.EndScrollView();
            }
            EditorGUILayout.EndHorizontal();
        }
        EditorGUILayout.EndVertical();

        // 하단.
        EditorGUILayout.Separator();


        EditorGUILayout.BeginHorizontal();
        {
            if (GUILayout.Button("Reload Settings"))
            {
                monsterData = CreateInstance<MonsterData>();
                monsterData.LoadData();
                selection = 0;
                monsterDataSource = null;
            }
            if (GUILayout.Button("Save"))
            {
                MonsterDataTool.monsterData.SaveData();
                CreateEnumStructure();
                AssetDatabase.Refresh(ImportAssetOptions.ForceUpdate);
            }
        }
        EditorGUILayout.EndHorizontal();
    }

    public void CreateEnumStructure()
    {
        string enumName = "MonsterList";
        StringBuilder builder = new StringBuilder();
        builder.AppendLine();
        for (int i = 0; i < monsterData.names.Length; i++)
        {
            if (monsterData.names[i] != string.Empty)
            {
                builder.AppendLine("    " + monsterData.names[i] + " = " + i + ",");
            }
        }
        EditorHelper.CreateEnumStructure(enumName, builder);
    }
}

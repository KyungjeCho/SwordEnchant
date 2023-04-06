using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityObject = UnityEngine.Object;
using SwordEnchant.Data;
using System.Text;

public class WeaponDataTool : EditorWindow
{
    public int uiWidthXLarge = 450;
    public int uiWidthLarge = 300;
    public int uiWidthMiddle = 200;
    public int uiWidthSmall = 150;
    private int selection = 0;

    private Vector2 SP1 = Vector2.zero;
    private Vector2 SP2 = Vector2.zero;

    private GameObject weaponDataSource = null;

    private static WeaponData weaponData;

    [MenuItem("Tools/Weapon Data")]
    static void Init()
    {
        // 데이터 로드
        weaponData = ScriptableObject.CreateInstance<WeaponData>();
        weaponData.LoadData();

        // 윈도우 생성
        WeaponDataTool window = GetWindow<WeaponDataTool>(false, "Weapon Data Tool");
        window.Show();
    }

    private void OnGUI()
    {
        // 데이터 예외처리
        if (weaponData == null)
        {
            return;
        }

        EditorGUILayout.BeginVertical();
        {
            UnityObject source = weaponDataSource;
            EditorHelper.EditorToolTopLayer(weaponData, ref selection, ref source, this.uiWidthMiddle);
            weaponDataSource = (GameObject)source;

            EditorGUILayout.BeginHorizontal();
            {
                EditorHelper.EditorToolListLayer(ref SP1, weaponData, ref selection, ref source, uiWidthLarge);
                weaponDataSource = (GameObject)source;

                EditorGUILayout.BeginVertical();
                {
                    SP2 = EditorGUILayout.BeginScrollView(this.SP2);
                    {
                        if (weaponData.GetDataCount() > 0)
                        {
                            EditorGUILayout.BeginVertical();
                            {
                                EditorGUILayout.Separator();
                                EditorGUILayout.LabelField("ID", selection.ToString(), GUILayout.Width(uiWidthLarge));
                                weaponData.names[selection] = EditorGUILayout.TextField("Name", weaponData.names[selection], GUILayout.Width(uiWidthXLarge));

                                EditorGUILayout.Separator();

                                if (weaponDataSource == null && weaponData.weaponClips[selection].weaponName != string.Empty)
                                {
                                    weaponData.weaponClips[selection].PreLoad();
                                    weaponDataSource = Resources.Load(weaponData.weaponClips[selection].weaponPath + weaponData.weaponClips[selection].weaponName) as GameObject;
                                }
                                // 무기 프리펩

                                // 무기 기본 스텟
                                weaponData.weaponClips[selection].damage = EditorGUILayout.FloatField("Damage", weaponData.weaponClips[selection].damage, GUILayout.Width(uiWidthXLarge));
                                weaponData.weaponClips[selection].size = EditorGUILayout.FloatField("Size", weaponData.weaponClips[selection].size, GUILayout.Width(uiWidthXLarge));
                                weaponData.weaponClips[selection].speed = EditorGUILayout.FloatField("Speed", weaponData.weaponClips[selection].speed, GUILayout.Width(uiWidthXLarge));
                                weaponData.weaponClips[selection].cooldown = EditorGUILayout.FloatField("Cooldown", weaponData.weaponClips[selection].cooldown, GUILayout.Width(uiWidthXLarge));
                                weaponData.weaponClips[selection].count = EditorGUILayout.FloatField("Count", weaponData.weaponClips[selection].count, GUILayout.Width(uiWidthXLarge));
                                weaponData.weaponClips[selection].criticalProb = EditorGUILayout.FloatField("Critical Probability", weaponData.weaponClips[selection].criticalProb, GUILayout.Width(uiWidthXLarge));
                                weaponData.weaponClips[selection].criticalDamage = EditorGUILayout.FloatField("Critical Damage", weaponData.weaponClips[selection].criticalDamage, GUILayout.Width(uiWidthXLarge));
                                weaponData.weaponClips[selection].rarity = (WeaponRarity)EditorGUILayout.EnumPopup("Rarity", weaponData.weaponClips[selection].rarity, GUILayout.Width(uiWidthLarge));
                                EditorGUILayout.Separator();

                                if (weaponDataSource == null && weaponData.weaponClips[selection].weaponName != string.Empty)
                                {
                                    weaponData.weaponClips[selection].PreLoad();
                                    weaponDataSource = Resources.Load(weaponData.weaponClips[selection].weaponPath + weaponData.weaponClips[selection].weaponName) as GameObject;
                                }
                                weaponDataSource = (GameObject)EditorGUILayout.ObjectField("Projectile", weaponDataSource, typeof(GameObject), false, GUILayout.Width(uiWidthXLarge));
                                if (weaponDataSource != null)
                                {
                                    weaponData.weaponClips[selection].weaponPath = EditorHelper.GetPath(weaponDataSource);
                                    weaponData.weaponClips[selection].weaponName = weaponDataSource.name;
                                }
                                else
                                {
                                    weaponData.weaponClips[selection].weaponPath = string.Empty;
                                    weaponData.weaponClips[selection].weaponName = string.Empty;
                                    weaponDataSource = null;
                                }
                            }
                            EditorGUILayout.EndVertical();
                        }
                    }
                    EditorGUILayout.EndScrollView();
                }
                EditorGUILayout.EndVertical();
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
                weaponData = CreateInstance<WeaponData>();
                weaponData.LoadData();
                selection = 0;
                weaponDataSource = null;
            }
            if (GUILayout.Button("Save"))
            {
                WeaponDataTool.weaponData.SaveData();
                CreateEnumStructure();
                AssetDatabase.Refresh(ImportAssetOptions.ForceUpdate);
            }
        }
        EditorGUILayout.EndHorizontal();
    }

    public void CreateEnumStructure()
    {
        string enumName = "WeaponList";
        StringBuilder builder = new StringBuilder();
        builder.AppendLine();
        for (int i = 0; i < weaponData.names.Length; i++)
        {
            if (weaponData.names[i] != string.Empty)
            {
                builder.AppendLine("    " + weaponData.names[i] + " = " + i + ",");
            }
        }
        EditorHelper.CreateEnumStructure(enumName, builder);
    }
}

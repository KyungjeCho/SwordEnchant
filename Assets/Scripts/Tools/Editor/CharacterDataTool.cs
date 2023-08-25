using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityObject = UnityEngine.Object;
using SwordEnchant.Data;
using System.Text;


public class CharacterDataTool : EditorWindow
{
    #region Variables
    public int uiWidthXLarge = 450;
    public int uiWidthLarge = 300;
    public int uiWidthMiddle = 200;
    public int uiWidthSmall = 150;
    private int selection = 0;

    private Vector2 SP1 = Vector2.zero;
    private Vector2 SP2 = Vector2.zero;

    private GameObject characterDataSource = null;

    private static CharacterData characterData;
    #endregion Variables

    #region Init
    [MenuItem("Tools/Character Data")]
    static void Init()
    {
        // 데이터 로드
        characterData = ScriptableObject.CreateInstance<CharacterData>();
        characterData.LoadData();

        // 윈도우 생성
        CharacterDataTool window = GetWindow<CharacterDataTool>(false, "Character Data Tool");
        window.Show();
    }
    #endregion Init

    #region On GUI
    private void OnGUI()
    {
        // 데이터 예외처리
        if (characterData == null)
        {
            return;
        }

        // 상단
        EditorGUILayout.BeginVertical();
        {
            UnityObject source = characterDataSource;
            EditorHelper.EditorToolTopLayer(characterData, ref selection, ref source, this.uiWidthMiddle);
            characterDataSource = (GameObject)source;

            EditorGUILayout.BeginHorizontal();
            {
                EditorHelper.EditorToolListLayer(ref SP1, characterData, ref selection, ref source, uiWidthLarge);
                characterDataSource = (GameObject)source;

                EditorGUILayout.BeginVertical();
                {
                    SP2 = EditorGUILayout.BeginScrollView(this.SP2);
                    {
                        if (characterData.GetDataCount() > 0)
                        {
                            EditorGUILayout.BeginVertical();
                            {
                                EditorGUILayout.Separator();
                                EditorGUILayout.LabelField("ID", selection.ToString(), GUILayout.Width(uiWidthLarge));
                                characterData.names[selection] = EditorGUILayout.TextField("Name", characterData.names[selection], GUILayout.Width(uiWidthXLarge));

                                EditorGUILayout.Separator();

                                if (characterDataSource == null && characterData.characterClips[selection].characterName != string.Empty)
                                {
                                    characterData.characterClips[selection].PreLoad();
                                    characterDataSource = Resources.Load(characterData.characterClips[selection].characterPath + characterData.characterClips[selection].characterName) as GameObject;
                                }
                                // 무기 프리펩

                                // 무기 기본 스텟
                                characterData.characterClips[selection].maxHp   = EditorGUILayout.FloatField("Max HP", characterData.characterClips[selection].maxHp, GUILayout.Width(uiWidthXLarge));
                                characterData.characterClips[selection].defence = EditorGUILayout.FloatField("Defence", characterData.characterClips[selection].defence, GUILayout.Width(uiWidthXLarge));
                                characterData.characterClips[selection].damage  = EditorGUILayout.FloatField("Damage", characterData.characterClips[selection].damage, GUILayout.Width(uiWidthXLarge));
                                characterData.characterClips[selection].size = EditorGUILayout.FloatField("Size", characterData.characterClips[selection].size, GUILayout.Width(uiWidthXLarge));
                                characterData.characterClips[selection].speed = EditorGUILayout.FloatField("Speed", characterData.characterClips[selection].speed, GUILayout.Width(uiWidthXLarge));
                                characterData.characterClips[selection].cooldown = EditorGUILayout.FloatField("Cooldown", characterData.characterClips[selection].cooldown, GUILayout.Width(uiWidthXLarge));
                                characterData.characterClips[selection].count = EditorGUILayout.FloatField("Count", characterData.characterClips[selection].count, GUILayout.Width(uiWidthXLarge));
                                characterData.characterClips[selection].luck = EditorGUILayout.FloatField("Luck", characterData.characterClips[selection].luck, GUILayout.Width(uiWidthXLarge));
                                characterData.characterClips[selection].criticalProb = EditorGUILayout.FloatField("Critical Probability", characterData.characterClips[selection].criticalProb, GUILayout.Width(uiWidthXLarge));
                                characterData.characterClips[selection].criticalDamage = EditorGUILayout.FloatField("Critical Damage", characterData.characterClips[selection].criticalDamage, GUILayout.Width(uiWidthXLarge));
                                characterData.characterClips[selection].defaultWeapon = (WeaponList)EditorGUILayout.EnumPopup("Default Weapon", characterData.characterClips[selection].defaultWeapon, GUILayout.Width(uiWidthLarge));
                                EditorGUILayout.Separator();

                                if (characterDataSource == null && characterData.characterClips[selection].characterName != string.Empty)
                                {
                                    characterData.characterClips[selection].PreLoad();
                                    characterDataSource = Resources.Load(characterData.characterClips[selection].characterPath + characterData.characterClips[selection].characterName) as GameObject;
                                }
                                characterDataSource = (GameObject)EditorGUILayout.ObjectField("Character Prefab", characterDataSource, typeof(GameObject), false, GUILayout.Width(uiWidthXLarge));
                                if (characterDataSource != null)
                                {
                                    characterData.characterClips[selection].characterPath = EditorHelper.GetPath(characterDataSource);
                                    characterData.characterClips[selection].characterName = characterDataSource.name;
                                }
                                else
                                {
                                    characterData.characterClips[selection].characterPath = string.Empty;
                                    characterData.characterClips[selection].characterName = string.Empty;
                                    characterDataSource = null;
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
                characterData = CreateInstance<CharacterData>();
                characterData.LoadData();
                selection = 0;
                characterDataSource = null;
            }
            if (GUILayout.Button("Save"))
            {
                CharacterDataTool.characterData.SaveData();
                CreateEnumStructure();
                AssetDatabase.Refresh(ImportAssetOptions.ForceUpdate);
            }
        }
        EditorGUILayout.EndHorizontal();
    }
    #endregion On GUI

    #region Create Enum Structure
    public void CreateEnumStructure()
    {
        string enumName = "CharacterList";
        StringBuilder builder = new StringBuilder();
        builder.AppendLine();
        for (int i = 0; i < characterData.names.Length; i++)
        {
            if (characterData.names[i] != string.Empty)
            {
                builder.AppendLine("    " + characterData.names[i] + " = " + i + ",");
            }
        }
        EditorHelper.CreateEnumStructure(enumName, builder);
    }
    #endregion Create Enum Structure


}

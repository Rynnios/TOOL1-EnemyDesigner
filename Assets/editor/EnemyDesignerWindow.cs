using System.Collections;
using UnityEngine;
using UnityEditor;
using Types;

public class EnemyDesignerWindow : EditorWindow
{
    Texture2D headerSectionTexture;
    Texture2D mageSectionTexture;
    Texture2D rogueSectionTexture;
    Texture2D warriorSectionTexture;

    Texture2D mageTexture;
    Texture2D warriorTexture;
    Texture2D rogueTexture;

    Color headerSectionColor = new Color(13f / 255f, 32f / 255f, 44f / 255f, 1f);
    Color mageSectionColor = new Color(255f / 255f, 153f / 255f, 51f / 255f, 1f);
    Color warriorSectionColor = new Color(51f / 255f, 51f / 255f, 255f / 255f, 1f);
    Color rogueSectionColor = new Color(255f / 255f, 102f / 255f, 102f / 255f, 1f);

    Rect headerSection;
    Rect mageSection;
    Rect rogueSection;
    Rect warriorSection;

    Rect mageIconSection;
    Rect warriorIconSection;
    Rect rogueIconSection;

    GUISkin skin;

    static MageData mageData;
    static RogueData rogueData;
    static WarriorData warriorData;

    public static MageData MageInfo { get { return mageData; } }
    public static RogueData RogueInfo { get { return rogueData; } }
    public static WarriorData WarriorInfo { get { return warriorData; } }

    float ICONSIZE = 80;

    [MenuItem("Window/ Enemy Designer")]    //Attribute, passes string value that represents where the window is accessible through via toolbar
    static void OpenWindow()    //static function for opening a window
    {
        //Get window call, set it to castsed version of the window, "typeof" accepts a type of parameter which is my class
        EnemyDesignerWindow window = (EnemyDesignerWindow)GetWindow(typeof(EnemyDesignerWindow));
        //Restrain size of window, minimum size
        window.minSize = new Vector2(600, 300);
        //Actually open the window
        window.Show();


    }
    
    /// <summary>
    /// Similar to start or awake function
    /// </summary>
    void OnEnable()
    {
        InitTextures();
        InitData();
        skin = Resources.Load<GUISkin>("guiStyles/EnemyWindowSkin");
    }

    //initiliaze scriptable objects and cast it to the datatype
    public static void InitData()
    {
        mageData = (MageData)ScriptableObject.CreateInstance(typeof(MageData));
        rogueData = (RogueData)ScriptableObject.CreateInstance(typeof(RogueData));
        warriorData = (WarriorData)ScriptableObject.CreateInstance(typeof(WarriorData));

    }

    /// <summary>
    /// Initialize all Texture2D values
    /// </summary>
    void InitTextures()
    {
        headerSectionTexture = new Texture2D(1, 1);   //new texture 2d, 1 pixel wide and high
        headerSectionTexture.SetPixel(0, 0, headerSectionColor);  //(0,0) position, headerSectionColor is a color variable defined above
        headerSectionTexture.Apply();

        mageSectionTexture = new Texture2D(1,1);
        mageSectionTexture.SetPixel(0, 0, mageSectionColor);
        mageSectionTexture.Apply();

        rogueSectionTexture = new Texture2D(1, 1);
        rogueSectionTexture.SetPixel(0, 0, rogueSectionColor);
        rogueSectionTexture.Apply();

        warriorSectionTexture = new Texture2D(1, 1);
        warriorSectionTexture.SetPixel(0, 0, warriorSectionColor);
        warriorSectionTexture.Apply();

        mageTexture = Resources.Load<Texture2D>("icons/MageIcon");
        warriorTexture = Resources.Load<Texture2D>("icons/WarriorIcon");
        rogueTexture = Resources.Load<Texture2D>("icons/RogueIcon");


    }

    /// <summary>
    /// Similar to Update Function
    /// Not called once per frame. Its called 1 or more times per interaction
    /// Everytime mouse goes over window or click on button or any interaction, GUI will be called 1+ times
    /// </summary>
    void OnGUI()
    {
        DrawLayouts();
        DrawHeaders();
        DrawMageSettings();
        DrawRogueSettings();
        DrawWarriorSettings();
    }

    /// <summary>
    /// Defines Rect values and paints textures based on Rects
    /// </summary>
    void DrawLayouts()
    {
        //50 pixels high, width of screeen no matter the screen resized or not
        headerSection.x = 0; 
        headerSection.y = 0;
        headerSection.width = position.width;
        headerSection.height = 50;

        mageSection.x = 0;
        mageSection.y = 50;
        mageSection.width = position.width/3f;
        mageSection.height = position.height - 50;

        mageIconSection.x = (mageSection.x + mageSection.width /2f) - ICONSIZE/2f;
        mageIconSection.y = mageSection.y + 8;
        mageIconSection.width = ICONSIZE;
        mageIconSection.height = ICONSIZE;

        warriorIconSection.x = (warriorSection.x + warriorSection.width / 2f) - ICONSIZE / 2f;
        warriorIconSection.y = warriorSection.y + 8;
        warriorIconSection.width = ICONSIZE;
        warriorIconSection.height = ICONSIZE;

        rogueIconSection.x = (rogueSection.x + rogueSection.width / 2f) - ICONSIZE / 2f;
        rogueIconSection.y = rogueSection.y + 8;
        rogueIconSection.width = ICONSIZE;
        rogueIconSection.height = ICONSIZE;

        warriorSection.x = position.width / 3f;
        warriorSection.y = 50;
        warriorSection.width = position.width / 3f;
        warriorSection.height = position.height - 50;

        rogueSection.x = (position.width / 3f) * 2;
        rogueSection.y = 50;
        rogueSection.width = position.width / 3f;
        rogueSection.height = position.height - 50;

        GUI.DrawTexture(headerSection, headerSectionTexture);
        GUI.DrawTexture(mageSection, mageSectionTexture);
        GUI.DrawTexture(warriorSection, warriorSectionTexture);
        GUI.DrawTexture(rogueSection, rogueSectionTexture);

        GUI.DrawTexture(mageIconSection, mageTexture);
        GUI.DrawTexture(warriorIconSection, warriorTexture);
        GUI.DrawTexture(rogueIconSection, rogueTexture);


    }

    /// <summary>
    /// Draw contents of headers
    /// </summary>
    void DrawHeaders()
    {
        GUILayout.BeginArea(headerSection);
        GUILayout.Label("Enemy Designer", skin.GetStyle("Header1"));
        GUILayout.EndArea();
    }

    /// <summary>
    /// Draw contents of mage region
    /// </summary>
    void DrawMageSettings()
    {
        GUILayout.BeginArea(mageSection);

        GUILayout.Space(ICONSIZE + 8);

        GUILayout.Label("Mage", skin.GetStyle("SubHeader"));

        GUILayout.Space(8);

        EditorGUILayout.BeginHorizontal();
        GUILayout.Label("Weapon", skin.GetStyle("Fields"));
        mageData.wpnType = (MageWpnType)EditorGUILayout.EnumPopup(mageData.wpnType);
        EditorGUILayout.EndHorizontal();

        GUILayout.Space(8);

        EditorGUILayout.BeginHorizontal();
        GUILayout.Label("Damage", skin.GetStyle("Fields"));
        mageData.dmgType = (MageDmgType)EditorGUILayout.EnumPopup(mageData.dmgType);
        EditorGUILayout.EndHorizontal();

        GUILayout.Space(8);

        EditorGUILayout.BeginHorizontal();
        GUILayout.Label("Drop Item", skin.GetStyle("Fields"));
        mageData.MageDropType = (dropType)EditorGUILayout.EnumPopup(mageData.MageDropType);
        EditorGUILayout.EndHorizontal();

        GUILayout.Space(8);

        //Button, will return false if button is clicked
        if (GUILayout.Button("Create!", GUILayout.Height(40)))
        {
            GeneralSettings.OpenWindow(GeneralSettings.SettingsType.MAGE);
        }

        GUILayout.EndArea();
    }

    /// <summary>
    /// Draw contents of rogue region
    /// </summary>
    void DrawRogueSettings()
    {
        GUILayout.BeginArea(rogueSection);

        GUILayout.Space(ICONSIZE + 8);

        GUILayout.Label("Rogue", skin.GetStyle("SubHeader"));

        GUILayout.Space(8);

        EditorGUILayout.BeginHorizontal();
        GUILayout.Label("Weapon", skin.GetStyle("Fields"));
        rogueData.wpnType = (RogueWpnType)EditorGUILayout.EnumPopup(rogueData.wpnType);
        EditorGUILayout.EndHorizontal();

        GUILayout.Space(8);

        EditorGUILayout.BeginHorizontal();
        GUILayout.Label("Strategy", skin.GetStyle("Fields"));
        rogueData.stratType = (RogueStrategyType)EditorGUILayout.EnumPopup(rogueData.stratType);
        EditorGUILayout.EndHorizontal();

        GUILayout.Space(8);

        EditorGUILayout.BeginHorizontal();
        GUILayout.Label("Drop Item", skin.GetStyle("Fields"));
        rogueData.RogueDropType = (dropType)EditorGUILayout.EnumPopup(rogueData.RogueDropType);
        EditorGUILayout.EndHorizontal();

        GUILayout.Space(8);

        //Button, will return false if button is clicked
        if (GUILayout.Button("Create!", GUILayout.Height(40)))
        {
            GeneralSettings.OpenWindow(GeneralSettings.SettingsType.ROGUE);
        }

        GUILayout.EndArea();
    }

    /// <summary>
    /// Draw contents of warrior region
    /// </summary>
    void DrawWarriorSettings()
    {
        GUILayout.BeginArea(warriorSection);

        GUILayout.Space(ICONSIZE + 8);

        GUILayout.Label("Warrior", skin.GetStyle("SubHeader"));

        GUILayout.Space(8);

        EditorGUILayout.BeginHorizontal();
        GUILayout.Label("Weapon", skin.GetStyle("Fields"));
        warriorData.wpnType = (WarriorWpnType)EditorGUILayout.EnumPopup(warriorData.wpnType);
        EditorGUILayout.EndHorizontal();

        GUILayout.Space(8);

        EditorGUILayout.BeginHorizontal();
        GUILayout.Label("Class", skin.GetStyle("Fields"));
        warriorData.classType = (WarriorClassType)EditorGUILayout.EnumPopup(warriorData.classType);
        EditorGUILayout.EndHorizontal();

        GUILayout.Space(8);

        EditorGUILayout.BeginHorizontal();
        GUILayout.Label("Drop Item", skin.GetStyle("Fields"));
        warriorData.WarriorDropType = (dropType)EditorGUILayout.EnumPopup(warriorData.WarriorDropType);
        EditorGUILayout.EndHorizontal();

        GUILayout.Space(8);

        //Button, will return false if button is clicked
        if (GUILayout.Button("Create!", GUILayout.Height(40)))
        {
            GeneralSettings.OpenWindow(GeneralSettings.SettingsType.WARRIOR);
        }

        GUILayout.EndArea();
    }


}

public class GeneralSettings : EditorWindow
{
    //pass as a parameter whenever we call openWindow
    //will specify what enemy was chosen
    public enum SettingsType
    {
        MAGE,
        WARRIOR,
        ROGUE
    }

    static SettingsType dataSetting;
    static GeneralSettings window;

    public static void OpenWindow(SettingsType setting)
    {
        dataSetting = setting;
        window = (GeneralSettings)GetWindow(typeof(GeneralSettings));
        window.minSize = new Vector2(250, 200);
        window.Show();
    }

    void OnGUI()
    {
        switch (dataSetting)
        {
            case SettingsType.MAGE:
                DrawSettings((CharacterData)EnemyDesignerWindow.MageInfo);
                break;
            case SettingsType.WARRIOR:
                DrawSettings((CharacterData)EnemyDesignerWindow.WarriorInfo);
                break;
            case SettingsType.ROGUE:
                DrawSettings((CharacterData)EnemyDesignerWindow.RogueInfo);
                break;
        }
    }

    void DrawSettings(CharacterData charData)
    {
        EditorGUILayout.BeginHorizontal();
        GUILayout.Label("Prefab");
        charData.prefab = (GameObject)EditorGUILayout.ObjectField(charData.prefab, typeof(GameObject), false);  //can't drop objects and place into this field
        EditorGUILayout.EndHorizontal();

        EditorGUILayout.BeginHorizontal();
        GUILayout.Label("Max health");
        charData.maxHealth = EditorGUILayout.FloatField(charData.maxHealth);
        EditorGUILayout.EndHorizontal();

        EditorGUILayout.BeginHorizontal();
        GUILayout.Label("Max energy");
        charData.maxEnergy = EditorGUILayout.FloatField(charData.maxEnergy);
        EditorGUILayout.EndHorizontal();

        EditorGUILayout.BeginHorizontal();
        GUILayout.Label("% Crit chance ");
        charData.critChance = EditorGUILayout.Slider(charData.critChance, 0, charData.power);
        EditorGUILayout.EndHorizontal();

        EditorGUILayout.BeginHorizontal();
        GUILayout.Label("Power");
        charData.power = EditorGUILayout.Slider(charData.power, 0, 100);
        EditorGUILayout.EndHorizontal();

        EditorGUILayout.BeginHorizontal();
        GUILayout.Label("Drop Chance");
        charData.dropChance = EditorGUILayout.Slider(charData.dropChance, 0, 100);
        EditorGUILayout.EndHorizontal();

        EditorGUILayout.BeginHorizontal();
        GUILayout.Label("Enemy name:");
        charData.characterName = EditorGUILayout.TextField(charData.characterName);
        EditorGUILayout.EndHorizontal();

        if (charData.prefab == null)
        {
            EditorGUILayout.HelpBox("This enemy needs a [Prefab] before it can be created!", MessageType.Warning);
        }
        else if (charData.characterName == null || charData.characterName.Length < 1)
        {
            EditorGUILayout.HelpBox("This enemy needs a name before it can be created!", MessageType.Warning);
        }
        else if (GUILayout.Button("Finish and Save", GUILayout.Height(30)))
        {
            SaveCharacterData();
            window.Close();
        }
    }

    void SaveCharacterData()
    {
        //Define some string values
        string prefabPath;  //Path to base prefab
        string newPrefabPath = "Assets/prefabs/characters/";
        string dataPath = "Assets/resources/characterData/data/";

        switch (dataSetting)
        {
            case SettingsType.MAGE:
                //Creates .asset file, .MageInfo var that refers to MageData class
                dataPath += "mage/" + EnemyDesignerWindow.MageInfo.characterName + ".asset";
                AssetDatabase.CreateAsset(EnemyDesignerWindow.MageInfo, dataPath);

                //Going to be where the copy of prefab asset it going to be
                newPrefabPath += "mage/" + EnemyDesignerWindow.MageInfo.name + ".prefab";

                //Find out where the prefab is
                prefabPath = AssetDatabase.GetAssetPath(EnemyDesignerWindow.MageInfo.prefab);
                ////Make copy of the asset
                AssetDatabase.CopyAsset(prefabPath, newPrefabPath);

                AssetDatabase.SaveAssets();
                AssetDatabase.Refresh();

                GameObject magePrefab = (GameObject)AssetDatabase.LoadAssetAtPath(newPrefabPath, typeof(GameObject));
                if (!magePrefab.GetComponent<Mage>())
                    magePrefab.AddComponent(typeof(Mage));
                magePrefab.GetComponent<Mage>().mageData = EnemyDesignerWindow.MageInfo;
                
                break;

            case SettingsType.WARRIOR:
                //Creates .asset file, .WarriorInfo var that refers to WarriorData class
                dataPath += "warrior/" + EnemyDesignerWindow.WarriorInfo.name + ".asset";
                AssetDatabase.CreateAsset(EnemyDesignerWindow.WarriorInfo, dataPath);

                //Going to be where the copy of prefab asset it going to be
                newPrefabPath += "warrior/" + EnemyDesignerWindow.WarriorInfo.name + ".prefab";

                //Find out where the prefab is
                prefabPath = AssetDatabase.GetAssetPath(EnemyDesignerWindow.WarriorInfo.prefab);
                ////Make copy of the asset
                AssetDatabase.CopyAsset(prefabPath, newPrefabPath); //(old prefab path, new prefab path)

                AssetDatabase.SaveAssets();
                AssetDatabase.Refresh();

                GameObject warriorPrefab = (GameObject)AssetDatabase.LoadAssetAtPath(newPrefabPath, typeof(GameObject));
                if (!warriorPrefab.GetComponent<Warrior>())
                    warriorPrefab.AddComponent(typeof(Warrior));
                warriorPrefab.GetComponent<Warrior>().warriorData = EnemyDesignerWindow.WarriorInfo;

                break;

            case SettingsType.ROGUE:
                dataPath += "rogue/" + EnemyDesignerWindow.RogueInfo.name + ".asset";
                AssetDatabase.CreateAsset(EnemyDesignerWindow.RogueInfo, dataPath);

                //Going to be where the copy of prefab asset it going to be
                newPrefabPath += "rogue/" + EnemyDesignerWindow.RogueInfo.name + ".prefab";

                //Find out where the prefab is
                prefabPath = AssetDatabase.GetAssetPath(EnemyDesignerWindow.RogueInfo.prefab);
                ////Make copy of the asset
                AssetDatabase.CopyAsset(prefabPath, newPrefabPath); //(old prefab path, new prefab path)

                AssetDatabase.SaveAssets();
                AssetDatabase.Refresh();

                GameObject roguePrefab = (GameObject)AssetDatabase.LoadAssetAtPath(newPrefabPath, typeof(GameObject));
                if (!roguePrefab.GetComponent<Rogue>())
                    roguePrefab.AddComponent(typeof(Rogue));
                roguePrefab.GetComponent<Rogue>().rogueData = EnemyDesignerWindow.RogueInfo;

                break;
        }
    }
}
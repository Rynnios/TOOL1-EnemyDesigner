using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class EnemyDesignerWindow : EditorWindow
{
    Texture2D headerSectionTexture;
    Texture2D mageSectionTexture;
    Texture2D rogueSectionTexture;
    Texture2D warriorSectionTexture;

    Color headerSectionColor = new Color(13f / 255f, 32f / 255f, 44f / 255f, 1f);
    Color mageSectionColor = new Color(255f / 255f, 153f / 255f, 51f / 255f, 1f);
    Color warriorSectionColor = new Color(51f / 255f, 51f / 255f, 255f / 255f, 1f);
    Color rogueSectionColor = new Color(255f / 255f, 102f / 255f, 102f / 255f, 1f);




    Rect headerSection;
    Rect mageSection;
    Rect rogueSection;
    Rect warriorSection;

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


        //rogueSectionTexture = Resources.Load<Texture2D>("icons/editor_rogue_gradient");
        //warriorSectionTexture = Resources.Load<Texture2D>("icons/editor_warrior_gradient");

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

    }

    /// <summary>
    /// Draw contents of headers
    /// </summary>
    void DrawHeaders()
    {
        GUILayout.BeginArea(headerSection);
        GUILayout.Label("Enemy Designer");
        GUILayout.EndArea();
    }

    /// <summary>
    /// Draw contents of mage region
    /// </summary>
    void DrawMageSettings()
    {
        GUILayout.BeginArea(mageSection);
        GUILayout.Label("Mage");
        GUILayout.EndArea();
    }

    /// <summary>
    /// Draw contents of rogue region
    /// </summary>
    void DrawRogueSettings()
    {
        GUILayout.BeginArea(rogueSection);
        GUILayout.Label("Rogue");
        GUILayout.EndArea();
    }

    /// <summary>
    /// Draw contents of warrior region
    /// </summary>
    void DrawWarriorSettings()
    {
        GUILayout.BeginArea(warriorSection);
        GUILayout.Label("Warrior");
        GUILayout.EndArea();
    }


}

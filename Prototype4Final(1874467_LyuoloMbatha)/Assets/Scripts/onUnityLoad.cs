using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEditor.SceneManagement;

//Allows for a scene to be saved upon pressing the play button
[InitializeOnLoad]
public class onUnityLoad 
{
    private static string scenePath 
    {
        get { return EditorPrefs.GetString("LoaderScene"); }
        set { EditorPrefs.SetString("LoaderScene", value); }

    }

     static onUnityLoad() 
    {
        EditorApplication.playmodeStateChanged = () =>
        {
            if (EditorApplication.isPlayingOrWillChangePlaymode && !EditorApplication.isPlaying)
            {
                if (EditorSceneManager.GetActiveScene().isDirty)
                {
                    Debug.Log("Auto-Saved open scene before entering playe mode");
                    AssetDatabase.SaveAssets();
                    EditorSceneManager.SaveOpenScenes();

                }

            }

        };
    
    }





}

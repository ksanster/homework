#if UNITY_EDITOR
using System.Threading;
using UnityEditor;
using UnityEngine;

public class FindMissingScripts : EditorWindow
{
    private static int gameObjectCount;
    private static int componentCount;
    private static int missingCount;
    private static int currentIndex;
    
    [MenuItem("Window/FindMissingScripts")]
    public static void ShowWindow()
    {
        EditorWindow.GetWindow(typeof(FindMissingScripts));
    }

    private void OnEnable()
    {
        gameObjectCount = 0; 
        componentCount = 0;
        componentCount = 0;
        currentIndex = 0;
    }

    public void OnGUI()
    {
        if (GUILayout.Button("Find Missing Scripts in scene"))
        {
            FindInScene();
        }
        GUILayout.Label($"Searched: {gameObjectCount} gameObjects, {componentCount} components. Found {missingCount} missing scripts");
    }
    
    private static void FindInScene()
    {
        var go = FindObjectsOfType(typeof(Component));
        gameObjectCount = go.Length; 
        componentCount = 0;
        missingCount = 0;
        currentIndex = 0;
        foreach (var obj in go)
        {
            var gameObject = (obj as Component).gameObject;
            FindInGO(gameObject);
            var progress = (float)currentIndex / gameObjectCount;
            EditorUtility.DisplayProgressBar("Progress", "Find missing scripts", progress);
            currentIndex++;
            Thread.Sleep(100);
        }
        EditorUtility.ClearProgressBar();
    }
    
    private static void FindInGO(GameObject g)
    {
        Component[] components = g.GetComponents<Component>();
        for (int i = 0; i < components.Length; i++)
        {
            componentCount++;
            if (components[i] == null)
            {
                missingCount++;
                string s = g.name;
                Transform t = g.transform;
                while (t.parent != null) 
                {
                    s = t.parent.name +"/"+s;
                    t = t.parent;
                }
                Debug.Log (s + " has an empty script attached in position: " + i, g);
            }
        }

        foreach (Transform childT in g.transform)
        {
            FindInGO(childT.gameObject);
        }
    }
}
#endif

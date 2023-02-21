using UnityEngine;

[CreateAssetMenu(menuName = "Editor/GreadEditorWindowOptions")]
public class GreadEditorDeleteOption : ScriptableObject
{
    private static GreadEditorDeleteOption _instance;

    public static GreadEditorDeleteOption Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = Resources.Load<GreadEditorDeleteOption>("Singleton");

                if (_instance == null)
                {
                    _instance = ScriptableObject.CreateInstance<GreadEditorDeleteOption>();
                }
            }

            return _instance;
        }
    }
}

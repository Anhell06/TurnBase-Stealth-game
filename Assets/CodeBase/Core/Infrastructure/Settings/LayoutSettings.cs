using CodeBase.HexLib;
using UnityEngine;

[System.Serializable]
[CreateAssetMenu(fileName = "LayoutSettings", menuName = "Setting/LayoutSettings")]
public class LayoutSettings : ScriptableObject
{
    public Vector2 Size = new Vector2(1, 0.75f);
    public Vector2 Origin = Vector2.zero;
}
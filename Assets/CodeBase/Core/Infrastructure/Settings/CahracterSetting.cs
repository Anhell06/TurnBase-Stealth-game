using Sirenix.OdinInspector;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CahracterSetting", menuName = "Setting/CahracterSetting")]
public class CahracterSetting : SerializedScriptableObject
{
    [SerializeField]
    public int VisabilityRange { get; private set; } = 2;
    [SerializeField]
    public List<TileType> VisabilityFilter { get; private set; } = new List<TileType>() {TileType.Floor };

}
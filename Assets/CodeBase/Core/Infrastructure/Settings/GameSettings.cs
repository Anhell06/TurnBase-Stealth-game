using UnityEngine;
using Zenject;

[CreateAssetMenu(fileName = "GameSettings", menuName = "Setting/GameSettings")]
public class GameSettings : ScriptableObjectInstaller
{
    [SerializeField]
    public LayoutSettings LayoutSettings;

    public override void InstallBindings()
    {
        Container.BindInstance(LayoutSettings);
    }
}
using CodeBase.HexLib;
using Sirenix.OdinInspector;
using UnityEngine;
using Zenject;

public class CharacterVisabilityView : MonoBehaviour
{
    private CharacterVisabilityController _controller;

    private void Start()
    {
        _controller.MakeHexesVisible(transform.position);
    }

    [Inject]
    public void Init(CharacterVisabilityController controller)
    {
        _controller = controller;
    }


    [Button]
    private void VisabilityTest()
    {
        _controller.MakeHexesVisible(transform.position);
    }

}

using Sirenix.OdinInspector;
using UnityEngine;
using Zenject;

namespace CodeBase.Character.Visability
{
    internal class CharacterVisabilityView : MonoBehaviour
    {
        private ICharacterVisabilityController _controller;

        private void Start()
        {
            _controller.MakeHexesVisible(transform.position);
        }

        [Inject]
        public void Init(ICharacterVisabilityController controller)
        {
            _controller = controller;
        }


        [Button]
        private void VisabilityTest()
        {
            _controller.MakeHexesVisible(transform.position);
        }

    }
}

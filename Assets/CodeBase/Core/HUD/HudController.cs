using CodeBase.Core.Infrastructure.TurnBaseSystem.Abstrations;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace CodeBase.Core.HUD
{
    public class HudController : MonoBehaviour
    {
        private IStateMachine _sm;

        [SerializeField]
        private Button _endTurnButton;
        private bool _isPlayerTurnState;

        [Inject]
        public void Init(IStateMachine sm)
        {
            _sm = sm;
            _sm.OnStateChanged += OnStateChanged;
            _endTurnButton.onClick.AddListener(OnEndTurnButtonClick);
        }

        private void OnStateChanged()
        {
            if (_sm.Data.CurrentState as IPlayerState != null)
            {
                _isPlayerTurnState = true;
                _endTurnButton.gameObject.SetActive(true);
            }
            else
            {
                _endTurnButton.gameObject.SetActive(false);
            }
        }

        private void OnEndTurnButtonClick()
        {
            if (_isPlayerTurnState)
                (_sm.Data.CurrentState as IPlayerState)?.EndTurn();
        }
    }
}

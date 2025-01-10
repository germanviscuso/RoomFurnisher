using Oculus.Interaction;
using UI.Components;
using UnityEngine;
using UnityEngine.Events;

namespace UI
{
    public class GameMenuUIController : MonoBehaviour
    {
        [SerializeField] private PointableButton _startButton;
        public UnityEvent<bool> OnGameMenuClosed = new UnityEvent<bool>();

        // Start is called before the first frame update
        void Start()
        {
            _startButton.AddReleaseListener(HandleStartButton);
        }

        private void HandleStartButton(PointerEvent arg0)
        {
            OnGameMenuClosed.Invoke(true);
            gameObject.SetActive(false);
        }
    
    }
}

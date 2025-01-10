using Oculus.Interaction;
using UnityEngine;
using UnityEngine.Events;

namespace UI.Components
{
    public class PointableButton : MonoBehaviour
    {
        [SerializeField] private PointableUnityEventWrapper _pokeEventWrapper;
        [SerializeField] private GameObject _text;
        [SerializeField] private AudioTrigger _pressAudioTrigger;
        [SerializeField] private AudioTrigger _releaseAudioTrigger;
        private void Awake()
        {
            SetupListeners();
        }

        private void OnDestroy()
        {
            RemoveListeners();
        }

        public void AddReleaseListener(UnityAction<PointerEvent> action)
        {
            _pokeEventWrapper.WhenRelease.AddListener(action);
        }

        public void RemoveReleaseListener(UnityAction<PointerEvent> action)
        { 
            _pokeEventWrapper.WhenRelease.RemoveListener(action);
        }

        private void SetupListeners()
        {
            _pokeEventWrapper.WhenRelease.AddListener(PlayReleaseAudio);
            _pokeEventWrapper.WhenSelect.AddListener(PlayPressAudio);
        }

        private void PlayPressAudio(PointerEvent pointerEvent)
        {
            _pressAudioTrigger.PlayAudio();
        }

        private void PlayReleaseAudio(PointerEvent pointerEvent)
        {
            _releaseAudioTrigger.PlayAudio();
        }

        private void RemoveListeners()
        {
            _pokeEventWrapper.WhenRelease.RemoveListener(PlayReleaseAudio);
            _pokeEventWrapper.WhenSelect.RemoveListener(PlayPressAudio);
        }
    
    }
}

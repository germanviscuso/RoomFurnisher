using System.Collections.Generic;
using Oculus.Interaction;
using UI.Components;
using UnityEngine;
using UnityEngine.Events;

namespace UI
{
    public class TutorialUIController : MonoBehaviour
    {
        [SerializeField] private List<GameObject> _tutorialPages;
        private int _currentPageIndex = 0;
        private int _maxPageIndex;
    
        [SerializeField] private PointableButton _prevButton;
        [SerializeField] private PointableButton _nextButton;
        [SerializeField] private PointableButton _exitButton;
    
        public UnityEvent<bool> OnTutorialClosed = new UnityEvent<bool>();

    
        // Start is called before the first frame update
        void Start()
        {
            _maxPageIndex = _tutorialPages.Count - 1;
            _tutorialPages[_currentPageIndex].SetActive(true);
            _prevButton.AddReleaseListener(HandlePrevButton);
            _nextButton.AddReleaseListener(HandleNextButton);
            _exitButton.AddReleaseListener(HandleExitButton);
        }

        private void Update()
        {
            if (_currentPageIndex == 0)
            {
                HidePrevButton();
            }
            else
            {
                ShowPrevButton();
            }
        
            if (_currentPageIndex == _maxPageIndex)
            {
                HideNextButton();
            }
            else
            {
                ShowNextButton();
            }
        }

        private void HandleExitButton(PointerEvent arg0)
        {
            CloseTutorial();
        }

        private void HandleNextButton(PointerEvent arg0)
        {
            NextPage();
        }

        private void HandlePrevButton(PointerEvent arg0)
        {
            PreviousPage();
        }

        private void NextPage()
        {
            if (_currentPageIndex < _maxPageIndex)
            {
                _tutorialPages[_currentPageIndex].SetActive(false);
                _currentPageIndex++;
                _tutorialPages[_currentPageIndex].SetActive(true);
            }
        }
    
        private void PreviousPage()
        {
            if (_currentPageIndex > 0)
            {
                _tutorialPages[_currentPageIndex].SetActive(false);
                _currentPageIndex--;
                _tutorialPages[_currentPageIndex].SetActive(true);
            }
        }
    
        private void HideNextButton()
        {
            _nextButton.gameObject.SetActive(false);
        }
    
        private void ShowNextButton()
        {
            _nextButton.gameObject.SetActive(true);
        }
    
        private void HidePrevButton()
        {
            _prevButton.gameObject.SetActive(false);
        }
    
        private void ShowPrevButton()
        {
            _prevButton.gameObject.SetActive(true);
        }
    
        private void CloseTutorial()
        {
            OnTutorialClosed.Invoke(true);
            gameObject.SetActive(false);
        }
    
        private void OnDestroy()
        {
            _prevButton.RemoveReleaseListener(HandlePrevButton);
            _nextButton.RemoveReleaseListener(HandleNextButton);
            _exitButton.RemoveReleaseListener(HandleExitButton);
        }
    }
}

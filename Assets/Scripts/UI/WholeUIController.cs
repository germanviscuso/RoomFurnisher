using UnityEngine;

namespace UI
{
    public class WholeUIController : MonoBehaviour
    {
        [SerializeField] private SettingsUIController _settingsUIController;
    
        // Contains the whole settings - GameSettingsScale
        [SerializeField] private GameObject _settingsObject;
    
        // Contains the tutorial - GameTutorialUI
        [SerializeField] private GameObject _tutorialObject;
        private TutorialUIController _tutorialUIController;
    
        // Contains the game Menu - GameMenuUI
        [SerializeField] private GameObject _menuObject;
        private GameMenuUIController _gameMenuUIController;
    
        // Contains the whole GameMenu - GameMenuScale (Tutorial, Menu) 
        [SerializeField] private GameObject _gameMenuObject;
        
        [SerializeField] private GameObject _furnitureMenuObject;
        
        [SerializeField] private GameObject _colorPickerMenuObject;
    
        private void Awake()
        {
            _tutorialUIController = _tutorialObject.GetComponent<TutorialUIController>();
            _tutorialUIController.OnTutorialClosed.AddListener(OnTutorialClosed);
            _gameMenuUIController = _menuObject.GetComponent<GameMenuUIController>();
            _gameMenuUIController.OnGameMenuClosed.AddListener(OnGameMenuClosed);
        
            ShowTutorial();
            HideMenu();
        }
    
        void Update()
        {
            if(_tutorialObject.activeSelf) return;
        
            if (OVRInput.GetDown(OVRInput.Button.Start))
            {
                if (_menuObject.activeSelf)
                {
                    HideMenu();
                }
                else
                {
                    ShowMenu();
                }
            }
        
            if (OVRInput.GetDown(OVRInput.Button.Two) && !_menuObject.activeSelf)
            {
                if (_settingsObject.activeSelf)
                {
                    HideSettings();
                }
                else
                {
                    ShowSettings();
                }
            }

            if (OVRInput.GetDown(OVRInput.Button.Three) && !_menuObject.activeSelf)
            {
                if (_furnitureMenuObject.activeSelf)
                {
                    _furnitureMenuObject.SetActive(false);
                }
                else
                {
                    _furnitureMenuObject.SetActive(true);
                }
            }
            
            if (OVRInput.GetDown(OVRInput.Button.Four) && !_menuObject.activeSelf)
            {
                if (_colorPickerMenuObject.activeSelf)
                {
                    _colorPickerMenuObject.SetActive(false);
                }
                else
                {
                    _colorPickerMenuObject.SetActive(true);
                }
            }
        }
    
        private void OnTutorialClosed(bool arg0)
        {
            ShowMenu();
        }
    
        private void OnGameMenuClosed(bool arg0)
        {
            HideMenu();
        }

        private void ShowSettings()
        {
            _settingsObject.SetActive(true);
        }

        private void HideSettings()
        {
            _settingsObject.SetActive(false);
        }
    
        private void ShowTutorial()
        {
            _tutorialObject.SetActive(true);
        }
    
        private void ShowMenu()
        {
            _menuObject.SetActive(true);
        }
    
        private void HideMenu()
        {
            _menuObject.SetActive(false);
        }
        
        public bool IsTutorialActive()
        {
            return _tutorialObject.activeSelf;
        }
    
        public bool IsMenuActive()
        {
            return _menuObject.activeSelf;
        }
    }
}

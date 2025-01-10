using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

namespace UI
{
    public class ColorPickerMenuController : MonoBehaviour
    {
        [FormerlySerializedAs("_furnitureTabViews")] [SerializeField] private List<ColorPickerTabView> _colorTabViews;
    
        private ColorPickerTabView _openTab;
    
        private void Start()
        {
            foreach (var view in _colorTabViews)
            {
                view.OpenNewTabEvent.AddListener(OpenTab);
            }
            CloseAllTabs();
            OpenFirstTab();
            _openTab = GetOpenTab();
        }
    
        private ColorPickerTabView GetOpenTab()
        {
            Debug.Log("Getting open tab");
            return _colorTabViews.Find(tab => tab.IsSelected);
        }

        private void CloseAllTabs()
        {
            Debug.Log("Closing all tabs");
            foreach (var tab in _colorTabViews)
            {
                tab.Hide();
            }
        }
    
        private void CloseOpenTab()
        {
            Debug.Log("Closing open tab");
            var openTab = GetOpenTab();
            if (openTab != null)
            {
                openTab.Hide();
            }
        }
    
        private void OpenFirstTab()
        {
            Debug.Log("Opening first tab");
            if (_colorTabViews.Count == 0)
            {
                Debug.LogError("No tabs found");
                return;
            }
            _colorTabViews[0].Show();
        }

        private void OpenTab(ColorPickerTabView tabView)
        {
            Debug.Log("Opening tab");
            if (_openTab == tabView)
            {
                return;
            }
        
            CloseOpenTab();
            tabView.Show();
            _openTab = tabView;
        }
    }
}

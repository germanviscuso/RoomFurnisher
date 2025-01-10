using System.Collections.Generic;
using UnityEngine;

namespace UI
{
    public class FurnitureMenuUIController : MonoBehaviour
    {
        // FurnitureTabView -> TabViewContent + TabViewButton
        [SerializeField] private List<FurnitureTabView> _furnitureTabViews;
    
        private FurnitureTabView _openTab;
    
        private void Start()
        {
            foreach (var view in _furnitureTabViews)
            {
                view.OpenNewTabEvent.AddListener(OpenTab);
            }
            CloseAllTabs();
            OpenFirstTab();
            _openTab = GetOpenTab();
        }
    
        private FurnitureTabView GetOpenTab()
        {
            Debug.Log("Getting open tab");
            return _furnitureTabViews.Find(tab => tab.IsSelected);
        }

        private void CloseAllTabs()
        {
            Debug.Log("Closing all tabs");
            foreach (var tab in _furnitureTabViews)
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
            if (_furnitureTabViews.Count == 0)
            {
                Debug.LogError("No tabs found");
                return;
            }
            _furnitureTabViews[0].Show();
        }

        private void OpenTab(FurnitureTabView tabView)
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

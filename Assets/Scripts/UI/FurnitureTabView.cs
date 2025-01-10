using System;
using Oculus.Interaction;
using TMPro;
using UI.Components;
using UnityEngine;
using UnityEngine.Events;

namespace UI
{
    public class FurnitureTabView : MonoBehaviour
    {
        [SerializeField] private TabViewButton TabViewButton;

        // Every tab view can customize its content
        [SerializeField] private GameObject TabViewContent;
        public bool IsSelected;
        public UnityEvent<FurnitureTabView> OpenNewTabEvent = new ();
        
        private void Awake()
        {
            TabViewButton = GetComponentInChildren<TabViewButton>();
            IsSelected = false;
        }

        private void Start()
        {
            TabViewButton.PointableButton.AddReleaseListener(HandleOpenTab);
        }

        private void HandleOpenTab(PointerEvent arg0)
        {
            OpenNewTabEvent.Invoke(this);
        }

        public void Show()
        {
            IsSelected = true;
            TabViewContent.SetActive(true);
            TabViewButton.GetComponentInChildren<TextMeshPro>().color = Color.yellow;
        }

        public void Hide()
        {
            IsSelected = false;
            TabViewContent.SetActive(false);
            TabViewButton.GetComponentInChildren<TextMeshPro>().color = Color.white;
        }
        
        private void OnDestroy()
        {
            TabViewButton.PointableButton.RemoveReleaseListener(HandleOpenTab);
        }
    }
}

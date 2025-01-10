using System;
using Oculus.Interaction;
using Meta.XR.MRUtilityKit;
using TMPro;
using UI.Components;
using UnityEngine;
using UnityEngine.Serialization;

namespace UI
{
    public class SettingsUIController : MonoBehaviour
    {
        [FormerlySerializedAs("_modeButton")]
        [FormerlySerializedAs("_wallsButton")]
        [Header("Show walls")]
        [SerializeField] private PointableButton _MRModeOnButton;
        [FormerlySerializedAs("_modeText")] [FormerlySerializedAs("_wallsText")] [SerializeField] private TextMeshPro _MRModeText;
    
        [FormerlySerializedAs("_floorButton")]
        [Header("Show floor")]
        [SerializeField] private PointableButton _collidersButton;
        [FormerlySerializedAs("_floorText")] [SerializeField] private TextMeshPro _collidersText;
    
        [Header("Materials")]
        [SerializeField] private Material _onMaterial;
        [SerializeField] private Material _offMaterial;
    
        private readonly string _onText = "ON";
        private readonly string _offText = "OFF";
    
        private Color _onColor;
        private Color _offColor;
        
        private RoomManager _roomManager;

        
        [SerializeField] private TextMeshPro _debugText;
    
        // Start is called before the first frame update
        void Start()
        {
            _onColor = _onMaterial.color;
            _offColor = _offMaterial.color;
            
            _roomManager = FindObjectOfType<RoomManager>();
            
            StartingSetup();
        }
        
        void Update()
        {
            if (_roomManager) return;
            _roomManager = FindObjectOfType<RoomManager>();
        }

        private void MRMode(PointerEvent arg0)
        {
            _debugText.text = "MR mode";

            _MRModeOnButton.RemoveReleaseListener(MRMode);
            _MRModeOnButton.AddReleaseListener(VRMode);
            _MRModeText.color = _onColor;
            _MRModeText.text = _onText;
            
            _roomManager.HideWalls();
            _roomManager.HideFloor();
            _roomManager.HideDoors();
            _roomManager.HideWindows();
        }
    
        private void VRMode(PointerEvent arg0)
        {
            _debugText.text = "VR mode";

            _MRModeOnButton.RemoveReleaseListener(VRMode);
            _MRModeOnButton.AddReleaseListener(MRMode);
            _MRModeText.color = _offColor;
            _MRModeText.text = _offText;
        
            _roomManager.ShowWalls();
            _roomManager.ShowFloor();
            _roomManager.ShowDoors();
            _roomManager.ShowWindows();
        }
    
        private void CollidersOn(PointerEvent arg0)
        {
            _debugText.text = "Colliders on";

            _collidersButton.RemoveReleaseListener(CollidersOn);
            _collidersButton.AddReleaseListener(CollidersOff);
            _collidersText.color = _onColor;
            _collidersText.text = _onText;

            _roomManager.DisplayFurnitureMesh(true);

        }
    
        private void CollidersOff(PointerEvent arg0)
        {
            _debugText.text = "Colliders off";

            _collidersButton.RemoveReleaseListener(CollidersOff);
            _collidersButton.AddReleaseListener(CollidersOn);
            _collidersText.color = _offColor;
            _collidersText.text = _offText;
        
            _roomManager.DisplayFurnitureMesh(false);
        }

    
        private void StartingSetup()
        {
            _MRModeText.text = _offText;
            _collidersText.text = _offText;
        
            _MRModeText.color = _offMaterial.color;
            _collidersText.color = _offMaterial.color;
            
            _MRModeOnButton.AddReleaseListener(MRMode);
            _collidersButton.AddReleaseListener(CollidersOn);
            _debugText.text = "Starting setup";
        }
        

        private void OnDestroy()
        {
            _MRModeOnButton.RemoveReleaseListener(MRMode);
            _MRModeOnButton.RemoveReleaseListener(VRMode);
            _collidersButton.RemoveReleaseListener(CollidersOn);
            _collidersButton.RemoveReleaseListener(CollidersOff);
        }
    }
}

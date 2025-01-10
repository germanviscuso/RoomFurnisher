using System.Collections.Generic;
using Oculus.Interaction;
using Types;
using UI.Components;
using UnityEngine;
using UnityEngine.Serialization;

namespace UI
{
    public class ColorPickerController : MonoBehaviour
    {
        [SerializeField] private GameObject _previewObject;
        [FormerlySerializedAs("_colors")] [SerializeField] private List<GameObject> _materials;
        
        [SerializeField] private PointableButton _colorPickerButton;
        
        private Material _selectedMaterial;
        
        [SerializeField] private bool _isWallColorPicker;
    
        // Start is called before the first frame update
        void Start()
        {
            _colorPickerButton.AddReleaseListener(HandleApplyMaterialButton);
            foreach (var material in _materials)
            {
                material.GetComponent<ColorListElement>().OnColorSelected.AddListener(SetPreviewMaterial);
            }

            _selectedMaterial = _materials[0].GetComponent<Renderer>().material;
            _previewObject.GetComponent<Renderer>().material = _selectedMaterial;
        }

        private void HandleApplyMaterialButton(PointerEvent selectedMaterial)
        {
            // Apply color to the object in the scene 
            // It depends on tab view selection
            Debug.Log("Applying material to object");
            if (_isWallColorPicker)
            {
                Debug.Log("Applying material to wall");
                var walls = GameObject.FindObjectsOfType<Wall>(true);
                foreach (var wall in walls)
                {
                    wall.GetComponent<Renderer>().material = _selectedMaterial;
                }
            }
            else
            {
                Debug.Log("Applying material to floor");
                var floors = GameObject.FindObjectsOfType<Floor>(true);
                foreach (var floor in floors)
                {
                    floor.GetComponent<Renderer>().material = _selectedMaterial;
                }
            }
        }

        private void SetPreviewMaterial(ColorListElement selectedMaterial)
        {
            _selectedMaterial = selectedMaterial.GetComponent<Renderer>().material;
            _previewObject.GetComponent<Renderer>().material = _selectedMaterial;
        }

    }
}

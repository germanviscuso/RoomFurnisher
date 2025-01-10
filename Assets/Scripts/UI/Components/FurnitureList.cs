using System.Collections.Generic;
using Oculus.Interaction;
using Oculus.Interaction.HandGrab;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Serialization;

namespace UI.Components
{
    public class FurnitureList : MonoBehaviour
    {
        [SerializeField] private List<GameObject> _furnitureList;
        [SerializeField] private Vector3 _scale;

        [FormerlySerializedAs("_furnitureListElementTemplate")] [SerializeField]
        private GameObject _furnitureListElementPrefab;

        [SerializeField] private float _padding;

        private List<GameObject> _preparedFurnitureList;
        
        public TextMeshPro DebugText; 

        private void Start()
        {
            var index = 0;
            foreach (var furniture in _furnitureList)
            {

                GameObject element = Instantiate(_furnitureListElementPrefab, transform);
                element.transform.localPosition = new Vector3(-index * _padding, 0, 0);
                FurnitureListElement furnitureListElement = element.GetComponent<FurnitureListElement>();
                furnitureListElement.FurniturePrefab = furniture;
                furnitureListElement.Scale = _scale;
                furnitureListElement.NewObjectScale = new Vector3(0.8f, 0.8f, 0.8f);
                furnitureListElement.PrepareObject();
                index++;
            }
        }
        

    }
}

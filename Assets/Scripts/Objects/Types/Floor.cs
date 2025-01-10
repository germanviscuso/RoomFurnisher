using Meta.XR.MRUtilityKit;
using UnityEngine;

namespace Types
{
    public class Floor : MonoBehaviour
    {
        [Header("Materials")]
        [SerializeField] private Material _invisibleMaterial;
        [SerializeField] private Material _defaultMaterial;
        
        private Material _visibleMaterial;
        
        private void Start()
        {
            _visibleMaterial = new Material(_defaultMaterial);
        } 
        
        public void SetVisible(bool visible)
        {
            gameObject.GetComponent<MeshRenderer>().enabled = visible;

            /*
            gameObject.GetComponent<MeshRenderer>().material = visible ? _visibleMaterial : _invisibleMaterial;
        */
        }
    }
}

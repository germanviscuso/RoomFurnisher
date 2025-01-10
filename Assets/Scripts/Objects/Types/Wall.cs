using UnityEngine;

namespace Types
{
    public class Wall : MonoBehaviour
    {
        [Header("Materials")]
        [SerializeField] private Material _invisibleMaterial;
        [SerializeField] private Color _color;
        [SerializeField] private Material _defaultMaterial;
        
        private Material _visibleMaterial;
        
        private void Start()
        {
            _visibleMaterial = new Material(_defaultMaterial)
            {
                color = _color
            };
        } 
        
        public void SetVisible(bool visible)
        {
            gameObject.GetComponent<MeshRenderer>().enabled = visible;
            /*
            gameObject.GetComponent<MeshRenderer>().material = visible ? _visibleMaterial : _invisibleMaterial;
        */
        }
        
        public void ChangeColor(Color color)
        {
            gameObject.GetComponent<MeshRenderer>().material.color = color;
            _visibleMaterial.color = color;
        }
    }
}

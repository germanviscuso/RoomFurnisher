using UnityEngine;

namespace Types
{
    public class Window : MonoBehaviour
    {
        /*[Header("Materials")]
        [SerializeField] private Material _invisibleMaterial;
        [SerializeField] private Material _defaultMaterial;*/
        
        private Material _visibleMaterial;
        
        private void Start()
        { 
            gameObject.SetActive(true);
        } 
        
        public void SetVisible(bool visible)
        {
            gameObject.SetActive(visible);
        }
    }
}

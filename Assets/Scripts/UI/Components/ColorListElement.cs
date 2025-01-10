using UnityEngine;
using UnityEngine.Events;

namespace UI.Components
{
    public class ColorListElement : MonoBehaviour
    {
        public UnityEvent<ColorListElement> OnColorSelected = new ();

        private void OnTriggerEnter(Collider other)
        {
            OnColorSelected.Invoke(this);
        }
    }
}

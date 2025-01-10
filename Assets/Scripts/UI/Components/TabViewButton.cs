using UnityEngine;
using UnityEngine.Serialization;

namespace UI.Components
{
    public class TabViewButton : MonoBehaviour
    {
        public PointableButton PointableButton;

        private void Awake()
        {
            PointableButton = GetComponentInChildren<PointableButton>();
        }
    }
}

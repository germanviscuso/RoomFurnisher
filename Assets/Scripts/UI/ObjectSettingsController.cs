using System.Collections;
using System.Collections.Generic;
using Oculus.Interaction;
using TMPro;
using UI.Components;
using UnityEngine;

public class ObjectSettingsController : MonoBehaviour
{
    [SerializeField] private PointableButton _deleteButton;
    [SerializeField] private bool _isLamp;
    
    [SerializeField] private PointableButton _LightSwitchButton;
    [SerializeField] private TextMeshPro _LightSwitchText;

    private readonly string _onText = "ON";
    private readonly string _offText = "OFF";
    
    private CameraObjectToTrack _cameraObjectToTrack;
    // Start is called before the first frame update
    void Start()
    {
        _cameraObjectToTrack = FindObjectOfType<CameraObjectToTrack>();
        _deleteButton.AddReleaseListener(HandleDeleteButton);
        if (_isLamp)
        {
            StartingSetup();
        }
    }

    private void HandleDeleteButton(PointerEvent arg0)
    {
        Destroy(gameObject.GetComponentInParent<BaseObject>().gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        // Calculate the direction from the camera to the object <- menu's forward is facing opposite direction then expected
        Vector3 direction = transform.position - _cameraObjectToTrack.transform.position;
        // Keep only the Y component of the direction
        direction.y = 0;

        // Check if the direction is not zero to avoid errors
        if (direction != Vector3.zero)
        {
            transform.rotation = Quaternion.LookRotation(direction);
        }
    }
    
    private void StartingSetup()
    {
        _LightSwitchText.text = _offText;
        _LightSwitchButton.AddReleaseListener(LightSwitch);
    }

    private void LightSwitch(PointerEvent arg0)
    {
        if (_LightSwitchText.text == _offText)
        {
            _LightSwitchText.text = _onText;
            gameObject.GetComponentInParent<BaseObject>().gameObject.GetComponentInChildren<Light>().enabled = true;
        }
        else
        {
            _LightSwitchText.text = _offText;
            gameObject.GetComponentInParent<BaseObject>().gameObject.GetComponentInChildren<Light>().enabled = false;
        }
    }
}

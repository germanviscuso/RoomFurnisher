using System;
using System.Collections;
using System.Collections.Generic;
using Oculus.Interaction;
using TMPro;
using UI.Components;
using UnityEngine;
using UnityEngine.Events;
using Utils;

public class ObjectController : MonoBehaviour
{
    // Add hand grab controller later
    private DistanceGrabController _distanceGrabController;   
    private SelectController _selectController;

    private bool _isBeingHold;
    private bool _isBeingHover;
    
    private GameObject _heldObject;
    private ObjectType _objectType;
    private HandType _handType;
    private string _objectName;
    private string _objectId;
    
    private ObjectInfo _objectInfo;
    
    
    [SerializeField] private TextMeshPro _text;
    
    [SerializeField] private Material _materialHover;
    [SerializeField] private Material _materialHold;
    
    public UnityEvent<ObjectInfo> OnObjectSelected = new UnityEvent<ObjectInfo>();
    private float _rotationSpeed = 60f; // Adjust rotation speed as needed
    private CameraObjectToTrack _cameraObjectToTrack;
    
    private float _rotationX;
    private float _positionAxisCameraTarget;
    private float _positionAxisLeftRight;
    
    private void Awake()
    {
        _distanceGrabController = GetComponent<DistanceGrabController>();
        _cameraObjectToTrack = FindObjectOfType<CameraObjectToTrack>();
    }
    void Start()
    {
        _distanceGrabController.OnActionTriggered.AddListener(OnActionTriggered);
    }
private void Update()
{
    if (_isBeingHover)
    {
        _heldObject.transform.rotation = Quaternion.Euler(0, _heldObject.transform.rotation.eulerAngles.y, 0);

        switch (_handType)
        {
            case HandType.Left:
                _rotationX = OVRInput.Get(OVRInput.Axis2D.SecondaryThumbstick).x;
                _positionAxisCameraTarget = OVRInput.Get(OVRInput.Axis2D.PrimaryThumbstick).y;
                _positionAxisLeftRight = OVRInput.Get(OVRInput.Axis2D.PrimaryThumbstick).x;
                break;

            case HandType.Right:
                _rotationX = OVRInput.Get(OVRInput.Axis2D.PrimaryThumbstick).x;
                _positionAxisCameraTarget = OVRInput.Get(OVRInput.Axis2D.SecondaryThumbstick).y;
                _positionAxisLeftRight = OVRInput.Get(OVRInput.Axis2D.SecondaryThumbstick).x;
                break;
        }

        // Use the dynamic action button based on the hand type
        if (OVRInput.GetDown(GetActionButton(_handType)))
        {
            var showSettingsCurrent = _heldObject.GetComponentInChildren<BaseObject>().ShowSettings;
            _heldObject.GetComponentInChildren<BaseObject>().ShowSettings = !showSettingsCurrent;
        }

        // Check if there's significant input to rotate the object
        if (Mathf.Abs(_rotationX) > 0.1f)
        {
            // Rotate object around the Y axis based on thumbstick input
            _heldObject.transform.Rotate(Vector3.up, _rotationX * _rotationSpeed * Time.deltaTime);
        }

        // Check if there's significant input to move the object
        if (Mathf.Abs(_positionAxisCameraTarget) > 0.1f)
        {
            Vector3 moveDirection = _heldObject.transform.position - _cameraObjectToTrack.transform.position;
            moveDirection.y = 0;
            moveDirection.Normalize();
            _heldObject.transform.position += moveDirection * _positionAxisCameraTarget * Time.deltaTime;
        }

        // Check if there's significant input to move the object left or right
        if (Mathf.Abs(_positionAxisLeftRight) > 0.1f)
        {
            Vector3 moveDirection = _cameraObjectToTrack.transform.right;
            moveDirection.y = 0;
            moveDirection.Normalize();
            _heldObject.transform.position += moveDirection * _positionAxisLeftRight * Time.deltaTime;
        }
    }
}
    /*private void Update()
    {
        if ( _isBeingHover)
        {
            _heldObject.transform.rotation = Quaternion.Euler(0, _heldObject.transform.rotation.eulerAngles.y, 0);
    
            switch (_handType)
            { 
                case HandType.Left:
                    _rotationX = OVRInput.Get(OVRInput.Axis2D.SecondaryThumbstick).x;
                    _positionAxisCameraTarget = OVRInput.Get(OVRInput.Axis2D.PrimaryThumbstick).y;
                    _positionAxisLeftRight = OVRInput.Get(OVRInput.Axis2D.PrimaryThumbstick).x;
                    break;

                case HandType.Right:
                    _rotationX = OVRInput.Get(OVRInput.Axis2D.PrimaryThumbstick).x;
                    _positionAxisCameraTarget = OVRInput.Get(OVRInput.Axis2D.SecondaryThumbstick).y;
                    _positionAxisLeftRight = OVRInput.Get(OVRInput.Axis2D.SecondaryThumbstick).x;
                    break;
            }
            
            if (OVRInput.GetDown(OVRInput.Button.Three))
            {
                var showSettingsCurrent = _heldObject.GetComponentInChildren<BaseObject>().ShowSettings;
                _heldObject.GetComponentInChildren<BaseObject>().ShowSettings = !showSettingsCurrent;
            }
            
            // Check if there's significant input to rotate the object
            if (Mathf.Abs(_rotationX) > 0.1f)
            {
                // Rotate object around the Y axis based on thumbstick input
                _heldObject.transform.Rotate(Vector3.up, _rotationX * _rotationSpeed * Time.deltaTime);
            }
                    
            // Check if there's significant input to move the object
            if (Mathf.Abs(_positionAxisCameraTarget) > 0.1f)
            {
                //Move object closer or further away based on thumbstick input
                // if thumbstick is pushed up, move object further away from the camera
                // if thumbstick is pushed down, move object closer to the camera
                        
                Vector3 moveDirection = _heldObject.transform.position - _cameraObjectToTrack.transform.position;
                moveDirection.y = 0;
                moveDirection.Normalize();
                _heldObject.transform.position += moveDirection * _positionAxisCameraTarget * Time.deltaTime;
            }
            
            // Check if there's significant input to move the object left or right
            if (Mathf.Abs(_positionAxisLeftRight) > 0.1f)
            {
                //Move object left or right based on thumbstick input
                // if thumbstick is pushed right, move object to the right base on camera view
                // if thumbstick is pushed left, move object to the left based on camera view
                        
                Vector3 moveDirection = _cameraObjectToTrack.transform.right;
                moveDirection.y = 0;
                moveDirection.Normalize();
                _heldObject.transform.position += moveDirection * _positionAxisLeftRight * Time.deltaTime;
            }
        }

    }*/

    private void OnActionTriggered(ObjectInfo objectInfo, ActionType actionType)
    {
        switch (actionType)
        {
            case ActionType.Hold:
                OnActionHold();
                break;
            case ActionType.Hover:
                OnActionHover(objectInfo);
                break;
            case ActionType.None:
                OnActionNone();
                break;
        }
    }

    private void OnActionNone()
    {
        ResetObject();
    }
    
    private OVRInput.Button GetActionButton(HandType handType)
    {
        return handType == HandType.Left ? OVRInput.Button.PrimaryIndexTrigger : OVRInput.Button.SecondaryIndexTrigger;
    }

    private void OnActionHover(ObjectInfo objectInfo)
    {
        SetObjectInfo(objectInfo);
        _isBeingHover = true;
        _isBeingHold = false;
        _text.text = "Hovering: " + _objectName + " ," + _objectType + "object, with " + _handType + " hand";
        /*
        _heldObject.GetComponent<MeshRenderer>().material = _materialHover;
    */
    }

    private void OnActionHold()
    {
        _isBeingHold = true;
        _isBeingHover = false;
        /*
        _heldObject.GetComponent<MeshRenderer>().material = _materialHold;
        */
        _text.text = "Holding: "+ _objectName + " ," + _objectType + "object, with " + _handType + " hand";
    }
    
    private void SetObjectInfo(ObjectInfo objectInfo)
    {
        _objectInfo = objectInfo;
        _objectName = objectInfo.ObjectName;
        _objectType = objectInfo.GetObjectType();
        _heldObject = objectInfo.GetObject();
        _handType = objectInfo.GetHandType();
        _heldObject.transform.SetParent(_distanceGrabController.transform);
        _objectId = _heldObject.GetComponent<BaseObject>().GetGlobalID();
    }
    
    private void ResetObject()
    {
        _isBeingHold = false;
        _isBeingHover = false;
        /*
        _heldObject.GetComponent<MeshRenderer>().material = _objectType == ObjectType.Big ? _materialBig : _materialSmall;
    */
    }

    private void OnDestroy()
    {
        _distanceGrabController.OnActionTriggered.RemoveListener(OnActionTriggered);
    }
}

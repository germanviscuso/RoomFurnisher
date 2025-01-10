using System;
using System.Collections.Generic;
using Oculus.Interaction;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using Utils;

public class DistanceGrabController : MonoBehaviour
{
    private bool _isBeingHover;
    private bool _isBeingHold;
    private bool _isNormal;

    private bool _wasEventSentHold;
    private bool _wasEventSentHover;
    private bool _wasEventSentNone;
    
    private HandType _handType;
    private ObjectType _objectType;
    private GameObject _object;
    private string _objectId;
    
    private GameObject _previousObject;
    private string _previousObjectId;
    
    [SerializeField] private GameObject ControllerInteractor;
    
    private DistanceGrabInteractor _controllerInteractor;

        
    public UnityEvent<ObjectInfo, ActionType> OnActionTriggered = new ();
    void Start()
    {
        _controllerInteractor = ControllerInteractor.GetComponent<DistanceGrabInteractor>();
        
        _handType = GetHandType();
        
        _wasEventSentHold = false;
        _wasEventSentHover = false;
        _wasEventSentNone = true;

    }

    private void FixedUpdate()
    {
        /*;
        if (_object.GetComponent<BaseObject>().GetGlobalID() != _previousObject.GetComponent<BaseObject>().GetGlobalID())
        {
            ResetEvents();
        }*/

        // Check state of the grabber
        _isBeingHover = _controllerInteractor.State == InteractorState.Hover;
        _isBeingHold = _controllerInteractor.State == InteractorState.Select;
        _isNormal = _controllerInteractor.State == InteractorState.Normal;
    }

    void Update()
    {
        
        if (_isBeingHold || _isBeingHover)
        {
            _object = _controllerInteractor.DistanceInteractable.RelativeTo.gameObject
                .GetComponentInParent<BaseObject>().gameObject;
            _objectId = _object.GetComponent<BaseObject>().GetGlobalID();
            _objectType = GetObjectType(_object);

            if (_previousObjectId is not null && _previousObjectId != _objectId)
            {
                OnActionTriggered.Invoke(new ObjectInfo(GetObjectType(_previousObject), _handType, _previousObject, _previousObject?.name), ActionType.None);
                ResetEvents(); 
            }
            
        }

        if (_isBeingHover && !_wasEventSentHover)
        {
            _objectType = GetObjectType(_object);
            OnActionTriggered.Invoke(new ObjectInfo(_objectType, _handType, _object, _object?.name), ActionType.Hover);
            _wasEventSentNone = false;
            _wasEventSentHover = true;
            _wasEventSentHold = false;
        } 
        
        if (_isNormal && !_wasEventSentNone)
        {
            OnActionTriggered.Invoke(new ObjectInfo(GetObjectType(_previousObject), _handType, _previousObject, _previousObject?.name), ActionType.None);
            _wasEventSentHover = false;
            _wasEventSentNone = true;
            _wasEventSentHold = false;
        }
        
        if (_isBeingHold && !_wasEventSentHold)
        {
            Debug.Log("Object is being hold");
            OnActionTriggered.Invoke(new ObjectInfo(_objectType, _handType, _object, _object?.name), ActionType.Hold);
            _wasEventSentHold = true;
            _wasEventSentHover = false;
            _wasEventSentNone = false;
        }
        
        _previousObject = _object;
        _previousObjectId = _objectId;
        
    }
    
    private HandType GetHandType()
    {
        return GetComponent<Left>() ? HandType.Left : HandType.Right;
    }
    
    private static ObjectType GetObjectType(GameObject heldObject)
    {
        return heldObject.GetComponent<Big>() ? ObjectType.Big : ObjectType.Small;
    }
    
    private void ResetEvents()
    {
        _wasEventSentHover = false;
        _wasEventSentNone = false;
        _wasEventSentHold = false;
    }
}
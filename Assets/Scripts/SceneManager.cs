using System;
using System.Collections.Generic;
using Meta.XR.MRUtilityKit;
using Oculus.Interaction;
using TMPro;
using UI;
using UnityEngine;
using UnityEngine.Events;

public class SceneManager : MonoBehaviour
{
    [SerializeField] private DistanceGrabInteractor _distanceGrabInteractorLeft;
    [SerializeField] private DistanceGrabInteractor _distanceGrabInteractorRight;
    [SerializeField] private WholeUIController _wholeUIController;
    [SerializeField] private TextMeshPro _debugText;
    [SerializeField] private GameObject _roomManager;
    [SerializeField] private MRUK _mruk;
    
    public MRUKRoom CurrentRoom { get; private set; }
    private void Awake()
    {
        _mruk.RegisterSceneLoadedCallback(OnSceneLoaded);
        Debug.Log("Scene manager awake");
    }

    private void OnSceneLoaded()
    {
        CurrentRoom = _mruk.GetCurrentRoom();
        Instantiate(_roomManager);
        Debug.Log("Scene manager scene loaded. Created room manager");
    }

    private void Update()
    {
        if (_wholeUIController.IsTutorialActive() || _wholeUIController.IsMenuActive())
        {
            _distanceGrabInteractorLeft.gameObject.SetActive(false);
            _distanceGrabInteractorRight.gameObject.SetActive(false);
        }
        else
        {
            _distanceGrabInteractorLeft.gameObject.SetActive(true);
            _distanceGrabInteractorRight.gameObject.SetActive(true);
        }
    }
    
}
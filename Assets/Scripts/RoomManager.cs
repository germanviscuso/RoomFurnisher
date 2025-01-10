using System;
using System.Collections;
using System.Collections.Generic;
using Meta.XR.MRUtilityKit;
using Types;
using UnityEngine;

public class RoomManager : MonoBehaviour
{
    /*
    [SerializeField] private AnchorPrefabSpawner _anchorPrefabSpawner;
    */
    private Wall[] _walls;
    private Floor _floor;
    private Door[] _doors;
    private Window[] _windows;
    private MRUKRoom _currentRoom;
    
    [SerializeField] 
    private GameObject _furnitureMeshEffectMesh;

    private void Start()
    {
        Debug.Log("Room manager start");
        Instantiate(_furnitureMeshEffectMesh);
        DisplayFurnitureMesh(false);
    }
    
    public void ShowWalls()
    {
        /*
        _walls = FindObjectsOfType<Wall>();
        */
        Debug.Log("Show walls");
        foreach (var wall in _walls)
        {
            wall.SetVisible(true);
        }
    }
    
    public void HideWalls()
    {
        _walls = FindObjectsOfType<Wall>();
        Debug.Log("Hide walls");
        foreach (var wall in _walls)
        {
            wall.SetVisible(false);
        }
    }
    
    public void ShowFloor()
    {
        _floor.SetVisible(true);
    }
    
    public void HideFloor()
    {
        _floor = FindObjectOfType<Floor>();
        _floor.SetVisible(false);
    }
    
    public void ShowDoors()
    {
        foreach (var door in _doors)
        {
            door.SetVisible(true);
        }
    }
    
    public void HideDoors()
    {
        _doors = FindObjectsOfType<Door>();
        foreach (var door in _doors)
        {
            door.SetVisible(false);
        }
    }
    
    public void ShowWindows()
    {
        foreach (var window in _windows)
        {
            window.SetVisible(true);
        }
    }
    
    public void HideWindows()
    {
        _windows = FindObjectsOfType<Window>();
        foreach (var window in _windows)
        {
            window.SetVisible(false);
        }
    }
    
    public void DisplayFurnitureMesh(bool isOn = true)
    {
        var anchors = MRUK.Instance.GetCurrentRoom().Anchors;
        Debug.Log("Display furniture mesh");
        Debug.Log(anchors.Count);
        foreach (var anchor in anchors)
        {
            if (anchor.Label != MRUKAnchor.SceneLabels.FLOOR && anchor.Label != MRUKAnchor.SceneLabels.CEILING 
                                                             && anchor.Label != MRUKAnchor.SceneLabels.WALL_FACE 
                                                             && anchor.Label != MRUKAnchor.SceneLabels.DOOR_FRAME
                                                             && anchor.Label != MRUKAnchor.SceneLabels.WINDOW_FRAME)
            {
                anchor.gameObject.SetActive(isOn);

            }
        }
    }
}

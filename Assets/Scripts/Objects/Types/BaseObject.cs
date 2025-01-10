using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class BaseObject : MonoBehaviour
{
    [FormerlySerializedAs("globalID")] public string GlobalID;
    [SerializeField] private ObjectController[] _objectControllers;
    public bool ShowSettings;
    
    private GameObject _settings;
    
    void Start()
    {
        GlobalID = System.Guid.NewGuid().ToString();
        FindControllers();
        ShowSettings = false;
        _settings = gameObject.GetComponentInChildren<ObjectSettingsController>().gameObject;
    }   
    
    void Update()
    {
        if (_objectControllers.Length == 0)
        {
            FindControllers();
        }

        if (transform.position.y < -10)
        {
            Destroy(gameObject);
        }

        _settings.SetActive(ShowSettings);
    }
    
    void FindControllers()
    {
        _objectControllers = FindObjectsOfType<ObjectController>();
        foreach (var controller in _objectControllers)
        {
            controller.OnObjectSelected.AddListener(OnObjectSelected);
        }
    }
    

    private void OnObjectSelected(ObjectInfo info)
    {
        if (info.GetObject().GetComponent<BaseObject>().GetGlobalID() == GlobalID)
        {
            Debug.Log("Object selected: " + GlobalID);
        }
    }

    public string GetGlobalID()
    {
        return GlobalID;
    }
    
}

using UnityEngine;
using Utils;

public class ObjectInfo
{
    private ObjectType ObjectType { get; set; }
    private HandType HandType { get; set; }
    private GameObject Object { get; set; }
    public string ObjectName { get; private set; }
    
    public ObjectInfo(ObjectType objectType, HandType handType, GameObject gameObject, string objectName)
    {
        ObjectType = objectType;
        HandType = handType;
        Object = gameObject;
        ObjectName = objectName;
    }
    
    public ObjectType GetObjectType()
    {
        return ObjectType;
    }
    
    public HandType GetHandType()
    {
        return HandType;
    }
    
    public GameObject GetObject()
    {
        return Object;
    }
}

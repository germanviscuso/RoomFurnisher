using System;
using Oculus.Interaction;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;

namespace UI.Components
{
    public class FurnitureListElement : MonoBehaviour
    {
        [FormerlySerializedAs("Furniture")] public GameObject FurniturePrefab;
        public Vector3 Scale;
        public Vector3 NewObjectScale;

        public GameObject Furniture;
        
        private TextMeshPro _text;

        private void Start()
        {
            _text = gameObject.GetComponentInParent<FurnitureList>().DebugText;
        }
        
        // Start is called before the first frame update
        void Update()
        {
            if (Furniture == null) return;
            Furniture.transform.Rotate(new Vector3(0, 10, 0) * Time.deltaTime);
        }
        
        private void OnTriggerEnter(Collider other) 
        {
            if (!other.gameObject.GetComponent<ControllerCollider>()) return;
            Debug.Log(other.gameObject.name);
            _text.text = Furniture.name + " collided with " + other.gameObject.name;
            CreateFurnitureFromList();
        }

        public void PrepareObject()
        {
            Furniture = Instantiate(FurniturePrefab, transform);
            Furniture.GetComponent<Rigidbody>().useGravity = false;
            Furniture.GetComponent<Rigidbody>().isKinematic = true;
            Furniture.GetComponent<BoxCollider>().enabled = true;
            Furniture.GetComponent<BoxCollider>().isTrigger = false;
            Furniture.GetComponent<MeshCollider>().enabled = false;
            Furniture.transform.localScale = Scale;
            Furniture.transform.rotation = Quaternion.identity;
            DisableGrabbing(Furniture);
        }

        public void DisableGrabbing(GameObject furniture)
        {
           furniture.GetComponentInChildren<Grabbable>().gameObject.SetActive(false);
        }
    
        public void EnableGrabbing(GameObject furniture)
        {
            furniture.GetComponentInChildren<Grabbable>().gameObject.SetActive(true);
        }
    
        public void CreateFurnitureFromList()
        {
            GameObject cameraToTrack = FindObjectOfType<CameraObjectToTrack>().gameObject;
            Vector3 spawnPosition = cameraToTrack.transform.position + cameraToTrack.transform.forward * 0.8f;
            spawnPosition.y = 0.5f;
        
            GameObject f = Instantiate(FurniturePrefab, spawnPosition, Quaternion.identity);
            f.transform.localScale = NewObjectScale;
            f.GetComponent<Rigidbody>().useGravity = true;
            f.GetComponent<Rigidbody>().isKinematic = false;
            f.GetComponent<BoxCollider>().enabled = true;
            EnableGrabbing(f);
        }
    }
}

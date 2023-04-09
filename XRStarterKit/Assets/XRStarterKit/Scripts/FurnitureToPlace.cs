using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FurnitureToPlace : MonoBehaviour
{
    public GameObject parentObject; // the object to which you want to add the prefab
    public GameObject prefab; // the prefab you want to add as a child

    void Start()
    {
        GameObject childObject = Instantiate(prefab, parentObject.transform); // instantiate the prefab as a child of the parentObject
    }
}

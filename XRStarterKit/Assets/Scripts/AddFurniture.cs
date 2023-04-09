using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AddFurniture : MonoBehaviour
{
    public GameObject furnitureToAdd;

    public void OnButtonClick()
    {
        SceneManager.LoadScene("ARBasic"); // load Scene A

        SceneManager.sceneLoaded += OnSceneLoaded; // subscribe to the sceneLoaded event
    }
    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        GameObject groundPlane = GameObject.Find("Ground Plane Stage"); // find the "Ground Plane Stage" object
        if (groundPlane != null)
        {
            GameObject childObject = Instantiate(furnitureToAdd, groundPlane.transform); // instantiate the prefab as a child of the "Ground Plane Stage"
        }

        SceneManager.sceneLoaded -= OnSceneLoaded; // unsubscribe from the sceneLoaded event
    }
}
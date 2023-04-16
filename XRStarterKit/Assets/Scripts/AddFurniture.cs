using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AddFurniture : MonoBehaviour
{

    // Reference to the furniture prefab you want to place in AR

    // Function called when the button is clicked
    public void OnButtonClick(GameObject furniturePrefab)
    {
        FurnitureController.FurnitureToPlace = furniturePrefab;
        // Load the ARBasic scene
        SceneManager.LoadScene("ARBasic");
    }
}


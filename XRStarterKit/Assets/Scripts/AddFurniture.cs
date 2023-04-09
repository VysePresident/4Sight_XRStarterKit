using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AddFurniture : MonoBehaviour
{
    public GameObject furnitureToAdd;

    public void OnButtonClick()
    {
        SceneManager.LoadScene("ARBasic");
        for(int i = 0; i < 3; i++)
            Instantiate(furnitureToAdd);
    }
}
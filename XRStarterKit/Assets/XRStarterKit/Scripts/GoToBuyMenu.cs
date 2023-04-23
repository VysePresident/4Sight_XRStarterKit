using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GoToBuyMenu : MonoBehaviour
{
    public void onClick() {
        Debug.Log("Going to Buy Menu");
        SceneManager.LoadScene("BuyMenuScene");

        // foreach(GameObject element in BuyManagerScript.Elements) 
        // {
        //     if (element.transform.GetChild(5).GetComponent<TextMeshPro>().text != "")
        //     {
        //         element.SetActive(false);
        //     }
        //     else {
        //         element.SetActive(true);
        //     }
        // }
    }
}

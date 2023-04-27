using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeleteCart : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void EmptyCart()
    {
        int totalElements = BuyManagerScript.NumBought.Length;
        BuyManagerScript.NumBought = "";

        for (int i =0; i < totalElements; i++) 
        {
            BuyManagerScript.NumBought = BuyManagerScript.NumBought + "0";
        }
        BuyManagerScript.TotalCost = 0;
        SceneManager.LoadScene("BuyMenuScene");

    }
}

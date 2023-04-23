using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;
using System.Text;

public class BuyManagerScript : MonoBehaviour
{
    public GameObject ContentHolder;
    public GameObject[] Elements;
    public static string NumBought;
    public static float TotalCost = 0;

    // Start is called before the first frame update
    void Start()
    {
        int totalElements = ContentHolder.transform.childCount;
        Elements = new GameObject[totalElements];
        NumBought = "";

        for (int i =0; i < totalElements; i++) 
        {
            NumBought = NumBought + "0";
            Elements[i] = ContentHolder.transform.GetChild(i).gameObject;
        }
    }

    public void Buy(GameObject ObjectBought)
    {
        String adding = (int.Parse(NumBought[Array.IndexOf(Elements, ObjectBought)].ToString()) + 1).ToString();
        NumBought =  NumBought.Remove(Array.IndexOf(Elements, ObjectBought), 1).Insert(Array.IndexOf(Elements, ObjectBought), adding);
        TotalCost = TotalCost + float.Parse(ObjectBought.transform.GetChild(3).GetComponent<TextMeshProUGUI>().text.Substring(1));
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BuySceneSetup : MonoBehaviour
{
    public GameObject ContentHolder;
    public GameObject PriceSection;
    public GameObject[] Elements;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(BuyManagerScript.TotalCost);
        int totalElements = ContentHolder.transform.childCount;
        Elements = new GameObject[totalElements];

        for (int i =0; i < totalElements; i++) 
        {
            Elements[i] = ContentHolder.transform.GetChild(i).gameObject;

            if (BuyManagerScript.NumBought[i] == '0')
            {
                Elements[i].SetActive(false);
                Elements[i].transform.GetChild(3).GetComponent<TextMeshProUGUI>().text = "0";
            }
            else
            {
                Elements[i].SetActive(true);
                Elements[i].transform.GetChild(3).GetComponent<TextMeshProUGUI>().text = BuyManagerScript.NumBought[i].ToString();
            }
        }

        PriceSection.transform.GetChild(2).GetComponent<TextMeshProUGUI>().text = "$" + BuyManagerScript.TotalCost.ToString();



    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

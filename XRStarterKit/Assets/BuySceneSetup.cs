using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BuySceneSetup : MonoBehaviour
{
    public GameObject ContentHolder;
    public GameObject[] Elements;

    // Start is called before the first frame update
    void Start()
    {
        int totalElements = ContentHolder.transform.childCount;
        Elements = new GameObject[totalElements];

        for (int i =0; i < totalElements; i++) 
        {
            Elements[i] = ContentHolder.transform.GetChild(i).gameObject;
            Debug.Log(Elements[i].transform.GetChild(3).GetComponent<TextMeshProUGUI>().text);

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

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

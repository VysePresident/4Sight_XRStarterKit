using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ModifyCount : MonoBehaviour
{
    public GameObject PriceSection;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Increment(GameObject Element)
    {
        Debug.Log("CLICKED INCREMENT");
        float price = float.Parse(Element.transform.GetChild(2).GetComponent<TextMeshProUGUI>().text.Substring(1));
        GameObject Count = Element.transform.GetChild(3).gameObject;

        Count.GetComponent<TextMeshProUGUI>().text = (int.Parse(Count.GetComponent<TextMeshProUGUI>().text) + 1).ToString();

        float newPrice = float.Parse(PriceSection.transform.GetChild(2).GetComponent<TextMeshProUGUI>().text.Substring(1)) + price;

        PriceSection.transform.GetChild(2).GetComponent<TextMeshProUGUI>().text = "$" + newPrice.ToString();

    }

    public void Decrement(GameObject Element)
    {
        Debug.Log("CLICKED DECREMENT");
        float price = float.Parse(Element.transform.GetChild(2).GetComponent<TextMeshProUGUI>().text.Substring(1));
        GameObject Count = Element.transform.GetChild(3).gameObject;

        Count.GetComponent<TextMeshProUGUI>().text = (int.Parse(Count.GetComponent<TextMeshProUGUI>().text) - 1).ToString();

        float newPrice = float.Parse(PriceSection.transform.GetChild(2).GetComponent<TextMeshProUGUI>().text.Substring(1)) - price;

        PriceSection.transform.GetChild(2).GetComponent<TextMeshProUGUI>().text = "$" + newPrice.ToString();
        if (Count.GetComponent<TextMeshProUGUI>().text == "0")
        {
            Element.SetActive(false);
        }
    }
}

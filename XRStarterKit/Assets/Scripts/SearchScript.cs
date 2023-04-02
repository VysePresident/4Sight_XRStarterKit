using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SearchScript : MonoBehaviour
{
    public GameObject ContentHolder;
    public GameObject[] Elements;
    public GameObject SearchBar;
    public int totalElements;

    // Start is called before the first frame update
    void Start()
    {
        totalElements = ContentHolder.transform.childCount;
        Elements = new GameObject[totalElements];

        for (int i =0; i < totalElements; i++) 
        {
            Elements[i] = ContentHolder.transform.GetChild(i).gameObject;
        }
    }

    public void Search()
    {
        foreach (GameObject element in Elements)
        {
            Debug.Log(element.transform.GetChild(2).GetComponent<TextMeshProUGUI>().text);
            element.SetActive(true);
        }
        
        string SearchText = SearchBar.GetComponent<TMP_InputField>().text.ToLower();

        foreach (GameObject element in Elements)
        {
            if (!(element.transform.GetChild(2).GetComponent<TextMeshProUGUI>().text.ToLower().Contains(SearchText)))
            {
                element.SetActive(false);
            }
        }

        SearchBar.GetComponent<TMP_InputField>().text = "";
    }
}

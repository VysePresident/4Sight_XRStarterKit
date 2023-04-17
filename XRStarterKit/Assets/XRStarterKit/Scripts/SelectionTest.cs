using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectionTest : MonoBehaviour
{
    public bool idle;           // The object is not selected
    public bool selected;       // The object is selected

    public Material originalMaterial;
    public Material selectedMaterial;
    public GameObject childObject;


    void Start()
    {
        idle = true;
        selected = false;
    }

    void Update()
    {
        if (idle)
        {
            if (Input.GetMouseButtonDown(0) && IsMouseOver())
            {
                Select();
            }
        }
        if (selected)
        {
            if (Input.GetMouseButtonDown(0) && !IsMouseOver())
            {
                Deselect();
            }
        }
    }

    void OnMouseOver()
    {
        if (idle)
        {
            if (Input.GetMouseButtonDown(0) && IsMouseOver())
            {
                Select();
            }
        }
    }

    void OnMouseExit()
    {
        if (selected)
        {
            if (Input.GetMouseButtonDown(0) && IsMouseOver())
            {
                Deselect();
            }
        }
    }

    private bool IsMouseOver()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        bool isMouseOver = Physics.Raycast(ray, out hit) && hit.transform == this.transform;
        if (isMouseOver)
        {
            Debug.Log("Mouse is over child object");
        }
        return isMouseOver;
    }

    // Functions for Selection
    void Deselect()
    {
        idle = true;
        selected = false;

        childObject.GetComponent<Renderer>().material = originalMaterial;
    }

    void Select()
    {
        idle = false;
        selected = true;

        childObject.GetComponent<Renderer>().material = selectedMaterial;
    }
}

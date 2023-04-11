using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectionTest : MonoBehaviour
{
    public bool idle;           // The object is not selected
    public bool selected;       // The object is selected
    public bool moving;           // The object is being moved
    public bool rotating;         // The object is being rotated

    public Material originalMaterial;
    public Material selectedMaterial;
    public GameObject childObject;


    void Start()
    {
        idle = true;
        selected = false;
        moving = false;
        rotating = false;
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
        moving = false;
        rotating = false;

        childObject.GetComponent<Renderer>().material = originalMaterial;
    }

    void Select()
    {
        idle = false;
        selected = true;
        moving = false;
        rotating = false;

        childObject.GetComponent<Renderer>().material = selectedMaterial;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Microsoft.MixedReality.Toolkit.UI;
using Microsoft.MixedReality.Toolkit.UI.BoundsControl;
using Normal.Realtime;

public class SelectionTest : MonoBehaviour
{
    public bool idle = true;            // The object is not selected
    public bool selected = false;       // The object is selected

    public Material originalMaterial;
    public Material selectedMaterial;
    public Material cantSelectMaterial;
    public GameObject childObject;


    public RealtimeView realtimeView;
    public RealtimeTransform realtimeTransform;

	public GameObject submenuPrefab;
	private GameObject submenuInstance;

	public string RT;

    void Start()
    {
		if (submenuInstance != null)
		{
            Debug.Log("submenu is not null, destroy");
			Destroy(submenuInstance);
		}
		submenuInstance = null;
	}

	void Update()
    {
		if (idle)
        {
            if (Input.GetMouseButtonDown(0) && IsMouseOver())
            {
                Select();
            }
            
            if (realtimeTransform.isOwnedRemotely)
            {
                childObject.GetComponent<Renderer>().material = cantSelectMaterial;
            }
            else
            {
                childObject.GetComponent<Renderer>().material = originalMaterial;
            }
        }
        if (selected)
        {
            if (Input.GetMouseButtonDown(0) && !IsMouseOver() /*&& realtimeTransform.isOwnedRemotely*/)
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
            if (Input.GetMouseButtonDown(0) && !IsMouseOver() /*&& realtimeTransform.isOwnedRemotely*/)
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


        realtimeView.ClearOwnership();
        realtimeView.preventOwnershipTakeover = false;
        realtimeTransform.ClearOwnership();
        RT = realtimeTransform.ownerID.ToString();

		if (submenuInstance != null)
		{
			Destroy(submenuInstance);
			submenuInstance = null;
		}

	}


	void Select()
	{
		idle = false;
		selected = true;

		childObject.GetComponent<Renderer>().material = selectedMaterial;

        realtimeView.RequestOwnership();
        realtimeView.preventOwnershipTakeover = true;
        realtimeTransform.RequestOwnership();
        RT = realtimeTransform.ownerID.ToString();

		if (submenuInstance == null)
		{
			submenuInstance = Instantiate(submenuPrefab);
			//submenuInstance.transform.SetParent(childObject.transform);
		}
	}

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Microsoft.MixedReality.Toolkit.UI;
using Microsoft.MixedReality.Toolkit.UI.BoundsControl;
using Normal.Realtime;
using UnityEngine.EventSystems;

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

	// Add fields for furniture details
	public string furnitureName;
	public string furnitureDescription;
	public float furniturePrice;

	public string RT;

    void Start()
    {

	}

	void Update()
	{
		if (idle)
		{
			if (Input.GetMouseButtonDown(0) && IsMouseOver() && !IsPointerOverUIElement())
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
			if (Input.GetMouseButtonDown(0) && !IsMouseOver() && !IsPointerOverUIElement() /*&& realtimeTransform.isOwnedRemotely*/)
			{
				Deselect();
			}
		}
	}


	private bool IsPointerOverUIElement()
	{
		// Touch screen
		if (Input.touchCount > 0)
        {
            foreach (Touch touch in Input.touches)
            {
                if (EventSystem.current.IsPointerOverGameObject(touch.fingerId))
                {
                    return true;
                }
            }
        }
		else {
			// Check if the pointer is over any UI element
			return EventSystem.current.IsPointerOverGameObject();
		}
		return false;
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
            if (Input.GetMouseButtonDown(0) && !IsMouseOver() && !IsPointerOverUIElement() /*&& realtimeTransform.isOwnedRemotely*/)
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

		// In SelectionTest.cs, inside the Select() method
		if (submenuInstance == null)
		{
			submenuInstance = Instantiate(submenuPrefab, childObject.transform.position, Quaternion.identity);
			submenuInstance.transform.SetParent(childObject.transform);

			// Pass the selected furniture's details, the furniture object, and the RealtimeView component to the submenu
			//FurnitureDetails furnitureDetails = GetComponent<FurnitureDetails>();
			//Debug.Log("Furniture details in selection test" + furnitureDetails);
			//RealtimeView furnitureRealtimeView = GetComponent<RealtimeView>();
			//subMenuController submenuController = submenuInstance.GetComponent<subMenuController>();
			//submenuController.SetFurnitureDetails(furnitureDetails, gameObject);
			subMenuController subMenuCtrl = submenuInstance.GetComponent<subMenuController>();
			if (subMenuCtrl != null)
			{
				subMenuCtrl.currentFurnitureObject = gameObject;
			}
		}

	}

}
   
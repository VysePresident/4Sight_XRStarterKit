using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Microsoft.MixedReality.Toolkit.UI;
using Microsoft.MixedReality.Toolkit.UI.BoundsControl;


public class SelectionTest : MonoBehaviour
{
    public bool idle;           // The object is not selected
    public bool selected;       // The object is selected
    public bool moving;           // The object is being moved
    public bool rotating;         // The object is being rotated

    public Material originalMaterial;
    public Material selectedMaterial;
    public GameObject childObject;
    public GameObject appBarPrefab;
    private GameObject appBarInstance;


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
        if (appBarInstance != null)
        {
            Destroy(appBarInstance);
            appBarInstance = null;
        }
    }

    void Select()
    {
        idle = false;
        selected = true;
        moving = false;
        rotating = false;

        childObject.GetComponent<Renderer>().material = selectedMaterial;

        if (appBarInstance == null)
        {
            //Vector3 appBarOffset = new Vector3(-1, -1, 0); // Adjust the Y value as needed
            //appBarInstance = Instantiate(appBarPrefab, transform.position + appBarOffset, Quaternion.identity);
            //appBarInstance.GetComponent<AppBar>().Target = GetComponent<BoundsControl>();

            Renderer renderer = GetComponent<Renderer>();
            Bounds bounds = renderer.bounds;
            float yOffset = bounds.size.y / 2f + 0.1f; // 0.1f as padding between the AppBar and the prefab
            Vector3 appBarOffset = new Vector3(0, -yOffset, 0);
            appBarInstance = Instantiate(appBarPrefab, transform.position + appBarOffset, Quaternion.identity);
            appBarInstance.GetComponent<AppBar>().Target = GetComponent<BoundsControl>();

			//AppBar appBar = appBarInstance.GetComponent<AppBar>();
			//appBar.OnButtonPressed.AddListener(OnAppBarButtonPressed);
		}

    }

	public void OnAppBarButtonPressed(AppBarButton button)
	{
		Debug.Log("AppBar Button Pressed: " + button.ButtonType);

		switch (button.ButtonType)
		{
			case AppBar.ButtonTypeEnum.Remove:
				RemoveObject();
				break;
				// You can add other cases for different AppBar buttons here
		}
	}


	public void OnAppBarButtonClick(AppBarButton button)
	{
		Debug.Log("AppBar Button Clicked: " + button.ButtonType);

		switch (button.ButtonType)
		{
			case AppBar.ButtonTypeEnum.Remove:
				RemoveObject();
				break;
				// You can add other cases for different AppBar buttons here
		}
	}

	private void RemoveObject()
	{
		if (appBarInstance != null)
		{
			Destroy(appBarInstance);
			appBarInstance = null;
		}
		Destroy(gameObject);
	}

}

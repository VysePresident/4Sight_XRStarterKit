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
    public GameObject childObject;
    public GameObject appBarPrefab;
    private GameObject appBarInstance;

    public RealtimeView realtimeView;
    public RealtimeTransform realtimeTransform;

    public string RT;

    void Start()
    {
        idle
        selected = false;
    }

	private void UpdateAppBar()
	{
		if (selected)
		{
			if (appBarInstance == null)
			{
				appBarInstance = Instantiate(appBarPrefab, Vector3.zero, Quaternion.identity);
				appBarInstance.GetComponent<AppBar>().Target = GetComponent<BoundsControl>();
				appBarInstance.transform.localScale = new Vector3(0.7f, 0.7f, 0.7f);
			}

			Camera cam = Camera.main;
			Vector3 screenPos = new Vector3(Screen.width / 2, 0, cam.nearClipPlane + 0.1f);
			Vector3 worldPos = cam.ScreenToWorldPoint(screenPos);
			appBarInstance.transform.position = worldPos;
		}
		else
		{
			if (appBarInstance != null)
			{
				Destroy(appBarInstance);
				appBarInstance = null;
			}
		}
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
		UpdateAppBar();
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

		childObject.GetComponent<Renderer>().material = selectedMaterial;
	}

}

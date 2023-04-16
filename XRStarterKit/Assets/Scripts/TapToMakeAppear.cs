using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Microsoft.MixedReality.Toolkit.UI;
using Microsoft.MixedReality.Toolkit.UI.BoundsControl;

public class TapToMakeAppear : MonoBehaviour
{
    bool cubeCreated = false;
    public GameObject cubePrefab;
	public GameObject appBarPrefab;
	private GameObject cube = new GameObject();
    
    // Give basic edit modes
    public enum editMode
    {
        Add,
        Move,
        Rotate
    }

    public editMode mode;

    void spawnObject()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (mode == editMode.Add)
        {
			//if (Input.GetMouseButtonDown(0) && !cubeCreated)
			//{
			//    Vector3 mousePos = Input.mousePosition;
			//    mousePos.z = 3; // set the distance from the camera
			//    Vector3 objectPos = Camera.main.ScreenToWorldPoint(mousePos);
			//    GameObject newObject = Instantiate(cubePrefab, objectPos, Quaternion.identity);
			//    cubeCreated = true;
			//}
			if (Input.GetMouseButtonDown(0) && !cubeCreated)
			{
				Vector3 mousePos = Input.mousePosition;
				mousePos.z = 3; // set the distance from the camera
				Vector3 objectPos = Camera.main.ScreenToWorldPoint(mousePos);
				GameObject newObject = Instantiate(cubePrefab, objectPos, Quaternion.identity);
				cubeCreated = true;

				// Instantiate AppBar and set the target to the new object's BoundsControl
				//GameObject newAppBar = Instantiate(appBarPrefab, objectPos, Quaternion.identity);
				//AppBar appBarComponent = newAppBar.GetComponent<AppBar>();
				//appBarComponent.Target = newObject.GetComponent<BoundsControl>();
			}

			if (Input.GetMouseButtonUp(0))
            {
                cubeCreated = false;
            }
        }
        if (mode == editMode.Move)
        {
            Debug.Log("MOVE MODE");
        }
        if (mode == editMode.Rotate)
        {
            Debug.Log("ROTATE MODE");
        }
    }
}

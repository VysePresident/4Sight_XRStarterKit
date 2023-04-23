using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Microsoft.MixedReality.Toolkit.UI;
using Microsoft.MixedReality.Toolkit.UI.BoundsControl;
using Normal.Realtime;

public class TapToMakeAppear : MonoBehaviour
{
    bool cubeCreated = false;
    public GameObject cubePrefab;
    public string prefabName;
	private GameObject cube = new GameObject();
    public static bool readyToPlace = false;
    
    // Give basic edit modes
    public enum editMode
    {
        Add,
        Move,
        Rotate
    }

    public editMode mode;

    private void Awake()
    {
        cubePrefab = FurnitureController.FurnitureToPlace;
        prefabName = cubePrefab.name;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (mode == editMode.Add)
        {
			if (Input.GetMouseButtonDown(0) && !cubeCreated)
			{
                Vector3 mousePos = Input.mousePosition;
                mousePos.z = 3; // set the distance from the camera
                Vector3 objectPos = Camera.main.ScreenToWorldPoint(mousePos);
                // Using Realtime.Instantiate
                GameObject newObject = Realtime.Instantiate(cubePrefab.name, objectPos, Quaternion.identity, destroyWhenOwnerOrLastClientLeaves: false);
				cubeCreated = true;
                mode = editMode.Move;
            }

			if (Input.GetMouseButtonUp(0))
            {
                cubeCreated = false;
            }
        }
        if (mode == editMode.Move)
        {
            //Debug.Log("MOVE MODE");
        }
        if (mode == editMode.Rotate)
        {
            Debug.Log("ROTATE MODE");
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TapToMakeAppear : MonoBehaviour
{
    bool cubeCreated = false;
    public GameObject cubePrefab;

    private GameObject cube = new GameObject();
    
    // Give basic edit modes
    public enum editMode
    {
        Add,
        Move,
        Rotate
    }

    public editMode mode;

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
                GameObject newObject = Instantiate(cubePrefab, objectPos, Quaternion.identity);
                cubeCreated = true;
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

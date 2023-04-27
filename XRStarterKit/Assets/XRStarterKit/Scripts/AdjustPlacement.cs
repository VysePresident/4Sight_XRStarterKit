using Microsoft.MixedReality.Toolkit.Utilities.Solvers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Microsoft.MixedReality.Toolkit.UI;
using UnityEngine.XR.WSA.Input;

public class AdjustPlacement : MonoBehaviour
{
    private bool isAdjusting = false;
    private Vector2 touchStartPos;
    private Quaternion objRotation;

    private TapToPlace tapToPlace;
    private SelectionTest selectionTest;


    void Start()
    {
        tapToPlace = GetComponent<TapToPlace>();
        tapToPlace.OnPlacingStopped.AddListener(OnObjectPlaced);
        tapToPlace.OnPlacingStarted.AddListener(OnObjectPickedUp);

        selectionTest = GetComponent<SelectionTest>();
    }

    // Update is called once per frame
    private void Update()
    {
        if (isAdjusting && selectionTest.selected)
        {
            if (Input.touchCount == 1 || Input.GetMouseButton(0))
            {
                Vector2 inputPos = Input.touchCount == 1 ? Input.GetTouch(0).position : Input.mousePosition;

                if (Input.GetMouseButtonDown(0) || (Input.touchCount == 1 && Input.GetTouch(0).phase == TouchPhase.Began))
                {
                    touchStartPos = inputPos;
                }
                else if (Input.GetMouseButton(0) || (Input.touchCount == 1 && Input.GetTouch(0).phase == TouchPhase.Moved))
                {
                    Vector2 delta = inputPos - touchStartPos;
                    Vector3 newPos = transform.position + new Vector3(delta.x * Time.deltaTime, 0, delta.y * Time.deltaTime);
                    RaycastHit hit;
                    if (Physics.Raycast(newPos, Vector3.down, out hit))
                    {
                        transform.position = hit.point;
                    }
                    transform.Translate(delta.x * Time.deltaTime, 0, delta.y * Time.deltaTime, Space.World);
                    touchStartPos = inputPos;
                }
            }
            else if (Input.touchCount == 2 || Input.GetMouseButton(1))
            {
                if (Input.GetMouseButtonDown(1) || (Input.touchCount == 2 && Input.GetTouch(0).phase == TouchPhase.Began))
                {
                    objRotation = transform.rotation;
                }
                else if (Input.GetMouseButton(1) || Input.touchCount == 2 && Input.GetTouch(0).phase == TouchPhase.Moved)
                {
                    Vector2 delta1 = Input.GetMouseButton(1) ? new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y")) : Input.GetTouch(0).deltaPosition;
                    Vector2 delta2 = Input.GetMouseButton(1) ? new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y")) : Input.GetTouch(0).deltaPosition;

                    float angle = Vector2.SignedAngle(delta1, delta2);
                    transform.rotation = Quaternion.Euler(0, angle, 0) * objRotation;
                }


                /*Touch touch1 = Input.GetTouch(0);
                Touch touch2 = Input.GetTouch(1);

                if (touch1.phase == TouchPhase.Began || touch2.phase == TouchPhase.Began)
                {
                    objRotation = transform.rotation;
                }
                else if (touch1.phase == TouchPhase.Moved || touch2.phase == TouchPhase.Moved)
                {
                    Vector2 delta1 = touch1.deltaPosition;
                    Vector2 delta2 = touch2.deltaPosition;
                    float angle = Vector2.SignedAngle(delta1, delta2);
                    transform.rotation = Quaternion.Euler(0, angle, 0) * objRotation;
                }*/
            }
        }
    }




    /*void Update()
    {
        if (isAdjusting && selectionTest.selected)
        {
            if (Input.touchCount == 1)
            {
                Touch touch = Input.GetTouch(0);

                if (touch.phase == TouchPhase.Began)
                {
                    touchStartPos = touch.position;
                }
                else if (touch.phase == TouchPhase.Moved)
                {
                    Vector2 delta = touch.position - touchStartPos;
                    Vector3 newPos = transform.position + new Vector3(delta.x * Time.deltaTime, 0, delta.y * Time.deltaTime);
                    RaycastHit hit;
                    if (Physics.Raycast(newPos, Vector3.down, out hit))
                    {
                        transform.position = hit.point;
                    }
                    /transform.Translate(delta.x * Time.deltaTime, 0, delta.y * Time.deltaTime, Space.World);
                    touchStartPos = touch.position;
                }
            }
            else if (Input.touchCount == 2)
            {
                Touch touch1 = Input.GetTouch(0);
                Touch touch2 = Input.GetTouch(1);

                if (touch1.phase == TouchPhase.Began || touch2.phase == TouchPhase.Began)
                {
                    objRotation = transform.rotation;
                }
                else if (touch1.phase == TouchPhase.Moved || touch2.phase == TouchPhase.Moved)
                {
                    Vector2 delta1 = touch1.deltaPosition;
                    Vector2 delta2 = touch2.deltaPosition;
                    float angle = Vector2.SignedAngle(delta1, delta2);
                    transform.rotation = Quaternion.Euler(0, angle, 0) * objRotation;

                }
            }
        }
    }*/
    public void ToggleAdjust()
    {
        isAdjusting = !isAdjusting;
        tapToPlace.enabled = !isAdjusting;
    }

    private void OnObjectPlaced()
    {
        //isAdjusting = !isAdjusting;
        //tapToPlace.enabled = !isAdjusting;
        isAdjusting = true;
        tapToPlace.enabled = false;
        Debug.Log("Tap To Place disabled!");
    }

    private void OnObjectPickedUp()
    {
        Debug.Log("TTP used to pick up object!");
    }
}
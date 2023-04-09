using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Normal.Realtime;

public class Draggable : MonoBehaviour
{
    private Vector3 screenPoint;
    private Vector3 offset;
    private float rotateSpeed = 5.0f; // The speed at which the object should rotate.
    private bool isRotating = false;

    // Touch variables
    private bool isTouching = false;
    private Vector2 touchStart;
    private float touchDistance;
    private float touchAngle;

    private GameObject lastTouchedObject = null;

    void OnMouseDown()
    {
        // Attempt to get a realtime transform
        RealtimeTransform realtimeTransform = GetComponent<RealtimeTransform>();
        if (realtimeTransform != null)
        {
            // Make sure another user doesn't own it
            if (realtimeTransform.isOwnedRemotelySelf)
            {
                Debug.LogWarning("Already owned by another player. Ignoring.");
                return;
            }

            // Take ownership
            if (!realtimeTransform.isOwnedLocallySelf)
            {
                realtimeTransform.RequestOwnership();
            }
        }

        screenPoint = Camera.main.WorldToScreenPoint(gameObject.transform.position);
        offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));

        // Check if the click was on this object, and if so, enable rotation
        RaycastHit hit;
        if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit))
        {
            if (hit.collider.gameObject == gameObject)
            {
                isRotating = false; // disable rotation when object is dragged
            }
        }
    }



    void OnMouseDrag()
    {
        if (!isRotating) // only drag when not rotating
        {
            Vector3 cursorPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);
            Vector3 cursorPosition = Camera.main.ScreenToWorldPoint(cursorPoint) + offset;
            transform.position = cursorPosition;
        }
    }

    private void OnMouseUp()
    {
        // Attempt to get a realtime transform
        RealtimeTransform realtimeTransform = GetComponent<RealtimeTransform>();
        if (realtimeTransform != null)
        {
            // Make sure we own it
            if (realtimeTransform.isOwnedLocallySelf)
            {
                // Release ownership
                realtimeTransform.ClearOwnership();
            }
        }

        // Disable rotation for all objects except for the one that was touched first
        if (lastTouchedObject == gameObject)
        {
            isRotating = false;
        }
        else
        {
            Draggable[] draggables = FindObjectsOfType<Draggable>();
            foreach (Draggable draggable in draggables)
            {
                if (draggable != this)
                {
                    draggable.isRotating = false;
                }
            }
        }
    }


    void Update()
    {
        // Check if user is touching screen
        if (Input.touchCount > 0)
        {
            // Two-finger touch rotation
            if (Input.touchCount == 2)
            {
                if (!isTouching)
                {
                    // Save touch start position and distance
                    touchStart = Input.GetTouch(0).position - Input.GetTouch(1).position;
                    touchDistance = touchStart.magnitude;
                    isTouching = true;

                    // Enable rotation only for the last touched object
                    if (lastTouchedObject == gameObject)
                    {
                        isRotating = true;
                    }
                }
                else
                {
                    // Calculate touch angle and rotate object
                    Vector2 currentTouch = Input.GetTouch(0).position - Input.GetTouch(1).position;
                    touchAngle = Vector2.Angle(touchStart, currentTouch);

                    // Rotate only the last touched object
                    if (lastTouchedObject == gameObject)
                    {
                        transform.Rotate(Vector3.up, touchAngle * rotateSpeed, Space.World);
                    }

                    touchStart = currentTouch;
                }
            }
            else
            {
                // One-finger touch drag
                isTouching = false;

                isRotating = false; // disable rotation when one finger touches

                // Update last touched object when touch is released
                lastTouchedObject = null;
            }

            // Update last touched object when touch begins
            if (Input.GetTouch(0).phase == TouchPhase.Began)
            {
                RaycastHit hit;
                if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.GetTouch(0).position), out hit))
                {
                    lastTouchedObject = hit.collider.gameObject;
                }
            }
        }
        else
        {
            // No touch detected
            isTouching = false;

            isRotating = false; // disable rotation when no touch detected

            // Update last touched object when touch is released
            lastTouchedObject = null;
        }
    }


}





/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Normal.Realtime;

public class Draggable : MonoBehaviour
{
	private Vector3 screenPoint;
    private Vector3 offset;

    void OnMouseDown()
    {
        // Attempt to get a realtime transform
        RealtimeTransform realtimeTransform = GetComponent<RealtimeTransform>();
        if (realtimeTransform != null)
        {
            // Make sure another user doesn't own it
            if (realtimeTransform.isOwnedRemotelySelf)
            {
                Debug.LogWarning("Already owned by another player. Ignoring.");
                return;
            }

            // Take ownership
            realtimeTransform.RequestOwnership();
        }

        screenPoint = Camera.main.WorldToScreenPoint(gameObject.transform.position);
        offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));
    }

    void OnMouseDrag()
    {
        Vector3 cursorPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);
        Vector3 cursorPosition = Camera.main.ScreenToWorldPoint(cursorPoint) + offset;
        transform.position = cursorPosition;
    }

    private void OnMouseUp()
    {
        // Attempt to get a realtime transform
        RealtimeTransform realtimeTransform = GetComponent<RealtimeTransform>();
        if (realtimeTransform != null)
        {
            // Make sure we own it
            if (realtimeTransform.isOwnedLocallySelf)
            {
                // Release ownership
                realtimeTransform.ClearOwnership();
            }
        }
    }
}*/

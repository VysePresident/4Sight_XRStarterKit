using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.XR.ARFoundation;

using Microsoft.MixedReality.Toolkit.UI;
using Microsoft.MixedReality.Toolkit.UI.BoundsControl;

public class FurnitureManager : MonoBehaviour
{
    public GameObject FurniturePrefab;
    public ReticleBehavior Reticle;
    public FurnitureSurfaceManager FurnitureSurfaceManager;
	public GameObject appBarPrefab;
	public FurnitureBehavior Furniture;
    public bool IsLocked = false;

    private void Update()
    {
        if (Furniture == null && WasTapped() && Reticle.CurrentPlane != null)
        {
            var obj = GameObject.Instantiate(FurniturePrefab);
            Furniture = obj.GetComponent<FurnitureBehavior>();
            Furniture.Reticle = Reticle;
            Furniture.transform.position = Reticle.transform.position;
            FurnitureSurfaceManager.LockPlane(Reticle.CurrentPlane);

			GameObject newAppBar = Instantiate(appBarPrefab, Reticle.transform.position, Quaternion.identity);
			AppBar appBarComponent = newAppBar.GetComponent<AppBar>();
			appBarComponent.Target = obj.GetComponent<BoundsControl>();
		}
        if(Furniture != null && WasTapped()) {
            IsLocked = !IsLocked;
            Furniture.IsLocked = IsLocked;
        }
    }

    private bool WasTapped()
    {
        if (Input.GetMouseButtonDown(0))
        {
            return true;
        }

        if (Input.touchCount == 0)
        {
            return false;
        }

        var touch = Input.GetTouch(0);
        if (touch.phase != TouchPhase.Began)
        {
            return false;
        }

        return true;
    }
}

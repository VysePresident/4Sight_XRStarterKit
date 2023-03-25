using System.Collections;
using System.Collections.Generic;
using System.Linq;

using Unity.Collections;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class ReticleBehavior : MonoBehaviour
{
    public GameObject Child;
    public FurnitureSurfaceManager FurnitureSurfaceManager;

    public ARPlane CurrentPlane;

    void Start()
    {
        Child = transform.GetChild(0).gameObject;
    }

    void Update()
    {
        var screenCenter = Camera.main.ViewportToScreenPoint(new Vector3(0.5f, 0.5f));
        var hits = new List<ARRaycastHit>();
        FurnitureSurfaceManager.RaycastManager.Raycast(screenCenter, hits, TrackableType.PlaneWithinBounds);

        CurrentPlane = null;
        ARRaycastHit? hit = null;

        if(hits.Count > 0) {
            var lockedPlane = FurnitureSurfaceManager.LockedPlane;
            hit = lockedPlane == null
            ? hits[0]
            : hits.SingleOrDefault(x => x.trackableId == lockedPlane.trackableId);
        }
        if(hit.HasValue) {
            CurrentPlane = FurnitureSurfaceManager.PlaneManager.GetPlane(hit.Value.trackableId);
            transform.position = hit.Value.pose.position;
        }
        Child.SetActive(CurrentPlane != null);
    }
}

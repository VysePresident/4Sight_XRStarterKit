using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FurnitureBehavior : MonoBehaviour
{
    public ReticleBehavior Reticle;
    public float Speed = 1.2f;
    public bool IsLocked = false;

    private void Update()
    {
        if(Reticle != null) 
        {
            var trackingPosition = Reticle.transform.position;
            if (Vector3.Distance(trackingPosition, transform.position) < 0.1)
            {
                return;
            }

            if(!IsLocked)
            {
                transform.position =
                Vector3.MoveTowards(transform.position, trackingPosition, Speed * Time.deltaTime);
            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FenceSpawner : MonoBehaviour
{
    public GameObject fencePrefab; // The fence prefab to spawn
    public Transform startPoint; // The starting point of the fence
    public Transform endPoint; // The ending point of the fence

    public float spacing = 1f; // The distance between each fence post

    void Start()
    {
        SpawnFence();
    }

    void SpawnFence()
    {
        Vector3 direction = endPoint.position - startPoint.position; // Get the direction between the two points
        float distance = direction.magnitude; // Get the distance between the two points

        int fenceCount = Mathf.RoundToInt(distance / spacing); // Calculate the number of fence posts needed

        Vector3 step = direction.normalized * spacing; // Calculate the step between each fence post

        Vector3 currentPoint = startPoint.position; // Set the current point to the starting point

        for (int i = 0; i <= fenceCount; i++)
        {
            GameObject fence = Instantiate(fencePrefab, currentPoint, Quaternion.identity); // Spawn a fence post at the current point
            fence.transform.LookAt(endPoint); // Rotate the fence post to face the end point
            currentPoint += step; // Move the current point to the next position
        }
    }
}
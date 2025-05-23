using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
using System.Collections.Generic;

public class ImageTrackedToFixedSpawner : MonoBehaviour
{
    public ARTrackedImageManager trackedImageManager;
    public GameObject modelPrefab; // The model you want to generate
    private bool hasSpawned = false; // To be generated only once

    private void OnEnable()
    {
        trackedImageManager.trackedImagesChanged += OnTrackedImagesChanged;
    }

    private void OnDisable()
    {
        trackedImageManager.trackedImagesChanged -= OnTrackedImagesChanged;
    }

    void OnTrackedImagesChanged(ARTrackedImagesChangedEventArgs eventArgs)
    {
        foreach (var trackedImage in eventArgs.added)
        {
            TrySpawnModel(trackedImage);
        }

        foreach (var trackedImage in eventArgs.updated)
        {
            if (trackedImage.trackingState == TrackingState.Tracking)
                TrySpawnModel(trackedImage);
        }
    }

    void TrySpawnModel(ARTrackedImage trackedImage)
    {
        if (hasSpawned || modelPrefab == null)
            return;

        // The ray at the center of the screen, to obtain the world coordinates
        Vector3 screenCenter = new Vector3(Screen.width / 2f, Screen.height / 2f, 0);
        List<ARRaycastHit> hits = new List<ARRaycastHit>();
        ARRaycastManager raycastManager = FindObjectOfType<ARRaycastManager>();

        if (raycastManager.Raycast(screenCenter, hits, TrackableType.Planes))
        {
            Pose hitPose = hits[0].pose;

            Quaternion rotated = Quaternion.Euler(0f, 150f, 0f);
            Instantiate(modelPrefab, hitPose.position, rotated);
            hasSpawned = true;
            Debug.Log("The model has been generated in the center of the screen");
        }
    }
}

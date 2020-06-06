using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
using GoogleARCore;

public class PlacementIndicator : MonoBehaviour
{
    private ARRaycastManager _rayManager;
    private GameObject _visual;
    public Trackable _curTrackable;

    private void Start ()
    {
        // get the components
        _rayManager = FindObjectOfType<ARRaycastManager>();
        _visual = transform.GetChild(0).gameObject;

        // hide the placement indicator visual
        _visual.SetActive(false);
    }

    private void Update ()
    {
        // shoot a raycast from the center of the screen
        List<ARRaycastHit> hits = new List<ARRaycastHit>();
        _rayManager.Raycast(new Vector2(Screen.width / 2, Screen.height / 2), hits, TrackableType.Planes);

        // if we hit an AR plane surface, update the position and rotation
        if(hits.Count > 0)
        {
            transform.position = hits[0].pose.position;
            transform.rotation = hits[0].pose.rotation;

            // enable the visual if it's disabled
            if(!_visual.activeInHierarchy)
                _visual.SetActive(true);
        }
    }

    //using GoogleARCore;
    //private void Start()
    //{
    //    _visual.SetActive(false);
    //}

    //private void Update()
    //{
    //    TrackableHit hit;
    //    TrackableHitFlags filter = TrackableHitFlags.PlaneWithinPolygon;

    //    if (Frame.Raycast(Screen.width / 2, Screen.height / 2, filter, out hit))
    //    {
    //        _curTrackable = hit.Trackable;

    //        transform.position = hit.Pose.position;
    //        transform.rotation = hit.Pose.rotation;

    //        _visual.SetActive(true);
    //    }
    //    else
    //    {
    //        _curTrackable = null;
    //        _visual.SetActive(false);
    //    }
    //}
}
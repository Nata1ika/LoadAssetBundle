using System;
using UnityEngine;
using Vuforia;

public class SimpleCloudHandler : MonoBehaviour, ICloudRecoEventHandler //, ITrackableEventHandler
{
    [SerializeField] CloudRecoBehaviour _cloudRecognition;
    //[SerializeField] TrackableBehaviour _trackableBehaviour;

    private bool _mIsScanning = false;
    private string mTargetMetadata = "";

    //private TargetFinder.UpdateState? _targetFinderState = null;
    //private TargetFinder _targetFinder;


    /// <summary>
    /// register for events at the CloudRecoBehaviour
    /// </summary>
    void Start()
	{
		_cloudRecognition.RegisterEventHandler(this);
        //_trackableBehaviour.RegisterTrackableEventHandler(this);
    }

    private void OnDestroy()
    {
        _cloudRecognition.UnregisterEventHandler(this);
        //_trackableBehaviour.UnregisterTrackableEventHandler(this);
    }
    
    /*
    private void Update()
    {
        if (_targetFinder == null)
        {
            return;
        }

        _targetFinderState = _targetFinder.Update();
    }*/


    /// <summary>
    /// called when TargetFinder has been initialized successfully
    /// </summary>
    public void OnInitialized(TargetFinder targetFinder)
	{
        //_targetFinder = targetFinder;
    }

	/// <summary>
	/// visualize initialization errors
	/// </summary>
	public void OnInitError(TargetFinder.InitState initError)
	{
	}

	/// <summary>
	/// visualize update errors
	/// </summary>
	public void OnUpdateError(TargetFinder.UpdateState updateError)
	{
	}

	/// <summary>
	/// when we start scanning, unregister Trackable from the ImageTargetTemplate, then delete all trackables
	/// </summary>
	public void OnStateChanged(bool scanning)
    {
		_mIsScanning = scanning;
        if (scanning)
        {
            // clear all known trackables
            ObjectTracker tracker = TrackerManager.Instance.GetTracker<ObjectTracker>();
            if (tracker == null)
            {
                return;
            }
            var targetFinder = tracker.GetTargetFinder<TargetFinder>();
            if (targetFinder == null)
            {
                return;
            }
            targetFinder.ClearTrackables(false);
		}
	}

    // Here we handle a cloud target recognition event
    public void OnNewSearchResult(TargetFinder.TargetSearchResult targetSearchResult)
    {
        Debug.Log("metadate: " + targetSearchResult.MetaData);
        // do something with the target metadata
        mTargetMetadata = targetSearchResult.MetaData;

        // stop the target finder (i.e. stop scanning the cloud)
        //_cloudRecognition.CloudRecoEnabled = false;
    }

    /*
    public void OnTrackableStateChanged(TrackableBehaviour.Status previousStatus, TrackableBehaviour.Status newStatus)
    {
        if (newStatus == TrackableBehaviour.Status.DETECTED ||
            newStatus == TrackableBehaviour.Status.TRACKED ||
            newStatus == TrackableBehaviour.Status.EXTENDED_TRACKED)
        {
            Debug.Log("Trackable " + _trackableBehaviour.TrackableName + " found");
            OnTrackingFound();
        }
        else if (previousStatus == TrackableBehaviour.Status.TRACKED &&
                 newStatus == TrackableBehaviour.Status.NO_POSE)
        {
            Debug.Log("Trackable " + _trackableBehaviour.TrackableName + " lost");
            OnTrackingLost();
        }
        else
        {
            // For combo of previousStatus=UNKNOWN + newStatus=UNKNOWN|NOT_FOUND
            // Vuforia is starting, but tracking has not been lost or found yet
            // Call OnTrackingLost() to hide the augmentations
            OnTrackingLost();
        }
    }

    private void OnTrackingFound()
    {
        
    }

    private void OnTrackingLost()
    {
        mTargetMetadata = "";
    }
    */

    void OnGUI()
    {
        GUI.Box(new Rect(100, 100, 200, 50), _mIsScanning ? "Scanning" : "Not scanning");
        GUI.Box(new Rect(100, 200, 200, 50), "Metadata: " + mTargetMetadata);
        //GUI.Box(new Rect(100, 300, 200, 50), "State: " + (_targetFinderState.HasValue ? _targetFinderState.ToString() : "unknow"));

        // If not scanning, show button
        // so that user can restart cloud scanning
        if (!_mIsScanning)
        {
            if (GUI.Button(new Rect(100, 400, 200, 50), "Restart Scanning"))
            {
                // Restart TargetFinder
                _cloudRecognition.CloudRecoEnabled = true;
            }
        }
    }    
}

using UnityEngine;
using System;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARCore;


public class Recorder : MonoBehaviour
{
    [NonSerialized] new public bool enabled;
    [NonSerialized] public string file;
    ARSession session;

    void Awake()
    {
        session = GetComponent<ARSession>();
    }

    void OnGUI()
    {
        if (enabled)
        {
            if (session.subsystem is ARCoreSessionSubsystem subsys && subsys.session != null && !subsys.recordingStatus.Recording())
            {
                using (ArRecordingConfig conf = new ArRecordingConfig(subsys.session))
                {
                    conf.SetMp4DatasetFilePath(subsys.session, file);
                    conf.SetRecordingRotation(subsys.session, 90);
                    subsys.StartRecording(conf);
                }
                Debug.Log($"record onto {file}", this);
            }
        }
    }

    public void Stop()
    {
        if (session.subsystem is ARCoreSessionSubsystem subsys && subsys.session != null && subsys.recordingStatus.Recording())
        {
            subsys.StopRecording();
            enabled = false;
        }
    }
}
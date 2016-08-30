using UnityEngine;
using System.Collections;

public class OrientationControls : MonoBehaviour {
    public enum AutoOrientation {
        AutoPortrait,
        AutoLandscape,           
        AutoAll,
        NoAuto
    }
    [SerializeField]
    private AutoOrientation AllowedOrientation = AutoOrientation.AutoPortrait;
    
    void Awake() {
        TestOrientation();
    }
    
    void OnApplicationFocus(bool focusStatus) {
        if (focusStatus) {
            TestOrientation();            
        }
    }
    
    void TestOrientation() {
        if (AndroidRotationLockUtil.AllowAutorotation()) {
            SetOrientationLock(AllowedOrientation);
            ResetOrientation(AllowedOrientation);
        } else {
            SetOrientationLock(AutoOrientation.NoAuto);
            ResetOrientation(AllowedOrientation);
        }
    }

    // Locks the orientation to the defined type
    void SetOrientationLock(AutoOrientation orientationLocked) {
        switch (orientationLocked) {
            case AutoOrientation.AutoLandscape:
                Screen.autorotateToPortrait = false;
                Screen.autorotateToPortraitUpsideDown = false;
                Screen.autorotateToLandscapeLeft = true;
                Screen.autorotateToLandscapeRight = true;
                break;
            case AutoOrientation.AutoPortrait:
                Screen.autorotateToPortrait = true;
                Screen.autorotateToPortraitUpsideDown = true;
                Screen.autorotateToLandscapeLeft = false;
                Screen.autorotateToLandscapeRight = false;
                break;
            case AutoOrientation.AutoAll:
                Screen.autorotateToPortrait = true;
                Screen.autorotateToPortraitUpsideDown = true;
                Screen.autorotateToLandscapeLeft = true;
                Screen.autorotateToLandscapeRight = true;                
                break;
            case AutoOrientation.NoAuto:
                Screen.autorotateToPortrait = false;
                Screen.autorotateToPortraitUpsideDown = false;
                Screen.autorotateToLandscapeLeft = false;
                Screen.autorotateToLandscapeRight = false;
                break;
            default:
                break;
        }
        Screen.orientation = ScreenOrientation.AutoRotation;
    }
    
    void ResetOrientation(AutoOrientation orientationLocked) {
        switch (orientationLocked) {
            case AutoOrientation.AutoLandscape:
                if (Screen.orientation == ScreenOrientation.Portrait || Screen.orientation == ScreenOrientation.PortraitUpsideDown) {
                    Screen.orientation = ScreenOrientation.LandscapeLeft;
                }                
                break;
            case AutoOrientation.AutoPortrait:
                if (Screen.orientation == ScreenOrientation.LandscapeLeft || Screen.orientation == ScreenOrientation.LandscapeRight) {
                    Screen.orientation = ScreenOrientation.Portrait;
                }
                break;
            default:
                break;
        }
        Screen.orientation = ScreenOrientation.AutoRotation;
    }
    
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetFullScreen : MonoBehaviour
{
    public void SetFullscreen(bool isFullScreen)
    {
        Screen.fullScreen = isFullScreen;
    }
}

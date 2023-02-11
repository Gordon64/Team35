using System.Collections;
using System.Collections.Generic;
using System.Security.Permissions;
using UnityEngine;

public class SettingButton : MonoBehaviour
{
    public GameObject SettingPanel; //Panel for player to select their new or saved game files.
    public GameObject Close_LoadGameButton; //Button to close the current panel.
    public GameObject Res;
    public GameObject ResText;
    public GameObject Vol;
    public GameObject VolText;
    public GameObject VolSlider;
    public GameObject VolSliderBackground;
    public GameObject VolSliderFillArea;
    public GameObject VolSliderFill;
    public GameObject VolSliderHandleSlideArea;
    public GameObject VolSliderHandle;


    //Function to open panel when "Continue" button is pressed.
    public void OpenSettings()
    {
        //Function to display panel and exit button
        if (SettingPanel != null)
        {
            Res.SetActive(true);
            ResText.SetActive(true);
            Vol.SetActive(true);
            VolText.SetActive(true);
            VolSlider.SetActive(true);
            VolSliderBackground.SetActive(true);
            VolSliderFillArea.SetActive(true);
            VolSliderFill.SetActive(true);
            VolSliderHandleSlideArea.SetActive(true);
            VolSliderHandle.SetActive(true);
            SettingPanel.SetActive(true);
        }

        if (Close_LoadGameButton != null)
        {
            Close_LoadGameButton.SetActive(true);
        }
    }
}

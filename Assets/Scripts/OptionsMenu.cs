using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
//using Unity.PlasticSCM.Editor.WebApi;

public class OptionsMenu : MonoBehaviour
{
    Resolution[] resolutions;
  //  public Dropdown resolustionDropDown;
    public TMP_Dropdown resolustionDropDown;
    void Start()
    {
       resolutions= Screen.resolutions;
       resolustionDropDown.ClearOptions();
     //  resolustionDropDown.AddOptions()
       List<string> options = new List<string>();
        int currentResolutionIndex = 0;
        for (int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + " X " + resolutions[i].height;
            options.Add(option);
            if (resolutions[i].width == Screen.currentResolution.width &&
                resolutions[i].height == Screen.currentResolution.height) 
            {
                currentResolutionIndex = i;
            }
        }
        resolustionDropDown.AddOptions(options);
        resolustionDropDown.value = currentResolutionIndex;
        resolustionDropDown.RefreshShownValue();
    }
    public void SetFullScreen(bool isFullScreen)
    {
        Screen.fullScreen = isFullScreen;
    }

    public void SetResolustion(int resolutionsIndex)
    {
        Resolution resolution = resolutions[resolutionsIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }
}

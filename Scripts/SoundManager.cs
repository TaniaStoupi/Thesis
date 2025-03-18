using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{
    //Variables
    [SerializeField] Image soundOnIcon;
    [SerializeField] Image soundOffIcon;
    private bool mute = false;

    // Start is called before the first frame update
    void Start()
    {
        UpdateButtonIcon();
        //Sets the music on
        AudioListener.pause = mute;
    }

    //This function will call when the player presses the sound button
    public void OnButtonPress()
    {
        //If the music plays and the player presses the button, then
        //Stop the music
        if(mute == false)
        {
            mute = true;
            AudioListener.pause = true;
        }
        //else if the music doesn't play and the player presses the button 
        //Start the music
        else
        {
            mute = false;
            AudioListener.pause = false;
        }

        //Calls the function to update the icons on the button
        UpdateButtonIcon();
    }


    //This function is to update the Icons on the button when the music plays and when is muted
    public void UpdateButtonIcon()
    {
        //If the music plays then enable the SoundOn Icon
        if(mute == false)
        {
            soundOnIcon.enabled = true;
            soundOffIcon.enabled = false;
        }
        //else enable the soundOff Icon
        else
        {
            soundOffIcon.enabled = true;
            soundOnIcon.enabled = false;
        }
    }
}

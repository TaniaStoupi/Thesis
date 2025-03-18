using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.UI;

public class VideoManagerTheatro : MonoBehaviour
{
    //public GameObject soundManager;
    [SerializeField] Image soundOnIcon;
    [SerializeField] Image soundOffIcon;
    public RawImage video1;
    public Button startVid1;
    public Button stopVid1;

   
    //When the video starts stop the music  
    public void StartVideo1()
    {
        AudioListener.pause = true;
        soundOffIcon.enabled = true;
        soundOnIcon.enabled = false;
        startVid1.gameObject.SetActive(false);
        stopVid1.gameObject.SetActive(true);
    }

    //When the video stops start the music and update the icon
    public void StopVideo1()
    {
        AudioListener.pause = false;
        soundOnIcon.enabled = true;
        soundOffIcon.enabled = false;
        startVid1.gameObject.SetActive(true);
        stopVid1.gameObject.SetActive(false);   
    }

   
}

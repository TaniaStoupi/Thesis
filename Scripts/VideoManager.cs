using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.UI;

public class VideoManager : MonoBehaviour
{
    //public GameObject soundManager;
    [SerializeField] Image soundOnIcon;
    [SerializeField] Image soundOffIcon;
    public RawImage video1;
    public RawImage video2;
    public Button startVid1;
    public Button stopVid1;
    public Button startVid2;
    public Button stopVid2;
    public Button nextVid;
    public Button prevVid;
 

    //Sets the video 2 to inactive
    private void Start()
    {
        video1.enabled = true;
        video2.enabled = false;
        prevVid.gameObject.SetActive(false);
        startVid2.gameObject.SetActive(false);
        stopVid2.gameObject.SetActive(false);
    }
    //When the video starts stop the music  
    public void StartVideo1()
    {
        AudioListener.pause = true;
        soundOffIcon.enabled = true;
        soundOnIcon.enabled = false;
        startVid1.gameObject.SetActive(false);
        stopVid1.gameObject.SetActive(true);
        startVid2.gameObject.SetActive(false);
        stopVid2.gameObject.SetActive(false);

    }

    //When the video stops start the music and update the icon
    public void StopVideo1()
    {
        AudioListener.pause = false;
        soundOnIcon.enabled = true;
        soundOffIcon.enabled = false;
        startVid1.gameObject.SetActive(true);
        stopVid1.gameObject.SetActive(false);
        startVid2.gameObject.SetActive(false);
        stopVid2.gameObject.SetActive(false);
    }

    public void StartVideo2()
    {
        AudioListener.pause = true;
        soundOffIcon.enabled = true;
        soundOnIcon.enabled = false;
        startVid1.gameObject.SetActive(false);
        stopVid1.gameObject.SetActive(false);
        startVid2.gameObject.SetActive(false);
        stopVid2.gameObject.SetActive(true);

    }

    //When the video stops start the music and update the icon
    public void StopVideo2()
    {
        AudioListener.pause = false;
        soundOnIcon.enabled = true;
        soundOffIcon.enabled = false;
        startVid1.gameObject.SetActive(false);
        stopVid1.gameObject.SetActive(false);
        startVid2.gameObject.SetActive(true);
        stopVid2.gameObject.SetActive(false);
    }
    // When the player presses the next video button makes the first video inactive
    //and the second video active, as well as the buttons of the first video
    public void PlayNextVideo()
    {
        video1.enabled = false;
        video2.enabled = true;
        nextVid.gameObject.SetActive(false);
        prevVid.gameObject.SetActive(true);
        startVid1.gameObject.SetActive(false);
        stopVid1.gameObject.SetActive(false);
        startVid2.gameObject.SetActive(true);
        stopVid2.gameObject.SetActive(true);
    }

    public void PlayPrevVideo()
    {
        video2.enabled = false;
        video1.enabled = true;
        prevVid.gameObject.SetActive(false);
        nextVid.gameObject.SetActive(true);
        startVid1.gameObject.SetActive(true);
        stopVid1.gameObject.SetActive(true);
        startVid2.gameObject.SetActive(false);
        stopVid2.gameObject.SetActive(false);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.UI;

public class VideoManagerHraion : MonoBehaviour
{
    //public GameObject soundManager;
    [SerializeField] Image soundOnIcon;
    [SerializeField] Image soundOffIcon;
    public RawImage video1;
    public RawImage video2;
    public RawImage video3;
    public Button startVid1;
    public Button stopVid1;
    public Button startVid2;
    public Button stopVid2;
    public Button startVid3;
    public Button stopVid3;
    public Button nextVidTo2;
    public Button nextVidTo3;
    public Button prevVidTo2;
    public Button prevVidTo1;

    //Sets the video 2 to inactive
    private void Start()
    {
        video2.enabled = false;
        video3.enabled = false;
        startVid2.gameObject.SetActive(false);
        stopVid2.gameObject.SetActive(false);
        startVid3.gameObject.SetActive(false);
        stopVid3.gameObject.SetActive(false);
        nextVidTo3.gameObject.SetActive(false);
        prevVidTo2.gameObject.SetActive(false);
        prevVidTo1.gameObject.SetActive(false);
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
        startVid3.gameObject.SetActive(false);
        stopVid3.gameObject.SetActive(false);

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
        startVid3.gameObject.SetActive(false);
        stopVid3.gameObject.SetActive(false);
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
        startVid3.gameObject.SetActive(false);
        stopVid3.gameObject.SetActive(false);
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
        startVid3.gameObject.SetActive(false);
        stopVid3.gameObject.SetActive(false);
    }

    public void StartVideo3()
    {
        AudioListener.pause = true;
        soundOffIcon.enabled = true;
        soundOnIcon.enabled = false;
        startVid1.gameObject.SetActive(false);
        stopVid1.gameObject.SetActive(false);
        startVid2.gameObject.SetActive(false);
        stopVid2.gameObject.SetActive(false);
        startVid3.gameObject.SetActive(false);
        stopVid3.gameObject.SetActive(true);

    }

    public void StopVideo3()
    {
        AudioListener.pause = false;
        soundOnIcon.enabled = true;
        soundOffIcon.enabled = false;
        startVid1.gameObject.SetActive(false);
        stopVid1.gameObject.SetActive(false);
        startVid2.gameObject.SetActive(false);
        stopVid2.gameObject.SetActive(false);
        startVid3.gameObject.SetActive(false);
        stopVid3.gameObject.SetActive(true);
    }
    // When the player presses the next video button makes the first video inactive
    //and the second video active, as well as the buttons of the first video
    public void PlayNextVideo()
    {
        video1.enabled = false;
        video2.enabled = true;
        video3.enabled = false;
        startVid1.gameObject.SetActive(false);
        stopVid1.gameObject.SetActive(false);
        startVid2.gameObject.SetActive(true);
        stopVid2.gameObject.SetActive(false);
        startVid3.gameObject.SetActive(false);
        stopVid3.gameObject.SetActive(false);
        nextVidTo3.gameObject.SetActive(true);
        prevVidTo2.gameObject.SetActive(true);
    }

    public void PlayNextVideoTo3()
    {
        video1.enabled = false;
        video2.enabled = false;
        video3.enabled = true;
        startVid1.gameObject.SetActive(false);
        stopVid1.gameObject.SetActive(false);
        startVid2.gameObject.SetActive(false);
        stopVid2.gameObject.SetActive(false);
        startVid3.gameObject.SetActive(true);
        stopVid3.gameObject.SetActive(false);
        nextVidTo3.gameObject.SetActive(false);
        nextVidTo2.gameObject.SetActive(false);
        prevVidTo1.gameObject.SetActive(false);
        prevVidTo2.gameObject.SetActive(true);
    }

    public void PlayPrevVideoTo2()
    {
        video2.enabled = true;
        video3.enabled = false;
        video1.enabled = false;
        startVid1.gameObject.SetActive(false);
        stopVid1.gameObject.SetActive(false);
        startVid2.gameObject.SetActive(true);
        stopVid2.gameObject.SetActive(false);
        startVid3.gameObject.SetActive(false);
        stopVid3.gameObject.SetActive(false);
        nextVidTo3.gameObject.SetActive(true);
        nextVidTo2.gameObject.SetActive(false);
        prevVidTo1.gameObject.SetActive(true);
        prevVidTo2.gameObject.SetActive(false);
    }

    public void PlayPrevVideo()
    {
        video2.enabled = false;
        video3.enabled = false;
        video1.enabled = true;
        startVid1.gameObject.SetActive(true);
        stopVid1.gameObject.SetActive(false);
        startVid2.gameObject.SetActive(false);
        stopVid2.gameObject.SetActive(false);
        startVid3.gameObject.SetActive(false);
        stopVid3.gameObject.SetActive(false);
        nextVidTo3.gameObject.SetActive(false);
        nextVidTo2.gameObject.SetActive(true);
        prevVidTo1.gameObject.SetActive(false);
        prevVidTo2.gameObject.SetActive(false);
    }
}

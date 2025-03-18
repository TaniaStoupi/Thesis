using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UICarousel : MonoBehaviour
{
    public Sprite[] gallery;
    public Image currentImage;
    public Button nextImg;
    public Button prevImg;

    public int i = 0;

    private void Start()
    {
        prevImg.interactable = false;
    }


    public void NextImg()
    {
        if(i < gallery.Length)
        {
            i++;
            currentImage.sprite = gallery[i];
            prevImg.interactable = true;
            
        }
        if (i == gallery.Length - 1)
        {
            nextImg.interactable = false;
        }


    }

    public void PrevImg()
    {
        i--;
        currentImage.sprite = gallery[i];
        nextImg.interactable = true;

        if (i == 0)
        {
            prevImg.interactable = false;
        }
        
               
    }
}

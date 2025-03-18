using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    //Variables
    public Button playButton;
    public Button exitButton;
    public Image clouds;
    public TextMeshProUGUI title;
    public GameObject map;
    public Button returnButton;
    
    public Button menuButton;
    public MansionQuizManager mansionQuizManager;
    public HraionQuizManager hraionQuizManager;
    public VasilikiQuizManager vasilikiQuizManager;
    public EfimiaQuizManager efimiaQuizManager;
    public SotirosQuizManager sotirosQuizManager;
    public ArtemidosQuizManager artemidosQuizManager;
    public LoutraQuizManager loutraQuizManager;
    public KardakiouQuizManager kardakiouQuizManager;
    public TheatroQuizManager theatroQuizManager;

    //For POI1

    public GameObject mansionPanel;
    public Button quiz;
    public GameObject photoCarousel;
    public GameObject textScroll;
    public GameObject videoPlayer;
    public GameObject mansionQuiz;

    //For POI2
    public GameObject hraionPanel;
    public Button quizHraion;
    public GameObject photoCarouselHraion;
    public GameObject textScrollHraion;
    public GameObject videoPlayerHraion;
    public GameObject hraionQuiz;

    //For POI3
    public GameObject vasilikiPanel;
    public Button quizVasiliki;
    public GameObject photoCarouselVasiliki;
    public GameObject textScrollVasiliki;
    public GameObject vasilikiQuiz;

    //For POI4
    public GameObject efimiaPanel;
    public Button quizEfimia;
    public GameObject photoCarouselEfimia;
    public GameObject textScrollEfimia;
    public GameObject videoPlayerEfimia;
    public GameObject efimiaQuiz;

    //For POI5
    public GameObject sotirosPanel;
    public Button quizSotiros;
    public GameObject photoCarouselSotiros;
    public GameObject textScrollSotiros;
    public GameObject sotirosQuiz;

    //For POI6
    public GameObject artemidosPanel;
    public Button quizArtemidos;
    public GameObject photoCarouselArtemidos;
    public GameObject textScrollArtemidos;
    public GameObject artemidosQuiz;

    //For POI7
    public GameObject loutraPanel;
    public Button quizLoutra;
    public GameObject photoCarouselLoutra;
    public GameObject textScrollLoutra;
    public GameObject videoPlayerLoutra;
    public GameObject loutraQuiz;

    //For POI8
    public GameObject kardakiouPanel;
    public Button quizKardakiou;
    public GameObject photoCarouselKardakiou;
    public GameObject textScrollKardakiou;
    public GameObject kardakiouQuiz;

    //For POI9
    public GameObject theatroPanel;
    public Button quizTheatro;
    public GameObject photoCarouselTheatro;
    public GameObject textScrollTheatro;
    public GameObject videoPlayerTheatro;
    public GameObject theatroQuiz;

    //For EndGame
    public GameObject gameOverPanel;
    public Button feedback;
    public TextMeshProUGUI gameOverText;

    public List<Button> pois;

    bool[] actPoi = new bool[9];
    bool show = true;
    int i;


    private void Awake()
    {
        ShowMenu(show);
        ShowPois(actPoi);
        mansionQuizManager = mansionQuizManager.GetComponent<MansionQuizManager>();
        hraionQuizManager = hraionQuizManager.GetComponent<HraionQuizManager>();
        vasilikiQuizManager = vasilikiQuizManager.GetComponent<VasilikiQuizManager>();
        efimiaQuizManager = efimiaQuizManager.GetComponent<EfimiaQuizManager>();
        sotirosQuizManager = sotirosQuizManager.GetComponent<SotirosQuizManager>();
        artemidosQuizManager = artemidosQuizManager.GetComponent<ArtemidosQuizManager>();
        loutraQuizManager = loutraQuizManager.GetComponent<LoutraQuizManager>();
        kardakiouQuizManager = kardakiouQuizManager.GetComponent<KardakiouQuizManager>();
        theatroQuizManager = theatroQuizManager.GetComponent<TheatroQuizManager>();
    }


    //Sets all POI Buttons Active or Inactive depending on the value each has in the boolean array, 
    //By default all values are equal to false.
    public void ShowPois(bool[] poi)
    {
        //actPoi = [false, false, false, false, false];

        pois[0].gameObject.SetActive(poi[0]);
        pois[1].gameObject.SetActive(poi[1]);
        pois[2].gameObject.SetActive(poi[2]);
        pois[3].gameObject.SetActive(poi[3]);
        pois[4].gameObject.SetActive(poi[4]);
        pois[5].gameObject.SetActive(poi[5]);
        pois[6].gameObject.SetActive(poi[6]);
        pois[7].gameObject.SetActive(poi[7]);
        pois[8].gameObject.SetActive(poi[8]);

    }

    //Sets all the Menu GameObjects Active by default the value is equal to true
    // the return button is used to return the player to the map so by default is false. (Same for the menu button,
    //with the difference that the player returns to the menu)
    //The panel for the first POI is by default false and becomes true when the player enters at the first POI.
    public void ShowMenu(bool show)
    {
        playButton.gameObject.SetActive(show);
        exitButton.gameObject.SetActive(show);
        clouds.gameObject.SetActive(show);
        title.gameObject.SetActive(show);
        returnButton.gameObject.SetActive(false);
        menuButton.gameObject.SetActive(false);
        mansionPanel.gameObject.SetActive(false);
        hraionPanel.gameObject.SetActive(false);
        vasilikiPanel.gameObject.SetActive(false);
        efimiaPanel.gameObject.SetActive(false);
        sotirosPanel.gameObject.SetActive(false);
        artemidosPanel.gameObject.SetActive(false);
        loutraPanel.gameObject.SetActive(false);
        kardakiouPanel.gameObject.SetActive(false);
        theatroPanel.gameObject.SetActive(false);
        gameOverPanel.gameObject.SetActive(false);
        

    }

    //This function will call when the player press the play button
    public void PressPlay()
    {
        //Makes all the menu GameObjects Inactive
        ShowMenu(show = false);
        //Makes Active the button to return to the menu
        menuButton.gameObject.SetActive(true);
        //Makes all the POIS Active
        for (i = 0; i <= 8; i++)
        {
            actPoi[i] = true;
            ShowPois(actPoi);
        }
        for (i = 1; i <= 8; i++)
        {
            pois[i].interactable = false;
        }

        //Makes POI2 interactable if the player passed the first POI and all the other POIS non interactable   
        if (PlayerPrefs.GetInt("rightAnswers",mansionQuizManager.rightAnswers) >0 || PlayerPrefs.GetInt("wrongAnswers",mansionQuizManager.wrongAnswers) >0 || 
            PlayerPrefs.GetInt("score",mansionQuizManager.score) >0 )
        {
            pois[1].interactable = true;

            for (i = 2; i <= 8; i++)
            {
                pois[i].interactable = false;
            }

            //Makes POI2 & POI3 interactable if the player passed the first and second POI and all the others non interactable
            if ((PlayerPrefs.GetInt("rightAnswers", mansionQuizManager.rightAnswers) > 0 || PlayerPrefs.GetInt("wrongAnswers", mansionQuizManager.wrongAnswers) > 0 ||
            PlayerPrefs.GetInt("score", mansionQuizManager.score) > 0) &&
            (PlayerPrefs.GetInt("rightAnswersHraion", hraionQuizManager.rightAnswersHraion) > 0 || PlayerPrefs.GetInt("wrongAnswersHraion", hraionQuizManager.wrongAnswersHraion) > 0 ||
            PlayerPrefs.GetInt("scoreHraion", hraionQuizManager.scoreHraion) > 0))
            {
                pois[1].interactable = true;
                pois[2].interactable = true;

                for (i = 3; i <= 8; i++)
                {
                    pois[i].interactable = false;
                }

                //Makes POI2 & POI3 & POI4 interactable if the player passed the first, second and third POI and all the others non interactable
                if ((PlayerPrefs.GetInt("rightAnswers", mansionQuizManager.rightAnswers) > 0 || PlayerPrefs.GetInt("wrongAnswers", mansionQuizManager.wrongAnswers) > 0 ||
                PlayerPrefs.GetInt("score", mansionQuizManager.score) > 0) &&
                (PlayerPrefs.GetInt("rightAnswersHraion", hraionQuizManager.rightAnswersHraion) > 0 || PlayerPrefs.GetInt("wrongAnswersHraion", hraionQuizManager.wrongAnswersHraion) > 0 ||
                PlayerPrefs.GetInt("scoreHraion", hraionQuizManager.scoreHraion) > 0) && (PlayerPrefs.GetInt("rightAnswersVasiliki", vasilikiQuizManager.rightAnswersVasiliki) > 0 ||
                PlayerPrefs.GetInt("wrongAnswersVasiliki", vasilikiQuizManager.wrongAnswersVasiliki) > 0 || PlayerPrefs.GetInt("scoreVasiliki", vasilikiQuizManager.scoreVasiliki) > 0))
                {
                    pois[1].interactable = true;
                    pois[2].interactable = true;
                    pois[3].interactable = true;

                    for (i = 4; i <= 8; i++)
                    {
                        pois[i].interactable = false;
                    }

                    //Makes POI2 & POI3 & POI4 & POI5 interactable if the player passed the first, second, third and fourth POI and all the others non interactable
                    if ((PlayerPrefs.GetInt("rightAnswers", mansionQuizManager.rightAnswers) > 0 || PlayerPrefs.GetInt("wrongAnswers", mansionQuizManager.wrongAnswers) > 0 ||
                    PlayerPrefs.GetInt("score", mansionQuizManager.score) > 0) &&
                    (PlayerPrefs.GetInt("rightAnswersHraion", hraionQuizManager.rightAnswersHraion) > 0 || PlayerPrefs.GetInt("wrongAnswersHraion", hraionQuizManager.wrongAnswersHraion) > 0 ||
                    PlayerPrefs.GetInt("scoreHraion", hraionQuizManager.scoreHraion) > 0) && (PlayerPrefs.GetInt("rightAnswersVasiliki", vasilikiQuizManager.rightAnswersVasiliki) > 0 ||
                    PlayerPrefs.GetInt("wrongAnswersVasiliki", vasilikiQuizManager.wrongAnswersVasiliki) > 0 || PlayerPrefs.GetInt("scoreVasiliki", vasilikiQuizManager.scoreVasiliki) > 0)
                    && (PlayerPrefs.GetInt("rightAnswersEfimia", efimiaQuizManager.rightAnswersEfimia) > 0 ||
                    PlayerPrefs.GetInt("wrongAnswersEfimia", efimiaQuizManager.wrongAnswersEfimia) > 0 || PlayerPrefs.GetInt("scoreEfimia", efimiaQuizManager.scoreEfimia) > 0))
                    {
                        pois[1].interactable = true;
                        pois[2].interactable = true;
                        pois[3].interactable = true;
                        pois[4].interactable = true;

                        for (i = 5; i <= 8; i++)
                        {
                            pois[i].interactable = false;
                        }

                        //Makes POI2 & POI3 & POI4 & POI5 & POI6 interactable if the player passed the first, second, third, fourth and fifth POI and all the others non interactable
                        if ((PlayerPrefs.GetInt("rightAnswers", mansionQuizManager.rightAnswers) > 0 || PlayerPrefs.GetInt("wrongAnswers", mansionQuizManager.wrongAnswers) > 0 ||
                        PlayerPrefs.GetInt("score", mansionQuizManager.score) > 0) &&
                        (PlayerPrefs.GetInt("rightAnswersHraion", hraionQuizManager.rightAnswersHraion) > 0 || PlayerPrefs.GetInt("wrongAnswersHraion", hraionQuizManager.wrongAnswersHraion) > 0 ||
                        PlayerPrefs.GetInt("scoreHraion", hraionQuizManager.scoreHraion) > 0) && (PlayerPrefs.GetInt("rightAnswersVasiliki", vasilikiQuizManager.rightAnswersVasiliki) > 0 ||
                        PlayerPrefs.GetInt("wrongAnswersVasiliki", vasilikiQuizManager.wrongAnswersVasiliki) > 0 || PlayerPrefs.GetInt("scoreVasiliki", vasilikiQuizManager.scoreVasiliki) > 0)
                        && (PlayerPrefs.GetInt("rightAnswersEfimia", efimiaQuizManager.rightAnswersEfimia) > 0 ||
                        PlayerPrefs.GetInt("wrongAnswersEfimia", efimiaQuizManager.wrongAnswersEfimia) > 0 || PlayerPrefs.GetInt("scoreEfimia", efimiaQuizManager.scoreEfimia) > 0) &&
                        (PlayerPrefs.GetInt("rightAnswersSotiros", sotirosQuizManager.rightAnswersSotiros) > 0 ||
                        PlayerPrefs.GetInt("wrongAnswersSotiros", sotirosQuizManager.wrongAnswersSotiros) > 0 || PlayerPrefs.GetInt("scoreSotiros", sotirosQuizManager.scoreSotiros) > 0))
                        {
                            pois[1].interactable = true;
                            pois[2].interactable = true;
                            pois[3].interactable = true;
                            pois[4].interactable = true;
                            pois[5].interactable = true;

                            for (i = 6; i <= 8; i++)
                            {
                                pois[i].interactable = false;
                            }

                            //Makes POI2 & POI3 & POI4 & POI5 & POI6 & POI7 interactable if the player passed the first, second, third, fourth, fifth and sixth POI and all the others
                            //non interactable
                            if ((PlayerPrefs.GetInt("rightAnswers", mansionQuizManager.rightAnswers) > 0 || PlayerPrefs.GetInt("wrongAnswers", mansionQuizManager.wrongAnswers) > 0 ||
                            PlayerPrefs.GetInt("score", mansionQuizManager.score) > 0) &&
                            (PlayerPrefs.GetInt("rightAnswersHraion", hraionQuizManager.rightAnswersHraion) > 0 || PlayerPrefs.GetInt("wrongAnswersHraion", hraionQuizManager.wrongAnswersHraion) > 0 ||
                            PlayerPrefs.GetInt("scoreHraion", hraionQuizManager.scoreHraion) > 0) && (PlayerPrefs.GetInt("rightAnswersVasiliki", vasilikiQuizManager.rightAnswersVasiliki) > 0 ||
                            PlayerPrefs.GetInt("wrongAnswersVasiliki", vasilikiQuizManager.wrongAnswersVasiliki) > 0 || PlayerPrefs.GetInt("scoreVasiliki", vasilikiQuizManager.scoreVasiliki) > 0)
                            && (PlayerPrefs.GetInt("rightAnswersEfimia", efimiaQuizManager.rightAnswersEfimia) > 0 ||
                            PlayerPrefs.GetInt("wrongAnswersEfimia", efimiaQuizManager.wrongAnswersEfimia) > 0 || PlayerPrefs.GetInt("scoreEfimia", efimiaQuizManager.scoreEfimia) > 0) &&
                            (PlayerPrefs.GetInt("rightAnswersSotiros", sotirosQuizManager.rightAnswersSotiros) > 0 ||
                            PlayerPrefs.GetInt("wrongAnswersSotiros", sotirosQuizManager.wrongAnswersSotiros) > 0 || PlayerPrefs.GetInt("scoreSotiros", sotirosQuizManager.scoreSotiros) > 0) &&
                            (PlayerPrefs.GetInt("rightAnswersArtemidos", artemidosQuizManager.rightAnswersArtemidos) > 0 ||
                            PlayerPrefs.GetInt("wrongAnswersArtemidos", artemidosQuizManager.wrongAnswersArtemidos) > 0 || PlayerPrefs.GetInt("scoreArtemidos", artemidosQuizManager.scoreArtemidos) > 0))
                            {
                                pois[1].interactable = true;
                                pois[2].interactable = true;
                                pois[3].interactable = true;
                                pois[4].interactable = true;
                                pois[5].interactable = true;
                                pois[6].interactable = true;

                                for (i = 7; i <= 8; i++)
                                {
                                    pois[i].interactable = false;
                                }

                                //Makes POI2 & POI3 & POI4 & POI5 & POI6 & POI7 & POI8 interactable if the player passed the first, second, third, fourth, fifth, sixth and seventh
                                //POI and all the others non interactable
                                if ((PlayerPrefs.GetInt("rightAnswers", mansionQuizManager.rightAnswers) > 0 || PlayerPrefs.GetInt("wrongAnswers", mansionQuizManager.wrongAnswers) > 0 ||
                                PlayerPrefs.GetInt("score", mansionQuizManager.score) > 0) &&
                                (PlayerPrefs.GetInt("rightAnswersHraion", hraionQuizManager.rightAnswersHraion) > 0 || PlayerPrefs.GetInt("wrongAnswersHraion", hraionQuizManager.wrongAnswersHraion) > 0 ||
                                PlayerPrefs.GetInt("scoreHraion", hraionQuizManager.scoreHraion) > 0) && (PlayerPrefs.GetInt("rightAnswersVasiliki", vasilikiQuizManager.rightAnswersVasiliki) > 0 ||
                                PlayerPrefs.GetInt("wrongAnswersVasiliki", vasilikiQuizManager.wrongAnswersVasiliki) > 0 || PlayerPrefs.GetInt("scoreVasiliki", vasilikiQuizManager.scoreVasiliki) > 0)
                                && (PlayerPrefs.GetInt("rightAnswersEfimia", efimiaQuizManager.rightAnswersEfimia) > 0 ||
                                PlayerPrefs.GetInt("wrongAnswersEfimia", efimiaQuizManager.wrongAnswersEfimia) > 0 || PlayerPrefs.GetInt("scoreEfimia", efimiaQuizManager.scoreEfimia) > 0) &&
                                (PlayerPrefs.GetInt("rightAnswersSotiros", sotirosQuizManager.rightAnswersSotiros) > 0 ||
                                PlayerPrefs.GetInt("wrongAnswersSotiros", sotirosQuizManager.wrongAnswersSotiros) > 0 || PlayerPrefs.GetInt("scoreSotiros", sotirosQuizManager.scoreSotiros) > 0) &&
                                (PlayerPrefs.GetInt("rightAnswersArtemidos", artemidosQuizManager.rightAnswersArtemidos) > 0 ||
                                PlayerPrefs.GetInt("wrongAnswersArtemidos", artemidosQuizManager.wrongAnswersArtemidos) > 0 || PlayerPrefs.GetInt("scoreArtemidos", artemidosQuizManager.scoreArtemidos) > 0)
                                && (PlayerPrefs.GetInt("rightAnswersLoutra", loutraQuizManager.rightAnswersLoutra) > 0 ||
                                PlayerPrefs.GetInt("wrongAnswersLoutra", loutraQuizManager.wrongAnswersLoutra) > 0 || PlayerPrefs.GetInt("scoreLoutra", loutraQuizManager.scoreLoutra) > 0))
                                {
                                    pois[1].interactable = true;
                                    pois[2].interactable = true;
                                    pois[3].interactable = true;
                                    pois[4].interactable = true;
                                    pois[5].interactable = true;
                                    pois[6].interactable = true;
                                    pois[7].interactable = true;

                                    for (i = 8; i <= 8; i++)
                                    {
                                        pois[i].interactable = false;
                                    }

                                    //Makes POI2 & POI3 & POI4 & POI5 & POI6 & POI7 & POI8 & POI9 interactable if the player passed the first, second, third, fourth, fifth, sixth, seventh
                                    // and eigth POI 
                                    if ((PlayerPrefs.GetInt("rightAnswers", mansionQuizManager.rightAnswers) > 0 || PlayerPrefs.GetInt("wrongAnswers", mansionQuizManager.wrongAnswers) > 0 ||
                                    PlayerPrefs.GetInt("score", mansionQuizManager.score) > 0) &&
                                    (PlayerPrefs.GetInt("rightAnswersHraion", hraionQuizManager.rightAnswersHraion) > 0 || PlayerPrefs.GetInt("wrongAnswersHraion", hraionQuizManager.wrongAnswersHraion) > 0 ||
                                    PlayerPrefs.GetInt("scoreHraion", hraionQuizManager.scoreHraion) > 0) && (PlayerPrefs.GetInt("rightAnswersVasiliki", vasilikiQuizManager.rightAnswersVasiliki) > 0 ||
                                    PlayerPrefs.GetInt("wrongAnswersVasiliki", vasilikiQuizManager.wrongAnswersVasiliki) > 0 || PlayerPrefs.GetInt("scoreVasiliki", vasilikiQuizManager.scoreVasiliki) > 0)
                                    && (PlayerPrefs.GetInt("rightAnswersEfimia", efimiaQuizManager.rightAnswersEfimia) > 0 ||
                                    PlayerPrefs.GetInt("wrongAnswersEfimia", efimiaQuizManager.wrongAnswersEfimia) > 0 || PlayerPrefs.GetInt("scoreEfimia", efimiaQuizManager.scoreEfimia) > 0) &&
                                    (PlayerPrefs.GetInt("rightAnswersSotiros", sotirosQuizManager.rightAnswersSotiros) > 0 ||
                                    PlayerPrefs.GetInt("wrongAnswersSotiros", sotirosQuizManager.wrongAnswersSotiros) > 0 || PlayerPrefs.GetInt("scoreSotiros", sotirosQuizManager.scoreSotiros) > 0) &&
                                    (PlayerPrefs.GetInt("rightAnswersArtemidos", artemidosQuizManager.rightAnswersArtemidos) > 0 ||
                                    PlayerPrefs.GetInt("wrongAnswersArtemidos", artemidosQuizManager.wrongAnswersArtemidos) > 0 || PlayerPrefs.GetInt("scoreArtemidos", artemidosQuizManager.scoreArtemidos) > 0)
                                    && (PlayerPrefs.GetInt("rightAnswersLoutra", loutraQuizManager.rightAnswersLoutra) > 0 ||
                                    PlayerPrefs.GetInt("wrongAnswersLoutra", loutraQuizManager.wrongAnswersLoutra) > 0 || PlayerPrefs.GetInt("scoreLoutra", loutraQuizManager.scoreLoutra) > 0)
                                    && (PlayerPrefs.GetInt("rightAnswersKardakiou", kardakiouQuizManager.rightAnswersKardakiou) > 0 ||
                                    PlayerPrefs.GetInt("wrongAnswersKardakiou", kardakiouQuizManager.wrongAnswersKardakiou) > 0 || PlayerPrefs.GetInt("scoreKardakiou", kardakiouQuizManager.scoreKardakiou) > 0))
                                    {
                                        pois[1].interactable = true;
                                        pois[2].interactable = true;
                                        pois[3].interactable = true;
                                        pois[4].interactable = true;
                                        pois[5].interactable = true;
                                        pois[6].interactable = true;
                                        pois[7].interactable = true;
                                        pois[8].interactable = true;

                                    }

                                }
                            }

                        }
                       
                }
                    
            }
                
        }
            
    }
            
        

   }

    //This function will call when the Player enters the Level 1, meaning when clicks on POI 1
    public void PressPOI1()
    {
        //Makes the map GameObject Inactive
        map.gameObject.SetActive(false);
        //Makes the panel for the first POI active
        mansionPanel.gameObject.SetActive(true);
        quiz.gameObject.SetActive(true);
        photoCarousel.gameObject.SetActive(true);
        textScroll.gameObject.SetActive(true);
        videoPlayer.gameObject.SetActive(true);
        mansionQuiz.gameObject.SetActive(false);
        //Makes the return button Active, so the player can return to the map
        returnButton.gameObject.SetActive(true);
        //Makes all the other POIS Inactive
        for (i = 0; i <= 8; i++)
        {
            actPoi[i] = false;
            ShowPois(actPoi);
        }    
        
    }

    //This function will call when the Player enters the Level 2, meaning when clicks on POI 2
    public void PressPOI2()
    {
        //Makes the map GameObject Inactive
        map.gameObject.SetActive(false);
        //Makes the panel for the first POI active
        hraionPanel.gameObject.SetActive(true);
        quizHraion.gameObject.SetActive(true);
        photoCarouselHraion.gameObject.SetActive(true);
        textScrollHraion.gameObject.SetActive(true);
        videoPlayerHraion.gameObject.SetActive(true);
        hraionQuiz.gameObject.SetActive(false);
        //Makes the return button Active, so the player can return to the map
        returnButton.gameObject.SetActive(true);
        //Makes all the other POIS Inactive
        for (i = 0; i <= 8; i++)
        {
            actPoi[i] = false;
            ShowPois(actPoi);
        }

    }

    //This function will call when the Player enters the Level 3, meaning when clicks on POI 3
    public void PressPOI3()
    {
        //Makes the map GameObject Inactive
        map.gameObject.SetActive(false);
        //Makes the panel for the first POI active
        vasilikiPanel.gameObject.SetActive(true);
        quizVasiliki.gameObject.SetActive(true);
        photoCarouselVasiliki.gameObject.SetActive(true);
        textScrollVasiliki.gameObject.SetActive(true);
        vasilikiQuiz.gameObject.SetActive(false);
        //Makes the return button Active, so the player can return to the map
        returnButton.gameObject.SetActive(true);
        //Makes all the other POIS Inactive
        for (i = 0; i <= 8; i++)
        {
            actPoi[i] = false;
            ShowPois(actPoi);
        }

    }

    //This function will call when the Player enters the Level 4, meaning when clicks on POI 4
    public void PressPOI4()
    {
        //Makes the map GameObject Inactive
        map.gameObject.SetActive(false);
        //Makes the panel for the first POI active
        efimiaPanel.gameObject.SetActive(true);
        quizEfimia.gameObject.SetActive(true);
        photoCarouselEfimia.gameObject.SetActive(true);
        textScrollEfimia.gameObject.SetActive(true);
        videoPlayerEfimia.gameObject.SetActive(true);
        efimiaQuiz.gameObject.SetActive(false);
        //Makes the return button Active, so the player can return to the map
        returnButton.gameObject.SetActive(true);
        //Makes all the other POIS Inactive
        for (i = 0; i <= 8; i++)
        {
            actPoi[i] = false;
            ShowPois(actPoi);
        }

    }

    //This function will call when the Player enters the Level 5, meaning when clicks on POI 5
    public void PressPOI5()
    {
        //Makes the map GameObject Inactive
        map.gameObject.SetActive(false);
        //Makes the panel for the first POI active
        sotirosPanel.gameObject.SetActive(true);
        quizSotiros.gameObject.SetActive(true);
        photoCarouselSotiros.gameObject.SetActive(true);
        textScrollSotiros.gameObject.SetActive(true);
        sotirosQuiz.gameObject.SetActive(false);
        //Makes the return button Active, so the player can return to the map
        returnButton.gameObject.SetActive(true);
        //Makes all the other POIS Inactive
        for (i = 0; i <= 8; i++)
        {
            actPoi[i] = false;
            ShowPois(actPoi);
        }

    }

    //This function will call when the Player enters the Level 6, meaning when clicks on POI 6
    public void PressPOI6()
    {
        //Makes the map GameObject Inactive
        map.gameObject.SetActive(false);
        //Makes the panel for the first POI active
        artemidosPanel.gameObject.SetActive(true);
        quizArtemidos.gameObject.SetActive(true);
        photoCarouselArtemidos.gameObject.SetActive(true);
        textScrollArtemidos.gameObject.SetActive(true);
        artemidosQuiz.gameObject.SetActive(false);
        //Makes the return button Active, so the player can return to the map
        returnButton.gameObject.SetActive(true);
        //Makes all the other POIS Inactive
        for (i = 0; i <= 8; i++)
        {
            actPoi[i] = false;
            ShowPois(actPoi);
        }

    }

    //This function will call when the Player enters the Level 7, meaning when clicks on POI 7
    public void PressPOI7()
    {
        //Makes the map GameObject Inactive
        map.gameObject.SetActive(false);
        //Makes the panel for the first POI active
        loutraPanel.gameObject.SetActive(true);
        quizLoutra.gameObject.SetActive(true);
        photoCarouselLoutra.gameObject.SetActive(true);
        textScrollLoutra.gameObject.SetActive(true);
        videoPlayerLoutra.gameObject.SetActive(true);
        loutraQuiz.gameObject.SetActive(false);
        //Makes the return button Active, so the player can return to the map
        returnButton.gameObject.SetActive(true);
        //Makes all the other POIS Inactive
        for (i = 0; i <= 8; i++)
        {
            actPoi[i] = false;
            ShowPois(actPoi);
        }

    }

    //This function will call when the Player enters the Level 8, meaning when clicks on POI 8
    public void PressPOI8()
    {
        //Makes the map GameObject Inactive
        map.gameObject.SetActive(false);
        //Makes the panel for the first POI active
        kardakiouPanel.gameObject.SetActive(true);
        quizKardakiou.gameObject.SetActive(true);
        photoCarouselKardakiou.gameObject.SetActive(true);
        textScrollKardakiou.gameObject.SetActive(true);
        kardakiouQuiz.gameObject.SetActive(false);
        //Makes the return button Active, so the player can return to the map
        returnButton.gameObject.SetActive(true);
        //Makes all the other POIS Inactive
        for (i = 0; i <= 8; i++)
        {
            actPoi[i] = false;
            ShowPois(actPoi);
        }

    }

    //This function will call when the Player enters the Level 9, meaning when clicks on POI 9
    public void PressPOI9()
    {
        //Makes the map GameObject Inactive
        map.gameObject.SetActive(false);
        //Makes the panel for the first POI active
        theatroPanel.gameObject.SetActive(true);
        quizTheatro.gameObject.SetActive(true);
        photoCarouselTheatro.gameObject.SetActive(true);
        textScrollTheatro.gameObject.SetActive(true);
        videoPlayerTheatro.gameObject.SetActive(true);
        theatroQuiz.gameObject.SetActive(false);
        //Makes the return button Active, so the player can return to the map
        returnButton.gameObject.SetActive(true);
        //Makes all the other POIS Inactive
        for (i = 0; i <= 8; i++)
        {
            actPoi[i] = false;
            ShowPois(actPoi);
        }

    }

    //This function will call when the player presses the return button in any POI
    public void ReturnToMap()
    {
        //Makes the map GameObject Active
        map.gameObject.SetActive(true);
        //Makes the panel for the POIS inactive
        mansionPanel.gameObject.SetActive(false);
        hraionPanel.gameObject.SetActive(false);
        vasilikiPanel.gameObject.SetActive(false);
        efimiaPanel.gameObject.SetActive(false);
        sotirosPanel.gameObject.SetActive(false);
        artemidosPanel.gameObject.SetActive(false);
        loutraPanel.gameObject.SetActive(false);
        kardakiouPanel.gameObject.SetActive(false);
        theatroPanel.gameObject.SetActive(false);
        //Makes the return button Inactive
        returnButton.gameObject.SetActive(false);
        //Makes all POIS Active
        for (i = 0; i <= 8; i++)
        {
            actPoi[i] = true;
            ShowPois(actPoi);
        }

        //Makes POI2 interactable if the player passed the first POI and all the others non interactable
        if (PlayerPrefs.GetInt("rightAnswers", mansionQuizManager.rightAnswers) > 0 || PlayerPrefs.GetInt("wrongAnswers", mansionQuizManager.wrongAnswers) > 0 ||
                PlayerPrefs.GetInt("score", mansionQuizManager.score) > 0)
        {
            pois[1].interactable = true;

            for (i = 2; i <= 8; i++)
            {
                pois[i].interactable = false;
            }

            //Makes POI2 & POI3  interactable if the player passed the first and second POI and all the others non interactable
            if ((PlayerPrefs.GetInt("rightAnswers", mansionQuizManager.rightAnswers) > 0 || PlayerPrefs.GetInt("wrongAnswers", mansionQuizManager.wrongAnswers) > 0 ||
            PlayerPrefs.GetInt("score", mansionQuizManager.score) > 0) &&
            (PlayerPrefs.GetInt("rightAnswersHraion", hraionQuizManager.rightAnswersHraion) > 0 || PlayerPrefs.GetInt("wrongAnswersHraion", hraionQuizManager.wrongAnswersHraion) > 0 ||
            PlayerPrefs.GetInt("scoreHraion", hraionQuizManager.scoreHraion) > 0))
            {
                pois[1].interactable = true;
                pois[2].interactable = true;

                for (i = 3; i <= 8; i++)
                {
                    pois[i].interactable = false;
                }

                // Makes POI2 &POI3 & POI4 interactable if the player passed the first, second and third POI and all the others non interactable
                if ((PlayerPrefs.GetInt("rightAnswers", mansionQuizManager.rightAnswers) > 0 || PlayerPrefs.GetInt("wrongAnswers", mansionQuizManager.wrongAnswers) > 0 ||
                PlayerPrefs.GetInt("score", mansionQuizManager.score) > 0) &&
                (PlayerPrefs.GetInt("rightAnswersHraion", hraionQuizManager.rightAnswersHraion) > 0 || PlayerPrefs.GetInt("wrongAnswersHraion", hraionQuizManager.wrongAnswersHraion) > 0 ||
                PlayerPrefs.GetInt("scoreHraion", hraionQuizManager.scoreHraion) > 0) && (PlayerPrefs.GetInt("rightAnswersVasiliki", vasilikiQuizManager.rightAnswersVasiliki) > 0 ||
                PlayerPrefs.GetInt("wrongAnswersVasiliki", vasilikiQuizManager.wrongAnswersVasiliki) > 0 || PlayerPrefs.GetInt("scoreVasiliki", vasilikiQuizManager.scoreVasiliki) > 0))
                {
                    pois[1].interactable = true;
                    pois[2].interactable = true;
                    pois[3].interactable = true;

                    for (i = 4; i <= 8; i++)
                    {
                        pois[i].interactable = false;
                    }

                    //Makes POI2 & POI3 & POI4 & POI5 interactable if the player passed the first, second, third and fourth POI and all the others non interactable
                    if ((PlayerPrefs.GetInt("rightAnswers", mansionQuizManager.rightAnswers) > 0 || PlayerPrefs.GetInt("wrongAnswers", mansionQuizManager.wrongAnswers) > 0 ||
                    PlayerPrefs.GetInt("score", mansionQuizManager.score) > 0) &&
                    (PlayerPrefs.GetInt("rightAnswersHraion", hraionQuizManager.rightAnswersHraion) > 0 || PlayerPrefs.GetInt("wrongAnswersHraion", hraionQuizManager.wrongAnswersHraion) > 0 ||
                    PlayerPrefs.GetInt("scoreHraion", hraionQuizManager.scoreHraion) > 0) && (PlayerPrefs.GetInt("rightAnswersVasiliki", vasilikiQuizManager.rightAnswersVasiliki) > 0 ||
                    PlayerPrefs.GetInt("wrongAnswersVasiliki", vasilikiQuizManager.wrongAnswersVasiliki) > 0 || PlayerPrefs.GetInt("scoreVasiliki", vasilikiQuizManager.scoreVasiliki) > 0)
                    && (PlayerPrefs.GetInt("rightAnswersEfimia", efimiaQuizManager.rightAnswersEfimia) > 0 ||
                    PlayerPrefs.GetInt("wrongAnswersEfimia", efimiaQuizManager.wrongAnswersEfimia) > 0 || PlayerPrefs.GetInt("scoreEfimia", efimiaQuizManager.scoreEfimia) > 0))
                    {
                        pois[1].interactable = true;
                        pois[2].interactable = true;
                        pois[3].interactable = true;
                        pois[4].interactable = true;

                        for (i = 5; i <= 8; i++)
                        {
                            pois[i].interactable = false;
                        }

                        //Makes POI2 & POI3 & POI4 & POI5 & POI6 interactable if the player passed the first, second, third, fourth and fifth POI and all the others non interactable
                        if ((PlayerPrefs.GetInt("rightAnswers", mansionQuizManager.rightAnswers) > 0 || PlayerPrefs.GetInt("wrongAnswers", mansionQuizManager.wrongAnswers) > 0 ||
                        PlayerPrefs.GetInt("score", mansionQuizManager.score) > 0) &&
                        (PlayerPrefs.GetInt("rightAnswersHraion", hraionQuizManager.rightAnswersHraion) > 0 || PlayerPrefs.GetInt("wrongAnswersHraion", hraionQuizManager.wrongAnswersHraion) > 0 ||
                        PlayerPrefs.GetInt("scoreHraion", hraionQuizManager.scoreHraion) > 0) && (PlayerPrefs.GetInt("rightAnswersVasiliki", vasilikiQuizManager.rightAnswersVasiliki) > 0 ||
                        PlayerPrefs.GetInt("wrongAnswersVasiliki", vasilikiQuizManager.wrongAnswersVasiliki) > 0 || PlayerPrefs.GetInt("scoreVasiliki", vasilikiQuizManager.scoreVasiliki) > 0)
                        && (PlayerPrefs.GetInt("rightAnswersEfimia", efimiaQuizManager.rightAnswersEfimia) > 0 ||
                        PlayerPrefs.GetInt("wrongAnswersEfimia", efimiaQuizManager.wrongAnswersEfimia) > 0 || PlayerPrefs.GetInt("scoreEfimia", efimiaQuizManager.scoreEfimia) > 0) &&
                        (PlayerPrefs.GetInt("rightAnswersSotiros", sotirosQuizManager.rightAnswersSotiros) > 0 ||
                        PlayerPrefs.GetInt("wrongAnswersSotiros", sotirosQuizManager.wrongAnswersSotiros) > 0 || PlayerPrefs.GetInt("scoreSotiros", sotirosQuizManager.scoreSotiros) > 0))
                        {
                            pois[1].interactable = true;
                            pois[2].interactable = true;
                            pois[3].interactable = true;
                            pois[4].interactable = true;
                            pois[5].interactable = true;

                            for (i = 6; i <= 8; i++)
                            {
                                pois[i].interactable = false;
                            }

                            //Makes POI2 & POI3 & POI4 & POI5 & POI6 & POI7 interactable if the player passed the first, second, third, fourth, fifth and sixth POI and all the others
                            //non interactable
                            if ((PlayerPrefs.GetInt("rightAnswers", mansionQuizManager.rightAnswers) > 0 || PlayerPrefs.GetInt("wrongAnswers", mansionQuizManager.wrongAnswers) > 0 ||
                            PlayerPrefs.GetInt("score", mansionQuizManager.score) > 0) &&
                            (PlayerPrefs.GetInt("rightAnswersHraion", hraionQuizManager.rightAnswersHraion) > 0 || PlayerPrefs.GetInt("wrongAnswersHraion", hraionQuizManager.wrongAnswersHraion) > 0 ||
                            PlayerPrefs.GetInt("scoreHraion", hraionQuizManager.scoreHraion) > 0) && (PlayerPrefs.GetInt("rightAnswersVasiliki", vasilikiQuizManager.rightAnswersVasiliki) > 0 ||
                            PlayerPrefs.GetInt("wrongAnswersVasiliki", vasilikiQuizManager.wrongAnswersVasiliki) > 0 || PlayerPrefs.GetInt("scoreVasiliki", vasilikiQuizManager.scoreVasiliki) > 0)
                            && (PlayerPrefs.GetInt("rightAnswersEfimia", efimiaQuizManager.rightAnswersEfimia) > 0 ||
                            PlayerPrefs.GetInt("wrongAnswersEfimia", efimiaQuizManager.wrongAnswersEfimia) > 0 || PlayerPrefs.GetInt("scoreEfimia", efimiaQuizManager.scoreEfimia) > 0) &&
                            (PlayerPrefs.GetInt("rightAnswersSotiros", sotirosQuizManager.rightAnswersSotiros) > 0 ||
                            PlayerPrefs.GetInt("wrongAnswersSotiros", sotirosQuizManager.wrongAnswersSotiros) > 0 || PlayerPrefs.GetInt("scoreSotiros", sotirosQuizManager.scoreSotiros) > 0) &&
                            (PlayerPrefs.GetInt("rightAnswersArtemidos", artemidosQuizManager.rightAnswersArtemidos) > 0 ||
                            PlayerPrefs.GetInt("wrongAnswersArtemidos", artemidosQuizManager.wrongAnswersArtemidos) > 0 || PlayerPrefs.GetInt("scoreArtemidos", artemidosQuizManager.scoreArtemidos) > 0))
                            {
                                pois[1].interactable = true;
                                pois[2].interactable = true;
                                pois[3].interactable = true;
                                pois[4].interactable = true;
                                pois[5].interactable = true;
                                pois[6].interactable = true;

                                for (i = 7; i <= 8; i++)
                                {
                                    pois[i].interactable = false;
                                }

                                //Makes POI2 & POI3 & POI4 & POI5 & POI6 & POI7 & POI8 interactable if the player passed the first, second, third, fourth, fifth, sixth and seventh
                                //POI and all the others non interactable
                                if ((PlayerPrefs.GetInt("rightAnswers", mansionQuizManager.rightAnswers) > 0 || PlayerPrefs.GetInt("wrongAnswers", mansionQuizManager.wrongAnswers) > 0 ||
                                PlayerPrefs.GetInt("score", mansionQuizManager.score) > 0) &&
                                (PlayerPrefs.GetInt("rightAnswersHraion", hraionQuizManager.rightAnswersHraion) > 0 || PlayerPrefs.GetInt("wrongAnswersHraion", hraionQuizManager.wrongAnswersHraion) > 0 ||
                                PlayerPrefs.GetInt("scoreHraion", hraionQuizManager.scoreHraion) > 0) && (PlayerPrefs.GetInt("rightAnswersVasiliki", vasilikiQuizManager.rightAnswersVasiliki) > 0 ||
                                PlayerPrefs.GetInt("wrongAnswersVasiliki", vasilikiQuizManager.wrongAnswersVasiliki) > 0 || PlayerPrefs.GetInt("scoreVasiliki", vasilikiQuizManager.scoreVasiliki) > 0)
                                && (PlayerPrefs.GetInt("rightAnswersEfimia", efimiaQuizManager.rightAnswersEfimia) > 0 ||
                                PlayerPrefs.GetInt("wrongAnswersEfimia", efimiaQuizManager.wrongAnswersEfimia) > 0 || PlayerPrefs.GetInt("scoreEfimia", efimiaQuizManager.scoreEfimia) > 0) &&
                                (PlayerPrefs.GetInt("rightAnswersSotiros", sotirosQuizManager.rightAnswersSotiros) > 0 ||
                                PlayerPrefs.GetInt("wrongAnswersSotiros", sotirosQuizManager.wrongAnswersSotiros) > 0 || PlayerPrefs.GetInt("scoreSotiros", sotirosQuizManager.scoreSotiros) > 0) &&
                                (PlayerPrefs.GetInt("rightAnswersArtemidos", artemidosQuizManager.rightAnswersArtemidos) > 0 ||
                                PlayerPrefs.GetInt("wrongAnswersArtemidos", artemidosQuizManager.wrongAnswersArtemidos) > 0 || PlayerPrefs.GetInt("scoreArtemidos", artemidosQuizManager.scoreArtemidos) > 0)
                                && (PlayerPrefs.GetInt("rightAnswersLoutra", loutraQuizManager.rightAnswersLoutra) > 0 ||
                                PlayerPrefs.GetInt("wrongAnswersLoutra", loutraQuizManager.wrongAnswersLoutra) > 0 || PlayerPrefs.GetInt("scoreLoutra", loutraQuizManager.scoreLoutra) > 0))
                                {
                                    pois[1].interactable = true;
                                    pois[2].interactable = true;
                                    pois[3].interactable = true;
                                    pois[4].interactable = true;
                                    pois[5].interactable = true;
                                    pois[6].interactable = true;
                                    pois[7].interactable = true;

                                    for (i = 8; i <= 8; i++)
                                    {
                                        pois[i].interactable = false;
                                    }

                                    //Makes POI2 & POI3 & POI4 & POI5 & POI6 & POI7 & POI8 & POI9 interactable if the player passed the first, second, third, fourth, fifth, sixth, seventh
                                    // and eigth POI 
                                    if ((PlayerPrefs.GetInt("rightAnswers", mansionQuizManager.rightAnswers) > 0 || PlayerPrefs.GetInt("wrongAnswers", mansionQuizManager.wrongAnswers) > 0 ||
                                    PlayerPrefs.GetInt("score", mansionQuizManager.score) > 0) &&
                                    (PlayerPrefs.GetInt("rightAnswersHraion", hraionQuizManager.rightAnswersHraion) > 0 || PlayerPrefs.GetInt("wrongAnswersHraion", hraionQuizManager.wrongAnswersHraion) > 0 ||
                                    PlayerPrefs.GetInt("scoreHraion", hraionQuizManager.scoreHraion) > 0) && (PlayerPrefs.GetInt("rightAnswersVasiliki", vasilikiQuizManager.rightAnswersVasiliki) > 0 ||
                                    PlayerPrefs.GetInt("wrongAnswersVasiliki", vasilikiQuizManager.wrongAnswersVasiliki) > 0 || PlayerPrefs.GetInt("scoreVasiliki", vasilikiQuizManager.scoreVasiliki) > 0)
                                    && (PlayerPrefs.GetInt("rightAnswersEfimia", efimiaQuizManager.rightAnswersEfimia) > 0 ||
                                    PlayerPrefs.GetInt("wrongAnswersEfimia", efimiaQuizManager.wrongAnswersEfimia) > 0 || PlayerPrefs.GetInt("scoreEfimia", efimiaQuizManager.scoreEfimia) > 0) &&
                                    (PlayerPrefs.GetInt("rightAnswersSotiros", sotirosQuizManager.rightAnswersSotiros) > 0 ||
                                    PlayerPrefs.GetInt("wrongAnswersSotiros", sotirosQuizManager.wrongAnswersSotiros) > 0 || PlayerPrefs.GetInt("scoreSotiros", sotirosQuizManager.scoreSotiros) > 0) &&
                                    (PlayerPrefs.GetInt("rightAnswersArtemidos", artemidosQuizManager.rightAnswersArtemidos) > 0 ||
                                    PlayerPrefs.GetInt("wrongAnswersArtemidos", artemidosQuizManager.wrongAnswersArtemidos) > 0 || PlayerPrefs.GetInt("scoreArtemidos", artemidosQuizManager.scoreArtemidos) > 0)
                                    && (PlayerPrefs.GetInt("rightAnswersLoutra", loutraQuizManager.rightAnswersLoutra) > 0 ||
                                    PlayerPrefs.GetInt("wrongAnswersLoutra", loutraQuizManager.wrongAnswersLoutra) > 0 || PlayerPrefs.GetInt("scoreLoutra", loutraQuizManager.scoreLoutra) > 0)
                                    && (PlayerPrefs.GetInt("rightAnswersKardakiou", kardakiouQuizManager.rightAnswersKardakiou) > 0 ||
                                    PlayerPrefs.GetInt("wrongAnswersKardakiou", kardakiouQuizManager.wrongAnswersKardakiou) > 0 || PlayerPrefs.GetInt("scoreKardakiou", kardakiouQuizManager.scoreKardakiou) > 0))
                                    {
                                        pois[1].interactable = true;
                                        pois[2].interactable = true;
                                        pois[3].interactable = true;
                                        pois[4].interactable = true;
                                        pois[5].interactable = true;
                                        pois[6].interactable = true;
                                        pois[7].interactable = true;
                                        pois[8].interactable = true;

                                    }
                                }


                            }

                        }


                    }


                }

            }

        }
    }
   
   //This function runs when the player presses the continue button in first quiz 
    public void GoToLevel2()
    {
        mansionPanel.SetActive(false);
        map.gameObject.SetActive(true);
        pois[1].interactable = true;
        for (i = 0; i <= 8; i++)
        {
            actPoi[i] = true;
            ShowPois(actPoi);
        }
        //pois[0].interactable = false;
        returnButton.gameObject.SetActive(false);
    }

    //This function runs when the player presses the continue button in the second quiz
    public void GoToLevel3()
    {
        hraionPanel.SetActive(false);
        map.gameObject.SetActive(true);
        pois[2].interactable = true;
        for (i = 0; i <= 8; i++)
        {
            actPoi[i] = true;
            ShowPois(actPoi);
        }
        //pois[0].interactable = false;
        returnButton.gameObject.SetActive(false);
    }

    //This function runs when the player presses the continue button in third quiz
    public void GoToLevel4()
    {
        vasilikiPanel.SetActive(false);
        map.gameObject.SetActive(true);
        pois[3].interactable = true;
        for (i = 0; i <= 8; i++)
        {
            actPoi[i] = true;
            ShowPois(actPoi);
        }
        returnButton.gameObject.SetActive(false);
    }

    //This function runs when the player presses the continue button in fourth quiz
    public void GoToLevel5()
    {
        efimiaPanel.SetActive(false);
        map.gameObject.SetActive(true);
        pois[4].interactable = true;
        for (i = 0; i <= 8; i++)
        {
            actPoi[i] = true;
            ShowPois(actPoi);
        }
        returnButton.gameObject.SetActive(false);
    }

    //This function runs when the player presses the continue button in fifth quiz
    public void GoToLevel6()
    {
        sotirosPanel.SetActive(false);
        map.gameObject.SetActive(true);
        pois[5].interactable = true;
        for (i = 0; i <= 8; i++)
        {
            actPoi[i] = true;
            ShowPois(actPoi);
        }
        returnButton.gameObject.SetActive(false);
    }


    //This function runs when the player presses the continue button in sixth quiz
    public void GoToLevel7()
    {
        artemidosPanel.SetActive(false);
        map.gameObject.SetActive(true);
        pois[6].interactable = true;
        for (i = 0; i <= 8; i++)
        {
            actPoi[i] = true;
            ShowPois(actPoi);
        }
        returnButton.gameObject.SetActive(false);
    }

    //This function runs when the player presses the continue button in seventh quiz
    public void GoToLevel8()
    {
        loutraPanel.SetActive(false);
        map.gameObject.SetActive(true);
        pois[7].interactable = true;
        for (i = 0; i <= 8; i++)
        {
            actPoi[i] = true;
            ShowPois(actPoi);
        }
        returnButton.gameObject.SetActive(false);
    }


    //This function runs when the player presses the continue button in eigth quiz
    public void GoToLevel9()
    {
        kardakiouPanel.SetActive(false);
        map.gameObject.SetActive(true);
        pois[8].interactable = true;
        for (i = 0; i <= 8; i++)
        {
            actPoi[i] = true;
            ShowPois(actPoi);
        }
        returnButton.gameObject.SetActive(false);
    }

    //This function runs when the player presses the continue button in ninth quiz
    public void EndGame()
    {
        theatroPanel.SetActive(false);
        map.gameObject.SetActive(true);
        for (i = 0; i <= 8; i++)
        {
            actPoi[i] = false;
            ShowPois(actPoi);
        }
        returnButton.gameObject.SetActive(false);
        gameOverPanel.gameObject.SetActive(true);
        menuButton.gameObject.SetActive(true);
    }

    

    //This function will call when the player presses the Exit button
    public void ExitApplication()
    {
        //Exits the Application
        Application.Quit();
    }


    //This function will call when the player presses the menu button
    public void ReturnToMenu()
    {
        //Makes all the menu GameObjects Active
        ShowMenu(show = true);
        map.gameObject.SetActive(true);
        //Makes all the POIS Inactive
        for (i = 0; i <= 8; i++)
        {
            actPoi[i] = false;
            ShowPois(actPoi);
        }
    }


}

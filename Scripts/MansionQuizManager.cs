using System.Collections;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MansionQuizManager : MonoBehaviour
{

    [SerializeField] Button quiz;
    [SerializeField] GameObject photoCarousel;
    [SerializeField] GameObject textScroll;
    [SerializeField] GameObject videoPlayer;
    [SerializeField] GameObject firstQuiz;
    [SerializeField] Button returnButton;



    public int currentQuestion = 0;
    public TextMeshProUGUI questionText;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI rightAnswersCounter;
    public TextMeshProUGUI wrongAnswersCounter;
    public Button[] answerButtons;
    public Button retryButton;
    public GameObject correct;
    public GameObject wrong;
    public Button nextLevel;
    public MansionQuestions questionsData;

    public int score = 0;
    public int rightAnswers = 0;
    public int wrongAnswers = 0;
   
    



    // This function called when the player presses the quiz button
    public void GoToQuiz()
    {
        photoCarousel.gameObject.SetActive(false);
        textScroll.gameObject.SetActive(false);
        videoPlayer.gameObject.SetActive(false);
        quiz.gameObject.SetActive(false);
        returnButton.gameObject.SetActive(false);
        firstQuiz.gameObject.SetActive(true);
        retryButton.interactable = false;

        if (PlayerPrefs.GetInt("rightAnswers") > 0 || PlayerPrefs.GetInt("wrongAnswers") > 0 || PlayerPrefs.GetInt("score") > 0)
        {
            foreach (Button b in answerButtons)
            {
                b.interactable = false;
            }

            retryButton.interactable = true;
        }

    }

    //When the player clicks the return button in the quiz will return to the text/photo/video screen
    public void GoBack()
    {
        photoCarousel.gameObject.SetActive(true);
        textScroll.gameObject.SetActive(true);
        videoPlayer.gameObject.SetActive(true);
        quiz.gameObject.SetActive(true);
        returnButton.gameObject.SetActive(true);
        firstQuiz.gameObject.SetActive(false);
    }

    // Start is called before the first frame update
    //Shows the question and the possible answers of ach question by calling the SetQuestion function
    void Start()
    {
        SetQuestion(currentQuestion);
        nextLevel.interactable = false;
        correct.gameObject.SetActive(false);
        wrong.gameObject.SetActive(false);


        //Load the previous try values
        LoadAnswers();

        scoreText.GetComponent<TextMeshProUGUI>().text = "Score:" + score;
        rightAnswersCounter.GetComponent<TextMeshProUGUI>().text = "Σωστές Απαντήσεις:" + rightAnswers + "/4";
        wrongAnswersCounter.GetComponent<TextMeshProUGUI>().text = "Λάθος Απαντήσεις:" + wrongAnswers + "/4";




    }

    //This function is for showing the question and answers on the UI
    void SetQuestion(int index)
    {
        //Makes the text equal to the text of the questions data set
        questionText.text = questionsData.questions[index].questionText;

        //Remove all previous Listeners for all the answer buttons
        foreach (Button b in answerButtons)
        {
            b.onClick.RemoveAllListeners();
        }

        //For each button replace the text with the right text from the questions data set
        for (int i = 0; i < answerButtons.Length; i++)
        {
            answerButtons[i].transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = questionsData.questions[index].answers[i];
            int answerIndex = i;
            //Checks if the answer is correct when the button clicks with the Check Answer function
            answerButtons[i].onClick.AddListener(() =>
            {
                CheckAnswer(answerIndex);
            });

        }

        
    }

    //This function checks if the answer is correct
    void CheckAnswer(int answerIndex)
    {
       
        //If the answer is correct adds +10 to score, show a correct message and makes all the button non interactable for 2 seconds
        if (answerIndex == questionsData.questions[currentQuestion].correctAnswer)
        {          
            score = score + 10;
            scoreText.GetComponent<TextMeshProUGUI>().text = "Score:" + score;

            rightAnswers = rightAnswers + 1;
            rightAnswersCounter.GetComponent<TextMeshProUGUI>().text = "Σωστές Απαντήσεις:" + rightAnswers + "/4";

            correct.gameObject.SetActive(true);

            foreach (Button b in answerButtons)
            {
                b.interactable = false;
            }

            StartCoroutine(Next());
        }
        //If the answer is wrong shows a wrong message, doesn't adds anything to score and makes all the butttons non interractable for 2 seconds
        else
        {
            wrong.gameObject.SetActive(true);
            wrongAnswers = wrongAnswers + 1;
            wrongAnswersCounter.GetComponent<TextMeshProUGUI>().text = "Λάθος Απαντήσεις:" + wrongAnswers + "/4";

            foreach (Button b in answerButtons)
            {
                b.interactable = false;
            }

            StartCoroutine(Next());
        }

    }

    //Waits for 2 seconds before shows the next question
    IEnumerator Next()
    {
        yield return new WaitForSeconds(2);

        currentQuestion++;

        if (currentQuestion < questionsData.questions.Length)
        {
            ResetQuiz();
        }
        if(currentQuestion == questionsData.questions.Length)
        {
            nextLevel.interactable = true;
            SaveAnswers();
        }

    }

    //Resets the buttons and shows the next question
    public void ResetQuiz()
    {
        correct.gameObject.SetActive(false);
        wrong.gameObject.SetActive(false);

        foreach(Button b in answerButtons)
        {
            b.interactable = true;
        }

        SetQuestion(currentQuestion);
    }

    //When the retry button clicked the values of the previous try set to zero and the answers buttons become interactable
   public void RetryQuiz()
    {
       
        foreach (Button b in answerButtons)
         {
             b.interactable = true;
         }
        PlayerPrefs.DeleteKey("rightAnswers");
        PlayerPrefs.DeleteKey("wrongAnswers");
        PlayerPrefs.DeleteKey("score");
        LoadAnswers();
        scoreText.GetComponent<TextMeshProUGUI>().text = "Score:" + score;
        rightAnswersCounter.GetComponent<TextMeshProUGUI>().text = "Σωστές Απαντήσεις:" + rightAnswers + "/4";
        wrongAnswersCounter.GetComponent<TextMeshProUGUI>().text = "Λάθος Απαντήσεις:" + wrongAnswers + "/4";
        retryButton.interactable = false;
    }

    //Loads the stored values of the previous try
    public void LoadAnswers()
    { 
        if(rightAnswers<=4 || wrongAnswers<=4 || score<=40)
        {
            rightAnswers = PlayerPrefs.GetInt("rightAnswers");
            wrongAnswers = PlayerPrefs.GetInt("wrongAnswers");
            score = PlayerPrefs.GetInt("score");
        }
       
    }

    //Save the values of a quiz try
    public void SaveAnswers()
    {
        if(rightAnswers<=4 || wrongAnswers<=4 || score<=40)
        {
            PlayerPrefs.SetInt("rightAnswers", rightAnswers);
            PlayerPrefs.SetInt("wrongAnswers", wrongAnswers);
            PlayerPrefs.SetInt("score", score);
            PlayerPrefs.Save();
        }
    }
    

}

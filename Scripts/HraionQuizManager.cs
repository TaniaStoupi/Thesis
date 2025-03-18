using System.Collections;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HraionQuizManager : MonoBehaviour
{

    [SerializeField] Button quizHraion;
    [SerializeField] GameObject photoCarouselHraion;
    [SerializeField] GameObject textScrollHraion;
    [SerializeField] GameObject videoPlayerHraion;
    [SerializeField] GameObject secondQuiz;
    [SerializeField] Button returnButtonHraion;



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
    public HraionQuestions questionsData;

    public int scoreHraion = 0;
    public int rightAnswersHraion = 0;
    public int wrongAnswersHraion = 0;





    // This function called when the player presses the quiz button
    public void GoToQuizHraion()
    {
        photoCarouselHraion.gameObject.SetActive(false);
        textScrollHraion.gameObject.SetActive(false);
        videoPlayerHraion.gameObject.SetActive(false);
        quizHraion.gameObject.SetActive(false);
        returnButtonHraion.gameObject.SetActive(false);
        secondQuiz.gameObject.SetActive(true);
        retryButton.interactable = false;

        if (PlayerPrefs.GetInt("rightAnswersHraion") > 0 || PlayerPrefs.GetInt("wrongAnswersHraion") > 0 || PlayerPrefs.GetInt("scoreHraion") > 0)
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
        photoCarouselHraion.gameObject.SetActive(true);
        textScrollHraion.gameObject.SetActive(true);
        videoPlayerHraion.gameObject.SetActive(true);
        quizHraion.gameObject.SetActive(true);
        returnButtonHraion.gameObject.SetActive(true);
        secondQuiz.gameObject.SetActive(false);
    }

    // Start is called before the first frame update
    //Shows the question and the possible answers of each question by calling the SetQuestion function
    void Start()
    {
        SetQuestion(currentQuestion);
        nextLevel.interactable = false;
        correct.gameObject.SetActive(false);
        wrong.gameObject.SetActive(false);


        //Load the previous try values
        LoadAnswers();

        scoreText.GetComponent<TextMeshProUGUI>().text = "Score:" + scoreHraion;
        rightAnswersCounter.GetComponent<TextMeshProUGUI>().text = "Σωστές Απαντήσεις:" + rightAnswersHraion + "/8";
        wrongAnswersCounter.GetComponent<TextMeshProUGUI>().text = "Λάθος Απαντήσεις:" + wrongAnswersHraion + "/8";




    }

    //This function is for showing the question and answers on the UI
   public void SetQuestion(int index)
    {
        //Makes the text equal to the text of the questions data set
        questionText.text = questionsData.questionshraion[index].questionText;

        //Remove all previous Listeners for all the answer buttons
        foreach (Button b in answerButtons)
        {
            b.onClick.RemoveAllListeners();
        }

        //For each button replace the text with the right text from the questions data set
        for (int i = 0; i < answerButtons.Length; i++)
        {
            answerButtons[i].transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = questionsData.questionshraion[index].answershraion[i];
            int answerIndex = i;
            //Checks if the answer is correct when the button clicks with the Check Answer function
            answerButtons[i].onClick.AddListener(() =>
            {
                CheckAnswer(answerIndex);
            });

        }


    }

    //This function checks if the answer is correct
   public void CheckAnswer(int answerIndex)
    {

        //If the answer is correct adds +10 to score, show a correct message and makes all the button non interactable for 2 seconds
        if (answerIndex == questionsData.questionshraion[currentQuestion].correctAnswer)
        {
            scoreHraion = scoreHraion + 10;
            scoreText.GetComponent<TextMeshProUGUI>().text = "Score:" + scoreHraion;

            rightAnswersHraion = rightAnswersHraion + 1;
            rightAnswersCounter.GetComponent<TextMeshProUGUI>().text = "Σωστές Απαντήσεις:" + rightAnswersHraion + "/8";

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
            wrongAnswersHraion = wrongAnswersHraion + 1;
            wrongAnswersCounter.GetComponent<TextMeshProUGUI>().text = "Λάθος Απαντήσεις:" + wrongAnswersHraion + "/8";

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

        if (currentQuestion < questionsData.questionshraion.Length)
        {
            ResetQuiz();
        }
        if (currentQuestion == questionsData.questionshraion.Length)
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

        foreach (Button b in answerButtons)
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
        PlayerPrefs.DeleteKey("rightAnswersHraion");
        PlayerPrefs.DeleteKey("wrongAnswersHraion");
        PlayerPrefs.DeleteKey("scoreHraion");
        LoadAnswers();
        scoreText.GetComponent<TextMeshProUGUI>().text = "Score:" + scoreHraion;
        rightAnswersCounter.GetComponent<TextMeshProUGUI>().text = "Σωστές Απαντήσεις:" + rightAnswersHraion + "/8";
        wrongAnswersCounter.GetComponent<TextMeshProUGUI>().text = "Λάθος Απαντήσεις:" + wrongAnswersHraion + "/8";
        retryButton.interactable = false;
    }

    //Loads the stored values of the previous try
    public void LoadAnswers()
    {
            rightAnswersHraion = PlayerPrefs.GetInt("rightAnswersHraion");
            wrongAnswersHraion = PlayerPrefs.GetInt("wrongAnswersHraion");
            scoreHraion = PlayerPrefs.GetInt("scoreHraion");
        

    }

    //Save the values of a quiz try
    public void SaveAnswers()
    {
        
            PlayerPrefs.SetInt("rightAnswersHraion", rightAnswersHraion);
            PlayerPrefs.SetInt("wrongAnswersHraion", wrongAnswersHraion);
            PlayerPrefs.SetInt("scoreHraion", scoreHraion);
            PlayerPrefs.Save();
        
    }

}

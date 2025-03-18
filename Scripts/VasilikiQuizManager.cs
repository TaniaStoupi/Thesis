using System.Collections;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class VasilikiQuizManager : MonoBehaviour
{

    [SerializeField] Button quizVasiliki;
    [SerializeField] GameObject photoCarouselVasiliki;
    [SerializeField] GameObject textScrollVasiliki;
    [SerializeField] GameObject thirdQuiz;
    [SerializeField] Button returnButtonVasiliki;



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
    public VasilikiQuestions questionsData;

    public int scoreVasiliki = 0;
    public int rightAnswersVasiliki = 0;
    public int wrongAnswersVasiliki = 0;





    // This function called when the player presses the quiz button
    public void GoToQuizVasiliki()
    {
        photoCarouselVasiliki.gameObject.SetActive(false);
        textScrollVasiliki.gameObject.SetActive(false);
        quizVasiliki.gameObject.SetActive(false);
        returnButtonVasiliki.gameObject.SetActive(false);
        thirdQuiz.gameObject.SetActive(true);
        retryButton.interactable = false;

        if (PlayerPrefs.GetInt("rightAnswersVasiliki") > 0 || PlayerPrefs.GetInt("wrongAnswersVasiliki") > 0 || PlayerPrefs.GetInt("scoreVasiliki") > 0)
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
        photoCarouselVasiliki.gameObject.SetActive(true);
        textScrollVasiliki.gameObject.SetActive(true);
        quizVasiliki.gameObject.SetActive(true);
        returnButtonVasiliki.gameObject.SetActive(true);
        thirdQuiz.gameObject.SetActive(false);
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

        scoreText.GetComponent<TextMeshProUGUI>().text = "Score:" + scoreVasiliki;
        rightAnswersCounter.GetComponent<TextMeshProUGUI>().text = "Σωστές Απαντήσεις:" + rightAnswersVasiliki + "/3";
        wrongAnswersCounter.GetComponent<TextMeshProUGUI>().text = "Λάθος Απαντήσεις:" + wrongAnswersVasiliki + "/3";




    }

    //This function is for showing the question and answers on the UI
   public void SetQuestion(int index)
    {
        //Makes the text equal to the text of the questions data set
        questionText.text = questionsData.questionsvasiliki[index].questionText;

        //Remove all previous Listeners for all the answer buttons
        foreach (Button b in answerButtons)
        {
            b.onClick.RemoveAllListeners();
        }

        //For each button replace the text with the right text from the questions data set
        for (int i = 0; i < answerButtons.Length; i++)
        {
            answerButtons[i].transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = questionsData.questionsvasiliki[index].answersvasiliki[i];
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
        if (answerIndex == questionsData.questionsvasiliki[currentQuestion].correctAnswer)
        {
            scoreVasiliki = scoreVasiliki + 10;
            scoreText.GetComponent<TextMeshProUGUI>().text = "Score:" + scoreVasiliki;

            rightAnswersVasiliki = rightAnswersVasiliki + 1;
            rightAnswersCounter.GetComponent<TextMeshProUGUI>().text = "Σωστές Απαντήσεις:" + rightAnswersVasiliki + "/3";

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
            wrongAnswersVasiliki = wrongAnswersVasiliki + 1;
            wrongAnswersCounter.GetComponent<TextMeshProUGUI>().text = "Λάθος Απαντήσεις:" + wrongAnswersVasiliki + "/3";

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

        if (currentQuestion < questionsData.questionsvasiliki.Length)
        {
            ResetQuiz();
        }
        if (currentQuestion == questionsData.questionsvasiliki.Length)
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
        PlayerPrefs.DeleteKey("rightAnswersVasiliki");
        PlayerPrefs.DeleteKey("wrongAnswersVasiliki");
        PlayerPrefs.DeleteKey("scoreVasiliki");
        LoadAnswers();
        scoreText.GetComponent<TextMeshProUGUI>().text = "Score:" + scoreVasiliki;
        rightAnswersCounter.GetComponent<TextMeshProUGUI>().text = "Σωστές Απαντήσεις:" + rightAnswersVasiliki + "/3";
        wrongAnswersCounter.GetComponent<TextMeshProUGUI>().text = "Λάθος Απαντήσεις:" + wrongAnswersVasiliki + "/3";
        retryButton.interactable = false;
    }

    //Loads the stored values of the previous try
    public void LoadAnswers()
    {
            rightAnswersVasiliki = PlayerPrefs.GetInt("rightAnswersVasiliki");
            wrongAnswersVasiliki = PlayerPrefs.GetInt("wrongAnswersVasiliki");
            scoreVasiliki = PlayerPrefs.GetInt("scoreVasiliki");
        

    }

    //Save the values of a quiz try
    public void SaveAnswers()
    {
        
            PlayerPrefs.SetInt("rightAnswersVasiliki", rightAnswersVasiliki);
            PlayerPrefs.SetInt("wrongAnswersVasiliki", wrongAnswersVasiliki);
            PlayerPrefs.SetInt("scoreVasiliki", scoreVasiliki);
            PlayerPrefs.Save();
        
    }

}

using System.Collections;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class KardakiouQuizManager : MonoBehaviour
{

    [SerializeField] Button quizKardakiou;
    [SerializeField] GameObject photoCarouselKardakiou;
    [SerializeField] GameObject textScrollKardakiou;
    [SerializeField] GameObject eigthQuiz;
    [SerializeField] Button returnButtonKardakiou;



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
    public KardakiouQuestions questionsData;

    public int scoreKardakiou = 0;
    public int rightAnswersKardakiou = 0;
    public int wrongAnswersKardakiou = 0;





    // This function called when the player presses the quiz button
    public void GoToQuizKardakiou()
    {
        photoCarouselKardakiou.gameObject.SetActive(false);
        textScrollKardakiou.gameObject.SetActive(false);
        quizKardakiou.gameObject.SetActive(false);
        returnButtonKardakiou.gameObject.SetActive(false);
        eigthQuiz.gameObject.SetActive(true);
        retryButton.interactable = false;

        if (PlayerPrefs.GetInt("rightAnswersKardakiou") > 0 || PlayerPrefs.GetInt("wrongAnswersKardakiou") > 0 || PlayerPrefs.GetInt("scoreKardakiou") > 0)
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
        photoCarouselKardakiou.gameObject.SetActive(true);
        textScrollKardakiou.gameObject.SetActive(true);
        quizKardakiou.gameObject.SetActive(true);
        returnButtonKardakiou.gameObject.SetActive(true);
        eigthQuiz.gameObject.SetActive(false);
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

        scoreText.GetComponent<TextMeshProUGUI>().text = "Score:" + scoreKardakiou;
        rightAnswersCounter.GetComponent<TextMeshProUGUI>().text = "Σωστές Απαντήσεις:" + rightAnswersKardakiou + "/2";
        wrongAnswersCounter.GetComponent<TextMeshProUGUI>().text = "Λάθος Απαντήσεις:" + wrongAnswersKardakiou + "/2";




    }

    //This function is for showing the question and answers on the UI
   public void SetQuestion(int index)
    {
        //Makes the text equal to the text of the questions data set
        questionText.text = questionsData.questionskardakiou[index].questionText;

        //Remove all previous Listeners for all the answer buttons
        foreach (Button b in answerButtons)
        {
            b.onClick.RemoveAllListeners();
        }

        //For each button replace the text with the right text from the questions data set
        for (int i = 0; i < answerButtons.Length; i++)
        {
            answerButtons[i].transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = questionsData.questionskardakiou[index].answerskardakiou[i];
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
        if (answerIndex == questionsData.questionskardakiou[currentQuestion].correctAnswer)
        {
            scoreKardakiou = scoreKardakiou + 10;
            scoreText.GetComponent<TextMeshProUGUI>().text = "Score:" + scoreKardakiou;

            rightAnswersKardakiou = rightAnswersKardakiou + 1;
            rightAnswersCounter.GetComponent<TextMeshProUGUI>().text = "Σωστές Απαντήσεις:" + rightAnswersKardakiou + "/2";

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
            wrongAnswersKardakiou = wrongAnswersKardakiou + 1;
            wrongAnswersCounter.GetComponent<TextMeshProUGUI>().text = "Λάθος Απαντήσεις:" + wrongAnswersKardakiou + "/2";

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

        if (currentQuestion < questionsData.questionskardakiou.Length)
        {
            ResetQuiz();
        }
        if (currentQuestion == questionsData.questionskardakiou.Length)
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
        PlayerPrefs.DeleteKey("rightAnswersKardakiou");
        PlayerPrefs.DeleteKey("wrongAnswersKardakiou");
        PlayerPrefs.DeleteKey("scoreKardakiou");
        LoadAnswers();
        scoreText.GetComponent<TextMeshProUGUI>().text = "Score:" + scoreKardakiou;
        rightAnswersCounter.GetComponent<TextMeshProUGUI>().text = "Σωστές Απαντήσεις:" + rightAnswersKardakiou + "/2";
        wrongAnswersCounter.GetComponent<TextMeshProUGUI>().text = "Λάθος Απαντήσεις:" + wrongAnswersKardakiou + "/2";
        retryButton.interactable = false;
    }

    //Loads the stored values of the previous try
    public void LoadAnswers()
    {
            rightAnswersKardakiou = PlayerPrefs.GetInt("rightAnswersKardakiou");
            wrongAnswersKardakiou = PlayerPrefs.GetInt("wrongAnswersKardakiou");
            scoreKardakiou = PlayerPrefs.GetInt("scoreKardakiou");
        

    }

    //Save the values of a quiz try
    public void SaveAnswers()
    {
        
            PlayerPrefs.SetInt("rightAnswersKardakiou", rightAnswersKardakiou);
            PlayerPrefs.SetInt("wrongAnswersKardakiou", wrongAnswersKardakiou);
            PlayerPrefs.SetInt("scoreKardakiou", scoreKardakiou);
            PlayerPrefs.Save();
        
    }

}

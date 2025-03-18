using UnityEngine;

[CreateAssetMenu(fileName = "Artemidos QuestionData", menuName = "ArtemidosQuestionData" )]


public class ArtemidosQuestions: ScriptableObject 
{
    [System.Serializable]

    public struct Question
    {
        public string questionText;
        public string[] answersartemidos;
        public int correctAnswer;
    }

    public Question[] questionsartemidos;
    
}

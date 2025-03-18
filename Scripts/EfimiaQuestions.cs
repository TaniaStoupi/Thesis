using UnityEngine;

[CreateAssetMenu(fileName = "Efimia QuestionData", menuName = "EfimiaQuestionData" )]


public class EfimiaQuestions: ScriptableObject 
{
    [System.Serializable]

    public struct Question
    {
        public string questionText;
        public string[] answersefimia;
        public int correctAnswer;
    }

    public Question[] questionsefimia;
    
}

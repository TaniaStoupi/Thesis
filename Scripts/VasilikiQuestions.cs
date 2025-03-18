using UnityEngine;

[CreateAssetMenu(fileName = "New QuestionDataVasiliki", menuName = "VasilikiQuestionData" )]


public class VasilikiQuestions: ScriptableObject 
{
    [System.Serializable]

    public struct Question
    {
        public string questionText;
        public string[] answersvasiliki;
        public int correctAnswer;
    }

    public Question[] questionsvasiliki;
    
}

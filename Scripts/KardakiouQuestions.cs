using UnityEngine;

[CreateAssetMenu(fileName = "Kardakiou QuestionData", menuName = "KardakiouQuestionData" )]


public class KardakiouQuestions: ScriptableObject 
{
    [System.Serializable]

    public struct Question
    {
        public string questionText;
        public string[] answerskardakiou;
        public int correctAnswer;
    }

    public Question[] questionskardakiou;
    
}

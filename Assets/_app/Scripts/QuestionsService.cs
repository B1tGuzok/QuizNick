using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestionsService
{
    QuizDB dB;

    public QuestionsService()
    {
        dB = new QuizDB();
    }

    public IEnumerable<Questions> GetQuenstions()
    {
        return dB.GetConnection().Table<Questions>();
    }
}
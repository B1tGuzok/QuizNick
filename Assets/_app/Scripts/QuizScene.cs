using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class QuizScene : MonoBehaviour
{
    List<Questions> LvlQuestions = new List<Questions>(); //вопросы выбранного уровня
    List<GameObject> Answers; //кнопки с ответами

    GameObject question, firstAnswer, secondAnswer, thirdAnswer, fourthAnswer, rightButton, pressedButton;
    GameObject EndWindow;
    TextMeshProUGUI Lives, CountAnswersText, EndText;

    public Sprite rightSprite;
    public Sprite wrongSprite;
    public Sprite degaultSprite;

    private string rightAnswer;
    private int lives;
    private int currentQuestion;
    private int countRightAnswers = 0;

    private void Start()
    {
        lives = 3;
        Lives = GameObject.Find("Lives").GetComponent<TextMeshProUGUI>();
        EndText = GameObject.Find("EndText").GetComponent<TextMeshProUGUI>();
        CountAnswersText = GameObject.Find("Right Answers").GetComponent<TextMeshProUGUI>();
        EndWindow = GameObject.Find("Panel");
        EndWindow.gameObject.SetActive(false);

        question = GameObject.Find("Question");
        firstAnswer = GameObject.Find("First Answer");
        secondAnswer = GameObject.Find("Second Answer");
        thirdAnswer = GameObject.Find("Third Answer");
        fourthAnswer = GameObject.Find("Fourth Answer");
        Answers = new List<GameObject>() { firstAnswer, secondAnswer, thirdAnswer, fourthAnswer };

        LoadQuestions();
        LoadQuestion();
    }

    private void LoadQuestions() //загрузка вопросов для конкретного уровня
    {
        for (int i = 0; i < MainScene.AllQuestions.Count; i++)
        {
            if (MainScene.AllQuestions[i].IdLvl == MainScene.lvl)
            {
                LvlQuestions.Add(MainScene.AllQuestions[i]);
            }
        }
    }

    private void LoadQuestion() //загрузка одного вопроса
    {
        currentQuestion = Random.Range(0, LvlQuestions.Count);
        question.GetComponent<TextMeshProUGUI>().text = LvlQuestions[currentQuestion].Question;
        rightAnswer = LvlQuestions[currentQuestion].RightAnswer;

        List<int> rnd = new List<int> { 10, 10, 10, 10 }; //лист дял рандома
        for (int i = 0; i < rnd.Count; i++) //типо делаю рандом
        {
            int k;
            do
            {
               k = Random.Range(0, 4);
            }
            while (rnd.Contains(k));
            rnd[i] = k;
        }
        //рандомное заполнение текста кнопок
        Answers[rnd[0]].GetComponentInChildren<TextMeshProUGUI>().text = LvlQuestions[currentQuestion].Answer1;
        Answers[rnd[1]].GetComponentInChildren<TextMeshProUGUI>().text = LvlQuestions[currentQuestion].Answer2;
        Answers[rnd[2]].GetComponentInChildren<TextMeshProUGUI>().text = LvlQuestions[currentQuestion].Answer3;
        Answers[rnd[3]].GetComponentInChildren<TextMeshProUGUI>().text = LvlQuestions[currentQuestion].Answer4;

        for (int j = 0; j < 4; j++) //поиск кнопки с правильным ответом
        {
            if (Answers[j].GetComponentInChildren<TextMeshProUGUI>().text == rightAnswer)
            {
                rightButton = Answers[j];
            }
        }
    }

    public void CheckAnswer(GameObject button) //проверка ответа
    {
        for (int j = 0; j < 4; j++) //чтобы не было повторного нажатия
            Answers[j].GetComponent<Button>().interactable = false;

        pressedButton = button;
        if (button == rightButton) //игрок ответил правильно
        {
            pressedButton.GetComponent<Image>().sprite = rightSprite;
            countRightAnswers++;
        }
        else //игрок ответил неправильно
        {
            lives--;
            pressedButton.GetComponent<Image>().sprite = wrongSprite;
            rightButton.GetComponent<Image>().sprite = rightSprite;
        }

        if (lives == 0)
        {
            ShowEndWindow("Вы проиграли!");
            Invoke("EndGame", 3f);
        }
        else if (LvlQuestions.Count == 1 && countRightAnswers == 10 && MainScene.openedLevels == 3)
        {
            ShowEndWindow("Вы прошли игру!");
            Invoke("EndGame", 3f);
        }
        else if (LvlQuestions.Count == 1 && countRightAnswers == 10)
        {
            ShowEndWindow("Вы открыли новый уровень!");
            Invoke("EndGame", 3f);
        }
        else if (LvlQuestions.Count == 1)
        {
            ShowEndWindow("Вы не проиграли, но и уровень не открыли..");
            Invoke("EndGame", 3f);
        }
        else
        {
            Invoke("AfterCheckAnswer", 1.5f);
        }
    }

    private void AfterCheckAnswer()
    {
        pressedButton.GetComponent<Image>().sprite = degaultSprite;
        rightButton.GetComponent<Image>().sprite = degaultSprite;
        LvlQuestions.RemoveAt(currentQuestion);
        LoadQuestion();
        for (int j = 0; j < 4; j++)
            Answers[j].GetComponent<Button>().interactable = true;
    }

    public void EndGame() 
    {
        if (countRightAnswers == 10 && MainScene.lvl == 1 && MainScene.openedLevels < 2) //доработать для сохранения прогресса
        {
            MainScene.openedLevels = 2;
            PlayerPrefs.SetInt("openedLevels", MainScene.openedLevels);
        }
        else if (countRightAnswers == 10 && MainScene.lvl == 2)
        {
            MainScene.openedLevels = 3;
            PlayerPrefs.SetInt("openedLevels", MainScene.openedLevels);
        }
        LvlQuestions.Clear();
        SceneManager.LoadScene(0);
    }

    private void ShowEndWindow(string res)
    {
        EndText.text = res;
        EndWindow.gameObject.SetActive(true);
    }

    private void OnGUI()
    {
        Lives.text = lives.ToString();
        CountAnswersText.text = countRightAnswers.ToString() + " / 10";

    }

    //---------------------------------------

    private void ToConsole(IEnumerable<Questions> questions)
    {
        foreach (var question in questions)
        {
            ToConsole(question.ToString());
        }
    }

    private void ToConsole(string msg)
    {
        Debug.Log(msg);
    }
}

using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainScene : MonoBehaviour
{
    static public int lvl; //для запуска определённого уровня
    static public int openedLevels = 1;
    static public List<Questions> AllQuestions = new List<Questions>();
    static bool firstDownload = true; //чтобы все вопросы загружались только ОДИН раз

    public Component[] LevelButtons; //для закрытия/открытия уровней

    public Sprite unlockLvl;

    QuestionsService questionsService;
    GameObject levels;

    bool showLevels = true; //для менюшки на главном экране

    public void Start()
    {

        if (PlayerPrefs.GetInt("openedLevels") != 0)
        {
            openedLevels = PlayerPrefs.GetInt("openedLevels");
        }

        levels = GameObject.Find("Levels"); //для открытия/закрытия панели уровней
        LevelButtons = levels.GetComponentsInChildren<Button>(); //заполняю лист дочерними элементами(кнопками)

        for (int i = 0; i < LevelButtons.Length; i++) //блокирую недоступные уровни
        {
            if (i + 1 > openedLevels)
            {
                LevelButtons[i].GetComponent<Button>().interactable = false;
            }
            else
            {
                ChangeLvlButtonSprite(LevelButtons[i].GetComponent<Image>());
            }
        }

        if (firstDownload)
        {
            questionsService = new QuestionsService();
            GetQuestions();
            firstDownload = false;
        }
        onPlayButtonClick();
    }

    private void GetQuestions() //заполнения листа (AllQuestions) вопросами и вариантами ответов
    {
        var questions = questionsService.GetQuenstions();
        foreach (var question in questions)
        {
            AllQuestions.Add(question);
        }
    }

    public void onPlayButtonClick()
    {
        showLevels = !showLevels;
        levels.gameObject.SetActive(showLevels);
    }

    public void onFirstLvlButtonClick()
    {
        lvl = 1;
        SceneManager.LoadScene(1);
    }

    public void onSecondLvlButtonClick()
    {
        lvl = 2;
        SceneManager.LoadScene(1);
    }

    public void onThirdLvlButtonClick()
    {
        lvl = 3;
        SceneManager.LoadScene(1);
    }

    public void onExitButtonClick()
    {
        PlayerPrefs.SetInt("openedLevels", openedLevels);
        Application.Quit();
    }

    private void ChangeLvlButtonSprite(Component Image)
    {
        Image.GetComponent<Image>().sprite = unlockLvl;
    }
}

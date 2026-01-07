using System;
using TMPro;
using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class QuestionManager : MonoBehaviour
{
    public TrolleyDeck deck;
    private List<TrolleyQuestion> questions;

    public GameObject twoOptionQuestionPrefab;
    public GameObject threeOptionQuestionPrefab;
    public TextMeshProUGUI questionText;
    

    private TrolleyQuestion currentQuestion;

    public Resource food;
    public Resource people;
    public Resource fuel;

    // Start is called once before the first execution of Update after the MonoBehaviour is created

    void Start()
    {
InitiaLizeDeck();

    }

    private void InitiaLizeDeck()
    {
        questions = new List<TrolleyQuestion>();
        for (int i = 0; i < deck.questions.Count; i++)
        {
            questions.Add(deck.questions[i]);
        }
            
        Shuffle(questions);
        currentQuestion = questions[0];
        Setup(currentQuestion);

        
    }
    
    private void Awake()
    {
        InitializeButtons();
    }


    public void Setup(TrolleyQuestion question)
    {
        questionText.text = question.questionText;
        switch (question.options.Length)
        {
            case 2:
                threeOptionQuestionPrefab.SetActive(false);
                twoOptionQuestionPrefab.SetActive(true);
                twoOptionQuestionPrefab.GetComponent<ButtonHolder>().text[0].text = question.options[0].optionText;
                twoOptionQuestionPrefab.GetComponent<ButtonHolder>().text[1].text = question.options[1].optionText;
                break;
            case 3:
                twoOptionQuestionPrefab.SetActive(false);
                threeOptionQuestionPrefab.SetActive(true);
                threeOptionQuestionPrefab.GetComponent<ButtonHolder>().text[0].text = question.options[0].optionText;
                threeOptionQuestionPrefab.GetComponent<ButtonHolder>().text[1].text = question.options[1].optionText;
                threeOptionQuestionPrefab.GetComponent<ButtonHolder>().text[2].text = question.options[2].optionText;
                break;
            default:
                Debug.Log("No correct options amount selected");
                break;
        }
    }

    public void ApplyOption(TrolleyOption option)
    {
        Debug.Log("Applying option");
        food.amount += option.foodAmountAlter;
        people.amount += option.peopleAmountAlter;
        fuel.amount += option.fuelAmountAlter;
        
        if (questions.Count != 0)
        {
            NextQuestion();
        questions.RemoveAt(0);
        
            
        }
        else
        {
            GameManager.instance.FrameCheck();
            Debug.Log("==========DECK OUT===========");
            GameManager.instance.gameEndedEvent.Invoke();
            DisableButtons();
        }
    }

    public void NextQuestion()
    {

        currentQuestion = questions[0];
        Setup(currentQuestion);


    }

    public void ForceQuestion(TrolleyQuestion question)
    {
        
        Setup(question);
    }

    public void InitializeButtons()
    {
        
        twoOptionQuestionPrefab.GetComponent<ButtonHolder>().buttons[0].onClick
            .AddListener(() => ApplyOption(currentQuestion.options[0]));
        twoOptionQuestionPrefab.GetComponent<ButtonHolder>().buttons[1].onClick
            .AddListener(() => ApplyOption(currentQuestion.options[1]));
        threeOptionQuestionPrefab.GetComponent<ButtonHolder>().buttons[0].onClick
            .AddListener(() => ApplyOption(currentQuestion.options[0]));
        threeOptionQuestionPrefab.GetComponent<ButtonHolder>().buttons[1].onClick
            .AddListener(() => ApplyOption(currentQuestion.options[1]));
        threeOptionQuestionPrefab.GetComponent<ButtonHolder>().buttons[2].onClick
            .AddListener(() => ApplyOption(currentQuestion.options[2]));
    }

    public static void Shuffle<T>(IList<T> list)
    {
        int n = list.Count;
        while (n > 1)
        {
            n--;
            int k = Random.Range(0, n + 1);

            // Swap
            T value = list[k];
            list[k] = list[n];
            list[n] = value;
        }
    }

    public void DisableButtons()
    {
        
        twoOptionQuestionPrefab.GetComponent<ButtonHolder>().buttons[0].onClick
            .RemoveAllListeners();
        twoOptionQuestionPrefab.GetComponent<ButtonHolder>().buttons[1].onClick
            .RemoveAllListeners();
        threeOptionQuestionPrefab.GetComponent<ButtonHolder>().buttons[0].onClick
            .RemoveAllListeners();
        threeOptionQuestionPrefab.GetComponent<ButtonHolder>().buttons[1].onClick
            .RemoveAllListeners();
        threeOptionQuestionPrefab.GetComponent<ButtonHolder>().buttons[2].onClick
            .RemoveAllListeners();
    }

    public void Restart()
    {
        InitiaLizeDeck();
        InitializeButtons();
    }
}

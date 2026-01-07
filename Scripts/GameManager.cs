using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public QuestionManager questionManager;
    public ResourceManager resourceManager;
    public TrolleyDeck endings;
    
    public UnityEvent gameEndedEvent;
    public UnityEvent gameOverEvent;
    public Button resetButton;
    
   
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        instance = this;
        resetButton.onClick.AddListener(()=> ResetGame());
        gameEndedEvent.AddListener(() => EndGame());
        gameOverEvent.AddListener(() => GameOver());
    }



    public void EndGame()
    {
        
        Debug.Log("EndGame");
        
        questionManager.ForceQuestion(endings.questions[0]);
        resetButton.gameObject.SetActive(true);
    }

    public void GameOver()
    {
        
        Debug.Log("GameOver");
        resetButton.gameObject.SetActive(true);
    }

    public void ResetGame()
    {
        questionManager.Restart();
        resourceManager.ResetResources();
        resetButton.gameObject.SetActive(false);
        
    }

    public IEnumerator FrameCheck()
    {
        yield return new WaitForEndOfFrame();
    }
}

using UnityEngine;

public class ResourceManager : MonoBehaviour
{
    public Resource[] resources;

    public TrolleyDeck endings;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        foreach (Resource resource in resources)
        {
            resource.amount = resource.startAmount;
        }
        
    }

    public void ResetResources()
    {
        foreach (Resource resource in resources)
        {
            resource.amount = resource.startAmount;
        }
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < resources.Length; i++)
        {
            Resource resource = resources[i];
            if (resource.amount > resource.maxAmount)
            {
                resource.amount = resource.maxAmount;
            }

            if (resource.amount < 0)
            {
                resource.amount = 0;
                GameManager.instance.gameOverEvent.Invoke();
                switch (resource.resourceType)
                {
                    case ResourceType.FOOD:
                        GameManager.instance.questionManager.ForceQuestion(endings.FindQuestionByID("NOFOOD"));
                        break;
                    case ResourceType.PEOPLE:
                        GameManager.instance.questionManager.ForceQuestion(endings.FindQuestionByID("NOPEOPLE"));
                        break;
                    case ResourceType.FUEL:
                        GameManager.instance.questionManager.ForceQuestion(endings.FindQuestionByID("NOFUEL"));
                        break;
                }
                
            }
        }
    }
}

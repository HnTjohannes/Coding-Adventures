using UnityEngine;

[CreateAssetMenu(fileName = "TrolleyOption", menuName = "SO/Trolley Option")]
public class TrolleyOption : ScriptableObject
{
    public string optionText;
    public int foodAmountAlter = 0;
    public int peopleAmountAlter = 0;
    public int fuelAmountAlter = 0;
    
    public bool hasFollowup = false;
    public TrolleyQuestion followupQuestion;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

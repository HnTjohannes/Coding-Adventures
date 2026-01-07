using UnityEngine;

[CreateAssetMenu(fileName = "Trolley Question", menuName = "SO/Question")]
public class TrolleyQuestion : ScriptableObject
{
    public string questionText;

    public string questionID;
    public TrolleyOption[] options;

}

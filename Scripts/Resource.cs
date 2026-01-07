using TMPro;
using UnityEngine;

[CreateAssetMenu(fileName = "Resource", menuName = "SO/Resource")]
public class Resource : ScriptableObject
{
    public ResourceType resourceType;
    public int amount = 0;
    public int startAmount = 50;
    public int maxAmount = 100;
}

public enum ResourceType
{
    none = 0,
    FOOD,
    PEOPLE,
    FUEL
}
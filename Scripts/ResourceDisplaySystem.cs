using TMPro;
using UnityEngine;

[RequireComponent(typeof(TextMeshProUGUI))]
public class ResourceDisplaySystem : MonoBehaviour
{
    public TextMeshProUGUI display;
    public Resource resource;


    // Update is called once per frame
    void Update()
    {
        display.text = resource.amount.ToString();
    }
}

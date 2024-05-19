using UnityEngine;
using UnityEngine.UI;

public class BubbleController : MonoBehaviour
{
    [SerializeField] private Image orcaSprite;
    [SerializeField] private Image orcaBorder;
    [SerializeField] private Image turtleSprite;
    [SerializeField] private Image turtleBorder;
    [SerializeField] private Image mermaidSprite;
    [SerializeField] private Image mermaidBorder;

    public void ActivateIcons(int level)
    {
        switch (level)
        {
            case 3:
                ActivateTurtle();
                break;
            case 4:
                ActivateTurtle();
                ActivateOrca();
                break;
        }
    }

    public void ActivateAll()
    {
        ActivateTurtle();
        ActivateMermaid();
        ActivateOrca();
    }

    public void ActivateOrca()
    {
        orcaSprite.color = Color.white;
        ColorUtility.TryParseHtmlString("#73B786", out Color color);
        orcaBorder.color = color;
    }

    public void ActivateTurtle()
    {
        turtleSprite.color = Color.white;
        ColorUtility.TryParseHtmlString("#73B786", out Color color);
        turtleBorder.color = color;
    }

    public void ActivateMermaid()
    {
        mermaidSprite.color = Color.white;
        ColorUtility.TryParseHtmlString("#73B786", out Color color);
        mermaidBorder.color = color;
    }

}

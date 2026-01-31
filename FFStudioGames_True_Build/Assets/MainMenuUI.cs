using System.Collections;
using UnityEngine;
using UnityEngine.UIElements;

public class MainMenuUI : MonoBehaviour
{
    private Label title;

    private void OnEnable()
    {
        var root = GetComponent<UIDocument>().rootVisualElement;
        
        var menu = root.Q<VisualElement>("MainMenuContainer");
        var btcontainer = menu.Q<VisualElement>("ButtonContainer");
        title = root.Q<Label>("Title");
        
        // Animate menu on start
        StartCoroutine(AnimateMenu(btcontainer));
    }

    private IEnumerator AnimateMenu(VisualElement container)
    {
        // Show title
        title.RemoveFromClassList("title-hidden");
        title.AddToClassList("title-visible");

        // Wait for title animation
        yield return new WaitForSeconds(0.5f);

        // Show buttons
        foreach (var button in container.Children())
        {
            button.RemoveFromClassList("button-hidden");
            button.AddToClassList("button-visible");
        }
    }
}

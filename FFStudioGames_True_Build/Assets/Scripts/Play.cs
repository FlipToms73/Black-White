using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;


#if UNITY_EDITOR
using UnityEditor; // needed for EditorApplication
#endif

public class Play : MonoBehaviour
{
    private Button buttonPlay;
    private Button buttonQuit;
    private void OnEnable()
    {
        var root = GetComponent<UIDocument>().rootVisualElement;
        
        var menu = root.Q<VisualElement>("MainMenuContainer");
        var btcontainer = menu.Q<VisualElement>("ButtonContainer");

        buttonPlay = btcontainer.Q<Button>("menuButtonPlay");
        buttonPlay.clicked += PlayGame;
        
        buttonQuit = btcontainer.Q<Button>("mainMenuQuitButton");
        buttonQuit.clicked += QuitGame;
    }

    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void QuitGame()
    {
        #if UNITY_EDITOR
            EditorApplication.isPlaying = false; // stops play mode in editor
        #else
            Application.Quit(); // quits the built game
        #endif
    }
}

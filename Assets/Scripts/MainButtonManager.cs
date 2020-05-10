using UnityEngine;
using UnityEngine.SceneManagement;
//Credit to this thread for info on how to check the current scene index: https://answers.unity.com/questions/1114722/getting-scene-index-as-int.html

public class MainButtonManager : MonoBehaviour
{
    private int currentSceneIndex;
    private void Start()
    {
        currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
    }
    public void QuitGame() => SceneManager.LoadScene(0);

    public void Retry() => SceneManager.LoadScene(currentSceneIndex);

    public void NextLevel() => SceneManager.LoadScene(currentSceneIndex + 1);
}

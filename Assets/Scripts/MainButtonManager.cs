using UnityEngine;
using UnityEngine.SceneManagement;

public class MainButtonManager : MonoBehaviour
{
    public void QuitGame() => SceneManager.LoadScene(0);

    public void Retry() => SceneManager.LoadScene(1);
}

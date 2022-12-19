using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
    public int Index = 1;
    public void StartGameButton()
    {
        SceneManager.LoadScene(Index);
    }
}

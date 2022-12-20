using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeSceneAfterTime : MonoBehaviour
{
    public string sceneName;
    public float waitTimeSeconds;

    private float _initial;
    
    private void Start()
    {
        _initial = Time.realtimeSinceStartup;
    }

    private void Update()
    {
        if (Time.realtimeSinceStartup > _initial + waitTimeSeconds)
        {
            SceneManager.LoadScene(sceneName);
        }
    }
}

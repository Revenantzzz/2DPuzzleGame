using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    public static SceneController Instance;

    private void Awake()
    {
        Instance = this;
    }
    public void LoadLevel(int sceneBuildIndex)
    {
        SceneManager.LoadSceneAsync(sceneBuildIndex);
    }
}

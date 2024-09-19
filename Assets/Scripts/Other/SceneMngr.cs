using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class SceneMngr : MonoBehaviour
{
    int lastLevel = 5;

    private string previousScene;
    private GameObject loadingScreen;

    private void Start()
    {
        loadingScreen = transform.GetChild(0).gameObject;
    }

    public void LoadLevel(int nr)
    {
        if (nr > -1 && nr <= lastLevel)
        {
            previousScene = "Level" + nr;
            StartCoroutine(LoadSceneAsync("Level" + nr));
        }
    }

    public void LoadScene(string sceneName)
    {
        if (sceneName == "Death")
        {
            Cursor.lockState = CursorLockMode.None;
        }
        else
        {
            previousScene = sceneName;
        }
        StartCoroutine(LoadSceneAsync(sceneName));
    }

    public void LoadPrevious()
    {
        StartCoroutine(LoadSceneAsync(previousScene));
    }

    IEnumerator LoadSceneAsync(string sceneName)
    {
        loadingScreen.SetActive(true);
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneName);
        operation.allowSceneActivation = false;

        while (!operation.isDone)
        {
            if (operation.progress >= 0.9f)
            {
                operation.allowSceneActivation = true;

            }
            yield return null;
        }
        loadingScreen.SetActive(false);
    }
}

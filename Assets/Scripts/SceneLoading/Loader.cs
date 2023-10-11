using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class Loader
{
    private static Action onLoaderCallback;

    private class LoadingMonoBehaviour: MonoBehaviour { }
    private static AsyncOperation loadingAsyncOperation;
    public enum Scene
    {
        Loading,
        SecretMarioStarship,
        BaseGame
    }
    public static void load(Scene scene)
    {
        //Set callback action to load target scene
        onLoaderCallback = () =>
        {
            GameObject loadingGameObject = new GameObject("Loading Game Object");
            loadingGameObject.AddComponent<LoadingMonoBehaviour>().StartCoroutine(LoadSceneAsync(scene));
        };
        //Load the loading scene
        SceneManager.LoadScene(Scene.Loading.ToString());
    }

    private static IEnumerator LoadSceneAsync(Scene scene)
    {
        yield return null;
        AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(scene.ToString());
        while (!asyncOperation.isDone)
        {
            yield return null;
        }
    }

    public static float GetLoadingProgress()
    {
        if(loadingAsyncOperation != null)
        {
            return loadingAsyncOperation.progress;
        }
        else
        {
            return 1f;
        }
    }

    public static void LoaderCallback()
    {
        //Triggered after the first update to let teh scene refresh
        //Execute the loaderCallBack action to load the target scene
        if (onLoaderCallback != null)
        {
            onLoaderCallback();
            onLoaderCallback = null;
        }
    }
}

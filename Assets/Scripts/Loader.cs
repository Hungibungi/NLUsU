using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class Loader
{
    public enum Scene {
        Menus,
        Loader,
        Game,
    }

    private static Action onLoaderCallback;

    public static void load(Scene scene) {
        onLoaderCallback = () => {
            SceneManager.LoadScene(scene.ToString());
        };

        SceneManager.LoadScene(Scene.Loader.ToString());
    }

    public static void LoadCallback() {
        if(onLoaderCallback != null) {
            onLoaderCallback();
            onLoaderCallback = null;
        }
    }
}

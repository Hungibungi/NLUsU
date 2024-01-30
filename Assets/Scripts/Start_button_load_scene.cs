using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Start_button_load_scene : MonoBehaviour
{
        public void LoadGameScene() {
        Loader.load(Loader.Scene.Game);
    }
}

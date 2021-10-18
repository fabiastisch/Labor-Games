using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utils.SceneLoader;

public class LoadDungeon : MonoBehaviour {
    // Start is called before the first frame update
    void Start() {
        if (!SceneLoader.Instance.LoadSceneWithPlayer("Dungeon")) {
            
            SceneLoader.onReady += SceneLoaderOnonReady;
        }
    }

    private void SceneLoaderOnonReady() {
        SceneLoader.onReady -= SceneLoaderOnonReady;
        SceneLoader.Instance.LoadSceneWithPlayer("Dungeon");
    }
}
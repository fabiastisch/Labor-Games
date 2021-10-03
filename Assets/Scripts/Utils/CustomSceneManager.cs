using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Utils {
    public static class CustomSceneManager {

        public static IEnumerator LoadYourAsyncScene(string scene, GameObject myGameObject)
        {
            // Set the current Scene to be able to unload it later
            Scene currentScene = SceneManager.GetActiveScene();

            // The Application loads the Scene in the background at the same time as the current Scene.
            AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(scene, LoadSceneMode.Additive);

            // Wait until the last operation fully loads to return anything
            while (!asyncLoad.isDone)
            {
                yield return null;
            }

            // Move the GameObject (you attach this in the Inspector) to the newly loaded Scene
            SceneManager.MoveGameObjectToScene(myGameObject, SceneManager.GetSceneByName(scene));
            // Unload the previous Scene
            SceneManager.UnloadSceneAsync(currentScene);
        }
    }
}
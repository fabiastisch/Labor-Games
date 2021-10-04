using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Utils.SceneLoader {
    public class SceneLoader : MonoBehaviour {
        public GameObject loadingScreen;
        public Slider slider;

        public void LoadScene(string sceneName) {
            StartCoroutine(LoadAsyncScene(sceneName));
        }

        public void LoadSceneWithGameObject(string sceneName, GameObject gameObject) {
            StartCoroutine(LoadAsyncScene(sceneName, gameObject));
        }

        private IEnumerator LoadAsyncScene(string scene, GameObject myGameObject = null) {
            // Set the current Scene to be able to unload it later
            Scene currentScene = SceneManager.GetActiveScene();

            loadingScreen.SetActive(true);

            // The Application loads the Scene in the background at the same time as the current Scene.
            AsyncOperation operation = SceneManager.LoadSceneAsync(scene, LoadSceneMode.Additive);

            // Wait until the last operation fully loads to return anything
            while (!operation.isDone) {
                float progress = Mathf.Clamp01(operation.progress / .9f);
                slider.value = progress;
                yield return null;
            }

            // Move the GameObject (you attach this in the Inspector) to the newly loaded Scene
            if (myGameObject) {
                SceneManager.MoveGameObjectToScene(myGameObject, SceneManager.GetSceneByName(scene));
            }

            // Unload the previous Scene
            SceneManager.UnloadSceneAsync(currentScene);
        }
    }
}
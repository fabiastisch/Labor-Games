using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Utils.SceneLoader {
    public class SceneLoader : MonoBehaviour {
        [SerializeField] private GameObject loadingScreen;
        [SerializeField] private Slider slider;
        [SerializeField] private bool isLoading = false;

        public void LoadScene(string sceneName) {
            if (!isLoading) {
                StartCoroutine(LoadAsyncScene(sceneName));
                isLoading = true;
            }
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
                float progress = Mathf.Clamp01(operation.progress / .9f) * 0.5f;
                slider.value = progress;
                yield return null;
            }

            // some delay
            for (int i = 0; i <= 5; i++) {
                slider.value = 0.5f + i*0.1f;
                yield return new WaitForSeconds(.03f);
            }
            
            // Move the GameObject (you attach this in the Inspector) to the newly loaded Scene
            if (myGameObject) {
                SceneManager.MoveGameObjectToScene(myGameObject, SceneManager.GetSceneByName(scene));
            }
            

            isLoading = false;
            // Unload the previous Scene
            SceneManager.UnloadSceneAsync(currentScene);
        }
    }
}
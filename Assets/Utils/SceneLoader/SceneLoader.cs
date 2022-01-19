using System;
using System.Collections;
using Dungeon;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Utils.SceneLoader
{
    public class SceneLoader : GenericSingleton<SceneLoader>
    {
        protected override void InternalInit()
        {
        }
        protected override void InternalOnDestroy()
        {
        }

        public static event Action onReady;
        [SerializeField] private GameObject loadingScreen;
        [SerializeField] private UnityEngine.UI.Slider slider;
        private bool isLoading = false;
        [SerializeField] private Text Text;
        private string loadingText = "Loading";
        private int textState = 0;

        public void LoadScene(string sceneName)
        {
            if (!isLoading)
            {
                StartCoroutine(LoadAsyncScene(sceneName));
                isLoading = true;
            }
        }

        public void LoadSceneWithGameObject(string sceneName, GameObject gObject)
        {
            if (!isLoading)
            {
                isLoading = true;
                StartCoroutine(LoadAsyncScene(sceneName, gObject));
            }
        }

        public bool LoadSceneWithPlayer(string sceneName)
        {
            if (isLoading) return false;
            GameObject player = GameObject.FindWithTag("Player");
            //Debug.Log("Player: " + player);
            LoadSceneWithGameObject(sceneName, player);
            return true;
        }

        private IEnumerator LoadAsyncScene(string scene, GameObject myGameObject = null)
        {
            // Set the current Scene to be able to unload it later
            Scene currentScene = SceneManager.GetActiveScene();

            loadingScreen.SetActive(true);

            // The Application loads the Scene in the background at the same time as the current Scene.
            AsyncOperation operation = SceneManager.LoadSceneAsync(scene, LoadSceneMode.Additive);

            // Wait until the last operation fully loads to return anything
            while (!operation.isDone)
            {
                float progress = Mathf.Clamp01(operation.progress / .9f) * 0.5f;
                ChangeText();
                slider.value = progress;
                yield return null;
            }

            // some delay
            for (int i = 0; i <= 5; i++)
            {
                slider.value = 0.5f + i * 0.1f;
                ChangeText();
                yield return new WaitForSeconds(.03f);
            }

            // Move the GameObject (you attach this in the Inspector) to the newly loaded Scene
            //Debug.Log("SceneSwitching object: " + myGameObject);
            if (myGameObject)
            {
                SceneManager.MoveGameObjectToScene(myGameObject, SceneManager.GetSceneByName(scene));
                myGameObject.transform.position = Spawn.instance.transform.position;
            }

            loadingScreen.SetActive(false);


            // Unload the previous Scene
            SceneManager.UnloadSceneAsync(currentScene);
            isLoading = false;
            onReady?.Invoke();
        }

        private void ChangeText()
        {
            textState++;
            textState = textState % 4;
            String text = loadingText;
            for (int i = 0; i < textState; i++)
            {
                text += ".";
            }

            Text.text = text;
        }
    }
}
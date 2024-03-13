using Eflatun.SceneReference;
using MEC;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

namespace ShootEmUp
{
    public static class Loader
    {
        static SceneReference loadingScene = new (SceneGuidToPathMapProvider.ScenePathToGuidMap["Assets/Scenes/LoadingScene.unity"]);
        static SceneReference targetScene;

        public static void Load(SceneReference scene) {
            targetScene = scene;
            SceneManager.LoadScene("LoadingScene");
            Timing.RunCoroutine(LoadTargetScene());
        }
        static IEnumerator<float> LoadTargetScene()
        {
            yield return Timing.WaitForOneFrame;
            SceneManager.LoadScene(targetScene.Name);
        }
    }
}

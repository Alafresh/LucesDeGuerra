using Eflatun.SceneReference;
using UnityEngine;
using UnityEngine.UI;

namespace ShootEmUp
{
    public class MainMenuUI: MonoBehaviour
    {
        [SerializeField] SceneReference startingLevel;
        [SerializeField] Button playBtn;
        [SerializeField] Button quitBtn;

        private void Awake()
        {
            playBtn.onClick.AddListener(() => Loader.Load(startingLevel));
            quitBtn.onClick.AddListener(() => Helpers.QuitGame());
            Time.timeScale = 1f;
        }
    }
}
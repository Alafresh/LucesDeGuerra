using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

namespace ShootEmUp
{
    public class MainMenuUI: MonoBehaviour
    {
        [SerializeField] string startingLevel;
        [SerializeField] Button playBtn;
        [SerializeField] Button quitBtn;

        private void Awake()
        {
            playBtn.onClick.AddListener(() => SceneManager.LoadScene(startingLevel));
            quitBtn.onClick.AddListener(() => Utilities.Helpers.QuitGame());
            Time.timeScale = 1f;
        }
    }
}
using System;
using UnityEngine.SceneManagement;
using UnityEngine;

namespace ShootEmUp
{
    public class GameManager : MonoBehaviour {
        public static GameManager Instance { get; private set; }
        public Player Player => _player;
        [SerializeField] private Player _player;
        [SerializeField] private GameObject gameOverUI;
        [SerializeField] private string mainMenuScene;
        [SerializeField] private GameObject winUI;
        int score;
        private float restartTimer = 3f;

        public bool IsGameOver() => _player.GetHelthNormalized() <= 0 || _player.GetFuelNormalized() <= 0;

        private void Awake()
        {
            Instance = this;
            
            //_player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        }

        private void Update()
        {
            if (IsGameOver())
            {
                restartTimer -= Time.deltaTime;
                if (gameOverUI.activeSelf == false)
                {
                    gameOverUI.SetActive(true);
                }

                if (restartTimer <= 0)
                {
                    SceneManager.LoadScene(mainMenuScene);
                }
            }
            if (score >= 100)
            {
                restartTimer -= Time.deltaTime;
                if (winUI.activeSelf == false)
                {
                    winUI.SetActive(true);
                }
                if (restartTimer <= 0)
                {
                    SceneManager.LoadScene(mainMenuScene);
                }
            }
        }

        public void AddScore(int amount) => score += amount;
        public int GetScore() => score;
    }
}
using System;
using Eflatun.SceneReference;
using UnityEngine;

namespace ShootEmUp
{
    public class GameManager : MonoBehaviour {
        public static GameManager Instance { get; private set; }
        public Player Player => _player;
        [SerializeField] private Player _player;
        [SerializeField] private GameObject gameOverUI;
        [SerializeField] private SceneReference mainMenuScene;
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
                    Loader.Load(mainMenuScene);
                }
            }
        }

        public void AddScore(int amount) => score += amount;
        public int GetScore() => score;
    }
}
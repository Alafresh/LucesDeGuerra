using UnityEngine;

namespace ShootEmUp
{
    public class GameManager : MonoBehaviour {
        public static GameManager Instance { get; private set; }
        Player player;
        int score;

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
                DontDestroyOnLoad(gameObject);
            }
            else
            {
                Destroy(gameObject);
            }
            player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        }

        public void AddScore(int amount) => score += amount;
        public int GetScore() => score;
    }
}
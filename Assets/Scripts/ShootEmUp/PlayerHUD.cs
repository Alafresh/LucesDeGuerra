using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace ShootEmUp
{
    public class PlayerHUD : MonoBehaviour
    {
        [SerializeField] private Image _helthBar;
        [SerializeField] private Image _fuelBar;
        [SerializeField] private TextMeshProUGUI _scoreText;

        private void Update()
        {
            _helthBar.fillAmount = GameManager.Instance.Player.GetHelthNormalized();
            _fuelBar.fillAmount = GameManager.Instance.Player.GetFuelNormalized();
            _scoreText.text = "Score: " + GameManager.Instance.GetScore();
        }
    }
}

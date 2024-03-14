using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace ShootEmUp
{
    public class PlayerHUD : MonoBehaviour
    {
        [SerializeField] private Image _helthBar;
        [SerializeField] private Image _fuelBar;

        private void Update()
        {
            _helthBar.fillAmount = GameManager.Instance.Player.GetHelthNormalized();
            _fuelBar.fillAmount = GameManager.Instance.Player.GetFuelNormalized();
        }
    }
}

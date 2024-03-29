﻿using UnityEngine;

namespace ShootEmUp
{
    public class PlayerWeapon : Weapon
    {
        InputReader input;
        float fireTimer;

        void Awake() => input = GetComponent<InputReader>();

        private void Update()
        {
            fireTimer += Time.deltaTime;
            if (input.Fire && fireTimer >= weaponStrategy.FireRate)
            {
                weaponStrategy.Fire(firePoint, layer);
                fireTimer = 0;
            }
        }
    }
}

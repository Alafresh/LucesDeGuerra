﻿using UnityEngine;

namespace ShootEmUp
{
    public class Enemy : Plane {
        protected override void Die()
        {
            GameManager.Instance.AddScore(10);
            Destroy(gameObject);
        }
    }
}
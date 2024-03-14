using UnityEngine;

namespace ShootEmUp
{
    public abstract class Plane : MonoBehaviour {
        [SerializeField] int maxHealth;
        protected int health;

        protected virtual void Awake() => health = maxHealth;
        public void SetMaxHealth(int amount) => maxHealth = amount;

        public void TakenDamage(int amount)
        {
            health -= amount;
            if (health <= 0)
            {
                Die();
            }
        }
        public float GetHelthNormalized() => health / (float) maxHealth;
        protected abstract void Die();
    }
}
using UnityEngine;

namespace ShootEmUp
{
    public abstract class Plane : MonoBehaviour {
        [SerializeField] int maxHealth;
        int health;

        protected virtual void Awake() => health = maxHealth;
        public void SetMaxHealth(int amount) => health = amount;

        public void TakenDamage(int amount)
        {
            health -= amount;
            if (health <= 0)
            {
                Die();
            }
        }
        public float GetHelthNormalized() => 1 - (health / maxHealth);
        protected abstract void Die();
    }
}
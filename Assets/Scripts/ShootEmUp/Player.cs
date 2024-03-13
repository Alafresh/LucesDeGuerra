using UnityEngine;

namespace ShootEmUp
{
    public class Player : Plane {
        [SerializeField] float maxFuel;
        [SerializeField] float fuelConsumptionRate;

        float fuel;
        public float GetFuelNormalized() => 1 - (fuel / maxFuel);

        private void Update()
        {
            fuel -= fuelConsumptionRate * Time.deltaTime;
        }

        protected override void Die()
        {
            

        }
    }
}
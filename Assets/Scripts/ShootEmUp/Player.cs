using UnityEngine;

namespace ShootEmUp
{
    public class Player : Plane {
        [SerializeField] float maxFuel;
        [SerializeField] float fuelConsumptionRate;

        float fuel;

        void Start()
        {
            fuel = maxFuel;
        } 
        
        public float GetFuelNormalized() =>  (fuel / maxFuel);

        private void Update()
        {
            fuel -= fuelConsumptionRate * Time.deltaTime;
            Debug.Log("Vida" +  health);
        }

        protected override void Die()
        {
            Debug.Log("Me mori" +  health);

        }
    }
}
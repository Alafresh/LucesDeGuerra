using System.Collections;
using UnityEngine;

namespace ShootEmUp
{

    public class Projectile : MonoBehaviour
    {
        [SerializeField] float speed;
        [SerializeField] GameObject muzzlePrefab;
        [SerializeField] GameObject hitPrefab;

        Transform parent;

        public void SetSpeed(float speed) => this.speed = speed;
        public void SetParent(Transform parent) => this.parent = parent;

        void Start ()
        {
            if (muzzlePrefab != null)
            {
                //instantiate muzzle flash
                var muzzleVFX = Instantiate(muzzlePrefab, transform.position, Quaternion.identity);
                muzzleVFX.transform.forward = gameObject.transform.forward;
                muzzleVFX.transform.SetParent(parent);
                DestroyParticleSystem(muzzleVFX);
            }
        }

        void Update ()
        {
            transform.SetParent(null);
            transform.position += transform.forward * (speed * Time.deltaTime);
        }
        
        
        private void OnCollisionEnter(Collision collision)
        {
            if (hitPrefab != null)
            {
                ContactPoint contact = collision.contacts[0];
                var hitVFX = Instantiate(hitPrefab, contact.point, Quaternion.identity);

                DestroyParticleSystem(hitVFX);
            }

            // IF HIT A PLANE, DAMAGE IT
            var plane = collision.gameObject.GetComponent<Plane>();
            if (plane != null)
            {
                plane.TakenDamage(10);
            }

            Destroy(gameObject);
        }

        private void DestroyParticleSystem(GameObject vfx)
        {
            var ps = vfx.GetComponent<ParticleSystem>();
            if (ps == null)
            {
                ps = vfx.GetComponent<ParticleSystem>();
            }
            Destroy(vfx, ps.main.duration);
        }
    }
}

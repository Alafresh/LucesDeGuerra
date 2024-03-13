namespace ShootEmUp
{
    public class Enemy : Plane {
        protected override void Die()
        {
            Destroy(gameObject);
        }
    }
}
namespace Assets.Units
{
    using Assets.Store;

    using UnityEngine;

    public class KillUnit : MonoBehaviour
    {
        private const string HealthTag = "Health";

        private Health health;

        private int evilLayer;

        public void Start()
        {
            this.health = GameObject.Find("Health").GetComponent<Health>();
            this.evilLayer = LayerMask.NameToLayer("Evil Units");
        }

        public void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.layer == this.evilLayer && this.gameObject.tag == KillUnit.HealthTag)
            {
                this.health.DoDamage();
            }

            GameObject.Destroy(other.gameObject);
        }
    }
}

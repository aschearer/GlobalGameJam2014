namespace Assets.Units
{
    using UnityEngine;

    public class KillUnit : MonoBehaviour
    {
        public void OnTriggerEnter(Collider other)
        {
            GameObject.Destroy(other.gameObject);
        }
    }
}

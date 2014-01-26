namespace Assets.Units
{
    using UnityEngine;

    public class CombatUnit : MonoBehaviour
    {
        public void OnCollisionEnter(Collision collision)
        {
            GameObject.Destroy(collision.collider.gameObject);
        }
    }
}

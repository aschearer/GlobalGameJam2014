namespace Assets.Tiles
{
    using UnityEngine;

    public class TileCollider : MonoBehaviour
    {
        public void OnCollisionEnter(Collision collision)
        {
            Debug.Log("Collided");
        }
    }
}

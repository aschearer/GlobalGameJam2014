namespace Assets.Buildings
{
    using UnityEngine;

    public class Buyable : MonoBehaviour
    {
        public void Purchased()
        {
            this.BroadcastMessage("TurnOn");
        }
    }
}

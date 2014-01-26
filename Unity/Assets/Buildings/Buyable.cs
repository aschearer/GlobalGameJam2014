namespace Assets.Buildings
{
    using UnityEngine;

    public class Buyable : MonoBehaviour
    {
        public int Price;

        public void Purchased()
        {
            this.BroadcastMessage("TurnOn");
        }
    }
}

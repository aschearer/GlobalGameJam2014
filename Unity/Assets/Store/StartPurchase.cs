namespace Assets.Store
{
    using UnityEngine;

    public class StartPurchase : MonoBehaviour
    {
        private Checkout checkout;

        public void Start()
        {
            this.checkout = GameObject.Find("Store").GetComponent<Checkout>();
        }

        public void OnMouseDown()
        {
            this.checkout.SendMessage("StartCheckout", this.gameObject);
        }
    }
}

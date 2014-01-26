namespace Assets.Store
{
    using Assets.Buildings;

    using UnityEngine;

    public class StartPurchase : MonoBehaviour
    {
        public GameObject PurchasePrefab;

        private Checkout checkout;

        private Bank bank;

        private Buyable buyable;

        public void Start()
        {
            this.checkout = GameObject.Find("Store").GetComponent<Checkout>();
            this.bank = GameObject.Find("Bank").GetComponent<Bank>();
            this.buyable = this.GetComponent<Buyable>();
        }

        public void OnMouseDown()
        {
            if (this.bank.CanPurchase(this.buyable.Price))
            {
                this.checkout.SendMessage("StartCheckout", this.PurchasePrefab);
            }
        }
    }
}

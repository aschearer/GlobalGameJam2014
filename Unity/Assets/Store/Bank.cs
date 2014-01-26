namespace Assets.Store
{
    using UnityEngine;

    public class Bank : MonoBehaviour
    {
        public int StartingGold = 1000;

        public int GoldPerSecond = 10;

        private int gold;

        private float elapsedTime;

        public void Deduct(int price)
        {
            this.gold -= price;
        }

        public bool CanPurchase(int price)
        {
            return this.gold >= price;
        }

        public void Start()
        {
            this.gold = this.StartingGold;
        }

        public void Update()
        {
            this.elapsedTime += Time.deltaTime;
            while (this.elapsedTime >= 1)
            {
                this.elapsedTime -= 1;
                this.gold += this.GoldPerSecond;
            }

            this.GetComponent<GUIText>().text = "Gold: " + this.gold;
        }
    }
}

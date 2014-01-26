namespace Assets.Buildings
{
    using Assets.Store;
    using Assets.Tiles;

    using UnityEngine;

    public class HarvestResources : MonoBehaviour
    {
        public int GoldPerUnit = 100;

        public int TotalGoldAvailable = 1000;

        private int goodLayer;

        private int goldRemaining;

        private Bank bank;

        public void Start()
        {
            this.goodLayer = LayerMask.NameToLayer("Units");
            this.bank = GameObject.Find("Bank").GetComponent<Bank>();
            this.goldRemaining = this.TotalGoldAvailable;
        }

        public void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.layer == this.goodLayer)
            {
                GameObject.Destroy(other.gameObject);
                bank.AddGold(this.GoldPerUnit);
                this.goldRemaining -= this.GoldPerUnit;
                if (this.goldRemaining <= 0)
                {
                    this.transform.parent.gameObject.tag = SelectedTile.EmptyTagName;

                    GameObject.Destroy(this.gameObject);
                }
            }
        }
    }
}

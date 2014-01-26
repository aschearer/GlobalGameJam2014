namespace Assets.Store
{
    using System;

    using UnityEngine;

    public class Health : MonoBehaviour
    {
        public int StartingLife = 100;

        public int DamagePerUnit = 1;

        private int currentLife;

        public void Start()
        {
            this.currentLife = this.StartingLife;
        }

        public void DoDamage()
        {
            this.currentLife = Math.Max(0, this.currentLife - this.DamagePerUnit);
        }

        public void Update()
        {
            this.GetComponent<GUIText>().text = "Health: " + this.currentLife;
        }
    }
}

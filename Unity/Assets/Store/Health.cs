namespace Assets.Store
{
    using System;

    using UnityEngine;

    public class Health : MonoBehaviour
    {
        public static float LatestPlayThrough;

        public int StartingLife = 100;

        public int DamagePerUnit = 1;

        private int currentLife;

        public void Start()
        {
            this.currentLife = this.StartingLife;
            Health.LatestPlayThrough = 0;
        }

        public void DoDamage()
        {
            this.currentLife = Math.Max(0, this.currentLife - this.DamagePerUnit);
            if (this.currentLife == 0)
            {
                Application.LoadLevel("Title");
            }
        }

        public void Update()
        {
            this.GetComponent<GUIText>().text = "Health: " + this.currentLife;
            Health.LatestPlayThrough += Time.deltaTime;
        }
    }
}

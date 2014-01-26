namespace Assets.Boards
{
    using UnityEngine;

    public class CreateGoldMine : MonoBehaviour
    {
        public float TimeTillNextGoldMine = 4;

        private float elapsedTime;

        public void Update()
        {
            this.elapsedTime += Time.deltaTime;
            while (this.elapsedTime > this.TimeTillNextGoldMine)
            {
                this.elapsedTime -= this.TimeTillNextGoldMine;
                this.AddGoldMine();
            }
        }

        private void AddGoldMine()
        {
        }
    }
}

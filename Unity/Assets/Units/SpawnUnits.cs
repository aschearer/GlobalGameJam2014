namespace Assets.Units
{
    using UnityEngine;

    public class SpawnUnits : MonoBehaviour
    {
        public GameObject UnitPrefab;

        public int NumberOfEnemiesToSpawn = 20;

        public float SecondsTillSpawn = 30;

        private float elapsedTime;

        private GameObject board;

        public void Start()
        {
            this.board = GameObject.Find("Board").gameObject;
        }

        public void Update()
        {
            this.elapsedTime += Time.deltaTime;
            if (this.elapsedTime >= this.SecondsTillSpawn)
            {
                this.elapsedTime -= this.SecondsTillSpawn;
                for (int i = 0; i < this.NumberOfEnemiesToSpawn; i++)
                {
                    var position = this.transform.position;
                    var unit = (GameObject)GameObject.Instantiate(this.UnitPrefab, position, Quaternion.identity);
                    unit.transform.parent = this.board.transform;
                }
            }
        }
    }
}

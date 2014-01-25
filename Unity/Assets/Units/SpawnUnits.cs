namespace Assets.Units
{
    using UnityEngine;

    public class SpawnUnits : MonoBehaviour
    {
        public GameObject UnitPrefab;

        public int NumberOfEnemiesToSpawn = 20;

        public float SpawnDuration = 1;

        public float SecondsTillSpawn = 5;

        private float spawnTimer;

        private float createUnitTimer;

        private GameObject board;

        private int enemiesToSpawn;

        public void Start()
        {
            this.board = GameObject.Find("Board").gameObject;
        }

        public void Update()
        {
            this.spawnTimer += Time.deltaTime;
            if (this.spawnTimer >= this.SecondsTillSpawn)
            {
                this.spawnTimer -= this.SecondsTillSpawn;
                this.enemiesToSpawn += this.NumberOfEnemiesToSpawn;
            }

            if (this.enemiesToSpawn > 0)
            {
                this.createUnitTimer += Time.deltaTime;
                var timeBetweenUnitSpawns = this.SpawnDuration / this.NumberOfEnemiesToSpawn;
                if (this.createUnitTimer >= timeBetweenUnitSpawns && this.enemiesToSpawn > 0)
                {
                    this.createUnitTimer -= timeBetweenUnitSpawns;
                    this.enemiesToSpawn--;
                    var position = this.transform.position;
                    var unit = (GameObject)GameObject.Instantiate(this.UnitPrefab, position, Quaternion.identity);
                    unit.transform.parent = this.board.transform;
                }
            }
        }
    }
}
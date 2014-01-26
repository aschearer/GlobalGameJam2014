namespace Assets.Units
{
    using Assets.Tiles;

    using UnityEngine;

    public class SpawnUnits : MonoBehaviour
    {
        public GameObject UnitPrefab;

        public int NumberOfUnitsToSpawn = 20;

        public float SpawnDuration = 1;

        public float SecondsTillSpawn = 5;

        public int NumberOfSpawns = 1;

        private float spawnTimer;

        private float createUnitTimer;

        private GameObject board;

        private int unitsToSpawn;

        private bool isSpawning;

        private int spawnsRemaining;

        public void Start()
        {
            this.board = GameObject.Find("Board").gameObject;
            this.spawnsRemaining = this.NumberOfSpawns;
        }

        public void TurnOn()
        {
            this.isSpawning = true;
        }

        public void Update()
        {
            if (!this.isSpawning)
            {
                return;
            }

            if (this.spawnsRemaining > 0)
            {
                this.spawnTimer += Time.deltaTime;
                while (this.spawnTimer >= this.SecondsTillSpawn)
                {
                    this.spawnTimer -= this.SecondsTillSpawn;
                    this.unitsToSpawn += this.NumberOfUnitsToSpawn;
                    this.spawnsRemaining--;
                }
            }

            if (this.unitsToSpawn > 0)
            {
                this.createUnitTimer += Time.deltaTime;
                var timeBetweenUnitSpawns = this.SpawnDuration / this.NumberOfUnitsToSpawn;
                while (this.createUnitTimer >= timeBetweenUnitSpawns)
                {
                    this.createUnitTimer -= timeBetweenUnitSpawns;
                    this.unitsToSpawn--;
                    var position = this.transform.position;
                    var unit = (GameObject)GameObject.Instantiate(this.UnitPrefab, position, Quaternion.identity);
                    unit.transform.parent = this.board.transform;
                }
            }
            else if (this.spawnsRemaining == 0)
            {
                // Tile is the grand parent
                this.transform.parent.parent.tag = SelectedTile.EmptyTagName;

                // Village is the parent
                GameObject.Destroy(this.transform.parent.gameObject);
            }
        }
    }
}
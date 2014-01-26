namespace Assets.Units
{
    using UnityEngine;

    public class SpawnEvilUnits : MonoBehaviour
    {
        public GameObject UnitPrefab;

        public int NumberOfEnemiesToSpawn = 20;

		public int EnemyIncreasePerWave = 2;

        public float SpawnDuration = 1;

        public float SecondsTillSpawn = 10f;

		public float SecondsTillSpawnDecreasePerWave = 0.1f;

		public float MinSecondsTillSpawn = 1f;

        public Material EvilUnitMaterial;

		private int wave = 0;

        private float spawnTimer;

        private float createUnitTimer;

        private int enemiesToSpawn;

        private GameObject spawnTile;

        private int layer;

        public void Start()
        {
            this.layer = LayerMask.NameToLayer("Evil Units");
        }

        public void Update()
        {
            this.spawnTimer += Time.deltaTime;
			float timeUntilSpawn = Mathf.Max(this.SecondsTillSpawn - this.wave * this.SecondsTillSpawnDecreasePerWave, MinSecondsTillSpawn);
			if (this.spawnTimer >= timeUntilSpawn)
            {
				this.spawnTimer -= timeUntilSpawn;
                this.enemiesToSpawn += this.NumberOfEnemiesToSpawn + this.wave * this.EnemyIncreasePerWave;
                this.spawnTile = this.GetEvilTile();
				this.wave++;
            }

            if (this.enemiesToSpawn > 0)
            {
                this.createUnitTimer += Time.deltaTime;
                var timeBetweenUnitSpawns = this.SpawnDuration / this.NumberOfEnemiesToSpawn;
                if (this.createUnitTimer >= timeBetweenUnitSpawns && this.enemiesToSpawn > 0)
                {
                    this.createUnitTimer -= timeBetweenUnitSpawns;
                    this.enemiesToSpawn--;
                    var position = this.spawnTile.transform.position;
                    var unit = (GameObject)GameObject.Instantiate(
                        this.UnitPrefab, 
                        position, 
                        this.spawnTile.transform.rotation);
                    unit.layer = this.layer;
                    unit.transform.parent = this.transform;
                    unit.transform.FindChild("Model").renderer.material = this.EvilUnitMaterial;
                }
            }
        }

        private GameObject GetEvilTile()
        {
            var evilTiles = GameObject.FindGameObjectsWithTag("Evil Tile");
            int i = Random.Range(0, evilTiles.Length);
            return evilTiles[i];
        }
    }
}
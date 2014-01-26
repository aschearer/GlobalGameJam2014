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
		
		public float SecondsWarningTillSpawn = 3f;
		
		public float SecondsTillSpawnDecreasePerWave = 0.1f;

		public float MinSecondsTillSpawn = 1f;

        public Material EvilUnitMaterial;

		public Material EvilTileWarningMaterial;

		private Material evilTileMaterial;

		private int wave = 0;

        private float spawnTimer;

        private float createUnitTimer;

        private int enemiesToSpawn;

        private GameObject spawnTile;

        private int layer;

        public void Start()
        {
			this.layer = LayerMask.NameToLayer("Evil Units");
			this.spawnTile = this.GetEvilTile();
			evilTileMaterial = this.spawnTile.renderer.material;
		}
		
		public void Update()
        {
            this.spawnTimer += Time.deltaTime;
			float timeUntilSpawn = Mathf.Max(this.SecondsTillSpawn - this.wave * this.SecondsTillSpawnDecreasePerWave, MinSecondsTillSpawn);
			if (this.spawnTimer >= timeUntilSpawn)
            {
				this.spawnTimer -= timeUntilSpawn;
                this.enemiesToSpawn += this.NumberOfEnemiesToSpawn + this.wave * this.EnemyIncreasePerWave;
				this.wave++;
				this.spawnTile.renderer.material = evilTileMaterial;
            }
			else if (spawnTimer >= timeUntilSpawn - SecondsWarningTillSpawn)
			{
				this.spawnTile.renderer.material = EvilTileWarningMaterial;
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
						Quaternion.Euler(new Vector3(0, 180, 0)));
                    unit.layer = this.layer;
                    unit.transform.parent = this.transform;
					unit.transform.FindChild("Model").renderer.material = this.EvilUnitMaterial;
					if (this.enemiesToSpawn == 0)
						this.spawnTile = this.GetEvilTile();
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
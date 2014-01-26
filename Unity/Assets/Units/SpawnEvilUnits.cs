namespace Assets.Units
{
    using UnityEngine;

    public class SpawnEvilUnits : MonoBehaviour
    {
        public GameObject UnitPrefab;

        public Material EvilUnitMaterial;

        public Material EvilTileWarningMaterial;

		public Material EvilTileMaterial;

		private GameObject boatModel;

        public float SecondsWarningTillSpawn = 3f;

        public float SpawnDuration = 1;

        private float spawnTimer;

        private float createUnitTimer;

        private int enemiesToSpawn;

        private int layer;

        public void Start()
        {
			this.boatModel = this.transform.FindChild("Boat").gameObject;
			this.layer = LayerMask.NameToLayer("Evil Units");
			boatModel.renderer.enabled = false;
        }

        public void SpawnUnits(int howMany)
        {
            Debug.Log("Spawning " + howMany + " units");
            this.spawnTimer = this.SecondsWarningTillSpawn;
            this.enemiesToSpawn = howMany;
			boatModel.renderer.enabled = true;
        }
        
        public void Update()
        {
            this.spawnTimer -= Time.deltaTime;
            if (this.spawnTimer > 0)
            {
                return;
            }

            if (this.enemiesToSpawn > 0)
            {
                this.createUnitTimer += Time.deltaTime;
                var timeBetweenUnitSpawns = this.SpawnDuration / this.enemiesToSpawn;
                if (this.createUnitTimer >= timeBetweenUnitSpawns && this.enemiesToSpawn > 0)
                {
                    this.createUnitTimer -= timeBetweenUnitSpawns;
                    this.enemiesToSpawn--;
                    var position = this.transform.position;
                    var unit = (GameObject)GameObject.Instantiate(
                        this.UnitPrefab, 
                        position,
                        Quaternion.Euler(new Vector3(0, 180, 0)));
                    unit.layer = this.layer;
                    unit.transform.parent = this.transform;
                    unit.transform.FindChild("Model").renderer.material = this.EvilUnitMaterial;

                    if (this.enemiesToSpawn == 0)
					{
						boatModel.renderer.enabled = false;
                    }
                }
            }
        }
    }
}
namespace Assets.Units
{
	using Assets.Store;
	using Assets.Tiles;

	using UnityEngine;
	
	public class SpeedUpUnit : MonoBehaviour
	{
	    public float TimeToLive = 10;

		private int unitLayer;

	    private bool isOn;

	    private float elapsedTime;

	    private int tileLayer;

	    public void Start()
		{
			this.unitLayer = LayerMask.NameToLayer("Units");
            this.tileLayer = LayerMask.NameToLayer("Tiles");
		}

	    public void TurnOn()
	    {
	        this.isOn = true;
	    }
		
		public void OnTriggerEnter(Collider other)
		{
		    if (!this.isOn)
		    {
		        return;
		    }

		    this.elapsedTime += Time.deltaTime;
		    if (this.elapsedTime >= this.TimeToLive)
		    {
                GameObject.Destroy(this.gameObject);
                if (this.gameObject.transform.parent.gameObject.layer == this.tileLayer)
                {
                    this.gameObject.transform.parent.gameObject.tag = SelectedTile.EmptyTagName;
                }
		    }

			if (other.gameObject.layer == this.unitLayer)
			{
				other.gameObject.SendMessage("SpeedUp");
			}
		}
	}
}

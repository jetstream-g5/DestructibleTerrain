using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class BulletController : MonoBehaviour {

	private Rigidbody2D rb; 
	[SerializeField]private Transform bulletSpriteTransform;  
	private CircleCollider2D destructionCircle;
	private GroundController groundController;
    [SerializeField]private GameObject explosion;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D>();
        destructionCircle = GetComponentInChildren<CircleCollider2D>();
	}

	void OnCollisionEnter2D( Collision2D coll ){
		if( coll.collider.tag == "Ground"){
            groundController = coll.gameObject.GetComponent<GroundController>();
            groundController.DestroyGround( destructionCircle );
		}
        Destroy(gameObject);
        Instantiate(explosion, this.transform.position, Quaternion.identity);
    }
}

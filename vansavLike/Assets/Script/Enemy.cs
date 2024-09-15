using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
	Transform pTransform;

	[Header("ë¨ìx")]
	[SerializeField]
	float speed;

	Transform mTransform;
	Vector3 moveDir;

	[Header("çUåÇóÕ")]
	public int attack;

	// Start is called before the first frame update
	void Start()
    {
		mTransform = this.transform;
		pTransform = GameObject.Find("pPlayer").transform;
	}

    // Update is called once per frame
    void Update()
    {
		Move();
    }

	private void Move()
	{
		moveDir = pTransform.position - mTransform.position;

		mTransform.position += moveDir.normalized * 0.01f * speed;
	}

	private void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.gameObject.tag == "Player")
		{
			Destroy(this.gameObject);
		}
	}
}

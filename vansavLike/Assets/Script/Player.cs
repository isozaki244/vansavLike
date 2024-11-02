using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
	[Header("ç≈ëÂëÃóÕ")]
	[SerializeField]
	private float maxHp;
	[Header("ë¨ìx")]
	[SerializeField]
	private float speed;
	[SerializeField]
	private float hp;

	// å¸Ç´
	private Vector3 dir;

	private Transform mTransform;

	private float scaleX;
	private Transform hpTransform;

	private WeaponEmitter weaponEmitter;

    // Start is called before the first frame update
    void Start()
    {
		mTransform = this.transform;
		hpTransform = mTransform.GetChild(0).transform;
		hp = maxHp;
		scaleX = hpTransform.localScale.x;
		weaponEmitter = mTransform.GetChild(2).GetComponent<WeaponEmitter>();
	}

    // Update is called once per frame
    void Update()
    {
		dir = new Vector3(0f, 0f, 0f);

		// âEà⁄ìÆ
        if(Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
		{
			dir.x = 1;
		}

		// ç∂à⁄ìÆ
		if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
		{
			dir.x = -1;
		}

		// è„à⁄ìÆ
		if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
		{
			dir.y = 1;
		}

		// â∫à⁄ìÆ
		if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
		{
			dir.y = -1;
		}

		mTransform.position += dir * speed * 0.01f;
		if (dir != new Vector3(0f, 0f, 0f))
		{
			weaponEmitter.SetEmitDir(dir);
		}
	}

	private void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.gameObject.tag == "Enemy")
		{
			Damaged(collision.gameObject.GetComponent<Enemy>().attack);
		}
	}

	void Damaged(int damage)
	{
		hp -= damage;

		hpTransform.localScale = new Vector3((hp / maxHp), hpTransform.localScale.y, hpTransform.localScale.z);
		Debug.Log(1 - hp / maxHp);
		hpTransform.localPosition = new Vector3(0 - (1 - hp / maxHp) / 2, hpTransform.localPosition.y);
	}
}

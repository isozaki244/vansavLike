using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
	[Header("最大体力")]
	[SerializeField]
	float maxHp;

	[Header("速度")]
	[SerializeField]
	float speed;

	[SerializeField]
	float hp;

	Transform mTransform;
	[SerializeField]
	float scaleX;
	[SerializeField]
	Transform hpTransform;

    // Start is called before the first frame update
    void Start()
    {
		mTransform = this.transform;
		hpTransform = mTransform.GetChild(0).transform;
		hp = maxHp;
		scaleX = hpTransform.localScale.x;
    }

    // Update is called once per frame
    void Update()
    {
		// 右移動
        if(Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
		{
			mTransform.position += new Vector3(0.01f, 0.0f, 0.0f) * speed;
		}

		// 左移動
		if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
		{
			mTransform.position += new Vector3(-0.01f, 0.0f, 0.0f) * speed;
		}

		// 上移動
		if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
		{
			mTransform.position += new Vector3(0.0f, 0.01f, 0.0f) * speed;
		}

		// 下移動
		if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
		{
			mTransform.position += new Vector3(0.0f, -0.01f, 0.0f) * speed;
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

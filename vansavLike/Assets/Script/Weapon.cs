using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
	[Header("速度")]
	[SerializeField]
	private float speed;

	[Header("ダメージ")]
	[SerializeField]
	private float damage;

	[Header("クールタイム")]
	[SerializeField]
	public float coolTime;

	// 発射向き
	private Vector3 direction;

	// クールタイム計測
	[System.NonSerialized]
	public float time;


	// Start is called before the first frame update
	void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
		this.transform.position += direction * speed * 0.01f;
    }

	public void SetDirection(Vector2 dir)
	{
		direction = dir;
	}
}

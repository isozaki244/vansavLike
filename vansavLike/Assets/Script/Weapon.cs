using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
	[Header("���x")]
	[SerializeField]
	private float speed;

	[Header("�_���[�W")]
	[SerializeField]
	private float damage;

	[Header("�N�[���^�C��")]
	[SerializeField]
	public float coolTime;

	// ���ˌ���
	private Vector3 direction;

	// �N�[���^�C���v��
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

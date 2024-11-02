using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponEmitter : MonoBehaviour
{
	// ����I�u�W�F�N�g
	private GameObject[] weapons = new GameObject[4];

	// ������
	private Weapon[] weaponInfos = new Weapon[4];

	// ������
	private int possession;

	// ���ˌ���
	private Vector2 emitDir;

	// Start is called before the first frame update
	void Start()
    {
		possession = 0;
		SetWeapon((GameObject)Resources.Load("Nife"));
		emitDir = new Vector2(1f, 0f);
    }

    // Update is called once per frame
    void Update()
    {
		for (int i = 0; i < possession; i++)
		{
			weaponInfos[i].time += Time.deltaTime;
			if (weaponInfos[i].coolTime < weaponInfos[i].time)
			{
				Emit(i);
				weaponInfos[i].time = 0f;
			}
		}
    }

	public void SetWeapon(GameObject weapon)
	{
		weapons[possession] = weapon;
		weaponInfos[possession] = weapon.GetComponent<Weapon>();
		possession++;
	}

	public void Emit(int num)
	{
		GameObject obj = Instantiate(weapons[num]);
		obj.transform.position = this.transform.position;
		obj.GetComponent<Weapon>().SetDirection(emitDir);
	}

	public void SetEmitDir(Vector2 vector)
	{
		emitDir = vector;
	}
}

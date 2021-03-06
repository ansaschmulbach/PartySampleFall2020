﻿using UnityEngine;

public class WeaponController : IWeapon {

	[Header("Settings")]
	public int damage;
	public float bulletSpeed;
	public float fireInterval = .5f;
	public string damageTag = "Enemy";

	[Header("Configurations")]
	public Transform fireOrigin;
	public GameObject bulletPrototype;

	[Header("Status (Do not modify these fields through Editor)")]
	public float lastFireTime;

	public override void OnTriggerPressed() {
		if (CanFire()) {
			Fire();
		}
	}

	public override bool CanFire() {
		var time = Time.time;
		return lastFireTime + fireInterval <= time;
	}

	private void Fire() {
		lastFireTime = Time.time;
		var bullet = Instantiate(bulletPrototype, fireOrigin ? fireOrigin.position : transform.position, transform.rotation);
		var controller = bullet.GetComponent<BulletController>();
		controller.damage = damage;
		controller.damageTag = damageTag;
		var velocity = bullet.transform.up * bulletSpeed;
		controller.GetComponent<Rigidbody2D>().velocity = velocity;
		AudioManager.PlayAtPoint(fireSfx, bullet.transform.position);
	}
}

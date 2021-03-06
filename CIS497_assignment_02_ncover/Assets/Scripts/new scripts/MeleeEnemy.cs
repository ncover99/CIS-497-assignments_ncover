﻿/*
 * Nathan Cover
 * MeleeEnemy.cs
 * Assignment_02
 * child of EnemyType.cs holds functionality for melee enemies
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Assignment_02
{
    public class MeleeEnemy : EnemyType
    {
        private Rigidbody2D _rb2d;

        // Start is called before the first frame update
        new void Start()
        {
            base.Start();
            _rb2d = GetComponent<Rigidbody2D>();
        }

        public override void Move()
        {
            var playerDir = new Vector2(transform.position.x - PlayerPos.position.x, 
                transform.position.y - PlayerPos.position.y).normalized;
            _rb2d.MovePosition(_rb2d.position + (-playerDir * Speed) * Time.fixedDeltaTime);
        }
    
        private void OnCollisionStay2D(Collision2D other)
        {
            var temp = other.collider.GetComponent<CanTakeDamage>();
            if (temp != null && other.gameObject.tag == "Player")
            {
                temp.TakeDamage();
            }
        }
    }   
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float _speed = 10;

    void Update()
    {
        transform.Translate(new Vector3(-1 *_speed * Time.deltaTime * 2000, 0, 0));
    }
}

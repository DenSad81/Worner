using System.Collections;
using System.Collections.Generic;
using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Animator))]

public class KnightMovement : MonoBehaviour
{
    [SerializeField] private float _runSpead = 500f;
    [SerializeField] private float _walkSpead = 100f;

    private Rigidbody2D _rigitbody2DKnight;
    private Animator _animator2DKnight;

    private const string ActualSpeedX = "actSpeedX";

    private void Start()
    {
        _rigitbody2DKnight = GetComponent<Rigidbody2D>();
        _animator2DKnight = GetComponent<Animator>();
    }

    private void Update()
    {
        float actualSpeedX = 0;
        Vector2 position = _rigitbody2DKnight.position;

        if (Input.GetKey(KeyCode.PageUp))
        {
            actualSpeedX = _walkSpead;

            if (Input.GetKey(KeyCode.Space))
                actualSpeedX = _runSpead;
        }

        if (Input.GetKey(KeyCode.Home))
        {
            actualSpeedX = -_walkSpead;

            if (Input.GetKey(KeyCode.Space))
                actualSpeedX = -_runSpead;
        }

        position.x += actualSpeedX * Time.deltaTime;
        _animator2DKnight.SetFloat(ActualSpeedX, actualSpeedX);

        _rigitbody2DKnight.position = position;
    }
}
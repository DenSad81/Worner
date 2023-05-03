using System.Collections;
using System.Collections.Generic;
using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class KnightMovement : MonoBehaviour
{
    [SerializeField] private float _runSpead = 500f;
    [SerializeField] private float _walkSpead = 100f;

    private Rigidbody2D _rigitbody2DKnight;
    private Animator _animator2DKnight;
    private const string actSpeedX = "actSpeedX";

    //_animator.SetBool(IsGrounded, value);

    private void Start()
    {
        _rigitbody2DKnight = this.gameObject.GetComponent<Rigidbody2D>();
        _animator2DKnight = this.gameObject.GetComponent<Animator>();
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
        _animator2DKnight.SetFloat(actSpeedX, actualSpeedX);

        _rigitbody2DKnight.position = position;
    }
}
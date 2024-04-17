using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    private Vector2 RawInput;
    [SerializeField]public float MovementSpeed = 5.0f;

	Vector2 MinBounds;
	Vector2 MaxBounds;
	[SerializeField] float PaddingLeft;
	[SerializeField] float PaddingRight;
	[SerializeField] float PaddingTop;
	[SerializeField] float PaddingBottom;

	Shooter Shooter;

	private void Awake()
	{
		Shooter = GetComponent<Shooter>();
	}

	void Start()
	{
		InitBound();
	}

	void Update()
	{
		Move();
	}

	void InitBound()
	{
		Camera MainCamera = Camera.main;
		MinBounds = MainCamera.ViewportToWorldPoint(new Vector2(0, 0));
		MaxBounds = MainCamera.ViewportToWorldPoint(new Vector2(1, 1));
	}

	void Move()
	{
		Vector2 delta = RawInput * MovementSpeed * Time.deltaTime;
		Vector2 NewPos = new Vector2();
		NewPos.x = Mathf.Clamp(transform.position.x + delta.x, MinBounds.x + PaddingLeft, MaxBounds.x - PaddingRight);
		NewPos.y = Mathf.Clamp(transform.position.y + delta.y, MinBounds.y + PaddingBottom, MaxBounds.y - PaddingTop);
		transform.position = NewPos;
	}

	void OnMove(InputValue value)
    {
        RawInput =value.Get<Vector2>();
    }

	void OnFire(InputValue value)
	{
		if(Shooter != null)
		{
			Shooter.IsFiring = value.isPressed;
		}
	}
}

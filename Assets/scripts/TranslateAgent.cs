using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Polyworks;

public class TranslateAgent : MonoBehaviour {

	public float xSpeed;
	public float ySpeed;
	public float zSpeed;
    private float _yDeviation;      
	private float _xDeviation;
	private float _zDeviation;    
	public Boundary boundary;     
	private int _activeLocation = -1;    
	private float _activeRotationY = 0;     
	private float _velocityY = 0.0f;    
	private float _velocityX = 0.0f;    
	private float _rotationXAxis = 0.0f;     
	private float _rotationYAxis = 0.0f;    

	private float _moveX;
	private float _moveY;
	private float _moveZ;

	private Vector3 _deviation;

	public void Move(float horizontal, float vertical, float depth = 0) 
	{        
		_moveX = (xSpeed != 0 && horizontal != 0) ? _normalizeInput(horizontal, boundary.minX, boundary.maxX, _deviation.x) : 0;
		_moveY = (ySpeed != 0 && vertical != 0) ? _normalizeInput(vertical, boundary.minY, boundary.maxY, _deviation.y) : 0; 
		_moveZ = (zSpeed != 0 && depth != 0) ? _normalizeInput(depth, boundary.minZ, boundary.maxZ, _deviation.z) : 0;
		        
		_deviation.x += _moveX;
		_deviation.y += _moveY;
		_deviation.z += _moveZ;

		transform.position = new Vector3(_moveX, _moveY, _moveZ);
	}

	public void Init()
	{
		_deviation = new Vector3();
	}

	private float _normalizeInput(float input, float min, float max, float curr)
	{
		if(input + curr > max || input + curr < min) 
		{
			return 0;
		}
		return input;
	}
}

/*
* Author: Iris Bermudez
* GitHub: https://github.com/AlgoritmoAlgoritmo
* Date: 06/10/2024 (DD/MM/YY)
*/


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class MouseLook : MonoBehaviour {
	#region Variables
	[SerializeField]
	private PlayerInput playerInput;
    [SerializeField]
    private Transform xRotationTransform;
    [SerializeField]
    private Transform yRotationTransform;


    public static bool allowRotation = true;

    [SerializeField]
    private float mouseSensitivity = 1.7f;

    [SerializeField]
    private float minimumX = -360f;
    [SerializeField]
    private float maximumX = 360f;

    [SerializeField]
    private float minimumY = -60f;
    [SerializeField]
    private float maximumY = 60f;

    private float currentSensitivityX = 1.5f;
    private float currentSensitivityY = 1.5f;

    private float rotationX;
    private float rotationY;

    private Quaternion originalRotation;

    #endregion

    #region MonoBehaviour methods
    private void FixedUpdate() {
        
    }
    #endregion

    #region Private methods
    private void HandleRotation() {
        if( currentSensitivityX != mouseSensitivity
            || currentSensitivityY != mouseSensitivity ) {
            currentSensitivityX = currentSensitivityY = mouseSensitivity;
        }

        mouseSensitivity = currentSensitivityX;
        mouseSensitivity = currentSensitivityY;

        if( axes == RotationAxes.MouseX ) {
            rotationX += Input.GetAxis( "Mouse X" ) * mouseSensitivity;

            rotationX = ClampAngle( rotationX, minimumX, maximumX );
            Quaternion xQuaternion = Quaternion.AngleAxis( rotationX, Vector3.up );
            transform.localRotation = originalRotation * xQuaternion;
        } else if( axes == RotationAxes.MouseY ) {
            rotationY += Input.GetAxis( "Mouse Y" ) * mouseSensitivity;

            rotationY = ClampAngle( rotationY, minimumY, maximumY );
            Quaternion yQuaternion = Quaternion.AngleAxis( -rotationY, Vector3.right );
            transform.localRotation = originalRotation * yQuaternion;
        }
    }


    private float ClampAngle( float angle, float min, float max ) {
        if( angle < -360f ) {
            angle += 360f;
        } else if( angle > 360 ) {
            angle -= 360f;
        }

        return Mathf.Clamp( angle, min, max );
    }

    #endregion
}

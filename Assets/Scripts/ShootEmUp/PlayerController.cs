using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ShootEmUp
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] float speed = 5f;
        [SerializeField] float smoothness = 0.1f;
        [SerializeField] float leanAngle = 15f;
        [SerializeField] float leanSpeed = 5f;


        [SerializeField] GameObject model;

        [Header("Camera Bounds")]
        [SerializeField] Transform cameraFollow;
        [SerializeField] float minX = -8f;
        [SerializeField] float maxX = 8f;
        [SerializeField] float minY = -4f;
        [SerializeField] float maxY = 4f;

        InputReader input;

        Vector3 currentVelocity;
        Vector3 targetPosition;

        private void Start()
        {
            input = GetComponent<InputReader>();
        }
        private void Update()
        {
            targetPosition += new Vector3(input.Move.x, input.Move.y, 0f) * (speed * Time.deltaTime);

            // calculate the min and max X and Y positions for the player based on the camera view
            var minPlayerX = cameraFollow.position.x + minX;
            var maxPlayerX = cameraFollow.position.x + maxX;
            var minPlayerY = cameraFollow.position.y + minY;
            var maxPlayerY = cameraFollow.position.y + maxY;

            // clamp the playr position to the camera view
            targetPosition.x = Mathf.Clamp(targetPosition.x, minPlayerX, maxPlayerX);
            targetPosition.y = Mathf.Clamp(targetPosition.y, minPlayerY, maxPlayerY);

            // lerp the player position to the target position
            transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref currentVelocity, smoothness);

            // calculate the rotation effect
            var targetRotationAngle = input.Move.x * leanAngle;

            var currentYRotation = transform.localEulerAngles.y;
            var newYRotation = Mathf.LerpAngle(currentYRotation, targetRotationAngle, leanSpeed * Time.deltaTime);

            // apply the rotation effect
            transform.localEulerAngles = new Vector3(0f, newYRotation, 0);

        }
    }
}

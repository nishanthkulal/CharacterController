using System;
using System.Collections;
using UnityEngine;

public partial class EnemyAI : MonoBehaviour
{
    [SerializeField] private Transform enemyHead;
    [SerializeField] private WheelControllers wheelController;
    [SerializeField] private WheelMesh wheelMesh;
    [SerializeField] private float rotationSpeed = 5f;

    private bool isLookingAtPlayer = false;

    void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player") && !isLookingAtPlayer)
        {
            Transform playerTransform = other.transform;
            StartCoroutine(LookAtPlayer(playerTransform));
        }
        else if (!isLookingAtPlayer)
        {
            StartCoroutine(SearchForPlayer());
        }
    }

    private string SearchForPlayer()
    {
        throw new NotImplementedException();
    }

    void Update()
    {
        UpdateWheelRotation();
    }

    private void UpdateWheelRotation()
    {
        HandleWheelRotationAndMesh(wheelController.frontRightWheel, wheelMesh.frontRightWheel);
        HandleWheelRotationAndMesh(wheelController.frontLeftWheel, wheelMesh.frontLeftWheel);
        HandleWheelRotationAndMesh(wheelController.backRightWheel, wheelMesh.backRightWheel);
        HandleWheelRotationAndMesh(wheelController.backLeftWheel, wheelMesh.backLeftWheel);
    }

    private void HandleWheelRotationAndMesh(WheelCollider coll, MeshRenderer meshs)
    {
        Quaternion quat;
        Vector3 pos;
        coll.GetWorldPose(out pos, out quat);
        meshs.transform.rotation = quat;
        meshs.transform.position = pos;

    }

    private IEnumerator LookAtPlayer(Transform playerTransform)
    {
        isLookingAtPlayer = true;

        Vector3 direction = (playerTransform.position - enemyHead.position).normalized;
        Quaternion targetRotation = Quaternion.LookRotation(direction);

        // adjust this value to control the rotation speed
        float timer = 0f;

        while (timer < 1f)
        {
            enemyHead.rotation = Quaternion.Slerp(enemyHead.rotation, targetRotation, rotationSpeed * Time.deltaTime);
            timer += Time.deltaTime;
            yield return null;
        }

        enemyHead.rotation = targetRotation; // ensure the enemy's head is exactly looking at the player
        isLookingAtPlayer = false;
    }

}

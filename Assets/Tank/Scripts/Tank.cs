using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.InputSystem;

public class Tank : MonoBehaviour
{
    const float MIN_X = 8f;
    const float MAX_X = -25f;

    [SerializeField]
    float moveSpeed = 5f;

    [SerializeField]
    float turnSpeed = 120f;

    [SerializeField]
    Transform muzzle;


    [SerializeField]
    private GameObject barrel;

    [SerializeField]
    private GameObject turret;

    [SerializeField]
    private GameObject spawnObject;


    void Update()
    {
        float move = 0f;
        float turn = 0f;

        // Tank movement
        if (Keyboard.current.wKey.isPressed) move = 1f;
        else if (Keyboard.current.sKey.isPressed) move = -1f;

        if (Keyboard.current.aKey.isPressed) turn = -1f;
        else if (Keyboard.current.dKey.isPressed) turn = 1f;

        float barrelRotationSpeed = 30f;
        float turretRotationSpeed = 15f;

        float xAngle = barrel.transform.localEulerAngles.x;
        float yAngle = turret.transform.localEulerAngles.y;

        float newX = xAngle;
        float newY = yAngle;


        if (Keyboard.current.upArrowKey.isPressed)
            newX -= barrelRotationSpeed * Time.deltaTime;

        if (Keyboard.current.downArrowKey.isPressed)
            newX += barrelRotationSpeed * Time.deltaTime;

        if (Keyboard.current.leftArrowKey.isPressed)
            newY -= turretRotationSpeed * Time.deltaTime;

        if (Keyboard.current.rightArrowKey.isPressed)
            newY += turretRotationSpeed * Time.deltaTime;

        Vector3 localEuler = barrel.transform.localEulerAngles;
        localEuler.x = newX;
        barrel.transform.localEulerAngles = localEuler;

        Vector3 localEuler2 = turret.transform.localEulerAngles;
        localEuler2.y = newY;
        turret.transform.localEulerAngles = localEuler2;

        transform.Translate(Vector3.forward * move * moveSpeed * Time.deltaTime);
        transform.Rotate(Vector3.up * turn * turnSpeed * Time.deltaTime);

        if (Keyboard.current.spaceKey.wasPressedThisFrame)
            fireRound();
    }




    void fireRound()
    {
        print("fire");
        Instantiate(spawnObject, muzzle.position, muzzle.rotation);

    }
}

using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerController : MonoBehaviour {
    // TODO work out why speed is varying across the scene

    [Header("General")]
    [Tooltip("In ms^-1")] [SerializeField] float controlSpeed = 1;
    [Tooltip("In m")] [SerializeField] float xRange = 5f;
    [Tooltip("In m")] [SerializeField] float yRange = 5f;
    [SerializeField] GameObject[] guns;

    [Header("Screen Position Based")]
    [SerializeField] float positionPitchFactor = -5f;
    [SerializeField] float controlPitchFactor = -20f;

    [Header("Control Throw Based")]
    [SerializeField] float positionYawFactor = 5f;
    [SerializeField] float controlRollFactor = -5f;

    float xThrow, yThrow;
    bool isControlEnabled = true;

    

    void Update (){
        if (isControlEnabled){
            ProcessTranslation();
            ProcessRotation();
            ProcessFiring();
        }
    }
   
    private void ProcessTranslation(){
        xThrow = CrossPlatformInputManager.GetAxis("Horizontal");
        float xOffset = controlSpeed * xThrow * Time.deltaTime;
        float rawNewXPos = transform.localPosition.x + xOffset;
        float clampedXPos = Mathf.Clamp(rawNewXPos, -xRange, xRange);

        yThrow = CrossPlatformInputManager.GetAxis("Vertical");
        float yOffset = controlSpeed * yThrow * Time.deltaTime;
        float rawNewYPos = transform.localPosition.y + yOffset;
        float clampedYPos = Mathf.Clamp(rawNewYPos, -yRange, yRange);

        transform.localPosition = new Vector3(clampedXPos, clampedYPos, transform.localPosition.z);
    }

    private void ProcessRotation(){
        float pitchDueToPosition = transform.localPosition.y * positionPitchFactor;
        float pitchDueToThrow = yThrow * controlPitchFactor;

        float pitch = pitchDueToPosition + pitchDueToThrow;
        float yaw = transform.localPosition.x * positionYawFactor;
        float roll = xThrow * controlRollFactor;

        transform.localRotation = Quaternion.Euler(pitch, yaw, roll);
    }

    void OnPlayerDeath(){
        print("stop controls, from collision handler");
        isControlEnabled = false;
    }

    void ProcessFiring(){
        if (CrossPlatformInputManager.GetButton("Fire")){
            foreach(GameObject gun in guns){
                gun.SetActive(true);
            }
        } else {
            foreach (GameObject gun in guns){
                gun.SetActive(false);
            }
        }
    }
}

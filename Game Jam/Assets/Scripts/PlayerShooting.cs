using UnityEngine;
using System.Collections;
using ControlWrapping;

public class PlayerShooting : MonoBehaviour {

    public float rotateSpeed = 10f;

    public float fireRate = 0.1f;
    public float arrowSpeed = 30f;
    public int numberOfArrows = 3;

    private GameObject arrowComponent;

    bool isShooting = false;
    float timeSinceLastShot = 0f;
    
    void Start () {

        arrowComponent = GetComponentInChildren<LightScript>().gameObject;
        arrowComponent.SetActive(false);
    }

    public void Aim(float aimHorizontal, float aimVertical)
    {
        Vector3 toAim = new Vector3(aimHorizontal, aimVertical, 0);
        
        toAim.Normalize();
        if (toAim != Vector3.zero)
        {
            float step = rotateSpeed * Time.deltaTime;
            Vector3 newAim = Vector3.RotateTowards(transform.forward, toAim, step, 0.0F);
            arrowComponent.transform.rotation = Quaternion.LookRotation(Vector3.forward, newAim) * Quaternion.Euler(0, 0, 90);
        }
        //animationComponent.AimAnimation(aimHorizontal, aimVertical, Quaternion.identity);
    }

    public void Shoot(ButtonPressState shootState)
    {
        if (shootState == ButtonPressState.Pressed && timeSinceLastShot >= fireRate)
        {
            Debug.Log("Drawing!");
            isShooting = true;
            arrowComponent.SetActive(true);
            //animator.SetBool("shooting", true);
        }
        if (shootState == ButtonPressState.Released && isShooting)
        {
            
            timeSinceLastShot = 0;
            numberOfArrows--;
            arrowComponent.SetActive(false);
            //animator.SetBool("shooting", false);
        }
    }

    public void AddArrows(int numberOfArrowsToAdd)
    {
        GameManager.Log("Added " + numberOfArrowsToAdd + " arrows", this, LogLevel.Verbose);
        numberOfArrows += numberOfArrowsToAdd;
    }

    public void SetShooting(bool shooting)
    {
        GameManager.Log("Shooting!", this, LogLevel.High);
        isShooting = false;
    }
}



using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Gun : MonoBehaviour
{
    private CharacterInput controls;

    public float PistolDamage = 10f;
    //public float SniperDamage = 20f;
    public float ShotgunDamage = 20f;

    public float PistolRange = 20f;
    //public float SniperRange = 50f;
    public float ShotgunRange = 15f;

    public float PistolFireRate = 0.1f;
    //public float SniperFireRate = 1f;
    public float ShotgunFireRate = 0.5f;

    public int ShotgunShots = 15; // Number of shots for the shotgun
    public float ShotgunSpreadAngle = 22.5f; // Half of 45 degrees

    public Transform player;
    public Text gunTypeText; // Reference to the UI Text element

    private float nextFireTime = 0f;
    private int currentGunIndex = 0; // 0 = Pistol, 1 = Sniper, 2 = Shotgun
    private float damage;
    private float range;
    private float fireRate;

    private LineRenderer lineRenderer;

    void Awake()
    {
        controls = new CharacterInput();
        lineRenderer = gameObject.AddComponent<LineRenderer>();
        lineRenderer.positionCount = 2;
        lineRenderer.startWidth = 0.05f;
        lineRenderer.endWidth = 0.05f;
        lineRenderer.material = new Material(Shader.Find("Unlit/Color"));
        lineRenderer.startColor = Color.red;
        lineRenderer.endColor = Color.red;
        lineRenderer.enabled = false; // Initially disable the line renderer
    }

    void OnEnable() => controls.Enable();
    void OnDisable() => controls.Disable();

    void Start()
    {
        UpdateGunTypeText(); // Initialize the text on start
        SetGunProperties(); // Set initial gun properties
    }

    void Update()
    {
        if (controls.Player.Switch.triggered) SwitchGun();

        if (controls.Player.Shoot.ReadValue<float>() > 0.01f && Time.time >= nextFireTime)
        {
            Shoot();
            nextFireTime = Time.time + fireRate;
        }
    }

    void SwitchGun()
    {
        currentGunIndex = (currentGunIndex + 1) % 2; // Cycle through 0, 1, 2

        SetGunProperties();
        UpdateGunTypeText(); // Update the displayed gun type
    }

    void SetGunProperties()
    {
        switch (currentGunIndex)
        {
            case 0: // Pistol
                damage = PistolDamage;
                range = PistolRange;
                fireRate = PistolFireRate;
                break;
            //case 1: // Sniper
              //  damage = SniperDamage;
                //range = SniperRange;
                //fireRate = SniperFireRate;
                //break;
            case 1: // Shotgun
                damage = ShotgunDamage;
                range = ShotgunRange;
                fireRate = ShotgunFireRate;
                break;
        }
    }

    void Shoot()
    {
        if (currentGunIndex == 0) // Pistol or Sniper
        {
            RaycastHit hit;
            if (Physics.Raycast(player.position, player.forward, out hit, range))
            {
                HandleHit(hit);
            }
            else
            {
                BulletPath(player.position, player.position + player.forward * range);
            }
        }
        else // Shotgun
        {
            // Fire all shots at once
            for (int i = 0; i < ShotgunShots; i++)
             {
                float angle = Random.Range(-ShotgunSpreadAngle, ShotgunSpreadAngle);
                Quaternion rotation = Quaternion.Euler(0, angle, 0);
                Vector3 direction = rotation * player.forward;

                RaycastHit hit;
                if (Physics.Raycast(player.position, direction, out hit, ShotgunRange))
                {
                    HandleHit(hit);
                }
                else
                {
                    BulletPath(player.position, player.position + direction * ShotgunRange);
                }
            }
        }
    }

    void HandleHit(RaycastHit hit)
    {
        target enemy = hit.transform.GetComponent<target>();
        if (enemy != null)
        {
            enemy.TakeDamage(damage);
        }
        BulletPath(player.position, hit.point);
    }

    private void BulletPath(Vector3 start, Vector3 end)
    {
        lineRenderer.SetPosition(0, start);
        lineRenderer.SetPosition(1, end);
        lineRenderer.enabled = true;
        StartCoroutine(DisableLineRenderer());
    }

    private IEnumerator DisableLineRenderer()
    {
        yield return new WaitForSeconds(0.1f); // Duration for which the line is visible
        lineRenderer.enabled = false;
    }

//    void UpdateGunTypeText()
  //  {
    //    if (gunTypeText != null)
      //  {
        //    string gunType = currentGunIndex == 0 ? "Pistol" : (currentGunIndex == 1 ? "Sniper" : "Shotgun");
          //  gunTypeText.text = "Current Gun: " + gunType;
       // }
    //}
}
 
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class Attack_Controller : MonoBehaviour
{
    public AudioClip sound1;
    AudioSource audioSource;

    public GameObject bulletParaent;
    public GameObject bulletPrefab;

    public Score scoreManager;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.JoystickButton2) || Input.GetMouseButtonDown(0))
        {
            if (PlayerHP.playerHP > 0 && scoreManager.Cscore > 0)
            {
                audioSource.PlayOneShot(sound1);

                var newBullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
                newBullet.transform.parent = bulletParaent.transform;
                scoreManager.CandyScoreDown();
            }
            else if (scoreManager != null)
            {
                scoreManager.Cscore = 0;
            }
        }
    }
}
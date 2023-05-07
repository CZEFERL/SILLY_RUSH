using UnityEngine;

public class ExplosionScript : MonoBehaviour
{
    public AudioSource explosionSound;

    private void Start()
    {
        AudioSource.PlayClipAtPoint(explosionSound.clip, new Vector3(0, 0, 0));
    }

    void AnimationEnd()
    {
        Destroy(gameObject);
    }
}

using UnityEngine;

public class ExplosionScript : MonoBehaviour
{
    void AnimationEnd()
    {
        Destroy(gameObject);
    }
}

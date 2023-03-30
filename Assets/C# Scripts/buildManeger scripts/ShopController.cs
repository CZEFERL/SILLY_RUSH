using UnityEngine;

public class ShopController : MonoBehaviour
{
    public static GameObject place = null;

    void Start()
    {
        gameObject.SetActive(false);
    }

    public void setBuild(GameObject building)
    {

        Instantiate(building, place.transform.position, place.transform.rotation);
        Destroy(place);
        gameObject.SetActive(false);
    }

    public void Cancel()
    {
        gameObject.SetActive(false);
    }
}
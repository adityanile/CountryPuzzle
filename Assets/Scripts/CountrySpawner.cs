using UnityEngine;

public class CountrySpawner : MonoBehaviour
{
    private Vector3 screenPoint;
    private Vector3 offset;

    private TouchManager touchManager;

    private Vector3 startPos;

    public GameObject reference;
    public GameObject country;

    public GameObject parent;

    private bool spawnCountry = false;

    private void Start()
    {
        touchManager = GameObject.Find("TouchManager").GetComponent<TouchManager>();
        startPos = transform.position;

        reference.SetActive(false);
    }

    public void OnMouseDown()
    {
        reference.SetActive(true);
        touchManager.allowMovement = false;

        screenPoint = Camera.main.WorldToScreenPoint(gameObject.transform.position);
        offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));
    }

    void OnMouseDrag()
    {
        Vector3 curScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);
        Vector3 curPosition = Camera.main.ScreenToWorldPoint(curScreenPoint) + offset;
        transform.position = curPosition;
    }

    private void OnMouseUp()
    {
        if (spawnCountry)
        {
            // Spawn the country
            GameObject inst = Instantiate(country, reference.transform.position, reference.transform.rotation);
            inst.transform.parent = parent.transform;

            Destroy(reference);
            Destroy(gameObject);
        }
        else
        {
            transform.position = startPos;
        }

        reference.SetActive(false);
        touchManager.allowMovement = true;
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.Equals(reference))
        {
            spawnCountry = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.Equals(reference))
        {
            spawnCountry = false;
        }
    }
}

using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayAgain : MonoBehaviour, IHittable
{
    private Rigidbody rb;
    protected int lifePoints = 1;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    public void GetHit(int damage)
    {
        lifePoints = (lifePoints - damage) < 0 ? 0 : (lifePoints - damage);
        if (lifePoints == 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
    void OnTriggerEnter(Collider col)
    {
        Debug.Log("hit");
        GetHit(1);
    }
}
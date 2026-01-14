using UnityEngine;
using UnityEngine.InputSystem;

public class spawner : MonoBehaviour
{
    [SerializeField] private float time = 10.0f;
    [SerializeField] private GameObject spawnObject;


    private void Awake()
    {
        print("awake");
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Instantiate(spawnObject, transform.position,transform.rotation);
		
        print("start");
    }

    // Update is called once per frame
    void Update()
    {
        if(Keyboard.current.spaceKey.isPressed){
            
            var go = Instantiate(spawnObject, transform.position,transform.rotation);
            Destroy(go, 4);
        }
    }
}

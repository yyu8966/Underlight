using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Item_Controller : MonoBehaviour
{
    
    // Start is called before the first frame update
    public int targetItemCount = 6;
   
    private int collectedItemCount = 0;
    public Text winText;
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject UI_ImageOne;
    [SerializeField] private GameObject door;
    private float moveAmount;
    void Start(){
        moveAmount = -.1f;
        startMoveUp();
        
    }

    // Update is called once per frame
    void Update(){
    transform.Translate(new Vector3 (0, moveAmount, 0) * Time.deltaTime, Space.Self);

      
        
    }
    
    void OnTriggerStay2D(Collider2D other){
        //print("collision entered");
        if(other.gameObject.tag == "Player"){
            //if(Input.GetKeyDown(KeyCode.F)){
                 print("item collected");
                 UI_ImageOne.SetActive(true);
                 collectedItemCount++;
                 Destroy(gameObject);
                 print(collectedItemCount);
                 print(targetItemCount);
           // }
           if (collectedItemCount >= targetItemCount)
            {
                openDoor();
               // WinGame();
            }
        }
     }
     void WinGame(){
        Debug.Log("Win！");
        winText.text = "You Win！";
    }
    private void startMoveDown(){
        moveAmount = .25f;
        Invoke("startMoveUp", 1);
    }

    private void startMoveUp(){
        moveAmount = -.25f;
        Invoke("startMoveDown", 1);
    }
    private void openDoor(){
        print("door opening");
        GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag("door");
         foreach (GameObject obj in objectsWithTag)
        {
            Destroy(obj);
        }
    }
}

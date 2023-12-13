using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item_Controller : MonoBehaviour
{
    
    // Start is called before the first frame update

    [SerializeField] private GameObject player;
    [SerializeField] private GameObject UI_ImageOne;
    [SerializeField] private GameObject Door;
    private float moveAmount;

    private int targetItemCount = 4;

    private int collectedItemCount = 0;

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
                 print(collectedItemCount);
                 if(collectedItemCount == targetItemCount){
                    doorOpen();
                 }
                 Destroy(gameObject);
           // }
        }
     }

    private void startMoveDown(){
        moveAmount = .25f;
        Invoke("startMoveUp", 1);
    }

    private void startMoveUp(){
        moveAmount = -.25f;
        Invoke("startMoveDown", 1);
    }

    private void doorOpen(){
        print("door opening");
        Destroy(Door);
    }

}

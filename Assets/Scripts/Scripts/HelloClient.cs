using UnityEngine;

public class HelloClient : MonoBehaviour
{
    private HelloRequester _helloRequester;


    private void Start()
    {
        _helloRequester = new HelloRequester();
       // _helloRequester.Start(); WIP

    }
     private void Update()
     {
         if (Input.GetKeyUp("x"))
         {
             _helloRequester.Start();
         }
         /*else if(Input.GetKeyUp("c"))
        {
            Debug.Log("Stopping program");
            _helloRequester.Stop();
        }*/

     }

    private void OnDestroy()
    {
        _helloRequester.Stop();

    }
}
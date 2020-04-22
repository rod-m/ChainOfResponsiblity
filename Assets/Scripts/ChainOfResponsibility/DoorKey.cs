using UnityEngine;
namespace ChainOfResponsibility
{
    public class DoorKey : ChainOfResponsibilityHandler
    {
        public string keyType = "BlueKey";
        public override object Handle(object request)
        {
            Debug.Log("Try this key " + keyType + " ? " + request.ToString());
            if (request.ToString() == keyType)
            {
               
                return true;
            }
            return base.Handle(request);
        }
    }
}
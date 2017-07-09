using System;
using UIKit;

namespace FetaProject.iOS
{
    public class PinImage
    {
        public string selectImage(string typeOfPin)
        {
            string type= "";
            int imageCounter=0;
            string[] arrayOfImage = {
                "Icons/event.png",
                "Icons/food.png",
                "Icons/help.png",
                "Icons/WC.png"
            };

            if(typeOfPin == "event")
            {
                imageCounter = 0;    
            }else if(typeOfPin == "food")
            {
                imageCounter = 1;
            }else if(typeOfPin=="help")
            {
                imageCounter = 2;
            }else if(typeOfPin=="WC")
            {
                imageCounter = 3;
            }
            type = arrayOfImage[imageCounter];
            return type;
        }
    }
}
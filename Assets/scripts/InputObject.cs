namespace Polyworks
{
    using System.Collections.Generic;

    [System.Serializable]
    public struct InputObject {
        public float horizontal;
        public float vertical;
        public float depth;
        
        public Dictionary<string, bool> buttons;

        public bool isCancelDown;
        public bool isSubmitDown;
        public bool isLeftDown;
        public bool isRightDown;
        public bool isUpDown;
        public bool isDownDown;

        public bool isZoomInDown;
        public bool isZoomOutDown;	
    }

}
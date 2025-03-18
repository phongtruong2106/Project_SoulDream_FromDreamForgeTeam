



    using UnityEngine;

    public class ZoomOnClick : Zoom
    {   
        [Header("Zoom OnClick")]
        public bool isClick;
        protected override void Start() {
            this.isClick = false;
        }

        protected void Update()
        {
            this.CheckClick();
            this.PressKeyExitZoom();
            this.ChangeOnClickStateBool();
        }

        protected virtual void OnMouseDown()
        {
            // if(!LockManager.Instance.isAfterOpenLock)
            // {
                this.isClick  = true;
        // }
            
        }
        

        protected virtual void CheckClick()
        {
            if(isClick)
            {
                this.ZoomTarget();
            }
        }
        protected virtual void PressKeyExitZoom()
        {
            if(Input.GetKeyDown(KeyCode.E))
            {
                this.DefaultZoomTarget();
                this.isClick = false;
            }
        }
        protected virtual void ChangeOnClickStateBool()
        {
            if(LockManager.Instance.isAfterOpenLock)
            {
                this.isClick  = false;
            }
        }
    }
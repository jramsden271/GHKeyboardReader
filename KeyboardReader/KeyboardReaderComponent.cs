using System;
using System.Collections.Generic;

using Grasshopper.Kernel;
using Rhino.Geometry;


using Gma.UserActivityMonitor;





namespace KeyboardReader
{
    public class KeyboardReaderComponent : GH_Component
    {
        /// <summary>
        /// Each implementation of GH_Component must provide a public 
        /// constructor without any arguments.
        /// Category represents the Tab in which the component will appear, 
        /// Subcategory the panel. If you use non-existing tab or panel names, 
        /// new tabs/panels will automatically be created.
        /// </summary>
        public KeyboardReaderComponent()
            : base("KeyboardReader", "KeyDown",
                "Sends 'true' if these keys are pressed",
                "JR", "Keys")
        {
        }

        bool isActivated = false; //does the user wish to use the component?
        bool isInstantiated = false; //has the hookmanager been set up?

        bool downW = false; //true if w is down
        bool downA = false;
        bool downS = false;
        bool downD = false;
        bool downQ = false;
        bool downE = false;
        
        
        

        /// <summary>
        /// Registers all the input parameters for this component.
        /// </summary>
        protected override void RegisterInputParams(GH_Component.GH_InputParamManager pManager)
        {
            pManager.AddBooleanParameter("activate", "activate", "Set to true to activate", GH_ParamAccess.item, false);
        }

        /// <summary>
        /// Registers all the output parameters for this component.
        /// </summary>
        protected override void RegisterOutputParams(GH_Component.GH_OutputParamManager pManager)
        {
            pManager.AddBooleanParameter("w", "w", "w", GH_ParamAccess.item);
            pManager.AddBooleanParameter("a", "a", "a", GH_ParamAccess.item);
            pManager.AddBooleanParameter("s", "s", "s", GH_ParamAccess.item);
            pManager.AddBooleanParameter("d", "d", "d", GH_ParamAccess.item);
            pManager.AddBooleanParameter("q", "q", "q", GH_ParamAccess.item);
            pManager.AddBooleanParameter("e", "e", "e", GH_ParamAccess.item);
        }

        /// <summary>
        /// This is the method that actually does the work.
        /// </summary>
        /// <param name="DA">The DA object can be used to retrieve data from input parameters and 
        /// to store data in output parameters.</param>
        protected override void SolveInstance(IGH_DataAccess DA)
        {
            
            DA.GetData(0, ref isActivated);


            if(isActivated)
            {
                if(!isInstantiated)
                {
                    isInstantiated = true;
                    HookManager.KeyDown += HookManager_KeyDown;
                    HookManager.KeyUp += HookManager_KeyUp;
                }
            }
            if(!isActivated)
            {
                if(isInstantiated)
                {
                    isInstantiated = false;
                    HookManager.KeyDown -= HookManager_KeyDown;
                    HookManager.KeyUp -= HookManager_KeyUp;
                }
            }
            



            DA.SetData(0, downW);
            DA.SetData(1, downA);
            DA.SetData(2, downS);
            DA.SetData(3, downD);
            DA.SetData(4, downQ);
            DA.SetData(5, downE);

        }

        void HookManager_KeyUp(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyCode.ToString() == "W") downW = false;
            if (e.KeyCode.ToString() == "A") downA = false;
            if (e.KeyCode.ToString() == "S") downS = false;
            if (e.KeyCode.ToString() == "D") downD = false;
            if (e.KeyCode.ToString() == "Q") downQ = false;
            if (e.KeyCode.ToString() == "E") downE = false;
        }

        void HookManager_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyCode.ToString() == "W") downW = true;
            if (e.KeyCode.ToString() == "A") downA = true;
            if (e.KeyCode.ToString() == "S") downS = true;
            if (e.KeyCode.ToString() == "D") downD = true;
            if (e.KeyCode.ToString() == "Q") downQ = true;
            if (e.KeyCode.ToString() == "E") downE = true;
        }


        /// <summary>
        /// Provides an Icon for every component that will be visible in the User Interface.
        /// Icons need to be 24x24 pixels.
        /// </summary>
        protected override System.Drawing.Bitmap Icon
        {
            get
            {
                // You can add image files to your project resources and access them like this:
                //return Resources.IconForThisComponent;
                return KeyboardReader.Properties.Resources.keyboard;
            }
        }

        /// <summary>
        /// Each component must have a unique Guid to identify it. 
        /// It is vital this Guid doesn't change otherwise old ghx files 
        /// that use the old ID will partially fail during loading.
        /// </summary>
        public override Guid ComponentGuid
        {
            get { return new Guid("{ef0266b2-1c50-4330-8184-60ae005c0162}"); }
        }
    }

    public class KeyboardReaderComponent2 : GH_Component
    {
        /// <summary>
        /// Each implementation of GH_Component must provide a public 
        /// constructor without any arguments.
        /// Category represents the Tab in which the component will appear, 
        /// Subcategory the panel. If you use non-existing tab or panel names, 
        /// new tabs/panels will automatically be created.
        /// </summary>
        public KeyboardReaderComponent2()
            : base("KeyboardReader", "KeyDown",
                "Sends 'true' when the selected key is pressed",
                "JR", "Keys")
        {
        }

        bool isActivated = false; //does the user wish to use the component?
        bool isInstantiated = false; //has the hookmanager been set up?

        bool down = false; //true if key is down
        string chartocheck = "";




        /// <summary>
        /// Registers all the input parameters for this component.
        /// </summary>
        protected override void RegisterInputParams(GH_Component.GH_InputParamManager pManager)
        {
            pManager.AddTextParameter("Character", "char", "Enter a single capital letter. The output will read true if this keyboard key is pressed.", GH_ParamAccess.item);
            pManager.AddBooleanParameter("activate", "activate", "Set to true to turn on this component.", GH_ParamAccess.item, false);
        }

        /// <summary>
        /// Registers all the output parameters for this component.
        /// </summary>
        protected override void RegisterOutputParams(GH_Component.GH_OutputParamManager pManager)
        {
            pManager.AddBooleanParameter("w", "w", "w", GH_ParamAccess.item);
        }

        /// <summary>
        /// This is the method that actually does the work.
        /// </summary>
        /// <param name="DA">The DA object can be used to retrieve data from input parameters and 
        /// to store data in output parameters.</param>
        /// 

        

        protected override void SolveInstance(IGH_DataAccess DA)
        {

            DA.GetData(0, ref chartocheck);
            DA.GetData(1, ref isActivated);


            if (isActivated)
            {
                if (!isInstantiated)
                {
                    isInstantiated = true;
                    HookManager.KeyDown += HookManager_KeyDown;
                    HookManager.KeyUp += HookManager_KeyUp;
                }
            }
            if (!isActivated)
            {
                if (isInstantiated)
                {
                    isInstantiated = false;
                    HookManager.KeyDown -= HookManager_KeyDown;
                    HookManager.KeyUp -= HookManager_KeyUp;
                    
                }
            }




            DA.SetData(0, down);


        }

        void HookManager_KeyUp(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyCode.ToString() == chartocheck) down = false;
        }

        void HookManager_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyCode.ToString() == chartocheck) down = true;
        }


        /// <summary>
        /// Provides an Icon for every component that will be visible in the User Interface.
        /// Icons need to be 24x24 pixels.
        /// </summary>
        protected override System.Drawing.Bitmap Icon
        {
            get
            {
                // You can add image files to your project resources and access them like this:
                //return Resources.IconForThisComponent;
                return KeyboardReader.Properties.Resources.keyboard;
            }
        }

        /// <summary>
        /// Each component must have a unique Guid to identify it. 
        /// It is vital this Guid doesn't change otherwise old ghx files 
        /// that use the old ID will partially fail during loading.
        /// </summary>
        public override Guid ComponentGuid
        {
            get { return new Guid("{e8a0b33f-e84a-4b09-a92e-292692fa0b94}"); }
        }
    }
}

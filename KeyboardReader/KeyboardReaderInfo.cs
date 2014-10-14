using System;
using System.Drawing;
using Grasshopper.Kernel;

namespace KeyboardReader
{
    public class KeyboardReaderInfo : GH_AssemblyInfo
    {
        public override string Name
        {
            get
            {
                return "KeyboardReader";
            }
        }
        public override Bitmap Icon
        {
            get
            {
                //Return a 24x24 pixel bitmap to represent this GHA library.
                return null;
            }
        }
        public override string Description
        {
            get
            {
                //Return a short string describing the purpose of this GHA library.
                return "";
            }
        }
        public override Guid Id
        {
            get
            {
                return new Guid("2cb9e2f8-9931-4adb-974b-7de10ab9226b");
            }
        }

        public override string AuthorName
        {
            get
            {
                //Return a string identifying you or your company.
                return "Buro Happold";
            }
        }
        public override string AuthorContact
        {
            get
            {
                //Return a string representing your preferred contact details.
                return "";
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp3
{
    public class Pope
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string ImagePath { get; set; }
        public string Description { get; set; }

        public Pope(int ID, string Name, string Description, string ImagePath="")
        {
            this.ID = ID;
            this.Name = Name;
            this.Description = Description;

            if(ImagePath == "" || ImagePath == null)
                this.ImagePath = "/Pages/null.png";
            else
                this.ImagePath = ImagePath;
        }
    }
}

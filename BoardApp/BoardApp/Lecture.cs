using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace BoardApp
{
    public class Lecture
    {
        private List<Bitmap> _lecturePictures { get; set; }
        private string _name { get; set; }

        public List<Bitmap> LecturePictures
        {
            get { return _lecturePictures; }
            set { value = _lecturePictures; }
        }
        public string Name
        {
            get { return _name; }
            set { value = _name; }
        }

    }
}

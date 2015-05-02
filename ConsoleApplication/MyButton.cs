using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace ConsoleApplication
{
    public class Eavr:EventArgs
    {
        public string clicker;
    }
    class MyButton
    {
        public event EventHandler<Eavr> onclick;
        public void click()
        {
            Eavr e = new Eavr();
            e.clicker = "sb";
            onclick(this, e);
        }
    }
}

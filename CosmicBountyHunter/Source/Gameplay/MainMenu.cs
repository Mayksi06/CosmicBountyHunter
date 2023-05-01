using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CosmicHunter
{
    public class MainMenu
    {
        public Basic2d bkg;
        public PassObject playClickDel, exitClickDel;
        //public List<Button2d> buttons = new List<Button2d>();

        public MainMenu(PassObject playClickDel, PassObject exitClickDel)
        {
            this.playClickDel = playClickDel;
            this.exitClickDel = exitClickDel;
        }

        public virtual void Update()
        {

        }

        public virtual void Draw()
        {

        }
    }
}
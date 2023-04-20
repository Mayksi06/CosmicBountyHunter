using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace CosmicHunter
{
    //keeps track of how much time has passed, needed for firing the projectiles
    public class MdTimer
    {
        public bool goodToGo;
        protected int mSec;
        protected TimeSpan timer = new TimeSpan();

        public MdTimer(int m)
        {
            goodToGo = false;
            mSec = m;
        }
        public MdTimer(int m, bool STARTLOADED)
        {
            goodToGo = STARTLOADED;
            mSec = m;
        }

        public int MSec
        {
            get { return mSec; }
            set { mSec = value; }
        }
        public int Timer
        {
            get { return (int)timer.TotalMilliseconds; }
        }

        public void UpdateTimer()
        {
            timer += Globals.gameTime.ElapsedGameTime;
        }

        public void UpdateTimer(float SPEED)
        {
            //speeding up or slowing down the time
            timer += TimeSpan.FromTicks((long)(Globals.gameTime.ElapsedGameTime.Ticks * SPEED));
        }

        public virtual void AddToTimer(int MSEC)
        {
            //add cooldowns
            timer += TimeSpan.FromMilliseconds((long)(MSEC));
        }

        public bool Test()
        {
            //set goodToGo to true
            if (timer.TotalMilliseconds >= mSec || goodToGo)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void Reset()
        {
            //set goodToGo back to false
            timer = timer.Subtract(new TimeSpan(0, 0, mSec / 60000, mSec / 1000, mSec % 1000));
            if (timer.TotalMilliseconds < 0)
            {
                timer = TimeSpan.Zero;
            }
            goodToGo = false;
        }

        public void Reset(int NEWTIMER)
        {
            //Reset with a given value
            timer = TimeSpan.Zero;
            MSec = NEWTIMER;
            goodToGo = false;
        }

        public void ResetToZero()
        {
            timer = TimeSpan.Zero;
            goodToGo = false;
        }

        public virtual XElement ReturnXML()
        {
            XElement xml = new XElement("Timer", new XElement("mSec", mSec), new XElement("timer", Timer));
            return xml;
        }

        public void SetTimer(TimeSpan TIME)
        {
            //set a timer with a timespan argument
            timer = TIME;
        }

        public virtual void SetTimer(int MSEC)
        {
            //set a timer with an int argument
            timer = TimeSpan.FromMilliseconds((long)(MSEC));
        }
    }
}
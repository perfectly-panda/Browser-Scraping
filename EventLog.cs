using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Browser
{
    public delegate void UpdateDelegate();

    public class EventLog
    {
        public BindingList<String> Log { get; private set; }

        protected int MaxLines { get; private set; }

        private UpdateDelegate Update { get; set; }

        public EventLog(int maxLines, UpdateDelegate update)
        {
            this.Log = new BindingList<string>();
            this.MaxLines = maxLines;

            this.Update = update;
        }


        public void AppendLog(string s)
        {
            try
            {
                Log.Add("["+DateTime.Now.ToString() + "]  " + s);

                if(Log.Count > MaxLines)
                {
                    TrimLog();
                }

                Update();
            }
            catch (Exception exc)
            {
                // exception handling
            }
        }

        private void TrimLog()
        {
            try
            {
                while (Log.Count > MaxLines)
                {
                    Log.RemoveAt(0);
                }
            }
            catch (Exception exc)
            {
                // exception handling
            }
        }
    }
}

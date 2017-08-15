using System;

namespace WindowsFormsApplication1
{
    internal class SetTextCallback
    {
        private Action<string> setText;

        public SetTextCallback(Action<string> setText)
        {
            this.setText = setText;
        }
    }
}
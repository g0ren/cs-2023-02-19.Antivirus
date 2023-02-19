namespace Antivirus
{
    class Program
    {
        public static void Main(string[] args)
        {
            string[] formNames = new string[] { 
                "Form1", 
                "DefenderForm0", 
                "DefenderForm1", 
                "DefenderForm2", 
                "DefenderForm3", 
                "DefenderForm4" };

            /*
             * Found classname by running:
             * 
             Console.WriteLine(WinAPI.GetWindowClassName(
                WinAPI.FindWindowByWindowName("DefenderForm0"))
                );
             * It's the same for all the forms
             */
            string classname = "WindowsForms10.Window.8.app.0.141b42a_r7_ad1";

            while (WinAPI.FindWindowByClassName(classname) > 0) { 
                foreach (string formName in formNames)
                {
                    string name = formName;
                    ThreadStart threadStart = new ThreadStart(() => {
                        while (WinAPI.FindWindowByWindowName(name) > 0)
                        {
                            int hWnd = WinAPI.FindWindowByWindowName(name);
                            WinAPI.SendQuitMessage(hWnd);
                            // The Console.WriteLine instruction is not only useful for debugging,
                            // but also acts like a little Sleep))
                            Console.WriteLine($"Killed window {name} #{hWnd}"); 
                        }
                    });
                    Thread thread = new Thread(threadStart);
                    thread.Start();
                }
            }
        }
    }
}
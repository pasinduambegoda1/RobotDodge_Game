using SplashKitSDK;

namespace Robot_Dodge
{
    class Program
    {
        static void Main()
        {
            Window gameWindow = new Window("Robot Dodge", 800, 600);
            RobotDodge robotdodge1=new RobotDodge(gameWindow);

            while (!gameWindow.CloseRequested && !robotdodge1.Quit){
                SplashKit.ProcessEvents();
                robotdodge1.HandleInput();
                robotdodge1.Update();  
                robotdodge1.Draw(); 
                
                
            } 
        }
    }
}

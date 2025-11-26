using System.ComponentModel;
using System.Data;
using SplashKitSDK;

public class RobotDodge{
    private Player _Player;
    private Window _GameWindow;

    private List<Robot> _Robots;

    public bool Quit =>_Player.Quit;
    
     public RobotDodge(Window gameWindow){
        _GameWindow = gameWindow;
        _Player = new Player(gameWindow);
        _Robots = new List<Robot>();
        _Robots.Add(RandomRobot());
       
    }
    public void HandleInput(){
        
        _Player.HandleInput();
        _Player.StayOnWindow(_GameWindow);
    }
   

    public void Draw(){
        
        _GameWindow.Clear(Color.White);
        foreach(Robot robot in _Robots){
            robot.Draw();
        }
        _Player.Draw();
        _GameWindow.Refresh(60);
}

    public void Update(){
         List<Robot> robotsToAdd = new List<Robot>();
         List<Robot> robotsToRemove = new List<Robot>();

        foreach(Robot robot in _Robots){
            //CheckCollisions(robot);
            if (_Player.CollidedWith(robot))
            {   robotsToRemove.Add(robot); 
                robotsToAdd.Add(RandomRobot()); //Create a new robot at a random location
            }
            
            else if(robot.IsOffScreen(_GameWindow)){
                robotsToRemove.Add(robot);
                robotsToAdd.Add(RandomRobot());
            }
            else{
                robot.Update();
            }
             
        }
        foreach (Robot robot in robotsToRemove)
        {
            _Robots.Remove(robot);
        }

        foreach (Robot robot in robotsToAdd)
        {
            _Robots.Add(robot);
        }
    }

    // public void CheckCollisions(Robot robot)
    // {if (_Player.CollidedWith(robot))
    // {
    //     robotsToAdd.Add(RandomRobot()); //Create a new robot at a random location
    // }
    
    // }
    public Robot RandomRobot(){
        if (SplashKit.Rnd() < 0.5)
        {
            return new Boxy(_GameWindow, _Player);
        }
        else
        {
            return new Roundy(_GameWindow, _Player);
        }
    }

}

using SplashKitSDK;
using System;
using System.Drawing;
using System.Dynamic;

public abstract class Robot{
     
    private Player _player;
    private Window gameWindow;

    private int Width=50;
    private int Height=50;

    private Vector2D Velocity {get; set;}

    public Circle CollisionCircle => SplashKit.CircleAt(X + Width / 2, Y + Height / 2, 20);
    

    public int width{
        get { return Width; }
    }

    public int height{
        get { return Height; }
    }


    public double X { get; private set; }
    public double Y { get; private set; }
    public SplashKitSDK.Color MainColor { get; private set; }

    public Robot(Window _gameWindow, Player player){
        
        // X =SplashKit.Rnd(gameWindow.Width - Width);
        // Y = SplashKit.Rnd(gameWindow.Height - Height);
        MainColor=SplashKitSDK.Color.RandomRGB(200);
        //Draw(); reason why this not running
        _player=player;
        gameWindow=_gameWindow;
        


        if (SplashKit.Rnd()<0.5){
            X=SplashKit.Rnd(gameWindow.Width-Width);
            if (SplashKit.Rnd()<0.5){
                Y=-Height;
            }
            else{
                Y=gameWindow.Height;
            }
            
        }
        else{
             Y=SplashKit.Rnd(gameWindow.Height-Height);
             if (SplashKit.Rnd()<0.5){
                X=-Width;
            }
            else{
                X=gameWindow.Width;
            }
        }


        
        const int SPEED=4;

        Point2D fromPt=new Point2D(){
            X=X, Y=Y
        };

        Point2D toPt=new Point2D(){
            X=_player.X,
            Y=_player.Y
        };

        Vector2D dir;
        dir=SplashKit.UnitVector(SplashKit.VectorPointToPoint(fromPt, toPt));

        Velocity=SplashKit.VectorMultiply(dir,SPEED);
    }

    public abstract void Draw();
    

    public void Update(){
            X += Velocity.X;
            Y += Velocity.Y;
    }

    public bool IsOffScreen(Window gameWindow){
        //X<-Width ||X>gameWindow.Width||Y<-Height || Y>gameWindow.Height
        if(X<-Width ||X>gameWindow.Width||Y<-Height || Y>gameWindow.Height){
            return true;
        }
        return false;
    }

}

public class Boxy:Robot{
    public Boxy(Window _gameWindow, Player player) : base(_gameWindow, player)
    {
        //MainColor = SplashKitSDK.Color.RandomRGB(200);
    }

    public override void Draw(){
    SplashKitSDK.Color gray= SplashKitSDK.Color.RGBAColor(128, 128, 128,255);
    double leftX = X + 12;
    double rightX = X + 27;
    double eyeY = Y + 10;
    double mouthY = Y + 30;
    SplashKit.FillRectangle(gray,X,Y, 50, 50);
    SplashKit.FillRectangle(MainColor, leftX, eyeY, 10, 10);
    SplashKit.FillRectangle(MainColor, rightX, eyeY, 10, 10);
    SplashKit.FillRectangle(MainColor, leftX, mouthY, 25, 10);
    SplashKit.FillRectangle(MainColor, leftX+2, mouthY+2, 21, 6);
    }

}

public class Roundy:Robot{
    public Roundy(Window _gameWindow, Player player) : base(_gameWindow, player)
    {
        //MainColor = SplashKitSDK.Color.RandomRGB(200);
    }

    public override void Draw(){
        double leftX, midX, rightX; 
        double midY, eyeY, mouthY;
        leftX = X + 17;
        midX =X+25;
        rightX=X+ 33;
        midY =Y+25;
        eyeY =Y+20;
        mouthY=Y+ 35;
        SplashKit.FillCircle(SplashKitSDK.Color.White, midX, midY, 25); 
        SplashKit.DrawCircle(SplashKitSDK.Color.Gray, midX, midY, 25); 
        SplashKit.FillCircle(MainColor, leftX, eyeY, 5); 
        SplashKit.FillCircle(MainColor, rightX, eyeY, 5); 
        SplashKit.FillEllipse(SplashKitSDK.Color.Gray, X, eyeY, 50, 30);
        SplashKit.DrawLine(SplashKitSDK.Color.Black, X, mouthY, X + 50, Y + 35);
    }


}

using SplashKitSDK;
using System.Collections.Generic;

public class Player
{
    private Bitmap _playerBitmap;
    private List<Bullet> _bullets;
    private int _lives;
    private int _score;

    private double window_width;

    public Player(Window gameWindow)
    {
        _playerBitmap = new Bitmap("Player", "images/Player.png");
        X = (gameWindow.Width - Width) / 2;
        Y = (gameWindow.Height - Height) / 2;
        window_width=gameWindow.Width;
        Quit = false;
        _lives = 5;
        _score = 0;
        _bullets = new List<Bullet>();
    }

    const int speed = 5;
    const int GAP = 10;
    

    public int X { get; private set; }
    public int Y { get; private set; }

    public bool Quit { get; private set; }

    public int Width => _playerBitmap.Width;
    public int Height => _playerBitmap.Height;

    public int Lives => _lives;
    public int Score => _score;

    public void lostlive()
    {
        _lives--;
    }

    public void IncreaseScore()
    {
        _score++;
    }

    public void Draw()
    {
        _playerBitmap.Draw(X, Y);
        DrawHearts();
        DrawScore();
        foreach (var bullet in _bullets)
        {
            bullet.Draw();
        }
    }

    public void HandleInput()
    {
        if (SplashKit.KeyDown(KeyCode.UpKey))
        {
            Y -= speed;
        }
        if (SplashKit.KeyDown(KeyCode.DownKey))
        {
            Y += speed;
        }
        if (SplashKit.KeyDown(KeyCode.RightKey))
        {
            X += speed;
        }
        if (SplashKit.KeyDown(KeyCode.LeftKey))
        {
            X -= speed;
        }
        if (SplashKit.KeyTyped(KeyCode.EscapeKey))
        {
            Quit = true;
        }

        if (SplashKit.MouseClicked(MouseButton.LeftButton))
        {
            Shoot(SplashKit.MousePosition());
        }
    }

    public void StayOnWindow(Window gameWindow)
    {
        if (X <= GAP) { X = GAP; }
        if (X >= gameWindow.Width - GAP - Width) { X = gameWindow.Width - GAP - Width; }
        if (Y <= GAP) { Y = GAP; }
        if (Y >= gameWindow.Height - GAP - Height) { Y = gameWindow.Height - GAP - Height; }
    }

    public void DrawHearts()
    {
        const int HEART_SIZE = 20;
        const int span=HEART_SIZE / 2;
        const int GAP = 10;
        for (int i = 0; i < _lives; i++)
        {
            double x = window_width - (HEART_SIZE + GAP) * (i + 1);
            double y = GAP;
            //SplashKit.FillCircle(Color.Red, x, y, HEART_SIZE / 2);
            SplashKit.FillTriangle(Color.Red, x-span,y,x+span,y, x,y+span);
            SplashKit.FillTriangle(Color.Red, x-span,y,x+span,y, x,y-span);
        }
    }

    public void DrawScore()
    {
        double x = window_width - 100;
        double y = 40;
        SplashKit.DrawText($"Score: {_score}", Color.Black, x, y);
    }
    public bool CollidedWith(Robot other)
    {
        return _playerBitmap.CircleCollision(X, Y, other.CollisionCircle);
    }

    public void Shoot(Point2D target)
    {
        Bullet newBullet = new Bullet(X + Width / 2, Y + Height / 2, target.X, target.Y);
        _bullets.Add(newBullet);
    }

    public List<Bullet> Bullets => _bullets;

    public void UpdateBullets(Window gameWindow)
    {
        _bullets.RemoveAll(bullet => bullet.IsOffScreen(gameWindow));
        foreach (var bullet in _bullets)
        {
            bullet.Update();
        }
    }
}

using SplashKitSDK;

public class Bullet
{
    private double _x, _y;
    private Vector2D _velocity;
    private const int SPEED = 10;
    private const int RADIUS = 5;

    public Bullet(double startX, double startY, double targetX, double targetY)
    {
        _x = startX;
        _y = startY;

        Vector2D direction = SplashKit.UnitVector(SplashKit.VectorPointToPoint(new Point2D { X = startX, Y = startY }, new Point2D { X = targetX, Y = targetY }));
        _velocity = SplashKit.VectorMultiply(direction, SPEED);
    }

    public void Update()
    {
        _x += _velocity.X;
        _y += _velocity.Y;
    }

    public void Draw()
    {
        SplashKit.FillCircle(Color.Red, _x, _y, RADIUS);
    }

    public bool IsOffScreen(Window window)
    {
        return _x < 0 || _x > window.Width || _y < 0 || _y > window.Height;
    }

    public Circle CollisionCircle => SplashKit.CircleAt(_x, _y, RADIUS);

    public bool CollidedWith(Robot robot)
    {
        return SplashKit.CirclesIntersect(CollisionCircle, robot.CollisionCircle);
    }
}

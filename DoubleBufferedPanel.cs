using System.Windows.Forms;

public class DoubleBufferedPanel : Panel
{
    public DoubleBufferedPanel()
    {
        this.DoubleBuffered = true;
        this.SetStyle(ControlStyles.OptimizedDoubleBuffer |
                      ControlStyles.AllPaintingInWmPaint |
                      ControlStyles.UserPaint, true);
    }
}
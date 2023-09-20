namespace ChessBoard
{
    public partial class Form1 : Form
    {


        public Form1()
        {
            InitializeComponent();
            MinimizeBox = false;
            FormBorderStyle = FormBorderStyle.FixedSingle;
            ChessWidth = (ClientSize.Width / 8);
            ChessHeight = (ClientSize.Height / 8);
        }

        public float ChessWidth { get; set; }
        public float ChessHeight { get; set; }
        private void Form1_Paint(object sender, PaintEventArgs e)
        {

            DrawBoard(e);


        }

        private void DrawBoard(PaintEventArgs e)
        {
            Image[] BlackFigures = new Image[9];
            Image[] WhiteFigures = new Image[9];

            BlackFigures[0] = Image.FromFile("Icons/BlackRook.png");
            BlackFigures[1] = Image.FromFile("Icons/BlackHorse.png");
            BlackFigures[2] = Image.FromFile("Icons/BlackBishop.png");
            BlackFigures[3] = Image.FromFile("Icons/BlackQueen.png");
            BlackFigures[4] = Image.FromFile("Icons/BlackKing.png");
            BlackFigures[5] = Image.FromFile("Icons/BlackBishop.png");
            BlackFigures[6] = Image.FromFile("Icons/BlackHorse.png");
            BlackFigures[7] = Image.FromFile("Icons/BlackRook.png");
            BlackFigures[8] = Image.FromFile("Icons/BlackPawn.png");


            WhiteFigures[0] = Image.FromFile("Icons/WhiteRook.png");
            WhiteFigures[1] = Image.FromFile("Icons/WhiteHorse.png");
            WhiteFigures[2] = Image.FromFile("Icons/WhiteBishop.png");
            WhiteFigures[3] = Image.FromFile("Icons/WhiteQueen.png");
            WhiteFigures[4] = Image.FromFile("Icons/WhiteKing.png");
            WhiteFigures[5] = Image.FromFile("Icons/WhiteBishop.png");
            WhiteFigures[6] = Image.FromFile("Icons/WhiteHorse.png");
            WhiteFigures[7] = Image.FromFile("Icons/WhiteRook.png");
            WhiteFigures[8] = Image.FromFile("Icons/WhitePawn.png");

            Pen Sqare = new Pen(Color.Black);
            Brush BlackBrush = new SolidBrush(Color.Gray);
            Brush WhiteBrush = new SolidBrush(Color.White);
            Font font = new Font("Arial", 16);
            for (int i = 1, j = 1, w = 0, b = 0, x = 5, y = 5, width = 0; i <= 64; i++)
            {

                e.Graphics.DrawRectangle(Sqare, x, y, ChessWidth, ChessHeight);
                if (i % 2 == 0 && j % 2 == 0)
                {
                    e.Graphics.FillRectangle(WhiteBrush, x, y, ChessWidth, ChessHeight);

                }
                else if (i % 2 != 0 && j % 2 == 0)
                {
                    e.Graphics.FillRectangle(BlackBrush, x, y, ChessWidth, ChessHeight);
                }
                else if (i % 2 == 0 && j % 2 != 0)
                {

                    e.Graphics.FillRectangle(BlackBrush, x, y, ChessWidth, ChessHeight);

                }
                else if (i % 2 != 0 && j % 2 != 0)
                {
                    e.Graphics.FillRectangle(WhiteBrush, x, y, ChessWidth, ChessHeight);
                }
                if (j < 2)
                {
                    e.Graphics.DrawImage(BlackFigures[b], (float)(x + ChessWidth / 5), (float)(y + ChessHeight / 5));
                    b++;
                }
                else if (j == 2)
                {
                    e.Graphics.DrawImage(BlackFigures[BlackFigures.Length - 1], (float)(x + ChessWidth / 5), (float)(y + ChessHeight / 5));
                }
                else if (j == 7)
                {
                    e.Graphics.DrawImage(WhiteFigures[BlackFigures.Length - 1], (float)(x + ChessWidth / 5), (float)(y + ChessHeight / 5));
                }
                else if (j == 8)
                {

                    e.Graphics.DrawImage(WhiteFigures[w], (float)(x + ChessWidth / 5), (float)(y + ChessHeight / 5));
                    w++;
                }


                x += Convert.ToInt32(ChessWidth);
                if (i % 8 == 0)
                {
                    y += Convert.ToInt32(ChessHeight);
                    x = 5;
                    j++;
                }


            }

        }
    }
}
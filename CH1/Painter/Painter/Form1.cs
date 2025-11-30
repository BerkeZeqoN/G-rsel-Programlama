namespace Painter
{
    public partial class Form1 : Form
    {
        // Gerekli deðiþkenler
        private bool isDrawing = false; // Fare tuþuna basýlý mý?
        private bool isErasing = false; // Silgi modunda mýyýz?
        private Point lastPoint;       // Bir önceki çizim noktasý
        private Color drawColor = Color.Black; // Kalemin rengi
        private int penWidth = 5;      // Kalemin varsayýlan kalýnlýðý

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            isDrawing = true;         // Çizime baþla
            lastPoint = e.Location;   // Mevcut fare pozisyonunu kaydet
        }
        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (isDrawing)
            {
                // Silgi modundaysak kalýnlýðý artýr, deðilsek normal kalýnlýðý kullan
                int currentWidth = isErasing ? 15 : penWidth;

                // Çizimi gerçekleþtirecek Graphics nesnesini oluþtur
                using (Graphics g = panel1.CreateGraphics())
                {
                    // Belirlenen renk ve kalýnlýkta kalemi oluþtur
                    using (Pen pen = new Pen(drawColor, currentWidth))
                    {
                        // lastPoint ve mevcut konum arasýna çizgi çek
                        g.DrawLine(pen, lastPoint, e.Location);
                    }
                }
                // Mevcut konumu bir sonraki çizgi için baþlangýç noktasý yap
                lastPoint = e.Location;
            }
        }
        private void panel1_MouseUp(object sender, MouseEventArgs e)
        {
            isDrawing = false; // Çizimi durdur
        }
        private void btnRenkSec_Click(object sender, EventArgs e)
        {
            isErasing = false; // Silgi modundan çýk

            using (ColorDialog colorDlg = new ColorDialog())
            {
                if (colorDlg.ShowDialog() == DialogResult.OK)
                {
                    drawColor = colorDlg.Color; // Seçilen rengi ata
                    ((Button)sender).BackColor = colorDlg.Color; // Buton rengini güncelle
                }
            }
        }
        private void btnTemizle_Click(object sender, EventArgs e)
        {
            // Panel'in yeniden çizilmesini zorlayarak tuvali temizler.
            panel1.Invalidate();
        }
        private void btnSilgi_Click(object sender, EventArgs e)
        {
            isErasing = true; // Silgi moduna geç

            // Çizim rengini panelin arka plan rengine ayarla (silgi iþlevi için)
            drawColor = panel1.BackColor;
        }
    }
}

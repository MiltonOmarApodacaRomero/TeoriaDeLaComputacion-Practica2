namespace TeoriaDeLaComputacion_Practica2;

public partial class Form1 : Form
{
    public Form1()
    {
        InitializeComponent();
    }

    private void Form1_Load(object sender, EventArgs e)
    {

    }

    private void btnValidar_Click(object sender, EventArgs e)
    {
        string input = txtInput.Text;

        Lexor.Procesar(input);
    }

    public void txtSalida_TextChanged(object sender, EventArgs e)
    {

    }
}
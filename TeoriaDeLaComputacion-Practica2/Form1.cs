using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace TeoriaDeLaComputacion_Practica2;


public partial class Form1 : Form
{
    [DllImport("user32.dll")]
    private static extern bool SetWindowDisplayAffinity(IntPtr hWnd, uint dwAffinity);
    
    public Form1()
    {
        InitializeComponent();
    }

    private void Form1_Load(object sender, EventArgs e)
    {
        SetWindowDisplayAffinity(this.Handle, 0x00000000);
        Lexor.Setup(this);
    }

    private void btnValidar_Click(object sender, EventArgs e)
    {
        string input = txtInput.Text;

        Lexor.Procesar(input);
    }

    public void txtSalida_TextChanged(object sender, EventArgs e)
    {

    }

    private void btnLimpiar_Click(object sender, EventArgs e) {
        txtSalida.Text = "";
    }
}
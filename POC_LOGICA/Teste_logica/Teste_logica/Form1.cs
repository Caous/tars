using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Teste_logica
{
    public partial class frmLogica : Form
    {
        public frmLogica()
        {
            InitializeComponent();
        }

        private void btnLogica_Click(object sender, EventArgs e)
        {
            string letters = txtValues.Text;

            string[] arrayLetters = letters.Split();

            char result = searchLetterRepat(letters);

            txtResult.Text = result.ToString() == " "? "Nulo": result.ToString();
        }

        private char searchLetterRepat(string letters)
        {
            char letter = ' ';
            string _lettersAux = "";
            
            foreach (char valor in letters)
            {                
                if (_lettersAux.IndexOf(valor) == -1)
                {                    
                    _lettersAux += valor;
                }
                else
                {
                    letter = valor;
                    break;
                }
            }
            return letter;
        }

     

    }

}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Gcodes;
using System.IO;
using Gcodes.Tokens;
using Gcodes.Ast;


namespace PlotterTest
{
    
    public partial class Form1 : Form
    {
        string file;
        public Form1()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            int size = -1;
            DialogResult result = openFileDialog1.ShowDialog(); // Show the dialog.
            if (result == DialogResult.OK) // Test result.
            {
                file = openFileDialog1.FileName;
                try
                {
                    
                    string text = File.ReadAllText(file);
                    size = text.Length;
                    textBox1.Text = file;
                   

                }
                catch (IOException)
                {
                }
            }
            Console.WriteLine(size); // <-- Shows file size in debugging mode.
            Console.WriteLine(result); // <-- For debugging use.
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            string src = File.ReadAllText(file);

            var lexer = new Lexer(src);
            List<Token> tokens = lexer.Tokenize().ToList();

            var parser = new Parser(tokens);
            List<Code> gcodes = parser.Parse().ToList();
            MessageBox.Show("File Loaded");
            foreach(var code in gcodes)
            {
                
                string test = code.ToString();
                if(!test.Equals("Gcodes.Ast.Mcode"))
                {
                    Gcode tempCode = (Gcode)code;
                    List<Argument> args = tempCode.args;
                    string output = tempCode.ToString().Substring(0, 2) + " ";
                    foreach (var arg in args)
                    {
                        output = output + arg.Kind.ToString() + " " + arg.Value.ToString() + " ";
                    }
                    listBox1.Items.Add(output);

                }



            }
            

        }
    }
}

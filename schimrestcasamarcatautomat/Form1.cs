using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace schimrestcasamarcatautomat
{
    public partial class Form1 : Form
    {

        public class valuta
        {
            public string tara;
            public string denumriemoneda;
            public string denumiresubunitati;
            public valuta(string t, string dm, string dsu)
            {
                tara = t;
                denumriemoneda= dm;
                denumiresubunitati = dsu;
            }

        }
        public class monedesibancnote
        {
            public float valoare;
            public valuta denumirevaluta;

            public monedesibancnote(float v, valuta dv)
            {
                valoare = v;
                denumirevaluta = dv;
            }
        }

        public List<monedesibancnote> banii = new List<monedesibancnote>();
        public valuta valutaaleasa = new valuta("Romania", "Leu", "Ban");

        public void adaugavalorilevaluteialese()
        {
            banii.Add(new monedesibancnote(5000.0f, valutaaleasa));
            banii.Add(new monedesibancnote(2000.0f, valutaaleasa));
            banii.Add(new monedesibancnote(1000.0f, valutaaleasa));
            banii.Add(new monedesibancnote(500.0f, valutaaleasa));
            banii.Add(new monedesibancnote(200.0f, valutaaleasa));
            banii.Add(new monedesibancnote(100.0f, valutaaleasa));
            banii.Add(new monedesibancnote(50.0f, valutaaleasa));
            banii.Add(new monedesibancnote(20.0f, valutaaleasa));
            banii.Add(new monedesibancnote(10.0f, valutaaleasa));
            banii.Add(new monedesibancnote(5.0f, valutaaleasa));
            banii.Add(new monedesibancnote(1.0f, valutaaleasa));
            banii.Add(new monedesibancnote(0.50f, valutaaleasa));
            banii.Add(new monedesibancnote(0.10f, valutaaleasa));
            banii.Add(new monedesibancnote(0.05f, valutaaleasa));
            banii.Add(new monedesibancnote(0.01f, valutaaleasa));
          

        }


        public monedesibancnote gasesteceamaimaremonedaXmaimicsauegalcuvaloareramasaY(float y)
        { 
            //de implementat
            //cauta cea mai mare valoare din lista de bani 
            //care sa fie mai mica decat valoarea de de restituit la casa de marcat
            
            for (int i = 0; i < banii.Count  ; i++)
            {
                if (banii[i].valoare <= y && y > 0.001)
                {
                    return banii[i];
                }
            }

            return null;
        }

        

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            adaugavalorilevaluteialese();
            float valoaredeplata = 123.45f;
            float valoareaplatitainbani = 150.0f;
            //verifica daca clientul a platiti suma minima de plata
            float valoareaderestdeplata = valoareaplatitainbani - valoaredeplata;
            float p = valoareaderestdeplata;

            textBox1.Text += " :" + valoaredeplata.ToString() + "\r\n";
            textBox1.Text += " :" + valoareaplatitainbani.ToString() + "\r\n";
            textBox1.Text += " :" + p.ToString() + "\r\n";
            textBox1.Text += " _________________________________________________";
            textBox1.Text += " \r\n";

            while(p>0.001)
            {
                try
                {
                    textBox1.Text += p.ToString() + " :";
                    textBox1.Text += gasesteceamaimaremonedaXmaimicsauegalcuvaloareramasaY(p).valoare.ToString() + " :";
                    p = p - gasesteceamaimaremonedaXmaimicsauegalcuvaloareramasaY(p).valoare;
                    textBox1.Text += p.ToString() + " :" + gasesteceamaimaremonedaXmaimicsauegalcuvaloareramasaY(p).valoare.ToString();
                }
                catch { }
                textBox1.Text += " :" + p.ToString() + "\r\n";
            };
        }
    }
}

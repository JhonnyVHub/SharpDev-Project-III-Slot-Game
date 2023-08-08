/*
 * Created by SharpDevelop.
 * User: Alunos
 * Date: 26/04/2023
 * Time: 21:12
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Media;
using System.Windows.Forms;

namespace cacaniquel
{
	public partial class MainForm : Form
	{
		public MainForm()
		{

			InitializeComponent();
			
		}
	
		Random rnd = new Random();
		SoundPlayer sound = new SoundPlayer("alavanca.wav"); // Cria uma variavel para armazenar e possibilar a manipulação de um arquivo sonoro
		int cont = 0; int n1, n2, n3; int money = 1000; // cont serve para armazenar o tempo do timer, n1 e semelhantes são os dados, money é money!
		
		
		void Button1Click(object sender, EventArgs e)
		{
			cont = 0; // Esse comando zera o contador sempre que o botão é pressionado
			button1.Visible = false;
			timer1.Enabled = true; // Ativa o timer
			sound.Play(); // Começa a tocar o som, anteriormente declarado no public
			pictureBox4.Load("lever5.gif"); // Sempre carrega o Gif quando pressionado
			money = money - 10; label1.Text = "R$ "+ money.ToString() + ",00";
		}
		void Timer1Tick(object sender, EventArgs e)
		{
			
			cont++; // vai add 1 ao valor da variavel sempre que o timer atingir 100ml
			
			if(cont > 6) { // Esse if vai girar os dados
				n1 = rnd.Next(1,7);
				pictureBox1.Load("dado" + n1 + ".png");
				n2 = rnd.Next(1,7);
				pictureBox2.Load("dado" + n2 + ".png");
				n3 = rnd.Next(1,7);
				pictureBox3.Load("dado" + n3 + ".png");
			}
			
			if(cont >= 30) { //Todos os outros ifs estão dentro destes! observe e pense sobre
				
				timer1.Enabled = false;
				button1.Visible = true;
			
				if(n1 == n2 && n1 == n3) {
					money += n1 * 50;
					MessageBox.Show("Parabéns! Você cagou demais!!!\nRecebeu R$ " + n1 * 50 + ",00. Que sorte!");
				}
				
				if(money == 0) {
					MessageBox.Show("Putz... Não acredito man! Tu conseguiu ZERAR O GAME!!!\nPeço que reinicie pra continuar... XD");
				}
				
				if(money == 3000) {
					MessageBox.Show("Tá... Isso que é sorte! PARABÉNS! VOCÊ ALCANÇOU O LIMITE DE MONEY...\nEstá proibido de jogar, favor reinicie.");
					button1.Visible = false;
				}
			}
		}	
	}
}

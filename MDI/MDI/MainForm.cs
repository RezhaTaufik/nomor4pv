/*
 * Created by SharpDevelop.
 * User: USER
 * Date: 6/6/2022
 * Time: 9:17 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;
using System.IO;
using System.Text;
using MySql.Data;
using MySql.Data.MySqlClient;
using System.Data.OleDb;
namespace MDI
{
	/// <summary>
	/// Description of MainForm.
	/// </summary>
	public partial class MainForm : Form
	{
		
		public MainForm()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}
		
		
		
		
		
			void Timer1Tick(object sender, EventArgs e)
{
if (progressBar1.Value == 100) {
 timer1.Enabled = false;
 Form1 formHome = new Form1();  
 formHome.Show();
 Hide();
 }else{
 progressBar1.Value +=10; //lama loading bar  }
} 
	}
	}
}

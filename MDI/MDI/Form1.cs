/*
 * Created by SharpDevelop.
 * User: USER
 * Date: 6/6/2022
 * Time: 9:26 PM
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
	/// Description of Form1.
	/// </summary>
	public partial class Form1 : Form
	{	private int count=0;
		MySqlConnection co = new MySqlConnection("Server = localhost; Database = programpv; Uid = root");
		//MySqlCommand mycommand = new MySqlCommand();
		MySqlDataAdapter myadapter = new MySqlDataAdapter();
		public Form1()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			//co.Open();
			ReadData();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}
		
		void ExitToolStripMenuItemClick(object sender, EventArgs e)
		{
			this.Close();
		}
		
		void NewToolStripMenuItemClick(object sender, EventArgs e)
		{
			Form1 frmchild = new Form1();
			frmchild.MdiParent = this;
			frmchild.Show();
			frmchild.Text += "ChildForm #" + count.ToString();
			count++;			
		}
		
		
		
		
		public void ReadData(){
			try{
				MySqlCommand mycommand = new MySqlCommand();
				mycommand.Connection = co;
				myadapter.SelectCommand = mycommand;
				mycommand.CommandText = "select * karyawan";
				DataSet ds = new DataSet();

				if (myadapter.Fill(ds,"dftpesan") > 0){
					dataGridView1.DataSource = ds;
					dataGridView1.DataMember = "dftpesan";
				}
			}
			catch (Exception ex){
				MessageBox.Show(ex.ToString());
			}
		}
		
		public void InsertData(){
			try{
				
				MySqlCommand mycommand = new MySqlCommand();
				co.Open();
				mycommand.Connection=co;
				
				mycommand.CommandText="insert into karyawan values('"+id.Text+"','"+nd.Text+"','"+nb.Text+"','"+alamat.Text+"','"+telp.Text+"','"+posisi.Text+"')";
				myadapter.SelectCommand= mycommand;
				if (mycommand.ExecuteNonQuery()==1){
					MessageBox.Show("Data berhasil dimasukan","Informasi",MessageBoxButtons.OK,MessageBoxIcon.Information);
					ReadData();
				}
				
			}
			catch(MySqlException ex){
				MessageBox.Show(ex.ToString());
			}
		}
		public void UpdateData(){
			try{
				MySqlCommand mycommand = new MySqlCommand();
				co.Open();
				mycommand.Connection=co;
				
				mycommand.CommandText="update karyawan values('"+id.Text+"','"+nd.Text+"','"+nb.Text+"','"+alamat.Text+"','"+telp.Text+"','"+posisi.Text+"')";
				myadapter.SelectCommand= mycommand;
				if (mycommand.ExecuteNonQuery()==1){
					MessageBox.Show("Data berhasil diupdate","Informasi",MessageBoxButtons.OK,MessageBoxIcon.Information);
					ReadData();
				}
				co.Close();
			}
			catch(MySqlException ex){
				MessageBox.Show(ex.ToString());
			}
		}
		public void DeleteData(){
			try{
				
				MySqlCommand mycommand = new MySqlCommand();
				co.Open();
				mycommand.Connection=co;
				
				mycommand.CommandText="delete from karyawan where id='"+id.Text+"'";
				myadapter.SelectCommand = mycommand;
				if (mycommand.ExecuteNonQuery()==1){
					MessageBox.Show("Data berhasil dihapus","Informasi",MessageBoxButtons.OK,MessageBoxIcon.Information);
					ReadData();
				}
				co.Close();
			}
			catch(MySqlException ex){
				MessageBox.Show(ex.ToString());
			}
		}
		public void ResetData(){
			id.Text="";
			nd.Text="";
			nb.Text="";
			alamat.Text="";
			telp.Text="";
			posisi.Text="";
			
		}
		
		public void finddata(){
			try{
				MySqlCommand mycommand = new MySqlCommand();
				co.Open();
				mycommand.Connection = co;
				myadapter.SelectCommand = mycommand;
				mycommand.CommandText = "select * from karyawan where id like '%"+cari.Text+"%' or nd like '%"+cari.Text+"%'";
				DataSet ds = new DataSet();
				if (myadapter.Fill(ds,"dftpesan") > 0){
					dataGridView1.DataSource = ds;
					dataGridView1.DataMember = "dftpesan";
				}
				co.Close();
			}
			catch (MySqlException ex){
				MessageBox.Show(ex.ToString());
			}
		}
		void Button1Click(object sender, EventArgs e)
		{
			InsertData();
		}
		
		void Button2Click(object sender, EventArgs e)
		{
			UpdateData();
		}
		
		void Button3Click(object sender, EventArgs e)
		{
			DeleteData();
		}
		
		void Button4Click(object sender, EventArgs e)
		{
			ResetData();
		}
		
		void DataGridView1CellContentClick(object sender, DataGridViewCellEventArgs e)
		{
			id.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
			nd.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
			nb.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
			alamat.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();	
			telp.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();	
			posisi.Text = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();				
		}
		
		void Form1Load(object sender, EventArgs e)
		{
				posisi.Items.Add("Web Developer");
				posisi.Items.Add("Cyber Security");
				posisi.Items.Add("Data Scientist");
				posisi.Items.Add("UI UX Designer");
		}
		
		void CariTextChanged(object sender, EventArgs e)
		{
			finddata();
		}
	}
}

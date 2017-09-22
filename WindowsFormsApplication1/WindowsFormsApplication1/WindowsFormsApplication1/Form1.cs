using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Net.Mail;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        public int RowIndex { get; private set; }

        public Form1()
        {
            InitializeComponent();

            string[] cities = { "Almaty", "Astana"};
            listBox1.Items.AddRange(cities);
            listBox1.SetSelected(0, true);
            displayDate.Visible = false;
            displayGender.Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            

            //displayCity.Text = listBox1.SelectedItem.ToString();

            if (radioMale.Checked)
            {
                displayGender.Text = radioMale.Text;
            }

            if (radioFemale.Checked)
            {
                displayGender.Text = radioFemale.Text;
            }

            if (radioNone.Checked)
            {
                displayGender.Text = radioNone.Text;
            }

            displayDate.Text = calendar.Value.ToString("dd/MM/yyyy");

            if (!string.IsNullOrWhiteSpace(mailbox.Text))
            {
                try
                {
                    var test = new MailAddress(mailbox.Text);
                    table.Rows.Add(namebox.Text, mailbox.Text, displayDate.Text, displayGender.Text, listBox1.Text);
                }
                catch (FormatException ex)
                {
                    string message = "Не Email!!";
                    string caption = "Ошибка";
                    MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                    DialogResult result;

                    result = MessageBox.Show(message, caption, buttons);
                    
                }
            }

            


        }

        private void display_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void radioMale_CheckedChanged(object sender, EventArgs e)
        {
           
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void calendar_ValueChanged(object sender, EventArgs e)
        {

        }

        private void table_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void mailbox_TextChanged(object sender, EventArgs e)
        {

        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {

        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void table_CellMouseUp(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                this.table.Rows[e.RowIndex].Selected = true;
                this.RowIndex = e.RowIndex;
                this.table.CurrentCell = this.table.Rows[e.RowIndex].Cells[1];
                this.contextMenuStrip1.Show(this.table, e.Location);
                contextMenuStrip1.Show(Cursor.Position);
            }
        }

        private void contextMenuStrip1_Click(object sender, EventArgs e)
        {
            if (!this.table.Rows[this.RowIndex].IsNewRow)
            {
                this.table.Rows.RemoveAt(this.RowIndex);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}

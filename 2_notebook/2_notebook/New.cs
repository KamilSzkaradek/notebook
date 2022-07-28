using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
namespace _2_notebook
{
    public partial class New : Form
    {
        public New()
        {
            InitializeComponent();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            addNote();
            this.Dispose();
        }
        private void addNote() 
        {
            var db = new notesEntities2();
            var id = (db.notes.OrderByDescending(a => a.ID).FirstOrDefault()?.ID ?? 0) + 1;
            var NewNote = new notes();
            NewNote.ID = id;
            NewNote.Name = textBox1.Text;
            NewNote.Content = richTextBox1.Text;
            db.notes.Add(NewNote);
            db.SaveChanges();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void label2_Click(object sender, EventArgs e) { }
        private void label1_Click(object sender, EventArgs e) { }
        private void richTextBox1_TextChanged(object sender, EventArgs e) { }
        private void textBox1_TextChanged(object sender, EventArgs e) { }
    }
}

using System;
using System.Linq;
using System.Windows.Forms;
namespace _2_notebook
{
    public partial class Edit : Form
    {
        private Note editedNote;
        public Edit(Note _note)
        {
            InitializeComponent();
            richTextBox1.Text = _note.Content;
            textBox1.Text = _note.Name;
            editedNote = _note;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            var db = new notesEntities2();
            if (db.notes.Any(a => a.Name == editedNote.Name))
            {
                var NoteModified = db.notes.Find(editedNote.ID);
                editedNote.Name = textBox1.Text;
                editedNote.Content = richTextBox1.Text;

                NoteModified.ID = editedNote.ID;
                NoteModified.Name = editedNote.Name;
                NoteModified.Content = editedNote.Content;
                db.Entry(NoteModified).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }
            this.Dispose();
        }
        private void button3_Click(object sender, EventArgs e)
        {
        }
        private void Edit_Load(object sender, EventArgs e) { }
        private void label1_Click(object sender, EventArgs e) { }
        private void richTextBox1_TextChanged(object sender, EventArgs e) { }
        private void textBox1_TextChanged(object sender, EventArgs e) { }
        private void label2_Click(object sender, EventArgs e) { }
    }
}

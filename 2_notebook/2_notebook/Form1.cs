using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
namespace _2_notebook
{
    public partial class Form1 : Form
    {
        List<Note> notes = new List<Note>();
        public Form1()
        {
            InitializeComponent();
            notes = GetNotes();
            button3.Enabled = false;
            button2.Enabled = false;

            foreach (Note note in notes)
            {
                listBox1.Items.Add(note);
            }
        }
        //get notes data from database
        public List<Note> GetNotes()
        {
            var db = new notesEntities2();
            var query = from item in db.notes select item;

            return query.ToList()
                .Select(item => new Note(item))
                .ToList();
        }
        //new
        private void button1_Click(object sender, EventArgs e)
            {
                New newNote = new New();
                newNote.Show();
            }
        //edit
        private void button2_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex > -1)
            {
                Edit edit = new Edit(notes[listBox1.SelectedIndex]);
                edit.Show();
                button3.Enabled = false;
                button2.Enabled = false;
            }
        }
        //remove
        private void button3_Click(object sender, EventArgs e)
        {
            var db = new notesEntities2();
            var delete = notes[listBox1.SelectedIndex].ID;
            var toDelete = db.notes.Find(delete);
            db.notes.Remove(toDelete);
            db.SaveChanges();
            refresh();
        }
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            button3.Enabled = true;
            button2.Enabled = true;
        }
        private void button4_Click(object sender, EventArgs e)
        {
            refresh();
        }
        private void refresh()
        {
            listBox1.Items.Clear();
            notes = GetNotes();
            foreach (Note note in notes)
            {
                listBox1.Items.Add(note);
            }
        }
    }
}

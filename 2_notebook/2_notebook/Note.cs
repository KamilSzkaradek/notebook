namespace _2_notebook
{
    public class Note
    {
        private int id;
        private string name;
        private string content;
        public Note(int _id, string _name, string _description) 
        {
            id = _id;
            name = _name;
            content = _description; 
        }
        public Note(notes item)
        {
            id = item.ID;
            name = item.Name;
            content = item.Content; 
        }
        public override string ToString()
        {
            return name;
        }
        public int ID
        {
            get { return id; }
            set { id = value; }
        }
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public string Content
        {
            get { return content; }
            set { content = value; }
        }
    }
}

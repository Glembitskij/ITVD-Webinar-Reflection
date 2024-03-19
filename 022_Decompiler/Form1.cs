using System.Reflection;

namespace _022_Decompiler
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();

            // Додавання фільтру для вибору файлів з розширенням .dll та .exe
            openFileDialog.Filter = "All files (*.*)|*.*";

            if (openFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                // Строка приема полного имени загружаемой сборки.
                string path = openFileDialog.FileName;

                try
                {
                    Assembly assembly = Assembly.LoadFile(path);
                    FillTree(assembly);
                }
                catch (FileNotFoundException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        private void FillTree(Assembly assembly)
        {
            Type[] types = assembly.GetTypes();

            foreach (Type type in types)
            {
                TreeNode newNode = new TreeNode(type.Name);
                treeView1.Nodes.Add(newNode);
            }
        }
    }
}

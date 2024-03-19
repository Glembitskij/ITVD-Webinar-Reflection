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

            IEnumerable<string> namespases = types.Select(t => t.Namespace).Distinct();

            foreach (string namespase in namespases)
            {
                TreeNode namespaseNode = new TreeNode(namespase);

                foreach (Type type in types.Where(t=>t.Namespace == namespase))
                {
                    TreeNode typeNode = new TreeNode(type.Name);

                    // Інформація про базовий тип
                    TreeNode baseTypeNode = new TreeNode("Base Type");
                    baseTypeNode.Nodes.Add(type?.BaseType?.ToString());
                    typeNode.Nodes.Add(baseTypeNode); 

                    // Інформація про поля классу MyClass
                    FieldInfo[] fieldInfos = type.GetFields(
                        BindingFlags.Public
                        | BindingFlags.NonPublic
                        | BindingFlags.Instance
                        | BindingFlags.Static);

                    // Перебираємо кожне поля та виводимо інформацію про нього
                    foreach (FieldInfo fieldInfo in fieldInfos)
                    {
                        typeNode.Nodes.Add(new TreeNode($"field - {fieldInfo.Name} " +
                            $": {fieldInfo.FieldType.Name}"));
                    }

                    // Інформація про властивості классу MyClass
                    PropertyInfo[] propertyInfos = type.GetProperties(BindingFlags.Public
                        | BindingFlags.NonPublic
                        | BindingFlags.Instance
                        | BindingFlags.Static);

                    // Перебираємо кожну властивість та виводимо інформацію про неї
                    foreach (PropertyInfo propertyInfo in propertyInfos)
                    {
                        typeNode.Nodes.Add(new TreeNode($"property - {propertyInfo.Name} " +
                            $": {propertyInfo.PropertyType.Name}"));
                    }

                    MethodInfo[] methodInfos = type.GetMethods(
                        BindingFlags.Public
                        | BindingFlags.NonPublic
                        | BindingFlags.Instance
                        | BindingFlags.Static
                        | BindingFlags.DeclaredOnly);

                    // Перебираємо кожний метод та виводимо інформацію про нього
                    foreach (MethodInfo methodInfo in methodInfos)
                    {
                        if (methodInfo.Name.StartsWith("get") || methodInfo.Name.StartsWith("set")) {
                            continue;
                        }

                        typeNode.Nodes.Add(new TreeNode(methodInfo.Name));
                    }

                    namespaseNode.Nodes.Add(typeNode);
                }

                treeView1.Nodes.Add(namespaseNode);
            }
        }

        private void TreeView1_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            MessageBox.Show(e.Node.Text);
        }
    }
}

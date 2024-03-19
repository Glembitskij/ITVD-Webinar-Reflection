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

            // ��������� ������� ��� ������ ����� � ����������� .dll �� .exe
            openFileDialog.Filter = "All files (*.*)|*.*";

            if (openFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                // ������ ������ ������� ����� ����������� ������.
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

                    // ���������� ��� ������� ���
                    TreeNode baseTypeNode = new TreeNode("Base Type");
                    baseTypeNode.Nodes.Add(type?.BaseType?.ToString());
                    typeNode.Nodes.Add(baseTypeNode); 

                    // ���������� ��� ���� ������ MyClass
                    FieldInfo[] fieldInfos = type.GetFields(
                        BindingFlags.Public
                        | BindingFlags.NonPublic
                        | BindingFlags.Instance
                        | BindingFlags.Static);

                    // ���������� ����� ���� �� �������� ���������� ��� �����
                    foreach (FieldInfo fieldInfo in fieldInfos)
                    {
                        typeNode.Nodes.Add(new TreeNode($"field - {fieldInfo.Name} " +
                            $": {fieldInfo.FieldType.Name}"));
                    }

                    // ���������� ��� ���������� ������ MyClass
                    PropertyInfo[] propertyInfos = type.GetProperties(BindingFlags.Public
                        | BindingFlags.NonPublic
                        | BindingFlags.Instance
                        | BindingFlags.Static);

                    // ���������� ����� ���������� �� �������� ���������� ��� ��
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

                    // ���������� ������ ����� �� �������� ���������� ��� �����
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

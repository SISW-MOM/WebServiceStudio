using System;
using System.Windows.Forms;
using IBS.Utilities.ASMWSTester.BatchRun;
using IBS.Utilities.ASMWSTester.BatchRun.ConfigNode;

namespace IBS.Utilities.ASMWSTester
{
    public partial class ValueFieldsForm : Form
    {
        public ValueFieldsForm()
        {
            InitializeComponent();
        }

        private void ValueFieldsForm_Load(object sender, EventArgs e)
        {
            BindList();
        }

        private void BindList()
        {
            listBox1.Items.Clear();

            if (BatchRunCongifFileHelper.testConfigNode != null)
            {
                foreach (VauleFieldConfigNode vauleField in BatchRunCongifFileHelper.testConfigNode.ValueFields)
                {
                    listBox1.Items.Add(vauleField.Name);
                }
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            VauleFieldConfigNode vauleFieldConfigNode = new VauleFieldConfigNode();
            vauleFieldConfigNode.Name = textBox1.Text;

            BatchRunCongifFileHelper.testConfigNode.ValueFields.Add(vauleFieldConfigNode);

            BindList();
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem != null)
            {
                selectVauleField = listBox1.SelectedItem.ToString();
                Close();
            }
        }

        public string SelectVauleField
        {
            get { return selectVauleField; }
            set { selectVauleField = value; }
        }

        private string selectVauleField;
    }
}
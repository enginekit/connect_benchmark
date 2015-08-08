using System;
using System.Collections.Generic;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Diagnostics;

using MySqlTest;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        List<TestCase> testList = new List<TestCase>();
        public Form1()
        {
            InitializeComponent();
        }

        void LoadTestCases()
        {
            testList.Clear();
            listboxTestCases.Items.Clear();
            TestCaseExtracter.ExtractTestCase(this.GetType().Assembly, testList);

            //load into listbox
            int j = testList.Count;
            for (int i = 0; i < j; ++i)
            {
                listboxTestCases.Items.Add(testList[i]);
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {

            listboxTestCases.DoubleClick += ListboxTestCases_DoubleClick;
            LoadTestCases();
        }
        private void ListboxTestCases_DoubleClick(object sender, EventArgs e)
        {
            TestCase testCase = listboxTestCases.SelectedItem as TestCase;
            if (testCase != null)
            {
                testCase.Run();
            }
        }
    }
}

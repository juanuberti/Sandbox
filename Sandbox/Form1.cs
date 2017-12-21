using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sandbox
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
             int[] arr = { 12, 11, 13, 5, 6, 7 };

            Heaps.Heap heap = Heaps.Heap.CreateHeapFromArray(arr);

            Heaps.HeapSort.Sort(heap.Items);

            /*
            string apikey = "eEwZONwouE3j0uUL38iQbJ22DRSqjtT1";
            string iv = "eEwZONwouE3j0uUL38iQbJ22DRSqjtT1";
            byte[] key = Encoding.UTF8.GetBytes(apikey); //Secert Key for the API. Used to encrypt the first call for the session nonce.
            string APIKeystring = Convert.ToBase64String(key);

            byte[] iv1 = Encoding.UTF8.GetBytes(iv); //Secert Key for the API. Used to encrypt the first call for the session nonce.
            string iv2= Convert.ToBase64String(iv1);


            Console.WriteLine(Encryption.DecryptString("U2FsdGVkX18RCEa2xypp0pd72Mkz / gQ6fWQwCMbRmu8 =", APIKeystring, iv2));
            */
            //Heaps.Controller.TestScenario();
               
        }
    }
}

using Newtonsoft.Json;
using System.Text.RegularExpressions;

namespace WinFormsApp10
{
    public partial class Form1 : Form
    {
        List<User> user = new();
        public Form1()
        {
            InitializeComponent();
        }


        private void textBox3_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Regex r = new(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
            if (!r.IsMatch(textBox3.Text))
            {
                e.Cancel = true;
                textBox3.Focus();
                errorProvider1.SetError(textBox3, "Invalid email format!");
            }

            else
            {
                e.Cancel = false;
                errorProvider1.SetError(textBox3, "");
            }
        }
        private void textBox4_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Regex r = new(@"\(?\d{3}\)?-? *\d{3}-? *-?\d{4}");
            if (!r.IsMatch(textBox4.Text))
            {
                e.Cancel = true;
                textBox4.Focus();
                errorProvider1.SetError(textBox4, "Invalid phone number format!");
            }

            else
            {
                e.Cancel = false;
                errorProvider1.SetError(textBox4, "");
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            listBox1.DataSource = user;

        }
        private void btn_Add_Click(object sender, EventArgs e)
        {
            user.Add(new User(textBox1.Text, textBox2.Text, textBox3.Text, textBox4.Text, dateTimePicker1.Value));
            label6.Text = textBox1.Text;
            textBox1.Text = null;
            textBox2.Text = null;
            textBox3.Text = null;
            textBox4.Text = null;
            dateTimePicker1.Value = DateTime.Now;
            listBox1.DataSource = null;

            listBox1.DataSource = user;
        }

        private void btn_Edit_Click(object sender, EventArgs e)
        {
            user.Remove(listBox1.SelectedItem as User);
            user.Add(new User(textBox1.Text, textBox2.Text, textBox3.Text, textBox4.Text, dateTimePicker1.Value));


            textBox1.Text = null;
            textBox2.Text = null;
            textBox3.Text = null;
            textBox4.Text = null;
            dateTimePicker1.Value = DateTime.Now;
            listBox1.DataSource = null;
            listBox1.DataSource = user;
            btn_Edit.Visible = false;

        }
       
      
        private void btn_Save_Click(object sender, EventArgs e)
        {

            var jsonString = JsonConvert.SerializeObject(user, Newtonsoft.Json.Formatting.Indented);

            File.WriteAllText($"{textBox1.Text}.json", jsonString);
            MessageBox.Show("Saved successfully");
            label6.Text = textBox1.Text;
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            dateTimePicker1.Value = DateTime.Today;

        }

        private void btn_Load_Click(object sender, EventArgs e)
        {

            List<User>? user = null;
            var jsonStr = File.ReadAllText($"{label6.Text}.json");
            user = JsonConvert.DeserializeObject<List<User>>(jsonStr);
            listBox1.DataSource = user;

            foreach (var userr in user)
            {
                textBox1.Text = userr.Name;
                textBox2.Text = userr.Surname;
                textBox3.Text = userr.Email;
                textBox4.Text = userr.PhoneNumber;

                dateTimePicker1.Value = userr.Birthdate;
            }
        }

    }
}

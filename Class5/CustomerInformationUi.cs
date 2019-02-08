using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Class5
{
    public partial class CustomerInformationUi : Form
    {
        public CustomerInformationUi()
        {
            InitializeComponent();
        }

        List<string> userName = new List<string>();
        List<string> firstName = new List<string>();
        List<string> lastName = new List<string>();
        List<string> contactNo = new List<string>();
        List<string> email = new List<string>();
        List<string> address = new List<string>();
        List<string> accountNo = new List<string>();
        List<int> amount = new List<int>();

        private int serial = 1;

        private string everyCustomer = "";
        List<string> showAllCustomerInfo = new List<string>(); 

        private void SaveButton_Click(object sender, EventArgs e)
        {
            showRichTextBox.Text = "Sl\t|User Name\t|First Name\t|Contact\t|Email\t\t|Address\t|AccountNo\t\n";
            if (InputValidation())
            {
                amount.Add(0);
                userName.Add(userNameTextBox.Text);
                firstName.Add(firstNameTextBox.Text);
                lastName.Add(lastNameTextBox.Text);
                contactNo.Add(contactNumberTextBox.Text);
                email.Add(emailTextBox.Text);
                address.Add(addressTextBox.Text);
                accountNo.Add(accountNoTextBox.Text);

                everyCustomer = serial + "\t" + userName.Last()+"\t" + firstName.Last()+"\t" + contactNo.Last()+"\t" + email.Last() +"\t"+
                                address.Last()+"\t"+accountNo.Last()+"\n";
                showAllCustomerInfo.Add(everyCustomer);
                showRichTextBox.Text += everyCustomer;
                serial++;
                MessageBox.Show("Successful Entry");
                Clear();
            }

        }

        //Show Button Work
        private void ShowButton_Click(object sender, EventArgs e)
        {
            
            showRichTextBox.Text = "Sl\t|User Name\t|First Name\t|Contact\t|Email\t\t|Address\t|AccountNo\t\n";

            foreach (string customerInfo in showAllCustomerInfo)
            {
                showRichTextBox.Text += customerInfo;
            }
        }

        //Deposite Button 

        private void DepositButton_Click(object sender, EventArgs e)
        {
            if ((accountNo.Contains(accountCheckTextBox.Text)) && !(amountTextBox.Text == ""))
            {
                int index = accountNo.IndexOf(accountCheckTextBox.Text);
                amount[index] +=Convert.ToInt32(amountTextBox.Text);
                balanceInformationLabel.Text = "Amount"+amountTextBox.Text+" Deposited Successfully";
            }
            else if (!(accountNo.Contains(accountCheckTextBox.Text)) && (amountTextBox.Text == ""))
            {
                balanceInformationLabel.Text = "Please Enter your account no and amount please.";

            }
            else if (!(accountNo.Contains(accountCheckTextBox.Text)))
            {
                balanceInformationLabel.Text = "Account Not matched";
            }
            else if (amountTextBox.Text == "")
            {
                balanceInformationLabel.Text = "Please Enter your ammount";
            }

        }

        //Withdraw Button
        private void WithdrawButton_Click(object sender, EventArgs e)
        {
            if ((accountNo.Contains(accountCheckTextBox.Text)) && !(amountTextBox.Text == ""))
            {
                int index = accountNo.IndexOf(accountCheckTextBox.Text);
                if ((amount[index] - Convert.ToInt32(amountTextBox.Text))> 0)
                {
                    amount[index] -= Convert.ToInt32(amountTextBox.Text);
                    balanceInformationLabel.Text = "Amount" + amountTextBox.Text + " Withdraw Successfully";
                }

                else
                {
                    balanceInformationLabel.Text = "Amount" + amount[index] + " Not sufficient balance.";

                }
                
            }
            else if (!(accountNo.Contains(accountCheckTextBox.Text)) && (amountTextBox.Text == ""))
            {
                balanceInformationLabel.Text = "Please Enter your account no and amount please.";

            }
            else if (!(accountNo.Contains(accountCheckTextBox.Text)))
            {
                balanceInformationLabel.Text = "Account Not matched";
            }
            else if(amountTextBox.Text == "")
            {
                balanceInformationLabel.Text = "Please Enter your ammount";
            }

        }

        //Balance Button

        private void BalanceButton_Click(object sender, EventArgs e)
        {
            if (accountNo.Contains(accountCheckTextBox.Text))
            {
                int index = accountNo.IndexOf(accountCheckTextBox.Text);

                balanceInformationLabel.Text = "Your Current Balance is " + amount[index];
            }
            else if (!(accountNo.Contains(accountCheckTextBox.Text)))
            {
                balanceInformationLabel.Text = "Account Not matched";
            }
        }


        //Input checker function

        private bool InputValidation()
        {
            bool chk = true;

            //User name check
            if (userNameTextBox.Text == "")
            {
                userNameLabel.Text = "Please enter your user name.";
                chk = false;
            }
            else
            {
                if (userName.Contains(userNameTextBox.Text))
                {
                    userNameLabel.Text = "Duplicate User Name Found.";
                    chk = false;
                }
                else
                {
                    userNameLabel.Text = "";
                }
            }

            //First Name check
            if (firstNameTextBox.Text == "")
            {
                firstNameLabel.Text = "Please enter your first name.";
                chk = false;
            }
            else
            {
                firstNameLabel.Text = "";
            }

            //Last Name check
            if (lastNameTextBox.Text == "")
            {
                lastNameLabel.Text = "Please enter your last name.";
                chk = false;
            }
            else
            {
                lastNameLabel.Text = "";
            }

            //Contact check

            if (contactNumberTextBox.Text == "")
            {
                contactNumberLabel.Text = "Please enter your contact number.";
                chk = false;
            }
            else
            {
                if (contactNo.Contains(contactNumberTextBox.Text))
                {
                    contactNumberLabel.Text = "Duplicate contact Number Found.";
                    chk = false;
                }
                else if(contactNumberTextBox.Text.Length!=11)
                {
                    contactNumberLabel.Text = "Contact Number must be 11 digit.";
                    chk = false;
                }
                else
                {
                    contactNumberLabel.Text = "";
                }
            }

            //Email Check

            if (emailTextBox.Text == "")
            {
                emailLabel.Text = "Please enter your email.";
                chk = false;
            }
            else
            {
                if(!(emailTextBox.Text.Contains('@') && emailTextBox.Text.Contains('.')))
                {
                    emailLabel.Text = "Please enter a valid email.";
                    chk = false;

                }
                else if (email.Contains(emailTextBox.Text))
                {
                    emailLabel.Text = "Duplicate email found.";
                    chk = false;                  
                }
                else
                {
                    emailLabel.Text = "";
                }
            }

            //Address check

            if (addressTextBox.Text == "")
            {
                addressLabel.Text = "Please enter your address.";
                chk = false;
            }
            else
            {
                addressLabel.Text = "";
            }

            //Account check

            if (accountNoTextBox.Text =="")
            {
                accountNoLabel.Text = "Please enter your account number.";
                chk = false;
            }
            else
            {
                if (accountNo.Contains(accountNoTextBox.Text))
                {
                    accountNoLabel.Text = "Duplicate account No Found.";
                    chk = false;
                }
                else if (accountNoTextBox.Text.Length != 8)
                {
                    accountNoLabel.Text = "Account Number must be 8 digit.";
                    chk = false;
                }
                else
                {
                    accountNoLabel.Text = "";
                }
            }

            return chk;

        }

        private void Clear()
        {
            userNameTextBox.Text ="";
            firstNameTextBox.Text="";
            lastNameTextBox.Text = "";
            contactNumberTextBox.Text = "";
            emailTextBox.Text = "";
            addressTextBox.Text = "";
            accountNoTextBox.Text = "";
            
        }

        private void accountNoTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void amountTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);

        }

        private void accountCheckTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void contactNumberTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

       

       

        

        


       


    }
}

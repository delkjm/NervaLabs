using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Data.OleDb;

public partial class Default2 : System.Web.UI.Page
{
    //string connectionString = "Data Source=LOCALHOST;Initial Catalog = Nerva; Integrated Security = True"; 
    SqlConnection connect = new SqlConnection(ConfigurationManager.ConnectionStrings["NervaLabsConnection"].ConnectionString);


    //connection string
    protected void Page_Load(object sender, EventArgs e)
    {



    }

    protected void btnExit_Click(object sender, EventArgs e)
    {
        System.Environment.Exit(1);
    }

    protected void btnlog_Click(object sender, EventArgs e) //login button
    {
        //connect.Open();

        if (userTxt.Text == "" || passTxt.Text == "")
        {
            ErrorOutput.Text = "please enter your username and password";
            ErrorOutput.ForeColor = System.Drawing.Color.Red;
            return;
        }
        
        
            //SqlConnection connect = new SqlConnection(connectionString);
            //string loginQuery = "select * from NervaTest where UserName =@username and Password =@password";
            //System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand(loginQuery, connect);
            //cmd.Connection = connect;
            //cmd.Parameters.AddWithValue("@username", userTxt.Text);
            //cmd.Parameters.AddWithValue("@password", passTxt.Text);

            //connect.Open();
            //SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            //adapter.TableMappings.Add("Table", "NervaTest");
            //DataSet ds = new DataSet("NervaTest");
            //adapter.Fill(ds);

            if (verifyCredentials(userTxt.Text, passTxt.Text) == true)
            {
                SuccessOutput.Text = "Login Successful!";
                SuccessOutput.ForeColor = System.Drawing.Color.Green;
            }
            else
            {
                ErrorOutput.Text = "Login Not Successful";
                // ErrorOutput.Text = "Login Failed! **Please try again**";
                ErrorOutput.ForeColor = System.Drawing.Color.Red;
                btnForgotPassword.Visible = true;
            }

            //int countRows = ds.Tables[0].Rows.Count;

            //if (countRows == 1)
            //{
            //    verifyCredentials(userTxt.Text,passTxt.Text);

            //    //SuccessOutput.Text = "Login Successful!";
            //    SuccessOutput.ForeColor = System.Drawing.Color.Green;
            //    //this.Hide();
            //    //logoutForm fm = new logoutForm();
            //    //fm.Show();
            //}
            //else
            //{
                
            //    ErrorOutput.Text = "Login Failed! **No record exists**";
            //    ErrorOutput.ForeColor = System.Drawing.Color.Red;
            //    btnForgotPassword.Visible = true;
            //}

            ////for (int i = 0; i <= countRows; i++)
            ////{
            ////    if ((ds.Tables.UserName.Equals(userTxt.Text)) && (ds.Tables.Password.Equals(passTxt.Text)))
            ////    {
            ////        SuccessOutput.Text = "login success";
            ////        SuccessOutput.ForeColor = System.Drawing.Color.Green;
            ////    }
            ////    else
            ////    {
            ////        SuccessOutput.Text = "incorrect username or password";
            ////        SuccessOutput.ForeColor = System.Drawing.Color.Red;
            ////        
            ////    }
            //}

            connect.Close();


        
        
    }

    protected void btnForgotPassword_Click(object sender, EventArgs e) //forgot password 
    {
        connect.Open();
       //SqlConnection connect = new SqlConnection(connectionString);
        string emailQuery = "select * from NervaTest where UserName = @username and Password =@password";

        System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand(emailQuery, connect);
        cmd.Connection = connect;
        cmd.Parameters.AddWithValue("@username", userTxt.Text);
        cmd.Parameters.AddWithValue("@password", passTxt.Text);


        
        int verify = 0;
        if (verify > 0)
        {
          //  Record found(write your logic here);
        }
        else
        {
           // No record found(write your logic here);
        }
        connect.Close();
        
    }


    protected Boolean verifyCredentials(String UserName, String Password)
    {
        //connect.Open();
        //  SqlConnection connect = new SqlConnection(connectionString);
        string loginQuery = "select * from NervaTest where UserName =@username and Password =@password";
        System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand(loginQuery, connect);
        cmd.Connection = connect;

        cmd.Parameters.AddWithValue("@username", userTxt.Text);
        cmd.Parameters.AddWithValue("@password", passTxt.Text);

        connect.Open();
        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
        adapter.TableMappings.Add("Table", "NervaTest");
        DataSet ds = new DataSet("NervaTest");
        adapter.Fill(ds);

        if (ds != null && ds.Tables[0].Rows.Count == 1)
        {
            
            SuccessOutput.Text = "Login Successful!";
            SuccessOutput.ForeColor = System.Drawing.Color.Green;
            //this.Hide();
            //logoutForm fm = new logoutForm();
            //fm.Show();
            connect.Close();
            return true;
        }
        else
        {
            
            
            ErrorOutput.Text = "Record does not exist. Try again!";
           // ErrorOutput.Text = "Login Failed! **Please try again**";
            ErrorOutput.ForeColor = System.Drawing.Color.Red;
            btnForgotPassword.Visible = true;
            connect.Close();
            return false;
        }
       // connect.Close();

    }

    //protected Boolean checkCredentials(String UserName, String Password)
    //{
    //    String returnString;
        

    //    String userNameCheck = "select UserName from NervaTest where UserName ='"+ userTxt.Text + "'";
    //    System.Data.SqlClient.SqlCommand usercmd = new System.Data.SqlClient.SqlCommand(userNameCheck, connect);

    //    SqlDataAdapter adapter = new SqlDataAdapter(usercmd);
    //    DataSet ds = new DataSet("NervaTest");
    //    adapter.Fill(ds);
    //    if (ds == null)
    //    {
    //        returnString = "Please enter a valid UserName";
    //        connect.Close();
    //        return false;
            
    //    }

    //    String passwordCheck = "select Password from NervaTest where Password ='" + passTxt.Text + "' AND UserName ='"+ userTxt.Text + "'";
    //    System.Data.SqlClient.SqlCommand passcmd = new System.Data.SqlClient.SqlCommand(passwordCheck, connect);

    //    SqlDataAdapter adapter2 = new SqlDataAdapter(passcmd);
    //    DataSet ds2 = new DataSet("NervaTest");
    //    adapter2.Fill(ds2);
    //    if (ds2 == null) {
    //        returnString = "Password entered does not match our records";
    //        connect.Close();
    //        return false;
    //    }

    //    return true;
    //    //connect.Close();
        
        

    //}
    

    }


           


   
      
    

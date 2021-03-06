﻿using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Data.SqlClient;
using System.Data.OracleClient;

public partial class Faculty : System.Web.UI.Page
{
    private TextBox[] FacultyTextBox = new TextBox[7];    

    protected void Page_Load(object sender, EventArgs e)
    {
        if (((OracleConnection)Application["oraConnection"]).State != ConnectionState.Open)
            ((OracleConnection)Application["oraConnection"]).Open();

        if (!IsPostBack)
        {
            ComboName.Items.Add("Ying Bai");
            ComboName.Items.Add("Satish Bhalla");
            ComboName.Items.Add("Black Anderson");
            ComboName.Items.Add("Steve Johnson");
            ComboName.Items.Add("Jenney King");
            ComboName.Items.Add("Alice Brown");
            ComboName.Items.Add("Debby Angles");
            ComboName.Items.Add("Jeff Henry");
        }
    }
    protected void cmdSelect_Click(object sender, EventArgs e)
    {
        string cmdString = "SELECT faculty_id, faculty_name, office, phone, college, title, email FROM Faculty ";
        cmdString += "WHERE faculty_name =: name";
        OracleCommand oraCommand = new OracleCommand();
        OracleDataReader oraDataReader;

        oraCommand.Connection = (OracleConnection)Application["oraConnection"];
        oraCommand.CommandType = CommandType.Text;
        oraCommand.CommandText = cmdString;
        oraCommand.Parameters.Add("name", OracleType.Char).Value = ComboName.Text;
        string strName = ShowFaculty(ComboName.Text);
        oraDataReader = oraCommand.ExecuteReader();
        if (oraDataReader.HasRows == true)
            FillFacultyReader(oraDataReader);
        else
            Response.Write("<script>alert('No matched faculty found!')</script>");
        oraDataReader.Close();
        oraCommand.Dispose();
    }
    private void FillFacultyReader(OracleDataReader FacultyReader)
    {
        int intIndex = 0;

        for (intIndex = 0; intIndex <= 6; intIndex++)        //Initialize the object array
            FacultyTextBox[intIndex] = new TextBox();
        MapFacultyTable(FacultyTextBox);
        while (FacultyReader.Read())
        {
            for (intIndex = 0; intIndex <= FacultyReader.FieldCount - 1; intIndex++)
                FacultyTextBox[intIndex].Text = FacultyReader.GetString(intIndex);
        }
    }
    private void MapFacultyTable(Object[] fText)        
    {
        fText[0] = txtID;
        fText[1] = txtName;                             
        fText[2] = txtOffice;     //The order must be identical
        fText[3] = txtPhone;      //with the real order in the query string
        fText[4] = txtCollege;
        fText[5] = txtTitle;
        fText[6] = txtEmail;
    }
    private string ShowFaculty(string fName)
    {
        string FacultyImage;
        switch (fName)
        {
            case "Black Anderson":
                FacultyImage = "Anderson.jpg";
                break;
            case "Ying Bai":
                FacultyImage = "Bai.jpg";
                break;
            case "Satish Bhalla":
                FacultyImage = "Satish.jpg";
                break;
            case "Steve Johnson":
                FacultyImage = "Johnson.jpg";
                break;
            case "Jenney King":
                FacultyImage = "King.jpg";
                break;
            case "Alice Brown":
                FacultyImage = "Brown.jpg";
                break;
            case "Debby Angles":
                FacultyImage = "Angles.jpg";
                break;
            case "Jeff Henry":
                FacultyImage = "Henry.jpg";
                break;
            default:
                FacultyImage = "No Match";
                break;
        }
        if (FacultyImage != "No Match")
            PhotoBox.ImageUrl = FacultyImage;
        else
            Response.Write("<script>alert('No matched faculty image found!')</script>");
        return FacultyImage;
    }
    protected void cmdBack_Click(object sender, EventArgs e)
    {
        Response.Redirect("Selection.aspx");
    }
}

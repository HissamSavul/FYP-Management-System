<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FYPDeadline.aspx.cs" Inherits="DBPROJECT.FYPDeadline" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style>
     .FYPHeading {
      font-family: 'Trebuchet MS';
      text-align: center;
      background-color: rgba(0, 0, 0, 0.8);
      color: rgba(210, 210, 210);
      height: auto;
      margin: 0 auto;
      width: 30%;
      padding: 1% 4%;
      border: 1px solid white;
      font-size:130%
     }
    input[type=text] {
      width: 100%;
      padding: 12px 20px;
      margin: 8px 0;
      box-sizing: border-box;
      border: 3px solid #ccc;
      -webkit-transition: 0.5s;
      transition: 0.5s;
      outline: none;
    }

    input[type=text]:focus {
      border: 3px solid #555;
    }

    .button {
      background: #e519a1;
      border-radius: 999px;
      box-sizing: border-box;
      color: black;
      cursor: pointer;
      font-size: 16px;
      font-weight: 700;
      line-height: 24px;
      outline: 0 solid transparent;
      padding: 8px 18px;
      user-select: none;
      -webkit-user-select: none;
      touch-action: manipulation;
      border: 0;
    }
    .button1:hover {
      background-color: #140035;
      color: white;
    }
    .button2:hover {
      background-color: #140035;
      color: white;
    }
    .button1 {width: 100%;}
    .button2 {width: auto;}

    body {
      background-image: url(https://contest.srg.firat.com.ng/storage/2022/04/5238994-scaled.jpg);
      background-repeat: no-repeat;
      background-attachment: fixed;  
      background-size: cover;
    }
    .dataGrid1 {
        width: 80%;
        border: solid 2px black;
        min-width: 100%;
        color: rgb(200, 200, 200);
        border: rgb(200, 200, 200);
    }
    </style>
</head>
<body>
     <br /><div class="FYPHeading">
        <h1>Final Year Project</h1>
    </div><br />

    <form id="form2" runat="server"  style="font-family: 'Trebuchet MS'; text-align: left; font-size:130%; width: 30%; height: auto; padding: 1% 4%; margin:0 auto;  background-color: rgba(0, 0, 0, 0.5); border: 1px solid white; color: rgba(210, 210, 210);">
        <h1 style="margin-top: 50px; text-align: center"><b>
                &nbsp;Assign Deadline</b></h1>
        <hr />

          <br />   
        <asp:Label ID="Label1" runat="server" Text="Project ID"></asp:Label>
        <br class="auto-style1" />
        <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
        <br class="auto-style1" />
        <br style="text-align: center" />   
        <asp:Label ID="Label2" runat="server" Text="Deadline Date"></asp:Label>
        <br class="auto-style1" />
        <asp:TextBox type="date" ID="TextBox2" runat="server" style = "width: 100%; padding: 12px 20px; margin: 8px 0; box-sizing: border-box; border: 3px solid #ccc; -webkit-transition: 0.5s; transition: 0.5s; outline: none;"></asp:TextBox>
        <br class="auto-style1" />
        <br class="auto-style1" />
        <asp:Label ID="Label3" runat="server" Text="Deadline Time"></asp:Label>
        <br class="auto-style1" />
        <asp:TextBox type="time" ID="TextBox3" runat="server" style = "width: 100%; padding: 12px 20px; margin: 8px 0; box-sizing: border-box; border: 3px solid #ccc; -webkit-transition: 0.5s; transition: 0.5s; outline: none;"></asp:TextBox>
        <br />
         <br />
        <asp:Button width="25%" class="button button2" ID="Button1" runat="server" Text="Assign" OnClick="Button1_Click2"/>
            <asp:Button  style="margin-left: 50%" class="button button2" ID="Button2" runat="server" Text="Return" OnClick="Button2_Click"  />
        <br />
        <br />

    </form>
</body>
</html>

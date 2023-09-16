﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="NotificationViewSupervisor.aspx.cs" Inherits="DBPROJECT.NotificationViewSupervisor" %>

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
      width: 45%;
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
<form id="form1" runat="server" style="font-family: 'Trebuchet MS'; text-align: center; font-size:130%; width: 45%; height: auto; padding: 1% 4%; margin:0 auto;  background-color: rgba(0, 0, 0, 0.5); border: 1px solid white; color: rgba(210, 210, 210);">
        <div>
            <h2 style="margin-top: 50px; text-align: center"><b>
                &nbsp;Notifications</b></h2>
            <hr />
            <p style="margin-top: 50px; text-align: center">
                <asp:GridView class = "dataGrid1" ID="GridView1" runat="server" OnSelectedIndexChanged="GridView1_SelectedIndexChanged">
                </asp:GridView>
            </p>

        </div>
        <br />
        <asp:Button class="button button1 button2" ID="Button1" runat="server" Text="Return" OnClick="Button1_Click" />
    <br/>
    </form>
</body>
</html>

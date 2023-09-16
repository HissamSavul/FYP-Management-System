<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FYPSupervisor-Interface.aspx.cs" Inherits="DBPROJECT.FYPSupervisor_Interface" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <meta name="viewport" content="width=device-width, initial-scale=1">    
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css">
    <style>
     .fa {
      padding: 10px;
      font-size: 20px;
      width: 30px;
      text-align: center;
      text-decoration: none;
      margin: 5px 2px;
      }

     .fa:hover {
        opacity: 0.7;
     }

     .fa-facebook {
       background: #3B5998;
       color: white;
     }

     .fa-twitter {
       background: #55ACEE;
       color: white;
     }

     .fa-google {
       background: #dd4b39;
       color: white;
     }

     .fa-youtube {
       background: #bb0000;
       color: white;
     }

     .fa-instagram {
       background: #125688;
       color: white;
     }
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
        <img alt="" src="logo.jpg" style="background-image:linear-gradient(); width="300" height="300"" /></div><br />

    <form id="form1" runat="server" style="font-family: 'Trebuchet MS'; text-align: left; font-size:130%; width: 30%; height: auto; padding: 1% 4%; margin:0 auto; background-color: rgba(0, 0, 0, 0.5); border: 1px solid white; color: rgba(210, 210, 210);">
        <div>
            <h1 style="margin-top: 50px; text-align: center"><b>
                &nbsp;Supervisor Interface</b></h1>
            <hr />
            <br />
          
        </div>
        <div style="text-align: center">
            <asp:Button class="button button1" ID="Button1" runat="server"  Text="View Supervised Projects" OnClick="Button1_Click" />
            <br/><br/>
            <asp:Button class="button button1" ID="Button8" runat="server" Text="Review Supervised Projects" OnClick="Button8_Click" />
            <br/><br/>
            <asp:Button class="button button1" ID="Button9" runat="server" OnClick="Button9_Click" Text="View Notifications" />
            <br/><br/>
            <asp:LinkButton ID="LinkButton1" runat="server" href="https://www.facebook.com/FastNUIslamabadOfficial/" class="fa fa-facebook" ></asp:LinkButton>
            <asp:LinkButton ID="LinkButton2" runat="server" href="https://www.google.com/search?q=fast+university&client=opera-gx&hs=wx1&sxsrf=ALiCzsbfG69X8B4L7Z-UwWfgSmdpAbSy6w%3A1654385935266&ei=D-2bYtnqD--W9u8Pg_WDqAY&gs_ssp=eJzj4tTP1TcwyTG0sDBg9OJPSywuUSjNyyxLLSrOLKkEAHGHCQo&oq=fastun&gs_lcp=Cgdnd3Mtd2l6EAMYATIECAAQQzIHCC4QgAQQCjIHCAAQgAQQCjIFCAAQgAQyBwgAEIAEEAoyBQgAEIAEMgUIABCABDIFCAAQgAQyBQgAEIAEMgUIABCABDoHCCMQsAMQJzoHCAAQRxCwAzoHCAAQsAMQQzoPCC4Q1AIQyAMQsAMQQxgBOgwILhDIAxCwAxBDGAE6CggAELEDEIMBEEM6CwgAEIAEELEDEIMBOggIABCABBDJA0oECEEYAEoECEYYAVDpFlizGGC8I2gBcAF4AIAB7wKIAeIEkgEFMi0xLjGYAQCgAQHIARLAAQHaAQYIARABGAg&sclient=gws-wiz" class="fa fa-google"></asp:LinkButton>
            <asp:LinkButton ID="LinkButton3" runat="server" href="https://twitter.com/fastnu_official?lang=en" class="fa fa-twitter"></asp:LinkButton>
            <asp:LinkButton ID="LinkButton4" runat="server" href="https://www.youtube.com/watch?v=ofN-g6xc1Vw" class="fa fa-youtube"></asp:LinkButton>
             <asp:LinkButton ID="LinkButton5" runat="server" href="https://www.instagram.com/fast_nuces/?hl=en" class="fa fa-instagram"></asp:LinkButton>
            <br /> <br /> 
            <asp:Button class="button button1 button2" ID="Button2" runat="server" Text="Logout" OnClick="Button2_Click" />
            <br/><br/>
        </div>
    </form>
</body>
</html>

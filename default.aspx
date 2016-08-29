<%@ Page Title="" Language="C#" AutoEventWireup="true" CodeBehind="default.aspx.cs"
    Inherits="AdminTool._default" %>

<html>
<head>
    <head>
        <title>Infobyd | Complete Zoho Solution | CRM Solution Provider </title>
        <link href="images/favicon.ico" rel="shortcut icon" type="image/x-icon" />
        <!-- Google Fonts -->
        <link href='http://fonts.googleapis.com/css?family=Roboto+Condensed:300italic,400italic,700italic,400,300,700'
            rel='stylesheet' type='text/css'>
        <link href='http://fonts.googleapis.com/css?family=Open+Sans:400italic,600italic,400,300,600,700'
            rel='stylesheet' type='text/css'>
        <!-- Font awesome -->
        <link rel="stylesheet" href="css-js/vendor/font-awesome/css/font-awesome.min.css">
        <!-- mmenu -->
        <link type="text/css" rel="stylesheet" href="css-js/vendor/mmenu/css/jquery.mmenu.css" />
        <!-- Bootstrap css -->
        <link rel="stylesheet" href="css-js/vendor/bootstrap/css/bootstrap.css">
        <!-- Animate css -->
        <link rel="stylesheet" href="css-js/css/animate.css">
        <link rel="stylesheet" href="css-js/css/style.css">
        <link rel="stylesheet" type="text/css" href="css-js/css/slide_login_register.css">

        <style>
            input[type=submit], input[type=reset], input[type=button]{
                font-size:medium;
                font-weight: bold;
            }
            input[type=submit]{
                margin:0 1% 10px 0;
            }
            input[type=reset]{
                margin:0 17% 10px 0;
            }
        </style>
    </head>
</head>
<body>
    <div class="main"> 
			<header  class="header-part">
				<div id="home" class="wrapper"> 
					<!-- Fixed navbar -->
					<div class="navi navbar-default" role="navigation">
						<div class="container">
					  		<div class="navbar-header page-scroll"> 
								<a href="#menu">
									<button type="button" data-effect="st-effect-1" class="navbar-toggle collapsed" data-toggle="collapse" data-target="#navbar" aria-expanded="false" aria-controls="navbar"> 
										<span class="sr-only">Toggle navigation</span> <span class="icon-bar"></span> 
										<span class="icon-bar"></span> 
										<span class="icon-bar"></span> 
									</button>
								</a> 
								<a class="navbar-brand" href="index.php"><img src="images/logo-infobyd.png" alt="TechGut" style="position:relative; bottom:20px;"></a> 
							</div>
					  		<div id="navbar" class="navbar-collapse collapse pull-right hidden-xs">
								<ul class="nav navbar-nav navbar-right">
									<li><a href="http://infobyd.com/">Home</a></li>
							  		<li> <a href="index.php#about">about us</a></li>
									<li class="dropdown"> 
										<a class="page-scroll drop dropdown-toggle" href="">Product</a>
										<ul class="dropdown-menu" role="menu">
											<li><a href="http://mail2lead.infobyd.com/">IB-Mail2Lead</a></li>
										</ul>
              						  </li>
                                     <li><a href="frmPricingList.aspx">Plan & Pricing</a></li> 
							  		<li> <a class="page-scroll" href="index.php#services">services</a></li>
									<li> <a class="page-scroll" href="team.php">team</a></li>
									<li class="dropdown"> <a class="page-scroll drop dropdown-toggle" href="http://infobyd.com/zoho-knowledge-center/">Knowledge centre</a></li>
						  			<!--<li> <a href="texting-with-CRM.php">texting with CRM</a></li>-->
									<li><a class="page-scroll" href="#contact">Contact</a></li>
									<li><a class="page-scroll" href="faq.php">FAQ</a></li>
								</ul>
							</div>
							<!--/.nav-collapse --> 
						</div>
				  	</div>
				  	<!-- End of Nav --> 
				</div>
			</header>
		</div>
		<!-- End of class="main" --> 
        <div class="container" style="border-bottom: 1px solid #CCCCCC;">
            <div class="wow bounceInLeft" align="center">
                <div class="col-sm-6" style="border-right: 1px solid #CCCCCC; padding-top: 20px;">
                    <!--responsive video tag-->
                    <h1 class="section-title">
                        watch product video</h1>
                    <hr>
                    <div class="embed-responsive embed-responsive-16by9" style="margin-bottom: 20px;">
                        <iframe class="embed-responsive-item" src="https://www.youtube.com/embed/D-SgoaHv3h8">
                        </iframe>
                    </div>
                </div>
                <!--class="col-sm-12"-->
            </div>
            <!--class="col-sm-6"-->
            <div class="wow bounceInRight" align="center" id="form">
                <div class="col-sm-6" style="padding-top: 20px;">
                    <div class="row">
                        <div class="col-sm-5" style="border-right: 3px solid #CCCCCC;">
                            <h2>
                                <span><a href="#" class="slidelink" id="showlogin">Login</a></span></h2>
                        </div>
                        <div class="col-sm-7">
                            <h2>
                                <span><a href="#" class="leftsidelink" id="showregister">Request for demo</a></span></h2>
                        </div>
                    </div>
                    <br>
                    <hr>
                    <div class="row">
                        <div class="col-sm-12" align="center">
                            <div id="w">
                                <div id="page">
                                    <div id="content-login">
                                        <div class="content">
                                            <form id="login" runat="server" name="login" action="default.aspx" method="post"
                                            siq_id="autopick_6887">
                                            <!-- <input type="email" name="email" id="email" class="txtfield" tabindex="1" autocomplete="off"
                                                placeholder="enter your username">
                                         <input type="password" name="password" id="password" class="txtfield" tabindex="2"
                                                autocomplete="off" placeholder="enter your password"><br>
                                            <input type="submit" name="loginbtn" id="loginbtn" value="Login" class="btn" tabindex="3">-->
                                                <asp:TextBox runat="server" ID="UserName" class="txtfield" TabIndex="1" autocomplete="off"
                                                    placeholder=" Username" />
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="UserName"
                                                    CssClass="text-danger" ErrorMessage="required." Font-Size="10" />
                                            
                                            
                                                <asp:TextBox runat="server" ID="Password" TextMode="Password" class="txtfield" TabIndex="1"
                                                    autocomplete="off" placeholder="Password" />
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="Password"
                                                    CssClass="text-danger" ErrorMessage="required." Font-Size="10" />
                                                <br />
                                                <asp:Label runat=server ID="ErrorMessage" Text="" Visible=true ForeColor=Red ></asp:Label>
                                               <asp:Button runat="server" ID="LoginButton" OnClick="LoginButton_Click" UseSubmitBehavior="false" Visible="true" Text="Login" class="btn"/>
                                            </form>
                                        </div>
                                    </div>
                                    <!-- /end #content-login -->
                                    <div id="content-register">
                                        <div class="content">
                                            <div id="crmWebToEntityForm" style="margin-bottom: 20px;">
                                                <form action="https://crm.zoho.com/crm/WebToLeadForm" name="WebToLeads1969077000000184001"
                                                method="POST" onsubmit="javascript:document.charset=&quot;UTF-8&quot;; return checkMandatory()"
                                                accept-charset="UTF-8" siq_id="autopick_7431">
                                                <!-- Do not remove this code. -->
                                                <input type="text" style="display: none;" name="xnQsjsdp" value="503b1277ce765935cad00b408569539d664b47120f48e2939f823fc19530195f">
                                                <input type="hidden" name="zc_gad" id="zc_gad" value="">
                                                <input type="text" style="display: none;" name="xmIwtLD" value="0a566b3b44c3c2a7a75c31fd52b82ddd34f04d68c6700ad97f460c0e670ead26">
                                                <input type="text" style="display: none;" name="actionType" value="TGVhZHM=">
                                                <input type="text" style="display: none;" name="returnURL" value="http://www.infobyd.com">
                                                <!-- Do not remove this code. -->
                                                <input type="text" style="display: none;" id="ldeskuid" name="ldeskuid">
                                                <input type="text" style="display: none;" id="LDTuvid" name="LDTuvid">
                                                <!-- Do not remove this code. -->
                                                <input type="text" name="First Name" class="txtfield" tabindex="1" autocomplete="off"
                                                    placeholder="First Name">
                                                <input type="text" name="Last Name" class="txtfield" tabindex="1" autocomplete="off"
                                                    placeholder="Last Name">
                                                <input type="text" name="Email" class="txtfield" tabindex="1" autocomplete="off"
                                                    placeholder="Email Address">
                                                <input type="text" name="Company" class="txtfield" tabindex="1" autocomplete="off"
                                                    placeholder="Company name">
                                                <textarea name="Description" class="txtfield" tabindex="1" autocomplete="off" placeholder="Message"></textarea>
                                                <br>
                                                <input type="reset" value="Reset" class="btn pull-right">
                                                <input type="submit" value="Submit" class="btn pull-right">
                                                <script>
                                                    var mndFileds = new Array('Company', 'Last Name');
                                                    var fldLangVal = new Array('Company', 'Last Name');
                                                    var name = '';
                                                    var email = '';

                                                    function checkMandatory() {
                                                        for (i = 0; i < mndFileds.length; i++) {
                                                            var fieldObj = document.forms['WebToLeads1969077000000184001'][mndFileds[i]];
                                                            if (fieldObj) {
                                                                if (((fieldObj.value).replace(/^\s+|\s+$/g, '')).length == 0) {
                                                                    if (fieldObj.type == 'file') {
                                                                        alert('Please select a file to upload.');
                                                                        fieldObj.focus();
                                                                        return false;
                                                                    }
                                                                    alert(fldLangVal[i] + ' cannot be empty.');
                                                                    fieldObj.focus();
                                                                    return false;
                                                                } else if (fieldObj.nodeName == 'SELECT') {
                                                                    if (fieldObj.options[fieldObj.selectedIndex].value == '-None-') {
                                                                        alert(fldLangVal[i] + ' cannot be none.');
                                                                        fieldObj.focus();
                                                                        return false;
                                                                    }
                                                                } else if (fieldObj.type == 'checkbox') {
                                                                    if (fieldObj.checked == false) {
                                                                        alert('Please accept  ' + fldLangVal[i]);
                                                                        fieldObj.focus();
                                                                        return false;
                                                                    }
                                                                }
                                                                try {
                                                                    if (fieldObj.name == 'Last Name') {
                                                                        name = fieldObj.value;
                                                                    }
                                                                } catch (e) { }
                                                            }
                                                        }
                                                        trackVisitor();
                                                    }
                                                </script>
                                                <script type='text/javascript' id='VisitorTracking'>                                                   
                                                
                                                 var $zoho = $zoho || { salesiq: { values: {}, ready: function () { $zoho.salesiq.floatbutton.visible('hide'); } } }; var d = document; s = d.createElement('script'); s.type = 'text/javascript'; s.defer = true; s.src = 'https://salesiq.zoho.com/infobyd1/float.ls?embedname=infobyd'; t = d.getElementsByTagName('script')[0]; t.parentNode.insertBefore(s, t); function trackVisitor() { try { if ($zoho) { var LDTuvidObj = document.forms['WebToLeads1969077000000184001']['LDTuvid']; if (LDTuvidObj) { LDTuvidObj.value = $zoho.salesiq.visitor.uniqueid(); } var firstnameObj = document.forms['WebToLeads1969077000000184001']['First Name']; if (firstnameObj) { name = firstnameObj.value + ' ' + name; } $zoho.salesiq.visitor.name(name); var emailObj = document.forms['WebToLeads1969077000000184001']['Email']; if (emailObj) { email = emailObj.value; $zoho.salesiq.visitor.email(email); } } } catch (e) { } }</script>
                                                </form>
                                            </div>
                                        </div>
                                    </div>
                                    <!-- /end #content-register -->
                                </div>
                                <!-- /end #page -->
                            </div>
                            <!-- /end #w -->
                        </div>
                    </div>
                </div>
            </div>
            <!--class="col-sm-6"-->
        </div>
    </div>
    <!-- End of class="main" -->
    <!--id="box"-->
    <section class="wow zoomIn testimmonial section-padding animated" style="visibility: visible;
        animation-name: zoomIn;">
			<div class="container">
				<div class="row">
					<div class="wow zoomIn col-sm-12 text-center p-padding animated animated" style="visibility: visible; animation-name: zoomIn;">
						<h1 class="section-title">client says</h1><img src="images/red-box.png" /><br><br>
                        <marquee direction="up" height="270px" scrolldelay="170" onmouseover="this.stop();" onmouseout="this.start();" style="height: 270px;">
							<div>
								<img src="./LoginAssets/1.jpg" width="100px" style="margin-right:10px;" align="left">
								<span>“Infobyd is a world class expert in the Zoho Product (CRM/Campaign/Book/Creater). They helps us customize the solution and Migration. Always getting quick response whenever we need them urgently. Highly recommend.. excellent work. <br>Thank you”</span><br>
								<span class="pull-right"> <q>Mark Robert</q></span>
							</div><br><br><br>
							<div>
								<img src="./LoginAssets/testimonial.jpg" width="100px" style="margin-right:10px;" align="left">
								“Infobyd team worked with me when I had just finished having a negative experience with another elancer and won me back. They have been incredibly responsive positive and helpful. I am giving them plenty of further work as they have the ability to quarterback and get done most things all with a smile on their face. I'd strongly recommend them, will be working with them again and suggest you do too!”<br>
								<span class="pull-right"> <q>Matt Route</q></span>
							</div><br><br>
							<div>
								<img src="./LoginAssets/testimonial.jpg" width="100px" style="margin-right:10px;" align="left">
								“I have enjoyed working with Infobyd team and will hire them again. They was extremely patient with me as I didnt understand Zoho and was more than happy to explain in detail (sometimes more than once LOL). They was efficient and got the job done! Thank you Infobyd Team.”<br>
								<span class="pull-right"> <q>Zoho CRM Setup and Support</q></span>
							</div><br><br><br>
							<div>
								<img src="./LoginAssets/testimonial.jpg" width="100px" style="margin-right:10px;" align="left">
								“Very much appreciated working with infobyd, clear communication and quality of work.”<br>
								<span class="pull-right"> <q>ZoHo CRM implementer</q></span>
							</div>
						</marquee>	
					</div>
				</div>
			</div>
	  </section>
    <!-- testimonial -->
    <!-- footer -->
    <footer>
			<div class="footer-wrapper section-padding">
				<div class="container">
					<div class="row">
						<div class="wow zoomIn col-xs-12 col-sm-6 col-md-4" style="visibility: hidden; animation-name: none;"> <a href="http://infobyd.com/"><h1 style="color:#FFFFFF;">Infobyd</h1><!--<img src="img/footer-logo.png" alt="TechGut">--></a>
							<p class="footer-content">We make quick and informed decisions in a complex, fast-paced, competitive business environment and adopt innovations in technologies to create more value for customers which maximizing customer opportunity across the relationship lifecycle with offerings needed to gain repeat business and stability.</p>
					</div>
					<!-- /.col-xs-12 .col-sm-3 .col-md-3 -->
			
					<div class="wow zoomIn col-xs-12 col-sm-6 col-md-4" style="visibility: hidden; animation-name: none;">
						<p class="footer-heading">find us</p>
						<ul class="footercontact">
							<li><i class="flaticon-mainpage"></i><span>address:</span> 164, Chhoti Khazrani, MIG, Indore - 452010</li>
							<li><i class="flaticon-phone16"></i><span>phone:</span><a href="tel:0731 400 3293">0731 400 3293</a></li>
							<li><i class="flaticon-email21"></i><span>e-mail:</span><a href="mailto:team@infobyd.com"> team@infobyd.com</a></li>
							<li><i class="flaticon-world91"></i><span>web:</span><a href="http://infobyd.com/" target="_blank"> www.infobyd.com</a></li>
						</ul>
						<i class="flaticon-home78"></i> </div>
						<!-- /.col-xs-12 .col-sm-3 .col-md-3 -->
			
						<div class="wow zoomIn col-xs-12 col-sm-3 col-md-4" align="center" style="visibility: hidden; animation-name: none;">
							<p class="footer-heading">ZOHO Partner</p>
							<img src="./LoginAssets/PS1PSSHIN9NT-180x180.PNG" height="140">
							<img src="./LoginAssets/Authorized-partner.png">
						</div>
						<!-- /.col-xs-12 .col-sm-3 .col-md-3 -->
					</div>
					<!-- /.row --> 
				</div>
				<!-- /.container --> 
			</div>
			<div class="footer-bottom">
				<div class="container">
					<div class="row">
						<div class="wow zoomIn col-xs-12" style="visibility: hidden; animation-name: none;">
							<p>© 2015 All rights reserved. <a href="http://infobyd.com/" target="_blank">infobyd.com</a></p>
							<div class="backtop  pull-right"> <i class="fa fa-angle-up back-to-top" style="display: none;"></i> </div>
							<!-- /.backtop --> 
						</div>
						<!-- /.col-xs-12 --> 
					</div>
					<!-- /.row --> 
				</div>
				<!-- /.container --> 
			</div>
			<!-- /.creditwrapper --> 
		</footer>
    <!-- /Footer -->

<!-- MENU -->
		<nav id="menu">
		<ul>
		  <li><a href="#home">home</a></li>
		  <li><a href="#about">about us</a></li>
		  <li> 
			<a href="">Product</a>
			<ul>
				<li><a href="http://mail2lead.infobyd.com/">IB-Mail2Lead</a></li>
			</ul>
			</li>
		  <li><a href="#services">services</a></li>
		  <li><a href="team.php">team</a></li>
		  <li><a href="http://infobyd.com/blog/">knowledge centre</a></li>
		  <li><a href="faq.php">faq</a></li>
		  <li><a href="#contact">contact</a></li>
		</ul>
		</nav>
  		<!-- /#menu --> 
  	</div>
	<!-- /.main --> 

    <!-- jQuery JS -->
    <script data-cfasync="false" src="css-js/js/jquery-1.11.1.js"></script>
    <!-- Modernizr JS -->
    <script data-cfasync="false" src="css-js/js/modernizr-2.6.2.min.js"></script>
    <!-- REVOLUTION Slider  -->
    <script data-cfasync="false" type="text/javascript" src="css-js/vendor/rs-plugin/js/jquery.themepunch.plugins.min.js"></script>
    <script data-cfasync="false" type="text/javascript" src="css-js/vendor/rs-plugin/js/jquery.themepunch.revolution.js"></script>
    <!-- Shuffle JS -->
    <script data-cfasync="false" src="css-js/js/jquery.shuffle.min.js"></script>
    <!-- mmenu -->
    <script data-cfasync="false" type="text/javascript" src="css-js/vendor/mmenu/js/jquery.mmenu.min.js"></script>
    <!-- Owl Carosel -->
    <script data-cfasync="false" src="css-js/vendor/owl/js/owl.carousel.min.js"></script>
    <script data-cfasync="false" src="css-js/js/wow.min.js"></script>
    <!-- waypoints JS-->
    <script data-cfasync="false" src="css-js/js/waypoints.min.js"></script>
    <!-- Counterup JS -->
    <script data-cfasync="false" src="css-js/js/jquery.counterup.min.js"></script>
    <!-- Custom Script JS -->
    <script data-cfasync="false" src="css-js/js/script.js"></script>
    <!-- Email JS -->
    <script data-cfasync="false" src="css-js/js/email.js"></script>
    <script type="text/javascript" src="css-js/js/formslider.js"></script>
</body>
</html>

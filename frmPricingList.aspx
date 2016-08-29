<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="frmPricingList.aspx.cs" Inherits="AdminTool.frmPricingList" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
    <head runat="server">
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
        <link rel="stylesheet" href="css-js/css/zoho-plans.css">
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
                                    <li><a href="frmPricingList.aspx"> Plan & Pricing</a></li> 
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

    <div class="container" id="padding">
	<div class="row">
		<div class="col-sm-12" align="right">
			<a href="#" class="slidelink" id="showlogin"><img src="images/indian-rupee-symbol.png" width="10px"/></a>&nbsp;&nbsp;&nbsp;|&nbsp;&nbsp;&nbsp;
			<a href="#" class="leftsidelink" id="showregister"><img src="images/yck49aazi.png" width="10px"/></a>
		</div>
		
		<div class="col-sm-12" id="free-trial"><h1>15 Days Free Trial. <strong>No credit card required.</strong></h1></div>
		
		<div class="col-sm-4" id="first">
			<div id="head">
				<h1>BASIC</h1>
				<div id="w">
					<div id="page">
						<div id="content-login">
							<div class="content"><h1 id="rs"><sup>&#x20B9;</sup> 300<span style="text-transform:none">/-month</span></h1>Our Basic Plan</div>
						</div>
						<div id="content-register">
							<div class="content"><h1 id="rs"><sup>&#36;</sup> 5<span style="text-transform:none">/-month</span></h1>Our Basic Plan</div>
						</div>
					</div>
				</div>
			</div>
			<ul>
				<li>Mail support</li>
				<li>3 Template</li>
				<li>250/- month (API)</li>
			</ul>
			
			<div align="center" style="margin-top:40px;">
				<a href="#openModal"><button class="btn btn-default">CONTACT US</button></a>
			</div>
		</div><!--id="first"-->
		
		<div class="col-sm-4" id="second">
			<div class="col-sm-12" align="center" style="border-bottom:1px solid #CCCCCC; margin-bottom:20px;">
				<a href="#" class="slidelink" id="showlogin">Monthly</a>&nbsp;&nbsp;&nbsp;|&nbsp;&nbsp;&nbsp;
				<a href="#" class="leftsidelink" id="showregister">Yearly</a>
			</div>
			
			<div id="head">
				<h1>STANDARD</h1>
				<div id="w">
					<div id="page1">
						<div id="content-login-new">
							<div class="content"><h1 id="rs"><sup>&#x20B9;</sup> 700<span style="text-transform:none">/-month</span></h1>Our Most Popular Plan</div>
						</div>
						<div id="content-register-new">
							<div class="content"><h1 id="rs"><sup>&#36;</sup> 12<span style="text-transform:none">/-month</span></h1>Our Basic Plan</div>
						</div>
					</div>
				</div>
			</div>
			<ul>
				<li>1000 API calls</li>
				<li>Mail support</li>
				<li>Call support</li>
				<li>5 Template</li>
				<li>Analytics</li>
				<li>Monitoring</li>
			</ul>
			
			<div align="center" style="margin-top:40px;">
				<a href="#openModal"><button class="btn btn-default">CONTACT US</button></a>
			</div>
		</div><!--id="second"-->
		
		<div class="col-sm-4" id="third">
			<div id="head">
				<h1>UNLIMITED EDITION</h1>
				<div id="w">
					<div id="page2">
						<div id="content-login-third">
							<div class="content"><h1 id="rs"><sup>&#x20B9;</sup> 1200<span style="text-transform:none">/-month</span></h1>Our Basic Plan</div>
						</div>
						<div id="content-register-third">
							<div class="content"><h1 id="rs"><sup>&#36;</sup> 20<span style="text-transform:none">/-month</span></h1>Our Basic Plan</div>
						</div>
					</div>
				</div>
			</div>
			<ul>
				<li>Unlimited API call</li>
				<li>Mail support</li>
				<li>Call support</li>
				<li>Report on your mail</li>
				<li>Unlimited Template</li>
				<li>Analytics</li>
			</ul>
			
			<div align="center" style="margin-top:40px;">
				<a href="#openModal"><button class="btn btn-default">CONTACT US</button></a>
			</div>
		</div><!--class="col-sm-4" id="third"-->
	</div><!--class row-->
</div><!--class container-->

<div id="openModal" class="modalDialog">
    <div style="padding-top:10px;">	
        <a href="#close" title="Close" class="close">X</a>
        <h2 style="border-bottom:1px solid #333333; text-align:center;">Request for Demo</h2>
        <form action='https://crm.zoho.com/crm/WebToLeadForm' name=WebToLeads1969077000000184001 method='POST' onSubmit='javascript:document.charset="UTF-8"; return checkMandatory()' accept-charset='UTF-8'>
			<!-- Do not remove this code. -->
			<input type='text' style='display:none;' name='xnQsjsdp' value='503b1277ce765935cad00b408569539d664b47120f48e2939f823fc19530195f'/>
			<input type='hidden' name='zc_gad' id='zc_gad' value=''/>
			<input type='text' style='display:none;' name='xmIwtLD' value='0a566b3b44c3c2a7a75c31fd52b82ddd34f04d68c6700ad97f460c0e670ead26'/>
			<input type='text' style='display:none;'  name='actionType' value='TGVhZHM='/>
		
			<input type='text' style='display:none;' name='returnURL' value='http&#x3a;&#x2f;&#x2f;www.infobyd.com' /> 
			 <!-- Do not remove this code. -->
			<input type='text' style='display:none;' id='ldeskuid' name='ldeskuid'></input>
			<input type='text' style='display:none;' id='LDTuvid' name='LDTuvid'></input>
			 <!-- Do not remove this code. -->
			
			<div class="form-inline">
				<div class="form-group" style="margin:40px 0 10px 0;">
					<input type='text' class='form-control' name='First Name' placeholder='First Name' size="50"/>
				</div>
				<div class="form-group" style="margin:10px 0 10px 0;">
					<input type='text' class='form-control' name='Last Name' placeholder='Last Name' size="50"/>
				</div>
				<div class="form-group" style="margin:10px 0 10px 0;">
					<input type='text' class='form-control'  name='Company' placeholder='Company' size="50"/>
				</div>
				<div class="form-group" style="margin:10px 0 10px 0;">
					<input type='text' class='form-control' name='Email' placeholder='Email Address' size="50"/>
				</div>
			</div>
			<div class="form-group" style="margin:10px 0 10px 0;">
				<textarea name='Description' class='form-control' placeholder='Message'></textarea>
			</div>
			<div class="form-group">
				<div id='mail_success' class='success' style="display:none;">Your message has been sent successfully. </div>
				<!-- success message -->
				<div id='mail_fail' class='error' style="display:none;"> Sorry, error occured this time sending your message. </div>
				<!-- error message --> 
			</div>
			<div class="form-group col-sm-12" align="right" style="padding:0px;">
				<input  class="btn" type='submit' value='Submit' />
				<input type='reset' class="btn" value='Reset'/>
			</div><br /><br />
			
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
		</script><script type='text/javascript' id='VisitorTracking'>		             var $zoho = $zoho || { salesiq: { values: {}, ready: function () { $zoho.salesiq.floatbutton.visible('hide'); } } }; var d = document; s = d.createElement('script'); s.type = 'text/javascript'; s.defer = true; s.src = 'https://salesiq.zoho.com/infobyd1/float.ls?embedname=infobyd'; t = d.getElementsByTagName('script')[0]; t.parentNode.insertBefore(s, t); function trackVisitor() { try { if ($zoho) { var LDTuvidObj = document.forms['WebToLeads1969077000000184001']['LDTuvid']; if (LDTuvidObj) { LDTuvidObj.value = $zoho.salesiq.visitor.uniqueid(); } var firstnameObj = document.forms['WebToLeads1969077000000184001']['First Name']; if (firstnameObj) { name = firstnameObj.value + ' ' + name; } $zoho.salesiq.visitor.name(name); var emailObj = document.forms['WebToLeads1969077000000184001']['Email']; if (emailObj) { email = emailObj.value; $zoho.salesiq.visitor.email(email); } } } catch (e) { } }</script>
		</form>
    </div>
</div>
    
    </div>
    </form>
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
<script>
    function modalClose() {
        if (location.hash == '#openModal') {
            location.hash = '';
        }
    }

    document.addEventListener('keyup', function (e) {
        if (e.keyCode == 27) {
            modalClose();
        }
    });

    var modal = document.querySelector('#openModal');
    modal.addEventListener('click', function (e) {
        modalClose();
    }, false);

    modal.children[0].addEventListener('click', function (e) {
        e.stopPropagation();
    }, false);
</script>
</body>

</html>

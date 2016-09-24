﻿using System;
using System.Collections;
using System.Collections.Specialized;
using System.IO;
using System.Net;
using System.Text;
using System.Data;
using System.Configuration;
using System.Web;
using System.Collections.Generic;
using System.Linq;

public class NVPAPICaller
{
    //Flag that determines the PayPal environment (live or sandbox)
    private const bool bSandbox = false;
    private const string CVV2 = "CVV2";

    // Live strings.
    private string pEndPointURL = "https://api-3t.paypal.com/nvp";
    private string host = "www.paypal.com";

    // Sandbox strings.
    private string pEndPointURL_SB = "https://api-3t.sandbox.paypal.com/nvp";
    private string host_SB = "www.sandbox.paypal.com";

    private const string SIGNATURE = "SIGNATURE";
    private const string PWD = "PWD";
    private const string ACCT = "ACCT";

    //Replace <Your API Username> with your API Username
    //Replace <Your API Password> with your API Password
    //Replace <Your Signature> with your Signature

    //This is sandbox Credential, Uncomment when we want sandbox paypal
    //public string APIUsername = "gettomahesh-facilitator_api1.yahoo.com";
    //private string APIPassword = "1393917556";
    //private string APISignature = "AFcWxV21C7fd0v3bYYYRCpSSRl31AntuypuaRoJKBirHlHBn1SfIR6l8";
    //private string Subject = "";
    //private string BNCode = "PP-ECWizard";


    //This is Live Credential, Uncomment when we want live paypal
    public string APIUsername =ConfigurationManager.AppSettings["APIUsername"].ToString();
    private string APIPassword =ConfigurationManager.AppSettings["APIPassword"].ToString(); 
    private string APISignature = ConfigurationManager.AppSettings["APISignature"].ToString();
    private string Subject = "";
    private string BNCode = "PP-ECWizard";


    //HttpWebRequest Timeout specified in milliseconds 
    private const int Timeout = 15000000;
    private static readonly string[] SECURED_NVPS = new string[] { ACCT, CVV2, SIGNATURE, PWD };

    public void SetCredentials(string Userid, string Pwd, string Signature)
    {
        APIUsername = Userid;
        APIPassword = Pwd;
        APISignature = Signature;
    }

    public bool ShortcutExpressCheckout(string amt, ref string token, ref string retMsg)
    {
        if (bSandbox)
        {
            pEndPointURL = pEndPointURL_SB;
            host = host_SB;
        }

        string returnURL = ConfigurationManager.AppSettings["returnURL"].ToString();
        string cancelURL = ConfigurationManager.AppSettings["cancelURL"].ToString();

        NVPCodec encoder = new NVPCodec();
        encoder["METHOD"] = "SetExpressCheckout";
        encoder["RETURNURL"] = returnURL;
        encoder["CANCELURL"] = cancelURL;
        encoder["BRANDNAME"] = "GST";//HttpContext.Current.Session["BrandName"].ToString();
        encoder["PAYMENTREQUEST_0_AMT"] = amt;
        encoder["PAYMENTREQUEST_0_ITEMAMT"] = amt;
        encoder["PAYMENTREQUEST_0_PAYMENTACTION"] = "Sale";
        encoder["PAYMENTREQUEST_0_CURRENCYCODE"] = "USD";

        // Get the Products
        
        encoder["L_PAYMENTREQUEST_0_NAME" + 0] = HttpContext.Current.Session["payment_name"].ToString();
        encoder["L_PAYMENTREQUEST_0_AMT" + 0] = HttpContext.Current.Session["payment_amt"].ToString();
        encoder["L_PAYMENTREQUEST_0_QTY" + 0] = HttpContext.Current.Session["payment_qty"].ToString();
        string pStrrequestforNvp = encoder.Encode();
        string pStresponsenvp = HttpCall(pStrrequestforNvp);

        NVPCodec decoder = new NVPCodec();
        decoder.Decode(pStresponsenvp);

        string strAck = decoder["ACK"].ToLower();
        if (strAck != null && (strAck == "success" || strAck == "successwithwarning"))
        {
            token = decoder["TOKEN"];
            string ECURL = "https://" + host + "/cgi-bin/webscr?cmd=_express-checkout" + "&token=" + token;
            retMsg = ECURL;
            return true;
        }
        else
        {
            retMsg = "ErrorCode=" + decoder["L_ERRORCODE0"] + "&" +
                "Desc=" + decoder["L_SHORTMESSAGE0"] + "&" +
                "Desc2=" + decoder["L_LONGMESSAGE0"];
            return false;
        }
    }

    public bool GetCheckoutDetails(string token, ref string PayerID, ref NVPCodec decoder, ref string retMsg)
    {
        if (bSandbox)
        {
            pEndPointURL = pEndPointURL_SB;
        }

        NVPCodec encoder = new NVPCodec();
        encoder["METHOD"] = "GetExpressCheckoutDetails";
        encoder["TOKEN"] = token;

        string pStrrequestforNvp = encoder.Encode();
        string pStresponsenvp = HttpCall(pStrrequestforNvp);

        decoder = new NVPCodec();
        decoder.Decode(pStresponsenvp);

        string strAck = decoder["ACK"].ToLower();
        if (strAck != null && (strAck == "success" || strAck == "successwithwarning"))
        {
            PayerID = decoder["PAYERID"];
            return true;
        }
        else
        {
            retMsg = "ErrorCode=" + decoder["L_ERRORCODE0"] + "&" +
                "Desc=" + decoder["L_SHORTMESSAGE0"] + "&" +
                "Desc2=" + decoder["L_LONGMESSAGE0"];

            return false;
        }
    }

    public bool DoCheckoutPayment(string finalPaymentAmount, string token, string PayerID, ref NVPCodec decoder, ref string retMsg)
    {
        if (bSandbox)
        {
            pEndPointURL = pEndPointURL_SB;
        }

        NVPCodec encoder = new NVPCodec();
        encoder["METHOD"] = "DoExpressCheckoutPayment";
        encoder["TOKEN"] = token;
        encoder["PAYERID"] = PayerID;
        encoder["PAYMENTREQUEST_0_AMT"] = finalPaymentAmount;
        encoder["PAYMENTREQUEST_0_CURRENCYCODE"] = "USD";
        encoder["PAYMENTREQUEST_0_PAYMENTACTION"] = "Sale";

        string pStrrequestforNvp = encoder.Encode();
        string pStresponsenvp = HttpCall(pStrrequestforNvp);

        decoder = new NVPCodec();
        decoder.Decode(pStresponsenvp);

        string strAck = decoder["ACK"].ToLower();
        if (strAck != null && (strAck == "success" || strAck == "successwithwarning"))
        {
            return true;
        }
        else
        {
            retMsg = "ErrorCode=" + decoder["L_ERRORCODE0"] + "&" +
                "Desc=" + decoder["L_SHORTMESSAGE0"] + "&" +
                "Desc2=" + decoder["L_LONGMESSAGE0"];

            return false;
        }
    }

    public string HttpCall(string NvpRequest)
    {
        string url = pEndPointURL;

        string strPost = NvpRequest + "&" + buildCredentialsNVPString();
        strPost = strPost + "&BUTTONSOURCE=" + HttpUtility.UrlEncode(BNCode);

        HttpWebRequest objRequest = (HttpWebRequest)WebRequest.Create(url);
        objRequest.Timeout = Timeout;
        objRequest.Method = "POST";
        objRequest.ContentLength = strPost.Length;

        try
        {
            using (StreamWriter myWriter = new StreamWriter(objRequest.GetRequestStream()))
            {
                myWriter.Write(strPost);
            }
        }
        catch (Exception e)
        {
            // Log the exception.
           
        }


        //Retrieve the Response returned from the NVP API call to PayPal.
        HttpWebResponse objResponse = (HttpWebResponse)objRequest.GetResponse();
        string result;
        using (StreamReader sr = new StreamReader(objResponse.GetResponseStream()))
        {
            result = sr.ReadToEnd();
        }

        return result;
    }

    private string buildCredentialsNVPString()
    {
        NVPCodec codec = new NVPCodec();

        if (!IsEmpty(APIUsername))
            codec["USER"] = APIUsername;

        if (!IsEmpty(APIPassword))
            codec[PWD] = APIPassword;

        if (!IsEmpty(APISignature))
            codec[SIGNATURE] = APISignature;

        if (!IsEmpty(Subject))
            codec["SUBJECT"] = Subject;

        codec["VERSION"] = "88.0";

        return codec.Encode();
    }

    public static bool IsEmpty(string s)
    {
        return s == null || s.Trim() == string.Empty;
    }
}

public sealed class NVPCodec : NameValueCollection
{
    private const string AMPERSAND = "&";
    private const string EQUALS = "=";
    private static readonly char[] AMPERSAND_CHAR_ARRAY = AMPERSAND.ToCharArray();
    private static readonly char[] EQUALS_CHAR_ARRAY = EQUALS.ToCharArray();

    public string Encode()
    {
        StringBuilder sb = new StringBuilder();
        bool firstPair = true;
        foreach (string kv in AllKeys)
        {
            string name = HttpUtility.UrlEncode(kv);
            string value = HttpUtility.UrlEncode(this[kv]);
            if (!firstPair)
            {
                sb.Append(AMPERSAND);
            }
            sb.Append(name).Append(EQUALS).Append(value);
            firstPair = false;
        }
        return sb.ToString();
    }

    public void Decode(string nvpstring)
    {
        Clear();
        foreach (string nvp in nvpstring.Split(AMPERSAND_CHAR_ARRAY))
        {
            string[] tokens = nvp.Split(EQUALS_CHAR_ARRAY);
            if (tokens.Length >= 2)
            {
                string name = HttpUtility.UrlDecode(tokens[0]);
                string value = HttpUtility.UrlDecode(tokens[1]);
                Add(name, value);
            }
        }
    }

    public void Add(string name, string value, int index)
    {
        this.Add(GetArrayName(index, name), value);
    }

    public void Remove(string arrayName, int index)
    {
        this.Remove(GetArrayName(index, arrayName));
    }

    public string this[string name, int index]
    {
        get
        {
            return this[GetArrayName(index, name)];
        }
        set
        {
            this[GetArrayName(index, name)] = value;
        }
    }

    private static string GetArrayName(int index, string name)
    {
        if (index < 0)
        {
            throw new ArgumentOutOfRangeException("index", "index cannot be negative : " + index);
        }
        return name + index;
    }
}
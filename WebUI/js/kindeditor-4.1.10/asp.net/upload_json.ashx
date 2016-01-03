﻿<%@ webhandler Language="C#" class="Upload" %>

/**
 * KindEditor ASP.NET
 *
 * 本ASP.NET程序是演示程序，建议不要直接在实际项目中使用。
 * 如果您确定直接使用本程序，使用之前请仔细确认相关安全设置。
 *
 */

using System;
using System.Collections;
using System.Web;
using System.IO;
using System.Globalization;
using LitJson;

public class Upload : IHttpHandler
{
	private HttpContext context;

	public void ProcessRequest(HttpContext context)
	{
        //String aspxUrl = context.Request.Path.Substring(0, context.Request.Path.LastIndexOf("/") + 1);
        //ManageFcmsCommon.XmlHelper xmlHelper = new ManageFcmsCommon.XmlHelper(context.Server.MapPath("~/Config/upload.xml"));

        //String aspxUrl = xmlHelper.GetText("upload/remoteDomain");
        
        ////文件保存目录路径
        //String savePath = xmlHelper.GetText("upload/localDir");

        ////文件保存目录URL
        //String saveUrl = aspxUrl + "/attached/";

        //文件保存目录路径
        String savePath = Common.ConfigHelper.ImgPhysicallPath + DateTime.Now.ToString("yyyyMMdd") + "/";

        //文件保存目录URL
        String saveUrl = Common.ConfigHelper.ImgVirtualPath + DateTime.Now.ToString("yyyyMMdd") + "/";

		//定义允许上传的文件扩展名
		var extTable = new Hashtable {{"image", "gif,jpg,jpeg,png,bmp"}, {"media", "mp4"}};
	    //extTable.Add("flash", "swf,flv");
	    //extTable.Add("media", "swf,flv,mp3,wav,wma,wmv,mid,avi,mpg,asf,rm,rmvb");
        //extTable.Add("file", "doc,docx,xls,xlsx,ppt,htm,html,txt,zip,rar,gz,bz2");

		//最大文件大小
		const int maxSize = 1000000;
		this.context = context;

        //HttpPostedFile imgFile = context.Request.Files["imgFile"];
        HttpPostedFile imgFile = context.Request.Files[0];
		if (imgFile == null)
		{
			showError("请选择文件。");
		}

        //String dirPath = context.Server.MapPath(savePath);
        String dirPath = savePath;
		if (!Directory.Exists(dirPath))
		{
            Directory.CreateDirectory(dirPath);
		}

		String dirName = context.Request.QueryString["dir"];
		if (String.IsNullOrEmpty(dirName)) {
			dirName = "image";
		}
		if (!extTable.ContainsKey(dirName)) {
			showError("目录名不正确。");
		}

		String fileName = imgFile.FileName;
		String fileExt = Path.GetExtension(fileName).ToLower();

		if (imgFile.InputStream.Length > maxSize)
		{
			showError("上传文件大小超过限制。");
		}

		if (String.IsNullOrEmpty(fileExt) || Array.IndexOf(((String)extTable[dirName]).Split(','), fileExt.Substring(1).ToLower()) == -1)
		{
			showError("上传文件扩展名是不允许的扩展名。\n只允许" + ((String)extTable[dirName]) + "格式。");
		}

		//创建文件夹
        //dirPath += dirName + "\\";
        //saveUrl += dirName + "/";
        
        //if (!Directory.Exists(dirPath)) {
        //    Directory.CreateDirectory(dirPath);
        //}
        //String ymd = DateTime.Now.ToString("yyyyMMdd", DateTimeFormatInfo.InvariantInfo);
        //dirPath += ymd + "/";
        //saveUrl += ymd + "/";
        
		if (!Directory.Exists(dirPath)) {
			Directory.CreateDirectory(dirPath);
		}

        String newFileName = Guid.NewGuid() + fileExt;
        String filePath = dirPath + newFileName;

		imgFile.SaveAs(filePath);

        String fileUrl = saveUrl + newFileName;

		Hashtable hash = new Hashtable();
		hash["error"] = 0;
		hash["url"] = fileUrl;
        hash["fileName"] = newFileName;
		context.Response.AddHeader("Content-Type", "text/html; charset=UTF-8");
		context.Response.Write(JsonMapper.ToJson(hash));
		context.Response.End();
	}

	private void showError(string message)
	{
		Hashtable hash = new Hashtable();
		hash["error"] = 1;
		hash["message"] = message;
		context.Response.AddHeader("Content-Type", "text/html; charset=UTF-8");
		context.Response.Write(JsonMapper.ToJson(hash));
		context.Response.End();
	}

	public bool IsReusable
	{
		get
		{
			return true;
		}
	}
}

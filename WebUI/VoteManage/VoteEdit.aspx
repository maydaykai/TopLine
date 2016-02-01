﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="VoteEdit.aspx.cs" Inherits="WebUI.VoteManage.VoteEdit" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>添加投票</title>
    <link href="/css/icon.css" rel="stylesheet" />
    <link href="../css/global.css" rel="stylesheet" />
    <script src="/js/jquery.tzCheckbox/jquery.min.js"></script>
    <script src="../js/lhgdialog/lhgdialog.min.js"></script>
    <script src="../js/lhgdialog/ShowDialog.js"></script>

</head>
<body style="margin:0;padding: 0;">
    <form id="form1" runat="server">
        <div style="font-size: 14px;width:250px; margin:0 auto;">
            <div>
                <span class="fl" style="margin-top:10px;">投票名称：</span>
                <span class="fl" style="margin-top:5px;">
                    <span class="fl">
                        <img src="/images/input_left.png" width="4" height="29" alt="" />
                    </span>
                    <input id="txtChannelName" type="text" runat="server" class="input_text" />
                    <span class="fl">
                        <img src="../images/input_right.png" style="width: 4px; height: 29px;" alt="" />
                    </span>
                </span>
            </div>
            <div>
                <span class="fl" style="margin-top:10px;">投票名称：</span>
                <span class="fl" style="margin-top:5px;">
                    <span class="fl">
                        <img src="/images/input_left.png" width="4" height="29" alt="" />
                    </span>
                    <input id="Text1" type="text" runat="server" class="input_text" />
                    <span class="fl">
                        <img src="../images/input_right.png" style="width: 4px; height: 29px;" alt="" />
                    </span>
                </span>
            </div>
            <div>
                <span class="fl" style="margin-top:10px;">投票名称：</span>
                <span class="fl" style="margin-top:5px;">
                    <span class="fl">
                        <img src="/images/input_left.png" width="4" height="29" alt="" />
                    </span>
                    <input id="Text2" type="text" runat="server" class="input_text" />
                    <span class="fl">
                        <img src="../images/input_right.png" style="width: 4px; height: 29px;" alt="" />
                    </span>
                </span>
            </div>
            <div>
                <span class="fl" style="margin-top:10px;">投票名称：</span>
                <span class="fl" style="margin-top:5px;">
                    <span class="fl">
                        <img src="/images/input_left.png" width="4" height="29" alt="" />
                    </span>
                    <input id="Text3" type="text" runat="server" class="input_text" />
                    <span class="fl">
                        <img src="../images/input_right.png" style="width: 4px; height: 29px;" alt="" />
                    </span>
                </span>
            </div>
            <div style="clear: both; text-align: center;">
                <asp:Button ID="Button1" runat="server" Text="提交" CssClass="inputButton" OnClick="Operate_Click" OnClientClick="javascript:$.dialog.tips('数据加载中...',6000,'loading.gif');" />
            </div>
        </div>
    </form>
</body>
</html>

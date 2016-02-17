<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="VoteEdit.aspx.cs" Inherits="WebUI.VoteManage.VoteEdit" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <link href="/css/icon.css" rel="stylesheet" />
    <link href="/css/global.css" rel="stylesheet" />
    <link href="/css/select.css" rel="stylesheet" />
    <link href="/js/jquery.tzCheckbox/jquery.tzCheckbox.css" rel="stylesheet" />
    <link rel="stylesheet" href="/js/kindeditor-4.1.10/themes/default/default.css" />
    <link rel="stylesheet" href="/js/kindeditor-4.1.10/plugins/code/prettify.css" />
    <script src="/js/jquery.tzCheckbox/jquery.min.js"></script>
    <script src="/js/jquery.tzCheckbox/jquery.tzCheckbox.js"></script>
    <script src="/js/lhgdialog/lhgcore.lhgdialog.min.js"></script>
    <script src="/js/lhgdialog/ShowDialog.js"></script>
    <%--<script src="/js/select2css.js"></script>--%>
    <script src="../js/My97DatePicker/WdatePicker.js"></script>
    <script charset="utf-8" src="/js/kindeditor-4.1.10/kindeditor.js"></script>
    <script charset="utf-8" src="/js/kindeditor-4.1.10/lang/zh_CN.js"></script>
    <script charset="utf-8" src="/js/kindeditor-4.1.10/plugins/code/prettify.js"></script>
    <script src="../js/juploader-1.0/jquery.jUploader-1.0.js"></script>
    <style type="text/css">
        .selectDiv .select_box {
            width:175px;
        }
        .selectDiv ul {
            width:190px;
        }
         .noBorderTable {
            border:none;
        }
            .noBorderTable td {
                border:none;
            }
        .imgS {
            max-width:400px;
            width:expression(document.body.clientWidth > 400?"400px":"auto" );
        }
    </style>
    <script type="text/javascript">  
        $(function () {
            $(':checkbox').tzCheckbox({ labels: ['Enable', 'Disable'] });
            var editor;
            KindEditor.ready(function (K) {
                editor = K.create('#<%=txtContent.ClientID%>', {
                    cssPath: '/js/kindeditor-4.1.10/plugins/code/prettify.css',
                    uploadJson: '/js/kindeditor-4.1.10/asp.net/upload_json.ashx',
                    afterCreate: function () {
                        var self = this;
                        K.ctrl(document, 13, function () {
                            self.sync();
                            K('form[name=form1]')[0].submit();
                        });
                        K.ctrl(self.edit.doc, 13, function () {
                            self.sync();
                            K('form[name=form1]')[0].submit();
                        });
                    }
                });
                prettyPrint();
            });
            $.jUploader.setDefaults({
                cancelable: true,
                allowedExtensions: ['jpg', 'png', 'gif','jpeg'],
                messages: {
                    upload: '上传',
                    cancel: '取消',
                    emptyFile: "{file} 为空，请选择一个文件.",
                    invalidExtension: "{file} 后缀名不合法. 只有 {extensions} 是允许的.",
                    onLeave: "文件正在上传，如果你现在离开，上传将会被取消。"
                }
            });
            $.jUploader({
                button: 'btnUpload', // 这里设置按钮id
                action: '/js/kindeditor-4.1.10/asp.net/upload_json.ashx', // 这里设置上传处理接口

                // 开始上传事件
                onUpload: function (fileName) {
                    $('#uploadTip').text('正在上传 ' + fileName + ' ...');
                },

                // 上传完成事件
                onComplete: function (fileName, response) {
                    if (response.error == "0" || response.error == 0) {
                        $('#<%=imgCoverImg.ClientID%>').attr('src', response.url);
                        $('#<%=hiCoverImg.ClientID%>').val(response.fileName);
                        $('#uploadTip').text(fileName + ' 上传成功');
                    } else {
                        $('#uploadTip').text('上传失败');
                    }
                },

                // 取消上传事件
                onCancel: function (fileName) {
                    $('#uploadTip').text(fileName + ' 上传取消');
                },

                // 系统信息显示
                showMessage: function (message) {
                    $('#uploadTip').text(message);
                }
            });
            $("#selArticleType").change(function() {
                if (this.value == "play")
                    $("#cover").show();
                else
                    $("#cover").hide();
            });
        });
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table cellpadding="0" cellspacing="0" class="editTable" border="0" style="min-width:800px;">
                <tr>
                    <td style="text-align: right; width: 150px;">投票标题：</td>
                    <td style="text-align: left; padding-left: 5px;">
                        <div style="float: left; margin-bottom: -3px;">
                            <span class="fl">
                                <img src="../images/input_left.png" style="width: 4px; height: 29px;" alt="" />
                            </span>
                            <input id="txtTitle" type="text" value="" class="input_text fl" style="width: 400px;" runat="server" />
                            <span class="fl">
                                <img src="../images/input_right.png" style="width: 4px; height: 29px;" alt="" />
                            </span>
                        </div>
                    </td>
                </tr>
                <tr id="cover" runat="server">
                    <td style="text-align: right;">封面图片：</td>
                    <td style="text-align: left; padding-left: 5px;">
                        <table class="noBorderTable">
                            <tr>
                                <td>
                                    <img class="fl imgS" src="../images/news_con_title.png" style="margin: 3px 3px 6px 0px; display: inline-block;" id="imgCoverImg" runat="server" />
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <div id="btnUpload" style="text-align: center;" class="fl inputButton"><span></span></div>
                                    <div id="uploadTip" style="margin-top: 10px; margin-left: 10px;" class="fl">请选择文件</div>
                                    <input type="hidden" id="hiCoverImg" runat="server" />
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td style="text-align: right; ">有效期：</td>
                    <td style="text-align: left; padding-left: 5px;">
                        <div style="float: left; margin-bottom: -3px;">
                            <span class="fl">
                                <img src="../images/input_left.png" style="width: 4px; height: 29px;" alt="" />
                            </span>
                            <input id="txtBeginDate" type="text" value="" class="input_text fl" maxlength="20" style="width: 100px;" disabled="disabled" runat="server" onclick="WdatePicker({ dateFmt: 'yyyy-MM-dd' })" />
                            <span class="fl">
                                <img src="../images/input_right.png" style="width: 4px; height: 29px;" alt="" />
                            </span>
                        </div>
                        <div style="float: left; margin-bottom: -3px;">
                            <span class="fl">
                                到
                            </span>
                        </div>
                        <div style="float: left; margin-bottom: -3px;">
                            <span class="fl">
                                <img src="../images/input_left.png" style="width: 4px; height: 29px;" alt="" />
                            </span>
                            <input id="txtEndDate" type="text" value="" class="input_text fl" maxlength="20" style="width: 100px;" disabled="disabled" runat="server" onclick="WdatePicker({ dateFmt: 'yyyy-MM-dd' })" />
                            <span class="fl">
                                <img src="../images/input_right.png" style="width: 4px; height: 29px;" alt="" />
                            </span>
                        </div>
                    </td>
                </tr>
                <tr>
                    <td style="text-align: right; ">投票描述：</td>
                    <td style="text-align: left; padding-left: 5px;">
                        <textarea id="txtContent" runat="server" style="width:700px;height:400px;" name="content"></textarea>
                    </td>
                </tr>
                <tr>
                    <td style="text-align: right; ">是否启用：</td>
                    <td style="text-align: left; padding-left: 5px;">
                        <input type="checkbox" id="ckbDisable" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td style="text-align: right; ">操作：</td>
                    <td style="text-align: left; padding-left: 5px;">
                        <asp:Button ID="Button1" runat="server" Text="提交" CssClass="inputButton" OnClick="Btn_Click" OnClientClick="javascript:$.dialog.tips('数据加载中...',6000,'loading.gif');" />&nbsp;&nbsp;<input type="button" class="inputButton" value="返回" onclick="location.href = 'VoteManage.aspx?columnId=<%=ColumnId%>    ';" />
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
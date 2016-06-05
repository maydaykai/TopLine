<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UserArticleEdit.aspx.cs" Inherits="WebUI.ArticleManage.UserArticleEdit" ValidateRequest="false" %>


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
    
    
    <script type="text/javascript" charset="utf-8" src="/js/ueditor/ueditor.config.js"></script>
    <script type="text/javascript" charset="utf-8" src="/js/ueditor/ueditor.all.min.js"> </script>
    <!--建议手动加在语言，避免在ie下有时因为加载语言失败导致编辑器加载失败-->
    <!--这里加载的语言文件会覆盖你在配置项目里添加的语言类型，比如你在配置项目里配置的是英文，这里加载的中文，那最后就是中文-->
    <script type="text/javascript" charset="utf-8" src="/js/ueditor/lang/zh-cn/zh-cn.js"></script>
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
            var ue = UE.getEditor('txtContent');
        });
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table cellpadding="0" cellspacing="0" class="editTable" border="0" style="min-width:800px;">
                <tr>
                    <td style="text-align: right; width: 150px;">文章标题：</td>
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
                <tr>
                    <td style="text-align: right; ">资讯正文：</td>
                    <td style="text-align: left; padding-left: 5px;">
                        <textarea id="txtContent" runat="server" style="width:1000px;height:500px;" name="content"></textarea>
                    </td>
                </tr>
                <tr runat="server" id="trAudit">
                    <td style="text-align: right; ">审核状态：</td>
                    <td style="text-align: left; padding-left: 5px;">
                        <label><input type="radio" value="1" id="rdStatusY" runat="server" name="status" />审核通过</label>
                        <label><input type="radio" value="2" id="rdStatusN" runat="server" name="status" />审核不通过</label>
                    </td>
                </tr>
                <tr>
                    <td style="text-align: right; ">操作：</td>
                    <td style="text-align: left; padding-left: 5px;">
                        <asp:Button runat="server" Text="提交" CssClass="inputButton" OnClick="Btn_Click" OnClientClick="javascript:$.dialog.tips('数据加载中...',6000,'loading.gif');" />&nbsp;&nbsp;<input type="button" class="inputButton" value="返回" onclick="location.href = 'UserArticleManage.aspx?columnId=<%=ColumnId%>';" />
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>

﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RightManage.aspx.cs" Inherits="WebUI.UserManage.RightManage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>权限列表</title>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link rel="stylesheet" href="/js/jqwidgets-ver3.1.0/jqwidgets/styles/jqx.base.css" type="text/css" />
    <script type="text/javascript" src="/js/jqwidgets-ver3.1.0/scripts/jquery-1.10.2.min.js"></script>
    <script type="text/javascript" src="/js/jqwidgets-ver3.1.0/jqwidgets/jqxcore.js"></script>
    <script type="text/javascript" src="/js/jqwidgets-ver3.1.0/jqwidgets/jqxdata.js"></script>
    <script type="text/javascript" src="/js/jqwidgets-ver3.1.0/jqwidgets/jqxbuttons.js"></script>
    <script type="text/javascript" src="/js/jqwidgets-ver3.1.0/jqwidgets/jqxscrollbar.js"></script>
    <script type="text/javascript" src="/js/jqwidgets-ver3.1.0/jqwidgets/jqxlistbox.js"></script>
    <script type="text/javascript" src="/js/jqwidgets-ver3.1.0/jqwidgets/jqxdropdownlist.js"></script>
    <script type="text/javascript" src="/js/jqwidgets-ver3.1.0/jqwidgets/jqxmenu.js"></script>
    <script type="text/javascript" src="/js/jqwidgets-ver3.1.0/jqwidgets/jqxgrid.js"></script>
    <script type="text/javascript" src="/js/jqwidgets-ver3.1.0/jqwidgets/jqxgrid.pager.js"></script>
    <script type="text/javascript" src="/js/jqwidgets-ver3.1.0/jqwidgets/jqxgrid.sort.js"></script>
    <script type="text/javascript" src="/js/jqwidgets-ver3.1.0/jqwidgets/jqxgrid.filter.js"></script>
    <script type="text/javascript" src="/js/jqwidgets-ver3.1.0/jqwidgets/jqxgrid.columnsresize.js"></script>
    <script type="text/javascript" src="/js/jqwidgets-ver3.1.0/jqwidgets/jqxgrid.selection.js"></script>
    <script type="text/javascript" src="/js/jqwidgets-ver3.1.0/jqwidgets/jqxpanel.js"></script>
    <link href="/js/jqwidgets-ver3.1.0/jqwidgets/styles/jqx.arctic.css" rel="stylesheet" />
    <link href="../css/global.css" rel="stylesheet" />
    <link href="../css/icon.css" rel="stylesheet" />
    <script src="../js/lhgdialog/lhgdialog.min.js"></script>
    <script src="../js/lhgdialog/ShowDialog.js"></script>

    <style>
        body {
            font-size: 14px;
        }
    </style>

    <script type="text/javascript">
        $(document).ready(function () {
            //主题
            var theme = "arctic";

            //数据源
            var source = {
                url: '/HanderAshx/UserManage/RightHandler.ashx',
                cache: false,
                datatype: "json",
                root: 'Rows',
                datafields: [
                    { name: 'RightName', type: 'string' },
                    { name: 'ID', type: 'int' }
                ]
            };

            //数据处理
            var dataadapter = new $.jqx.dataAdapter(source, {
                contentType: "application/json; charset=utf-8",
                loadError: function (xhr, status, error) {
                    alert(error);
                }
            });

            var linkrenderer = function (row, column, value) {
                var parm = "/UserManage/RightEdit.aspx?" + column + "=" + value + "&columnId=<%=ColumnId%>";
                var link = "<a style='text-align:center;margin-left:30px;height:25px; line-height:25px;' href='javascript:void(0)' onclick=\"MessageWindow(270,100,'" + parm + "')\"; target='_self'>修改</a>";
                var html = link;// $.jqx.dataFormat.formatlink(link);
                return html;
            };


            //数据绑定
            $("#jqxgrid").jqxGrid({
                theme: theme,
                source: dataadapter,
                width: 200,
                renderstatusbar: function (statusbar) {
                    var container = $("<div style='overflow: hidden; position: relative; margin: 5px;'></div>");
                    var addButton = $("<div style='float: left; margin-left: 5px; cursor:pointer;'><img style='position: relative; margin-top: 2px;' src='/js/jqwidgets-ver3.1.0/images/add.png'/><span style='margin-left: 4px; position: relative; top: -3px;'>增加</span></div>");
                    container.append(addButton);
                    statusbar.append(container);
                    addButton.jqxButton({ width: 60, height: 20 });
                    addButton.click(function (event) {
                        MessageWindow(270, 100, '/UserManage/RightEdit.aspx?columnId=<%=ColumnId%>');
                    });
                },
                showstatusbar: true,
                autoheight: true,
                virtualmode: true,
                rendergridrows: function (args) {
                    return args.data;
                },
                columns: [
                    { text: '<b>权限名称</b>', dataField: 'RightName', width: 100, cellsalign: 'center', align: 'center' },
                    { text: '<b>权限管理</b>', dataField: 'ID', width: 100, cellsrenderer: linkrenderer, cellsalign: 'center', align: 'center' }
                ]
            });

        });
    </script>
</head>
<body>
    <div id='jqxWidget' style="font-size: 14px; font-family: Verdana; float: left;">
        <div id="jqxgrid">
        </div>
    </div>
</body>
</html>



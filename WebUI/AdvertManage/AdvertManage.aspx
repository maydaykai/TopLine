﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AdvertManage.aspx.cs" Inherits="WebUI.AdvertManage.AdvertManage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>广告管理</title>
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
    <script type="text/javascript">
        var deleteConfirm = function (id) {
            $.dialog.confirm("您确定要删除吗？", function () {
                var obj = new Object();
                obj.id = id;
                var jsonobj = JSON.stringify(obj);
                $.ajax({
                    type: "POST",
                    url: "../API/Article.svc/DeleteAdvert",
                    contentType: "application/json; charset=utf-8",
                    data: jsonobj,
                    dataType: 'json',
                    beforeSend: function () {
                        $.dialog.tips('数据加载中...', 6000, 'loading.gif');
                    },
                    success: function (result) {
                        var jsondatas = JSON.parse(result.d);
                        MessageAlert(jsondatas.message, jsondatas.result, window.location.href);
                    }
                });
            });
        };
        $(function () {
            //主题
            var theme = "arctic";

            //数据源
            var source = {
                url: '/HanderAshx/AdvertManage/AdvertHandler.ashx',
                cache: false,
                datatype: "json",
                root: "Rows",
                datafields: [
                    { name: 'ID', type: 'string' },
                    { name: 'Title', type: 'string' },
                    { name: 'LinkUrl', type: 'string' },
                    { name: 'ChannelName', type: 'string' },
                    { name: 'StatusStr', type: 'string' }
                ],
                pagesize: 20,
                sort: function () { $("#jqxgrid").jqxGrid('updatebounddata', 'sort'); },
                beforeprocessing: function (data) { source.totalrecords = data.TotalRows; }
            };

            //数据处理
            var dataadapter = new $.jqx.dataAdapter(source, {
                contentType: "application/json; charset=utf-8",
                loadError: function (xhr, status, error) {
                    alert(error);
                }
            });
            var linkrenderer = function (row, column, value) {
                var parm = column + "=" + value + "&columnId=<%=ColumnId%>";
                var rightEdit = '<%=RightEdit%>' === 'True';
                var rightDelete = '<%=RightDelete%>' === 'True';
                var link = "";
                if (rightEdit)
                    link += "<a href='AdvertEdit.aspx?" + parm + "'  target='_self' style='margin-left:10px;height:25px;line-height:25px;'>修改</a>";
                if (rightDelete)
                    link += "<a style='text-align:center;margin-left:15px;height:25px; line-height:25px;' href='javascript:void(0)' onclick=\"deleteConfirm('" + value + "')\"; target='_self'>删除</a>";
                return link;
            };
            //数据绑定
            $("#jqxgrid").jqxGrid({
                theme: theme,
                source: dataadapter,
                width: 1580,
                rendergridrows: function (args) {
                    return args.data;
                },
                renderstatusbar: function (statusbar) {
                    var rightAdd = '<%=RightAdd%>' === 'True';
                    if (rightAdd) {
                        var container = $("<div style='overflow: hidden; position: relative; margin: 5px;'></div>");
                        var addButton = $("<div style='float: left; margin-left: 5px; cursor:pointer;'><img style='position: relative; margin-top: 2px;' src='/js/jqwidgets-ver3.1.0/images/add.png'/><span style='margin-left: 4px; position: relative; top: -3px;'>增加</span></div>");
                        container.append(addButton);
                        statusbar.append(container);
                        addButton.jqxButton({ width: 60, height: 20 });
                        addButton.click(function (event) {
                            window.location.href = "/AdvertManage/AdvertEdit.aspx?columnId=<%=ColumnId%>";
                        });
                    }
                },
                showstatusbar: true,
                sortable: true,
                pageable: true,
                autoheight: true,
                virtualmode: true,
                sorttogglestates: 1,
                pagesizeoptions: ['10', '20', '30'],
                columns: [
                        { text: '<b>操作</b>', dataField: 'ID', width: 120, cellsalign: 'center', align: 'center', cellsrenderer: linkrenderer },
                        { text: '<b>名称</b>', dataField: 'Title', width: 250, cellsalign: 'center', align: 'center' },
                        { text: '<b>链接地址</b>', dataField: 'LinkUrl', width: 250, cellsalign: 'center', align: 'center' },
                        { text: '<b>所属频道</b>', dataField: 'ChannelName', width: 250, cellsalign: 'center', align: 'center' },
                        { text: '<b>状态</b>', dataField: 'StatusStr', width: 250, cellsalign: 'center', align: 'center' }
                ]
            });

        });
    </script>
</head>
<body>
    <div id='jqxWidget' style="font-size: 13px; font-family: Verdana; float: left;">
        <div id="jqxgrid">
        </div>
    </div>
</body>
</html>
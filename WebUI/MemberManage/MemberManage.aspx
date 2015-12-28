<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MemberManage.aspx.cs" Inherits="WebUI.MemberManage.MemberManage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>会员管理</title>
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
    <script type="text/javascript">
        $(document).ready(function () {
            //主题
            var theme = "arctic";

            //参数组装
            function buildQueryString(data) {
                var str = ''; for (var prop in data) {
                    if (data.hasOwnProperty(prop)) {
                        str += prop + '=' + data[prop] + '&';
                    }
                }
                return str.substr(0, str.length - 1);
            }

            var formatedData = '';

            //数据源
            var source = {
                url: '/HanderAshx/MemberManage/MemberHandler.ashx',
                cache: false,
                datatype: "json",
                root: 'Rows',
                datafields: [
                    { name: 'ID', type: 'string' },
                    { name: 'Name', type: 'string' },
                    { name: 'Email', type: 'string' },
                    { name: 'CreateTime', type: 'date' }
                ],
                pagesize: 20,
                formatdata: function (data) {
                    data.pagenum = data.pagenum || 0;
                    data.pagesize = data.pagesize || 20;
                    data.sortdatafield = data.sortdatafield || 'ID';
                    data.sortorder = data.sortorder || 'desc';
                    formatedData = buildQueryString(data);
                    return formatedData;
                },
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
                var link = "<a href='UserEdit.aspx?" + parm + "'  target='_self' style='margin-left:10px;height:25px;line-height:25px;'>修改</a>";
                var html = $.jqx.dataFormat.formatlink(link);
                return html;
            };

            //数据绑定
            $("#jqxgrid").jqxGrid({
                theme: theme,
                source: dataadapter,
                width: 980,
                sortable: true,
                pageable: true,
                autoheight: true,
                sorttogglestates: 1,
                pagesizeoptions: ['10', '20', '30'],
                columns: [
                        { text: '<b>操作</b>', dataField: 'ID', width: 50, cellsalign: 'center', align: 'center', cellsrenderer: linkrenderer },
                        { text: '<b>用户名</b>', dataField: 'Name', width: 120, cellsalign: 'center', align: 'center' },
                        { text: '<b>邮箱</b>', dataField: 'Email', width: 120, cellsalign: 'center', align: 'center' },
                        { text: '<b>注册时间</b>', dataField: 'CreatedTime', width: 180, cellsformat: "yyyy-MM-dd HH:mm:ss", cellsalign: 'center', align: 'center' }
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
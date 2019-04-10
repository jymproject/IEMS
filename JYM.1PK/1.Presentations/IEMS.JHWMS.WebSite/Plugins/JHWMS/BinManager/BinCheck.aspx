<%@ Page Language="C#" AutoEventWireup="true" CodeFile="BinCheck.aspx.cs" Inherits="Plugins_JHWMS_BinManager_BinCheck" %>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>库存质检管理</title>
    <link rel="Stylesheet" type="text/css" href="<%= Page.ResolveUrl("~/") %>resources/css/ext-chinese-font.css" />
    <link rel="Stylesheet" type="text/css" href="<%= Page.ResolveUrl("~/") %>resources/css/main.css" />
    <script type="text/javascript">
        var thisDirUrl = "<%= Page.ResolveUrl("./") %>";
        var thisRootUrl = "<%= Page.ResolveUrl("~/") %>";
    </script>
    <script type="text/javascript" src="<%= Page.ResolveUrl("~/") %>resources/js/jquery-1.7.1.js"></script>
   <!--gridMain数据展示-->
    <script type="text/javascript">
        var gridMainFresh = function () {
            var store = App.gridMain.getStore();
            store.currentPage = 1;
            store.pageSize = 100;
            App.gridMainPagingToolbar.doRefresh();
            return false;
        }
    </script>

     <script type="text/javascript">
        var commandcolumn_click = function (command, record) {
            if (command.toLowerCase() == "qualified".toLowerCase()) {
                qualifiedBin(record);
            }
             if (command.toLowerCase() == "unqualified".toLowerCase()) {
                unqualifiedBin(record);
            }
        }
     </script>
    <!--库存质检合格-->
    <script type="text/javascript">
        //列表刷新数据重载方法
        var qualifiedBin = function (record) {
            if (!record) {
                Ext.Msg.alert("提示", "请选择需要质检的库位库存");
                return;
            }
           var msg = "确定将库位【" + record.data.BIN_NO + "】" + "的库存资料质检为合格吗？"
           Ext.Msg.confirm("提示", msg, function (btn) {
                if (btn == "yes") {                   
                    var packageGuid = record.data.PACKAGE_GUID;
                    var binNo = record.data.BIN_NO;
                    var creationDate = record.data.CREATION_DATE;
                    var materNo = record.data.MATER_NO;
                    var materName = record.data.MATER_NAME;
                    var palletNo = record.data.PALLET_NO;
                    var batchNo = record.data.BATCH_NO;
                    var productQty = record.data.PRODUCT_QTY;
                    var productDate = record.data.PRODUCT_DATE;
                    var memo = record.data.MEMO;
                    var currStatus = record.data.CHECK_STATUS;

                    App.direct.QualifiedBin(packageGuid,currStatus ,binNo,creationDate,materNo,materName,palletNo,batchNo,productQty,productDate,memo,{  //
                        success: function (result) {
                            if (result == "") {
                                gridMainFresh();
                                Ext.Msg.alert('成功', "质检确认合格成功！");
                            } else {
                                Ext.Msg.alert("失败", result);
                            }
                        },
                        failure: function (errorMsg) {
                            Ext.Msg.alert("错误", errorMsg);
                        }
                    });
                }
            });
            return false;
        }
    </script>
    <!--库存质检不合格-->
    <script type="text/javascript">
        //列表刷新数据重载方法
        var unqualifiedBin = function (record) {
            if (!record) {
                Ext.Msg.alert("提示", "请选择需要质检的库位库存");
                return;
            }
           var msg = "确定将库位【" + record.data.BIN_NO + "】" + "的库存资料质检为不合格吗？"
           Ext.Msg.confirm("提示", msg, function (btn) {
                if (btn == "yes") {                    
                    var packageGuid = record.data.PACKAGE_GUID;
                    var binNo = record.data.BIN_NO;
                    var creationDate = record.data.CREATION_DATE;
                    var materNo = record.data.MATER_NO;
                    var materName = record.data.MATER_NAME;
                    var palletNo = record.data.PALLET_NO;
                    var batchNo = record.data.BATCH_NO;
                    var productQty = record.data.PRODUCT_QTY;
                    var productDate = record.data.PRODUCT_DATE;
                    var memo = record.data.MEMO;
                    var currStatus = record.data.CHECK_STATUS;

                    App.direct.UnQualifiedBin(packageGuid, currStatus,binNo,creationDate,materNo,materName,palletNo,batchNo,productQty,productDate,memo,{//
                        success: function (result) {
                            if (result == "") {
                                gridMainFresh();
                                Ext.Msg.alert('成功', "质检确认不合格成功！");
                            } else {
                                Ext.Msg.alert("失败", result);
                            }
                        },
                        failure: function (errorMsg) {
                            Ext.Msg.alert("错误", errorMsg);
                        }
                    });
                }
            });
            return false;
        }
    </script>
    <script type="text/javascript">
        //历史查询根据DeleteFlag的值进行样式绑定
        var SetRowClass = function (record, rowIndex, rowParams, store) {
            if (record.get("CHECK_STATUS") == "0") {
                return "x-grid-row-deleted";
            }
        }
        var template = '<span style="background:{0};width:70px;display:block;text-align:center;">{1}</span>';
        var pctChange = function (value) {
            return Ext.String.format(template, (value == "合格") ? "green" : "red", value);
        };
    </script>

    <%--<script type="text/javascript">
        var showAddWindows = function (record) {
            App.txtSrnName.setValue("");
            App.txtSrmNo.setValue("");
            App.txtMinCol.setValue("");
            App.txtMaxCol.setValue("");
            App.winAdd.show();
            return false;
        }
     </script>--%>
</head>
<body>
    <form id="form1" runat="server">
        <ext:ResourceManager runat="server" />
        <ext:Viewport ID="viewport" runat="server" Layout="border">
            <Items>
                 <ext:Panel runat="server" Region="North" AutoHeight="true">
                   <TopBar>
                        <ext:Toolbar runat="server">
                            <Items>
                                <ext:ToolbarSeparator />
                                <ext:Button runat="server" Icon="Find" Text="查询" ID="Button2">
                                    <Listeners>
                                        <Click Handler="gridMainFresh();" />
                                    </Listeners>
                                </ext:Button>
                                <ext:ToolbarSeparator />
                                <ext:ToolbarFill />
                            </Items>
                        </ext:Toolbar>
                    </TopBar>
                    <Items>
                        <ext:FormPanel runat="server" Layout="ColumnLayout" AutoHeight="true" Region="North">
                            <Items>
                                <ext:Container runat="server" Layout="FormLayout" ColumnWidth=".3" Padding="1">
                                    <Items>
                                        <ext:TextField ID="txtBinNo" runat="server" FieldLabel="库位号" ReadOnly="false"
                                            LabelAlign="Right">
                                        </ext:TextField>
                                    </Items>
                                </ext:Container>
                                 <ext:Container runat="server" Layout="FormLayout" ColumnWidth=".3" Padding="1">
                                    <Items>
                                        <ext:TextField ID="txtPalletNo" runat="server" FieldLabel="工装号" ReadOnly="false"
                                            LabelAlign="Right">
                                        </ext:TextField>
                                    </Items>
                                </ext:Container>
                                <ext:Container runat="server" Layout="FormLayout" ColumnWidth=".3" Padding="1">
                                    <Items>
                                        <ext:TextField ID="txtMaterNo" runat="server" FieldLabel="物料号" ReadOnly="false"
                                            LabelAlign="Right">
                                        </ext:TextField>
                                    </Items>
                                </ext:Container>
                                <ext:Container runat="server" Layout="FormLayout" ColumnWidth=".3" Padding="1">
                                    <Items>
                                        <ext:TextField ID="txtBatchNo" runat="server" FieldLabel="批次号" ReadOnly="false"
                                            LabelAlign="Right">
                                        </ext:TextField>
                                    </Items>
                                </ext:Container>
                                <ext:Container runat="server" Layout="FormLayout" ColumnWidth=".3" Padding="1">
                                    <Items>
                                        <ext:TextField ID="txtMemo" runat="server" FieldLabel="备注" ReadOnly="false"
                                            LabelAlign="Right">
                                        </ext:TextField>
                                    </Items>
                                </ext:Container>
                                <ext:Container runat="server" Layout="FormLayout" ColumnWidth=".3" Padding="1">
                                    <Items>
                                       <ext:ComboBox ID ="txtCheckStatus" runat="server" FieldLabel="质检状态" ReadOnly="false"  Text=""
                                          LabelAlign="Right" Editable ="false">
                                       </ext:ComboBox>
                                    </Items>
                                </ext:Container>
                            </Items>
                        </ext:FormPanel>
                    </Items>
                </ext:Panel>
                <ext:GridPanel ID="gridMain" runat="server" Region="Center">
                    <Store>
                        <ext:Store runat="server" PageSize="15">
                            <Proxy>
                                <ext:PageProxy DirectFn="App.direct.GridPanelBindData" />
                            </Proxy>
                            <Model>
                                <ext:Model runat="server">
                                    <Fields>
                                        <ext:ModelField Name="PACKAGE_GUID" />
                                        <ext:ModelField Name="BIN_NO" />
                                        <ext:ModelField Name="CREATION_DATE" />
                                        <ext:ModelField Name="MATER_NO" />
                                        <ext:ModelField Name="MATER_NAME" />
                                        <ext:ModelField Name="PALLET_NO" />
                                        <ext:ModelField Name="BATCH_NO" />
                                        <ext:ModelField Name="PRODUCT_QTY" />
                                        <ext:ModelField Name="PRODUCT_DATE" />
                                        <ext:ModelField Name="MEMO" />
                                        <ext:ModelField Name="CHECK_STATUS" />    
                                    </Fields>
                                </ext:Model>
                            </Model>
                        </ext:Store>
                    </Store>
                    <ColumnModel runat="server">
                        <Columns>
                            <ext:RowNumbererColumn Width="35" runat="server" />
                            <ext:Column runat="server" DataIndex="PACKAGE_GUID"      Text="库位编号"  Visible="false"   Width="100" />
                            <ext:Column runat="server" DataIndex="BIN_NO"      Text="库位编号"    Width="100" />
                            <ext:Column runat="server" DataIndex="CREATION_DATE"           Text="入库时间"    Width="100" />
                            <ext:Column runat="server" DataIndex="MATER_NO"         Text="物料编码"    Width="100" />
                            <ext:Column runat="server" DataIndex="MATER_NAME"  Text="物料名称"        Width="80"/>
                            <ext:Column runat="server" DataIndex="PALLET_NO"    Text="工装编号"      Width="80"/>
                            <ext:Column runat="server" DataIndex="BATCH_NO"   Text="批次号"      Width="80" />
                            <ext:Column runat="server" DataIndex="PRODUCT_QTY" Text="生产数量"    Width="80" />
                            <ext:Column runat="server" DataIndex="PRODUCT_DATE" Text="生产日期"    Width="80" />
                            <ext:Column runat="server" DataIndex="MEMO" Text="备注"    Width="80" />
                            <ext:Column runat="server" DataIndex="CHECK_STATUS" Text="质检状态"    Width="80" >
                                <Renderer Fn="pctChange" />
                            </ext:Column>
                            <ext:CommandColumn runat="server" Width="320" Text="操作" Align="Center">
                                <Commands>
                                    <ext:GridCommand Icon="LockKey" CommandName="qualified" Text="确认质检合格">
                                        <ToolTip Text="确认质检为合格" />
                                    </ext:GridCommand>
                                    <ext:CommandSeparator />
                                    <ext:GridCommand Icon="LockKey" CommandName="unqualified" Text="确认质检不合格">
                                        <ToolTip Text="确认质检为不合格" />
                                    </ext:GridCommand>
                                </Commands>
                                <Listeners>
                                    <Command Handler="return commandcolumn_click(command, record);" />
                                </Listeners>
                            </ext:CommandColumn>
                            
                        </Columns>
                    </ColumnModel>
                    <BottomBar>
                        <ext:PagingToolbar ID="gridMainPagingToolbar" runat="server">
                            <Plugins>
                                <ext:ProgressBarPager runat="server" />
                            </Plugins>
                        </ext:PagingToolbar>
                    </BottomBar>
                    <View>
                        <ext:GridView runat="server" StripeRows="true" TrackOver="true" />
                    </View>
                </ext:GridPanel>
            </Items>
        </ext:Viewport>
    </form>
</body>
</html>

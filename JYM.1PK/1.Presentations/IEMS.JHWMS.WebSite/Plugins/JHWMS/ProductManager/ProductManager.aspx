<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ProductManager.aspx.cs" Inherits="Plugins_JHWMS_ProductManager_ProductManager" %>

<%@ Register Assembly="Ext.Net" Namespace="Ext.Net" TagPrefix="ext" %>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>产品信息维护</title>
    <link rel="Stylesheet" type="text/css" href="<%= Page.ResolveUrl("~/") %>resources/css/ext-chinese-font.css" />
    <link rel="Stylesheet" type="text/css" href="<%= Page.ResolveUrl("~/") %>resources/css/main.css" />
    <script type="text/javascript">
        var thisDirUrl = "<%= Page.ResolveUrl("./") %>";
        var thisRootUrl = "<%= Page.ResolveUrl("~/") %>";
    </script>
    <script type="text/javascript" src="<%= Page.ResolveUrl("~/") %>resources/js/jquery-1.7.1.js"></script>
        <script type="text/javascript" src="<%= Page.ResolveUrl("./") %>TriggerFieldSearchMaterDatas.js?id=<%=DateTime.Now.ToString("yyyyMMddHHmmss") %>"></script>

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
        //按钮点击处理
        var cmdcol_click_handle = function (command, record) {

            if (command.toLowerCase() == "forcedelete") {
                var objId = record.data.OBJID;
                if (objId == 0) {
                    Ext.Msg.alert("错误", '未获取到OBJID，请联系管理员');
                    return;
                }
                Ext.Msg.confirm("提示", '确定要删除产品信息【' + objId + '】吗？', function (btn) {
                    if (btn == "yes") {
                        App.direct.ForceDelete(objId, {
                            success: function (result) {
                                if (result == "") {
                                    Ext.Msg.alert('成功', "删除产品信息【" + objId + "】成功！");
                                    //站台状态刷新
                                    App.gridMainPagingToolbar.doRefresh();
                                } else {
                                    Ext.Msg.alert("删除失败", result);
                                }
                            },
                            failure: function (errorMsg) {
                                Ext.Msg.alert("错误", errorMsg);
                            }
                        });
                    }
                });
            }
            if (command.toLowerCase() == "forceexchange") {
                var objId = record.data.OBJID;
                if (objId == 0) {
                    Ext.Msg.alert("错误", '未获取到OBJID，请联系管理员');
                    return;
                }
                Ext.Msg.confirm("提示", '确定要切换为该产品信息【' + objId + '】吗？', function (btn) {
                    if (btn == "yes") {
                        App.direct.ForceExchange(objId, {
                            success: function (result) {
                                if (result == "") {
                                    Ext.Msg.alert('成功', "切换【" + objId + "】成功！");
                                    //站台状态刷新
                                    App.gridMainPagingToolbar.doRefresh();
                                } else {
                                    Ext.Msg.alert("切换失败", result);
                                }
                            },
                            failure: function (errorMsg) {
                                Ext.Msg.alert("错误", errorMsg);
                            }
                        });
                    }
                });
            }
            if (command.toLowerCase() == "forceedit") {
                var objId = record.data.OBJID;
                if (objId == 0) {
                    Ext.Msg.alert("错误", '未获取到OBJID，请联系管理员');
                    return;
                }
             
                showEditWindow(record);

         





            }
      
            return false;
        };
    </script>
    <script type="text/javascript">
        var saveAddWindows = function () {
            var shiftId = App.txtShiftIdAdd.getValue();
            var equipNo = App.txtEquipNo_add.getValue();
            var materNo = App.txtAddMaterNo.getValue();
            var batchNo = App.txtBatchNo.getValue();
            var productName = App.txtProductName.getValue();
            var packType = App.txtPackType.getValue();
            var standardWeight = App.txtStandardWeight.getValue();
            var allowErrRange = App.txtAllowErrRange.getValue();
            var srmName = App.txtSrmName.getValue();
            var letterNo = App.txtLetterNo.getValue();
            var productQty = App.txtProductQty.getValue();
            var orderQty = App.txtOrderQty.getValue();
            var productBatch = App.txtProductBatch.getValue();
            var shipDesc = App.txtShipDesc.getValue();
            var srmDesc = App.txtSrmDesc.getValue();
            var whNo = App.txtWhNo.getValue();
            var productDate = App.txtProductDate.getValue();
            var shipDate = App.txtShipDate.getValue();
            if (materNo == null || materNo == "") {
                Ext.Msg.alert("错误", '请选择物料编码!');
                return;
            }


            if (shiftId == null || shiftId == "") {
                Ext.Msg.alert("错误", '请选择生产班组!');
                return;
            }

            if (equipNo == null || equipNo == "") {
                Ext.Msg.alert("错误", '请选择生产机台!');
                return;
            }
            if (batchNo == null || batchNo == "") {
                Ext.Msg.alert("错误", '请输入批次!');
                return;
            }
            if (productName == null || productName == "") {
                Ext.Msg.alert("错误", '请输入产品名称!');
                return;
            } if (packType == null || packType == "") {
                Ext.Msg.alert("错误", '请输入包装类型!');
                return;
            } if (standardWeight == null || standardWeight == "") {
                Ext.Msg.alert("错误", '请输入标准重量!');
                return;
            } if (allowErrRange == null || allowErrRange == "") {
                Ext.Msg.alert("错误", '请输入允许误差!');
                return;
            } if (srmName == null || srmName == "") {
                Ext.Msg.alert("错误", '请输入客户名称!');
                return;
            } if (letterNo == null || letterNo == "") {
                Ext.Msg.alert("错误", '请输入确认函号!');
                return;
            } if (productQty == null || productQty == "") {
                Ext.Msg.alert("错误", '请输入产品数量!');
                return;
            } if (orderQty == null || orderQty == "") {
                Ext.Msg.alert("错误", '请输入订单数量!');
                return;
            } if (shipDesc == null || shipDesc == "") {
                Ext.Msg.alert("错误", '请输入发货描述!');
                return;
            } if (srmDesc == null || srmDesc == "") {
                Ext.Msg.alert("错误", '请输入客户要求!');
                return;
            }
            if (whNo == null || whNo == "") {
                Ext.Msg.alert("错误", '请输入归属仓库!');
                return;
            } if (productDate == null || productDate == "") {
                Ext.Msg.alert("错误", '请输入生产时间!');
                return;
            }
            if (shipDate == null || shipDate == "") {
                Ext.Msg.alert("错误", '请输入预计发货日期!');
                return;
            }


            App.direct.InsertDb(materNo,productBatch, shiftId, equipNo, batchNo, productName, packType, standardWeight, allowErrRange, srmName, letterNo, productQty, orderQty, shipDesc, srmDesc, whNo, productDate, shipDate, {
                success: function (result) {
                    if (result == "True") {
                        Ext.Msg.alert('成功', "生成产品信息成功！");
                    }
                    else {
                        Ext.Msg.alert('错误', result);
                    }
                    App.winAdd.close();
                    gridMainFresh();
                },

                failure: function (errorMsg) {
                    Ext.Msg.alert('异常', errorMsg);
                }
            });

            return false;
        };
    </script>

     <script type="text/javascript">
         var saveEditWindows = function () {
             var objid = App.OBJID_EDIT.getValue();
             var shiftId = App.txtshifid_edit.getValue();
             var equipNo = App.txtEquipNo_edit.getValue();
             var batchNo = App.txtBatchNo_edit.getValue();

             var materNo = App.txtMaterNo_edit.getValue();

             var productName = App.txtProductName_edit.getValue();
             var packType = App.txtPackType_edit.getValue();
             var standardWeight = App.txtStandardWeight_edit.getValue();
             var allowErrRange = App.txtAllowErrRange_edit.getValue();
             var srmName = App.txtSrmName_edit.getValue();
             var letterNo = App.txtLetterNo_edit.getValue();
             var productQty = App.txtProductQty_edit.getValue();
             var orderQty = App.txtOrderQty_edit.getValue();
             var shipDesc = App.txtShipDesc_edit.getValue();
             var srmDesc = App.txtSrmDesc_edit.getValue();
             var whNo = App.txtWhNo_edit.getValue();
             var productDate = App.txtProductDate_edit.getValue();
             var shipDate = App.txtShipDate_edit.getValue();
             var productBatch = App.txtProductBatch_edit.getValue();
             if (productBatch == null || productBatch == "") {
                 Ext.Msg.alert("错误", '请输入生产批次!');
                 return;
             }
             if (materNo == null || materNo == "") {
                 Ext.Msg.alert("错误", '请输入物料编码!');
                 return;
             }
             if (shiftId == null || shiftId == "") {
                 Ext.Msg.alert("错误", '请选择生产班组!');
                 return;
             }
             if (equipNo == null || equipNo == "") {
                 Ext.Msg.alert("错误", '请选择生产机台!');
                 return;
             }
             if (batchNo == null || batchNo == "") {
                 Ext.Msg.alert("错误", '请输入批次!');
                 return;
             }
             if (productName == null || productName == "") {
                 Ext.Msg.alert("错误", '请输入产品名称!');
                 return;
             } if (packType == null || packType == "") {
                 Ext.Msg.alert("错误", '请输入包装类型!');
                 return;
             } if (standardWeight == null || standardWeight == "") {
                 Ext.Msg.alert("错误", '请输入标准重量!');
                 return;
             } if (allowErrRange == null || allowErrRange == "") {
                 Ext.Msg.alert("错误", '请输入允许误差!');
                 return;
             } if (srmName == null || srmName == "") {
                 Ext.Msg.alert("错误", '请输入客户名称!');
                 return;
             } if (letterNo == null || letterNo == "") {
                 Ext.Msg.alert("错误", '请输入确认函号!');
                 return;
             } if (productQty == null || productQty == "") {
                 Ext.Msg.alert("错误", '请输入产品数量!');
                 return;
             } if (orderQty == null || orderQty == "") {
                 Ext.Msg.alert("错误", '请输入订单数量!');
                 return;
             } if (shipDesc == null || shipDesc == "") {
                 Ext.Msg.alert("错误", '请输入发货描述!');
                 return;
             } if (srmDesc == null || srmDesc == "") {
                 Ext.Msg.alert("错误", '请输入客户要求!');
                 return;
             }
             if (whNo == null || whNo == "") {
                 Ext.Msg.alert("错误", '请输入归属仓库!');
                 return;
             } if (productDate == null || productDate == "") {
                 Ext.Msg.alert("错误", '请输入生产时间!');
                 return;
             }
             if (shipDate == null || shipDate == "") {
                 Ext.Msg.alert("错误", '请输入预计发货日期!');
                 return;
             }
             App.direct.UpdateDb(materNo,objid, productBatch, shiftId, equipNo, batchNo, productName, packType, standardWeight, allowErrRange, srmName, letterNo, productQty, orderQty, shipDesc, srmDesc, whNo, productDate, shipDate, {
                 success: function (result) {
                     if (result == "True") {
                         Ext.Msg.alert('成功', "更新产品信息成功！");
                     }
                     else {
                         Ext.Msg.alert('错误', result);
                     }
                     App.winEdit.close();
                     gridMainFresh();
                 },

                 failure: function (errorMsg) {
                     Ext.Msg.alert('异常', errorMsg);
                 }
             });

             return false;
         };
    </script>


    <script type="text/javascript">
        var showAddWindows = function () {
            App.txtAddMaterNo.setValue("");

            App.txtBatchNo.setValue("");
            App.txtProductName.setValue("");
            App.txtPackType.setValue("");
            App.txtStandardWeight.setValue("");
            App.txtAllowErrRange.setValue("");
            App.txtSrmName.setValue("");
            App.txtLetterNo.setValue("");
            App.txtProductQty.setValue("");
            App.txtOrderQty.setValue("");
            App.txtShipDesc.setValue("");
            App.txtSrmDesc.setValue("");
            App.txtWhNo.setValue("");
            App.txtProductDate.setValue("");
            App.txtShipDate.setValue("");
            App.txtProductBatch.setValue("");
            App.winAdd.show();
            return false;
        }
    </script>

        <script type="text/javascript">
            var showEditWindow = function (record) {
                App.txtMaterNo_edit.setValue(record.data.MATER_NO);
                App.txtProductName_edit.setValue(record.data.PRODUCT_NAME);
                App.txtshifid_edit.setValue(record.data.SHIFT_ID);
                App.txtEquipNo_edit.setValue(record.data.EQUIP_NO);

                App.txtBatchNo_edit.setValue(record.data.BATCH_NO);
                //App.txtProductName_edit.setValue(record.data.PRODUCT_NAME);
                App.txtPackType_edit.setValue(record.data.PACKAGE_STYLE);
                App.txtStandardWeight_edit.setValue(record.data.STANDARD_WEIGHT);
                App.txtAllowErrRange_edit.setValue(record.data.ERROR_WEIGHT);
                App.txtSrmName_edit.setValue(record.data.SRM_NAME);
                App.txtLetterNo_edit.setValue(record.data.LETTER_NO);
                App.txtProductQty_edit.setValue(record.data.PRODUCT_QTY);
                App.txtOrderQty_edit.setValue(record.data.ORDER_QTY);
                App.txtShipDesc_edit.setValue(record.data.SHIPMENTS_DESC);
                App.txtSrmDesc_edit.setValue(record.data.SRM_DESC);
                App.txtWhNo_edit.setValue(record.data.WH_NO);
                //App.txtProductDate_edit.setValue(record.data.PRODUCT_DATE.Replace('-', '/').Substring(0, 10));
                App.txtProductDate_edit.setValue(record.data.PRODUCT_DATE.substring(0, 10).replace('-', '/').replace('-', '/').replace('/0', '/').replace('/0', '/'));
                App.txtShipDate_edit.setValue(record.data.SHIPMENTS_DATE.substring(0, 10).replace('-', '/').replace('-', '/').replace('/0', '/').replace('/0', '/'));
                //App.txtShipDate_edit.setValue(record.data.SHIPMENTS_DATE.Replace('-', '/').Substring(0, 10));
                App.txtProductBatch_edit.setValue(record.data.PRODUCT_BATCH_NO);
                App.OBJID_EDIT.setValue(record.data.OBJID);
                App.winEdit.show();
                return false;
            }
    </script>

</head>
<body>
    <form runat="server">
        <ext:ResourceManager runat="server" />
        <ext:Viewport ID="Viewport1" runat="server" Layout="BorderLayout">
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
                                <ext:Button runat="server" Icon="Add" Text="添加" ID="Button3">
                                    <Listeners>
                                        <Click Handler="showAddWindows();" />
                                    </Listeners>
                                </ext:Button>
                                <ext:ToolbarSpacer />
                                <ext:ToolbarFill />
                            </Items>
                        </ext:Toolbar>
                    </TopBar>
                    <Items>
                        <ext:FormPanel runat="server" Layout="ColumnLayout" AutoHeight="true" Region="North">
                            <Items>
                                <ext:Container runat="server" Layout="FormLayout" ColumnWidth=".3" Padding="1">
                                    <Items>
                                        <ext:TextField ID="txtEquipNo" runat="server" FieldLabel="生产机台" ReadOnly="false"
                                            LabelAlign="Right">
                                        </ext:TextField>
                                    </Items>
                                </ext:Container>
                                <ext:Container runat="server" Layout="FormLayout" ColumnWidth=".3" Padding="1">
                                    <Items>
                                        <ext:TextField ID="txtShiftId" runat="server" FieldLabel="生产班组" ReadOnly="false"
                                            LabelAlign="Right">
                                        </ext:TextField>
                                    </Items>
                                </ext:Container>
                            </Items>
                        </ext:FormPanel>
                    </Items>
                </ext:Panel>
                <ext:GridPanel ID="gridMain" runat="server" Region="Center">
                    <Store>
                        <ext:Store runat="server" PageSize="100" Height="100%">
                            <Proxy>
                                <ext:PageProxy DirectFn="App.direct.GetProductInfo" />
                            </Proxy>
                            <Model>
                                <ext:Model ID="model1" runat="server">
                                    <Fields>
                                        <ext:ModelField Name="OBJID" />
                                        <ext:ModelField Name="EQUIP_NO" />
                                        <ext:ModelField Name="BATCH_NO" />
                                        <ext:ModelField Name="SHIFT_ID" />
                                                                                <ext:ModelField Name="MATER_NO" />
                                        <ext:ModelField Name="PRODUCT_ORGANIZATION" />

                                        <ext:ModelField Name="PRODUCT_DATE" />
                                        <ext:ModelField Name="PRODUCT_NAME" />
                                        <ext:ModelField Name="PACKAGE_STYLE" />
                                        <ext:ModelField Name="STANDARD_WEIGHT" />
                                        <ext:ModelField Name="ERROR_WEIGHT" />
                                        <ext:ModelField Name="SRM_NAME" />
                                        <ext:ModelField Name="LETTER_NO" />
                                        <ext:ModelField Name="PRODUCT_BATCH_NO" />
                                        <ext:ModelField Name="PRODUCT_QTY" />
                                        <ext:ModelField Name="ORDER_QTY" />
                                        <ext:ModelField Name="SHIPMENTS_DATE" />
                                        <ext:ModelField Name="SHIPMENTS_DESC" />
                                        <ext:ModelField Name="SRM_DESC" />
                                        <ext:ModelField Name="WH_NO" />
                                        <ext:ModelField Name="DELETE_FLAG" />
                                        <ext:ModelField Name="RECORD_USER_ID" />
                                        <ext:ModelField Name="RECORD_TIME" />
                                        <ext:ModelField Name="SLMS_FLAG" />
                                        <ext:ModelField Name="READTIME" />
                                        <ext:ModelField Name="READ_USER_ID" />
                                        <ext:ModelField Name="READ_TIME" />


                                    </Fields>
                                </ext:Model>
                            </Model>
                        </ext:Store>
                    </Store>
                    <ColumnModel ID="columnModel" runat="server">
                        <Columns>
                            <ext:RowNumbererColumn Width="30" runat="server" />
                            <ext:Column runat="server" DataIndex="OBJID" Text="OBJID" Width="70" />
                            <ext:Column runat="server" DataIndex="EQUIP_NO" Text="生产机台" Width="70" />
                            <ext:Column runat="server" DataIndex="BATCH_NO" Text="批次号" Width="70" />
                            <ext:Column runat="server" DataIndex="SHIFT_ID" Text="生产班组" Width="90" />
                             <ext:Column runat="server" DataIndex="MATER_NO" Text="物料编码" Width="90" />

                                                         <ext:Column runat="server" DataIndex="PRODUCT_ORGANIZATION" Text="产品组织号" Width="90" />

                            <ext:Column runat="server" DataIndex="PRODUCT_NAME" Text="产品名称" Width="90" />
                            <ext:Column runat="server" DataIndex="PACKAGE_STYLE" Text="包装类型" Width="100" />
                            <ext:Column runat="server" DataIndex="STANDARD_WEIGHT" Text="标准重量" Width="100" />
                            <ext:Column runat="server" DataIndex="ERROR_WEIGHT" Text="允许误差" Width="100" />
                            <ext:Column runat="server" DataIndex="SRM_NAME" Text="客户名称" Width="100" />
                            <ext:Column runat="server" DataIndex="LETTER_NO" Text="确认函号" Width="80" />
                            <ext:Column runat="server" DataIndex="PRODUCT_BATCH_NO" Text="生产批号" Width="80" />
                            <ext:Column runat="server" DataIndex="PRODUCT_QTY" Text="生产数量" Width="80" />
                            <ext:Column runat="server" DataIndex="ORDER_QTY" Text="订单数量" Width="80" />
                            <ext:Column runat="server" DataIndex="SHIPMENTS_DESC" Text="发货描述" Width="80" />
                            <ext:Column runat="server" DataIndex="SRM_DESC" Text="客户要求" Width="80" />
                            <ext:Column runat="server" DataIndex="WH_NO" Text="归属仓库" Width="80" />
                            <ext:Column runat="server" DataIndex="DELETE_FLAG" Text="删除标记" Width="80" />
                            <ext:Column runat="server" DataIndex="RECORD_USER_ID" Text="记录人" Width="80" />
                            <ext:Column runat="server" DataIndex="SLMS_FLAG" Text="使用标记" Width="80" />
                            <ext:Column runat="server" DataIndex="READ_USER_ID" Text="切换用户" Width="80" />

                            <ext:DateColumn runat="server" DataIndex="PRODUCT_DATE" Text="生产日期" Width="140" Format="yyyy-MM-dd HH:mm:ss" />
                            <ext:DateColumn runat="server" DataIndex="SHIPMENTS_DATE" Text="预计发货日期" Width="140" Format="yyyy-MM-dd HH:mm:ss" />
                            <ext:DateColumn runat="server" DataIndex="RECORD_TIME" Text="记录时间" Width="140" Format="yyyy-MM-dd HH:mm:ss" />
                            <ext:DateColumn runat="server" DataIndex="READTIME" Text="读取日期" Width="140" Format="yyyy-MM-dd HH:mm:ss" />
                            <ext:DateColumn runat="server" DataIndex="READ_TIME" Text="切换时间" Width="140" Format="yyyy-MM-dd HH:mm:ss" />

                            <ext:CommandColumn runat="server" Width="350" Text="操作" Align="Center">
                                <Commands>
                                    <ext:GridCommand Icon="Delete" CommandName="ForceDelete" Text="删除">
                                        <ToolTip Text="删除" />
                                    </ext:GridCommand>
                                    <ext:CommandSeparator />
                                    <ext:GridCommand Icon="TableEdit" CommandName="ForceEdit" Text="修改">
                                        <ToolTip Text="修改" />
                                    </ext:GridCommand>
                                    <ext:CommandSeparator />
                                    <ext:GridCommand Icon="Accept" CommandName="ForceExchange" Text="切换">
                                        <ToolTip Text="切换" />
                                    </ext:GridCommand>
                                    <ext:CommandSeparator />

                                </Commands>
                                <Listeners>
                                    <Command Handler="return cmdcol_click_handle(command, record);" />
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
                        <ext:GridView runat="server" StripeRows="true" TrackOver="true" EnableTextSelection="true" />
                    </View>
                </ext:GridPanel>
                <ext:Window ID="winAdd" runat="server" Icon="MonitorAdd" Closable="false" Title="添加产品信息"
                    Width="600" Height="450" Resizable="false" Hidden="true" Modal="false" BodyStyle="background-color:#fff;"
                    BodyPadding="5" Layout="Form">
                    <Items>
                        <ext:FormPanel runat="server" BodyPadding="5" Border="false">
                            <FieldDefaults>
                                <CustomConfig>
                                    <ext:ConfigItem Name="LabelWidth" Value="80" Mode="Raw" />
                                    <ext:ConfigItem Name="PreserveIndicatorIcon" Value="true" Mode="Raw" />
                                </CustomConfig>
                            </FieldDefaults>
                            <Items>

                                <ext:Container runat="server" Layout="HBoxLayout" Padding="5">
                                    <Items>
                                        <ext:ComboBox ID="txtShiftIdAdd" runat="server" Editable="false" FieldLabel="生产班组" LabelAlign="Right" Flex="1" IndicatorText="*" IndicatorCls="red-text" />
                                        <ext:ComboBox ID="txtEquipNo_add" runat="server" Editable="false" FieldLabel="生产机台" LabelAlign="Right" Flex="1" IndicatorText="*" IndicatorCls="red-text" />
                                    </Items>
                                </ext:Container>
                                 <ext:Container runat="server" Layout="HBoxLayout" Padding="5">
                                    <Items>
                                        <ext:FieldContainer runat="server" FieldLabel="物料编码" Layout="HBox" LabelAlign="Right" Flex="1">
                                            <Items>
                                                <ext:TriggerField ID="txtAddMaterNo" runat="server" Flex="1" Editable="false">
                                                    <Triggers>
                                                        <ext:FieldTrigger Icon="Search" />
                                                    </Triggers>
                                                    <Listeners>
                                                        <TriggerClick Fn="TriggerFieldSearchMaterDatas" />
                                                    </Listeners>
                                                </ext:TriggerField>
                                                <ext:TextField ID="txtProductName" runat="server" Width="120" ReadOnly="true" />
                                            </Items>
                                        </ext:FieldContainer>
                                    </Items>
                                </ext:Container>
                                <ext:Container runat="server" Layout="HBoxLayout" Padding="5">
                                    <Items>
                                        <ext:TextField ID="txtBatchNo" runat="server" FieldLabel="批次号" LabelAlign="right" Flex="1" />
                                        <%--<ext:TextField ID="txtProductName" runat="server" FieldLabel="产品名称" LabelAlign="right" Flex="1" />--%>
                                    </Items>
                                </ext:Container>
                                <ext:Container runat="server" Layout="HBoxLayout" Padding="5">
                                    <Items>
                                        <ext:TextField ID="txtStandardWeight" runat="server" FieldLabel="标准重量" LabelAlign="right" Flex="1" IndicatorText="*" IndicatorCls="red-text" />
                                        <ext:TextField ID="txtAllowErrRange" runat="server" FieldLabel="允许误差" LabelAlign="right" Flex="1" IndicatorText="*" IndicatorCls="red-text" />
                                    </Items>
                                </ext:Container>
                                <ext:Container runat="server" Layout="HBoxLayout" Padding="5">
                                    <Items>
                                        <ext:TextField ID="txtSrmName" runat="server" FieldLabel="客户名称" LabelAlign="right" Flex="1" />
                                        <ext:TextField ID="txtLetterNo" runat="server" FieldLabel="确认函号" LabelAlign="right" Flex="1" />
                                    </Items>
                                </ext:Container>
                                <ext:Container runat="server" Layout="HBoxLayout" Padding="5">
                                    <Items>
                                        <ext:TextField ID="txtProductBatch" runat="server" FieldLabel="生产批号" LabelAlign="right" Flex="1" />
                                        <ext:TextField ID="txtProductQty" runat="server" FieldLabel="生产数量" LabelAlign="right" Flex="1" />
                                        <ext:TextField ID="txtOrderQty" runat="server" FieldLabel="订单数量" LabelAlign="right" Flex="1" />
                                    </Items>
                                </ext:Container>
                                <ext:Container runat="server" Layout="HBoxLayout" Padding="5">
                                    <Items>
                                        <ext:TextField ID="txtShipDesc" runat="server" FieldLabel="发货描述" LabelAlign="right" Flex="1" />
                                        <ext:TextField ID="txtPackType" runat="server" FieldLabel="包装类型" LabelAlign="right" Flex="1" />
                                    </Items>
                                </ext:Container>
                                <ext:Container runat="server" Layout="HBoxLayout" Padding="5">
                                    <Items>
                                        <ext:TextField ID="txtSrmDesc" runat="server" FieldLabel="客户要求" LabelAlign="right" Flex="1" />
                                    </Items>
                                </ext:Container>
                                <ext:Container runat="server" Layout="HBoxLayout" Padding="5">
                                    <Items>
                                        <%--<ext:TextField ID="txtWhNo" runat="server" FieldLabel="归属仓库" LabelAlign="right" Flex="1" />--%>
                                       <ext:ComboBox ID="txtWhNo" runat="server" Editable="false" FieldLabel="归属仓库" LabelAlign="Right" Flex="1" IndicatorText="*" IndicatorCls="red-text" />

                                    </Items>
                                </ext:Container>
                                <ext:Container runat="server" Layout="HBoxLayout" Padding="5">
                                    <Items>
                                        <ext:DateField ID="txtProductDate" runat="server" FieldLabel="生产日期" LabelAlign="right" Flex="1" />
                                        <ext:DateField ID="txtShipDate" runat="server" FieldLabel="预计发货日期" LabelAlign="right" Flex="1" />
                                    </Items>
                                </ext:Container>
                            </Items>
                        </ext:FormPanel>
                    </Items>
                    <Buttons>
                        <ext:Button ID="btnAddSave" runat="server" Text="确定" Icon="Accept">
                            <ToolTips>
                                <ext:ToolTip runat="server" Html="点击进行添加" />
                            </ToolTips>
                            <Listeners>
                                <Click Handler="saveAddWindows();" />
                            </Listeners>
                        </ext:Button>
                        <ext:Button ID="btnAddCancel" runat="server" Text="取消" Icon="Cancel">
                            <ToolTips>
                                <ext:ToolTip runat="server" Html="点击关闭窗口" />
                            </ToolTips>
                            <Listeners>
                                <Click Handler="App.winAdd.close();" />
                            </Listeners>
                        </ext:Button>
                    </Buttons>
                </ext:Window>
                        <ext:Window ID="winEdit" runat="server" Icon="MonitorAdd" Closable="false" Title="修改产品信息"
                    Width="600" Height="400" Resizable="false" Hidden="true" Modal="false" BodyStyle="background-color:#fff;"
                    BodyPadding="5" Layout="Form">
                    <Items>
                        <ext:FormPanel runat="server" BodyPadding="5" Border="false">
                            <FieldDefaults>
                                <CustomConfig>
                                    <ext:ConfigItem Name="LabelWidth" Value="80" Mode="Raw" />
                                    <ext:ConfigItem Name="PreserveIndicatorIcon" Value="true" Mode="Raw" />
                                </CustomConfig>
                            </FieldDefaults>
                            <Items>
                                <ext:Container runat="server" Layout="HBoxLayout" Padding="5">
                                    <Items>
                                         <ext:TextField ID="OBJID_EDIT" runat="server" FieldLabel="OBJID" LabelAlign="right" Flex="1" Disabled =" true"/>
                                        <ext:ComboBox ID="txtshifid_edit" runat="server" Editable="false" FieldLabel="生产班组" LabelAlign="Right" Flex="1" IndicatorText="*" IndicatorCls="red-text" />
                                        <ext:ComboBox ID="txtEquipNo_edit" runat="server" Editable="false" FieldLabel="生产机台" LabelAlign="Right" Flex="1" IndicatorText="*" IndicatorCls="red-text" />
                                    </Items>
                                </ext:Container>
                                     <ext:Container runat="server" Layout="HBoxLayout" Padding="5">
                                    <Items>
                                        <ext:FieldContainer runat="server" FieldLabel="物料编码" Layout="HBox" LabelAlign="Right" Flex="1">
                                            <Items>
                                                <ext:TriggerField ID="txtMaterNo_edit" runat="server" Flex="1" Editable="false">
                                                    <Triggers>
                                                        <ext:FieldTrigger Icon="Search" />
                                                    </Triggers>
                                                    <Listeners>
                                                        <TriggerClick Fn="TriggerFieldSearchMaterDatas" />
                                                    </Listeners>
                                                </ext:TriggerField>
                                                <ext:TextField ID="txtProductName_edit" runat="server" Width="120" ReadOnly="true" />
                                            </Items>
                                        </ext:FieldContainer>
                                    </Items>
                                </ext:Container>
                                <ext:Container runat="server" Layout="HBoxLayout" Padding="5">
                                    <Items>
                                        <ext:TextField ID="txtBatchNo_edit" runat="server" FieldLabel="批次号" LabelAlign="right" Flex="1" />
                                        <%--<ext:TextField ID="txtProductName_edit" runat="server" FieldLabel="产品名称" LabelAlign="right" Flex="1" />--%>
                                    </Items>
                                </ext:Container>
                                <ext:Container runat="server" Layout="HBoxLayout" Padding="5">
                                    <Items>
                                        <ext:TextField ID="txtStandardWeight_edit" runat="server" FieldLabel="标准重量" LabelAlign="right" Flex="1" IndicatorText="*" IndicatorCls="red-text" />
                                        <ext:TextField ID="txtAllowErrRange_edit" runat="server" FieldLabel="允许误差" LabelAlign="right" Flex="1" IndicatorText="*" IndicatorCls="red-text" />
                                    </Items>
                                </ext:Container>
                                <ext:Container runat="server" Layout="HBoxLayout" Padding="5">
                                    <Items>
                                        <ext:TextField ID="txtSrmName_edit" runat="server" FieldLabel="客户名称" LabelAlign="right" Flex="1" />
                                        <ext:TextField ID="txtLetterNo_edit" runat="server" FieldLabel="确认函号" LabelAlign="right" Flex="1" />
                                    </Items>
                                </ext:Container>
                                <ext:Container runat="server" Layout="HBoxLayout" Padding="5">
                                    <Items>
                                        <ext:TextField ID="txtProductBatch_edit" runat="server" FieldLabel="生产批号" LabelAlign="right" Flex="1" />
                                        <ext:TextField ID="txtProductQty_edit" runat="server" FieldLabel="生产数量" LabelAlign="right" Flex="1" />
                                        <ext:TextField ID="txtOrderQty_edit" runat="server" FieldLabel="订单数量" LabelAlign="right" Flex="1" />
                                    </Items>
                                </ext:Container>
                                <ext:Container runat="server" Layout="HBoxLayout" Padding="5">
                                    <Items>
                                        <ext:TextField ID="txtShipDesc_edit" runat="server" FieldLabel="发货描述" LabelAlign="right" Flex="1" />
                                        <ext:TextField ID="txtPackType_edit" runat="server" FieldLabel="包装类型" LabelAlign="right" Flex="1" />
                                    </Items>
                                </ext:Container>
                                <ext:Container runat="server" Layout="HBoxLayout" Padding="5">
                                    <Items>
                                        <ext:TextField ID="txtSrmDesc_edit" runat="server" FieldLabel="客户要求" LabelAlign="right" Flex="1" />
                                    </Items>
                                </ext:Container>
                                <ext:Container runat="server" Layout="HBoxLayout" Padding="5">
                                    <Items>
                                       <ext:ComboBox ID="txtWhNo_edit" runat="server" Editable="false" FieldLabel="归属仓库" LabelAlign="Right" Flex="1" IndicatorText="*" IndicatorCls="red-text" />
                                    </Items>
                                </ext:Container>
                                <ext:Container runat="server" Layout="HBoxLayout" Padding="5">
                                    <Items>
                                        <ext:DateField ID="txtProductDate_edit"  runat="server" FieldLabel="生产日期" LabelAlign="right" Flex="1" />
                                        <ext:DateField ID="txtShipDate_edit" runat="server" FieldLabel="预计发货日期" LabelAlign="right" Flex="1" />
                                    </Items>
                                </ext:Container>
                            </Items>
                        </ext:FormPanel>
                    </Items>
                    <Buttons>
                        <ext:Button ID="Button1" runat="server" Text="确定" Icon="Accept">
                            <ToolTips>
                                <ext:ToolTip runat="server" Html="点击进行添加" />
                            </ToolTips>
                            <Listeners>
                                <Click Handler="saveEditWindows();" />
                            </Listeners>
                        </ext:Button>
                        <ext:Button ID="Button4" runat="server" Text="取消" Icon="Cancel">
                            <ToolTips>
                                <ext:ToolTip runat="server" Html="点击关闭窗口" />
                            </ToolTips>
                            <Listeners>
                                <Click Handler="App.winEdit.close();" />
                            </Listeners>
                        </ext:Button>
                    </Buttons>
                </ext:Window>
            </Items>
        </ext:Viewport>
    </form>
</body>
</html>


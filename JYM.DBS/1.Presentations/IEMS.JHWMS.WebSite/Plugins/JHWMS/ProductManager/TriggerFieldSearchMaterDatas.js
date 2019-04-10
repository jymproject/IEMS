//查询物料信息
Ext.create("Ext.window.Window", {
//查询带回窗体
    id: "McUI_SearchBox_SearchMaterData_Window",
    height: 460,
    hidden: true,
    width: 560,
    html: "<iframe src='" + thisRootUrl + "McUI/SearchBox/SearchMaterData.aspx' width=100% height=100% scrolling=no  frameborder=0></iframe>",
    bodyStyle: "background-color: #fff;",
    closable: true,
    title: "请选择",
    modal: true
});

var McUI_SearchBox_SearchMaterData_Request = function (record) {
    //返回值处理
    App.txtProductName.setValue(record.data.MATER_NAME);
    App.txtAddMaterNo.setValue(record.data.MATER_NO);
    App.txtProductName_edit.setValue(record.data.MATER_NAME);
    App.txtMaterNo_edit.setValue(record.data.MATER_NO);
}

var TriggerFieldSearchMaterDatas = function () {//查询
    var window = App.McUI_SearchBox_SearchMaterData_Window;
    window.show();
}
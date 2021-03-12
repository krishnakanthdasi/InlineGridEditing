var demo = (function () {
     

    return {
        jqGrid: {
              
            nullAsUnknownFormatter: function (cellvalue, options, rowObject) {
                if (cellvalue === null) {
                    cellvalue = 'Unknown';
                }

                return cellvalue;
            },
            onJqGridInlineSuccessSaveRow: function (e, jqXHR, rowId, options) {
                var response = JSON.parse(jqXHR.responseText);

                return [response.Status, null];
            },
            onJqGridInlineAfterSaveRow: function (e, rowId, jqXHR, data, otions) {
                var response = JSON.parse(jqXHR.responseText);

                if (response.Status) {
                    $('#' + rowId).attr('id', response.EmpId);
                }
            }
        }
    };
})();
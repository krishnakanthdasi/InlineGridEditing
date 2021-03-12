var demo = (function () {


    return {
        jqGrid: {
            employee: {
                department: function (cellvalue, options, rowObject) {
                    var departmentDescription = cellvalue;

                    if (!isNaN(cellvalue)) {
                        var departmentValue = parseInt(cellvalue);
                        
                        switch (departmentValue) {
                            case 1:
                                departmentDescription = 'IT';
                                break;
                            case 2:
                                departmentDescription = 'Finance';
                                break;
                            case 3:
                                departmentDescription = 'REFM';
                                break;
                            case 4:
                                departmentDescription = 'Retail';
                                break;
                            default:
                                departmentDescription = '';
                                break;
                        }
                    }

                    return departmentDescription;
                },
                maritalStatus: function (cellvalue, options, rowObject) {
                    var maritalStatusDescription = cellvalue;

                    if (!isNaN(cellvalue)) {
                        var maritalStatusValue = parseInt(cellvalue);

                        switch (maritalStatusValue) {
                            case 1:
                                maritalStatusDescription = 'Married';
                                break;
                            case 2:
                                maritalStatusDescription = 'Single';
                                break;
                            case 3:
                                maritalStatusDescription = 'Divorced';
                                break;
                             
                            default:
                                maritalStatusDescription = '';
                                break;
                        }
                    }

                    return maritalStatusDescription;
                },
                permenant: function (cellvalue, options, rowObject) {
                    var permenantDescription = cellvalue;

                    if (permenantDescription === null) {
                        permenantDescription = 'No';
                    }
                    else if (!isNaN(cellvalue)) {
                        var permenantValue = cellvalue;

                        switch (permenantValue) {
                            case 'Yes':
                                permenantDescription = 'Yes';
                                break;
                            case 'No':
                                permenantDescription = 'No';
                                break;

                            default:
                                permenantDescription = 'No';
                                break;
                        }
                    }

                    return permenantDescription;
                } 
            },

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
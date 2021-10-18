function TimeTrickToReadableDatetime(date) {

    return (date.replace('/Date(', '').replace(')/', ''));
    //if (date != null || date != null) {
    //   return (date.replace('/Date(', '')).replace(')/', '');
    //    //tmp = new Date(tmp);
    //}
    //else
    //    return 'Date is not defined'
}

function getUrlParameter(name) {
    name = name.replace(/[\[]/, '\\[').replace(/[\]]/, '\\]');
    var regex = new RegExp('[\\?&]' + name + '=([^&#]*)');
    var results = regex.exec(location.search);
    return results === null ? '' : decodeURIComponent(results[1].replace(/\+/g, ' '));
};
//navTabToggle.js

if (location.hash) {
    $('a[ng-href=\'' + location.hash + '\']').tab('show');
}
var activeTab = localStorage.getItem('activeTab');
if (activeTab) {
    $('a[ng-href="' + activeTab + '"]').tab('show');
}

$('body').on('click',
    'a[data-toggle=\'tab\']',
    function(e) {
        e.preventDefault();
        var tabName = this.getAttribute('href');
        if (history.pushState) {
            history.pushState(null, null, tabName);
        } else {
            location.hash = tabName;
        }
        localStorage.setItem('activeTab', tabName);

        $(this).tab('show');
        return false;
    });
$(window).on('popstate',
    function() {
        var anchor = location.hash ||
            $('a[data-toggle=\'tab\']').first().attr('ng-href');
        $('a[ng-href=\'' + anchor + '\']').tab('show');
    });
/** @license -*- Engage Auth Widget -*-
 *  Copyright (c) 2011, Janrain, Inc. All rights reserved.
 *  Version: 2012.2_rc6
 */

(function() {
    window.janrain.engage = {};
    if (!janrain.settings.linkClass) janrain.settings.linkClass = 'janrainEngage';
    janrain.settings.version = '2012.2_rc6';
    janrain.settings.permissions = [];
    if (!janrain.settings.language) janrain.settings.language = 'en';
    if (!janrain.settings.appUrl) janrain.settings.appUrl = 'https://pivotcard.rpxnow.com';
    if (!janrain.settings.providers) janrain.settings.providers = [
	'blogger',
	'facebook',
	'google',
	'yahoo',
	'openid',
	'flickr'];
    if (!janrain.settings.buttonBorderColor) janrain.settings.buttonBorderColor = '#CCCCCC';
    if (!janrain.settings.type) janrain.settings.type = 'embed';
    if (!janrain.settings.fontFamily) janrain.settings.fontFamily = 'lucida grande, Helvetica, Verdana, sans-serif';
    if (!janrain.settings.buttonBackgroundStyle) janrain.settings.buttonBackgroundStyle = 'gradient';
    if (!janrain.settings.format) janrain.settings.format = 'two column';
    if (!janrain.settings.borderColor) janrain.settings.borderColor = '#C0C0C0';
    if (!janrain.settings.actionText) janrain.settings.actionText = 'Sign in using your account with';
    if (!janrain.settings.backgroundColor) janrain.settings.backgroundColor = '#ffffff';
    if (!janrain.settings.borderRadius && janrain.settings.borderRadius != 0) janrain.settings.borderRadius = '10';
    if (!janrain.settings.width) janrain.settings.width = '392';
    if (!janrain.settings.borderWidth && janrain.settings.borderWidth != 0) janrain.settings.borderWidth = '10';
    if (!janrain.settings.providersPerPage) janrain.settings.providersPerPage = '6';
    if (!janrain.settings.buttonBorderRadius && janrain.settings.buttonBorderRadius != 0) janrain.settings.buttonBorderRadius = '5';
    if (!janrain.settings.fontColor) janrain.settings.fontColor = '#666666';


    var scripts = document.getElementsByTagName('script')[0];

    // only load for non-english
    if (janrain.settings.language != 'en') {
      var translationScript = document.createElement('script');
      translationScript.type = 'text/javascript';
      if (document.location.protocol === 'https:') {
        host = 'https://d29usylhdk1xyu.cloudfront.net/';
      } else {
        host = 'http://widget-cdn.rpxnow.com/';
      }
      translationScript.src = host + 'js/lib/' + janrain.settings.language + '/translate.js';
      scripts.parentNode.insertBefore(translationScript, scripts);
    }

    var e = document.createElement('script');
    e.type = 'text/javascript';
    if (document.location.protocol === 'https:') {
      e.src = 'https://d29usylhdk1xyu.cloudfront.net/js/lib/engage_signin.js?version=2012.2_rc6';
    } else {
      e.src = 'http://widget-cdn.rpxnow.com/js/lib/engage_signin.js?version=2012.2_rc6';
    }
    scripts.parentNode.insertBefore(e, scripts);
})();

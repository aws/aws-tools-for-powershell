var AWSHelpObj = {
    /*
     * toggles the display of the popup Fx versions panel,
     * placing it beneath the simulated Other Versions link
     */
    toggleVersions: function() {
        var el;
        if (el = document.getElementById("vsPanel")) {
            el.style.display = (el.style.display == 'inline-block' ? 'none' : 'inline-block');
        }
    },

    addEvent: function (obj, type, fn) {
        if (obj.attachEvent) {
            obj['e' + type + fn] = fn;
            obj[type + fn] = function() {
                obj['e' + type + fn](window.event);
            }
            obj.attachEvent('on' + type, obj[type + fn]);
        }
        else {
            obj.addEventListener(type, fn, false);
        }
    },

    removeEvent: function(obj, type, fn) {
        if (obj.detachEvent) {
            obj.detachEvent('on' + type, obj[type + fn]);
            obj[type + fn] = null;
        }
        else {
            obj.removeEventListener(type, fn, false);
        }
    },

    isParentOf: function(target, parent) {
        var current = target;
        while (current !== document.body) {
            if (current === parent) {
                return true;
            }
            else {
                current = current.parentNode;
            }
        }
        return false;
    },

    displayLink: function (page, tocid) {
        var queryString = "?page=" + page + "&tocid=" + tocid;

        var pos = window.location.href.lastIndexOf('/items/');
        var baseUrl = window.location.href.substr(0, pos) + '/Index.html' + queryString;

        prompt('Copy this URL to use to navigate to this page', baseUrl);
    },

    showRegionalDisclaimer: function (host) {
        if (host && host.match(/.cn$/))
            return true;

        return false;
    },

    searchFormSubmit: function(formElement) {
        //#facet_doc_product=AWS+Tools+for+Windows+PowerShell&amp;facet_doc_guide=Cmdlet+Reference
        var docsBase;
        if (window.location.host === "")
            docsBase = "http://docs.aws.amazon.com";
        else
            docsBase = window.location.protocol + "//" + window.location.host;
        var si = jQuery("#sel").attr("selectedIndex");
        var so = jQuery("#sel").attr("options").item(si).value;
        if (so.indexOf("documentation") === 0) {
            var this_doc_product = jQuery("#this_doc_product").val();
            var this_doc_guide = jQuery("#this_doc_guide").val();
            var action = "";
            var facet = "";
            if (so === "documentation-product" || so === "documentation-guide") {
                action += "?doc_product=" + encodeURIComponent(this_doc_product);
                facet += "#facet_doc_product=" + encodeURIComponent(this_doc_product);
                if (so === "documentation-guide") {
                    action += "&doc_guide=" + encodeURIComponent(this_doc_guide);
                    facet += "&facet_doc_guide=" + encodeURIComponent(this_doc_guide);
                }
            }
            if (jQuery.browser.msie) {
                var sq = jQuery("#sq").val();
                action += "&searchPath=" + encodeURIComponent(so);
                action += "&searchQuery=" + encodeURIComponent(sq);
                window.location.href = docsBase + "/search/doc-search.html" + action + facet;
                return false;
            } else {
                formElement.action = docsBase + "/search/doc-search.html" + facet;
            }
        } else {
            formElement.action = "http://aws.amazon.com/search";
        }
        return true;
    },

    setAssemblyVersion: function () {
        jQuery.ajax({
            url: "../items/assemblyversions.json",
            dataType: "json",
            success: function (data) {
                var v = data["awspowershell.dll"];
                if (v) {
                    jQuery("#assemblyVersion").text(v);
                }
            }
        });
    }
};

(function() {
    //var clickable = document.getElementById("vsLink");
    //AWSHelpObj.addEvent(document.body, 'click', function (evt) 
    //{
    //    var tgt = evt.target ? evt.target : evt.srcElement;
    //    if (!AWSHelpObj.isParentOf(tgt, clickable)) 
    //    {
    //        document.getElementById('vsPanel').style.display = 'none';
    //    }
    //});
})();

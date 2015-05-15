var AWSTOCObj = {

    init: function (tocRootObj) {
        this.tocRoot = tocRootObj;
        this.clearActiveTopic();
    },

    navigateTo: function (ns, id, member, page) {
        this.clearActiveTopic();
        var tgtid = "";
        if (ns) {
            tgtid += ns;
            //this.collapseTOCGroup(this);
            this.expandTOCGroup(jQuery("li#" + ns));
        }

        if (id) {
            if (tgtid != "")
                tgtid += "_";
            tgtid += id;
            this.setActiveTopic(jQuery("li#" + tgtid).children("a.nav"));
        }
        if (page)
            this.setContentPane(page);
        else
            this.setContentPane("./items/" + member + ".html");
    },

    clearActiveTopic: function () {
        var prev = jQuery(this.tocRoot).data("activeTopic");
        if (prev) { jQuery(prev).removeClass("activeTopic"); }
    },

    setActiveTopic: function (tocItem) {
        jQuery(tocItem).addClass("activeTopic");
        jQuery(this.tocRoot).data("activeTopic", tocItem);
    },

    setContentPane: function(t) {
        jQuery(window.parent.frames["contentpane"].document.location).attr("href", t);
    },

    toggleTOCGroup: function(tocGroup) {
        if (!tocGroup) return;
        var t = jQuery(tocGroup);
        if (t) {
            t.children("ul").toggleClass("expanded");
            t.toggleClass("expanded");            
        }
    },
    
    collapseTOCGroup: function(g) {
        g.children("ul").removeClass("expanded");
        g.removeClass("expanded");
    },
    
    expandTOCGroup: function(g) {
        g.children("ul").addClass("expanded");
        g.addClass("expanded");
    },
    
    dummy: null
};

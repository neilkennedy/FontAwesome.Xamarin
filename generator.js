/*
    Use this JS snippet to get the public string properties of all the FontAwesome icons.
    
    Use Chrome dev tools to run the below snippet into http://fortawesome.github.io/Font-Awesome/cheatsheet/
    
    Call fontAwesomeXamarin.generate() to print all the icon properties to the dev console.

*/
var FontAwesomeXamarin = {

    columns: $('.col-md-4.col-sm-6.col-lg-3').clone(),

    generate: function () {
        var self = this,
            label,
            unicode,
            spanElement,
            iElement;
        $.each(self.columns, function (index, column) {
            column = $(column);
            spanElement = column.find('span');
            iElement = column.find('i');

            unicode = spanElement.text().replace("[&#x", "\\u").replace(";]", "").replace("(alias)","");

            spanElement.remove();
            iElement.remove();

            label = self.toTitleCase(column.text());
            label = label.replace("Fa", "FA").replace(/- */g, ""); //remove the dashes and capitalise the Fa

            var startIdx = label.indexOf('F');
            console.log("public static string " + label.substr(startIdx) + " = \"" + unicode + "\";");

        });
    },

    toTitleCase: function (str) {
        str = str.replace(/^\s+|\s+$/g, ""); //trim whitespace

        return str.replace(/([^\W_]+[^\s-]*) */g, function (txt) {
            return txt.charAt(0).toUpperCase() + txt.substr(1).toLowerCase();
        });
    }
};

window.fontAwesomeXamarin = FontAwesomeXamarin;

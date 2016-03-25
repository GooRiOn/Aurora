Array.prototype['firstOrNull'] = function (filter) {
    if (typeof filter == "undefined")
        return this.length > 0 ? this[0] : null;
    for (var i = 0; i < this.length; i++)
        if (filter(this[i]))
            return this[i];
    return null;
};
Array.prototype['remove'] = function (item) {
    var index = this.indexOf(item);
    this.splice(index, 1);
};
//# sourceMappingURL=array-extensions.js.map
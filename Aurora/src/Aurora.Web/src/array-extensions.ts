interface Array<T> {
    firstOrNull(predicate?: (item: T) => boolean): T;
    remove(item: any): void;
}

Array.prototype['firstOrNull'] = function (filter?: (item: any) => boolean)
{
    if (typeof filter == "undefined")
        return this.length > 0 ? this[0] : null;

    for (var i = 0; i < this.length; i++)
        if (filter(this[i]))
            return this[i];

    return null;
}

Array.prototype['remove'] = function (item: any)
{
    var index = this.indexOf(item);
    this.splice(index, 1);
}

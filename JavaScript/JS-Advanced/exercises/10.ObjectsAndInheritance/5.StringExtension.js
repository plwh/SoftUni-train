(function solve (){
    String.prototype.ensureStart = function (str) {
        return this.startsWith(str)? this : str.concat(this);
    };

    String.prototype.ensureEnd = function (str) {
        return this.endsWith(str) ? this : this.concat(str);
    };

    String.prototype.isEmpty = function () {
        return this.length == 0 ? true : false;
    };

    String.prototype.truncate = function (n) {
        let result = '';

        if(this.length < n) {
            result = this;
        } else {

        }

        return result;
    };

    String.format = function (string, ...parameters ) {
        let result = string;

        for (let i = 0; i < parameters.length; i ++) {
            result = result.replace(`{${i}}`, parameters[i]);
        }

        return result;
    };
})();

let str = 'my string'
str = str.ensureStart('my')
str = str.ensureStart('hello ')
str = str.truncate(16)
str = str.truncate(14)
str = str.truncate(8)
str = str.truncate(4)
str = str.truncate(2)
str = String.format('The {0} {1} fox',
    'quick', 'brown');
console.log(str);
str = String.format('jumps {0} {1}',
    'dog');
console.log(str);
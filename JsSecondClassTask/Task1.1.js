function ProtoShape(){};

ProtoShape.prototype.GetProtoSquare = function(){};

function ProtoSquare(side){
    this.side = side;
}

ProtoSquare.prototype.proto = ProtoShape.prototype;

ProtoSquare.prototype.GetProtoSquare = function(){
    console.log(parseInt(Math.pow(this.side, 2)));
}

function ProtoCircle(radius){
this.radius = radius;
}

ProtoCircle.prototype.proto = ProtoShape.prototype;

ProtoCircle.prototype.GetProtoSquare = function(){
    console.log(parseInt(Math.pow(this.radius, 2))* Math.PI);
}
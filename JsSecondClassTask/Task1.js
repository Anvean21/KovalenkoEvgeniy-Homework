class Shape{
     GetSquare(){
     console.log("Площадь фигуры равна:");   
    }
}

class Circle extends Shape{
    constructor(radius){
        super();
        this.radius = radius;
    }
    GetSquare(){
        super.GetSquare();
        console.log(parseInt(Math.pow(this.radius, 2)) * Math.PI)
    }
}

class Square extends Shape{
    constructor(side){
        super();
        this.side = side;
    }
    GetSquare(){
        super.GetSquare();
        console.log(parseInt(Math.pow(this.side, 2)))
    }
}

let circle = new Circle(10);
circle.GetSquare();

let square = new Square(10);
square.GetSquare();
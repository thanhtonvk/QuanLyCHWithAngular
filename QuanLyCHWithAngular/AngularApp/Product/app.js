var app = angular.module("Product",[]);
app.controller("ProductController",function($scope,$http){
    debugger;
    $scope.GetAllData = function(searchString){
        searchString = document.getElementById("txtSearch").value.toString();
        $http({
            method:"get",
            url:"/Admin/Product/GetAllData/?searchString="+searchString,
        }).then(function(response){
            $scope.ProductList = response.data;
        },function(){
            alert("Lỗi lấy dữ liệu");
        })
    }
    $scope.InsertData = function(){
        var Action = document.getElementById("btnSave").getAttribute("value");
        if(Action=="Submit"){
            $scope.Product = {};
            $scope.Product.Name = $scope.Name_;
            $scope.Product.Details = $scope.Details_;
            $scope.Product.Image = $scope.Image_;
            $scope.Product.Cost = $scope.Cost_;
            $scope.Product.IDCategory = $scope.IDCategory_;
            $http({
                method: "post",
                url: "/Admin/Product/InsertData",
                dataType:"json",
                data:JSON.stringify($scope.Product)
            }).then(function(response){
                alert(response.data);
                $scope.GetAllData('');
                $scope.Name = "";
            })
        }else{
            $scope.Product = {};
            $scope.Product.Name = $scope.Name_;
            $scope.Product.Details = $scope.Details_;
            $scope.Product.Image = $scope.Image_;
            $scope.Product.Cost = $scope.Cost_;
            $scope.Product.IDCategory = $scope.IDCategory_;
            $scope.Product.ID = document.getElementById("ID_").value;
            $http({
                method:"post",
                url: "/Admin/Product/UpdateData",
                dataType:"json",
                data:JSON.stringify($scope.Product)
            }).then(function(response){
                alert(response.data);
                $scope.GetAllData('');
                $scope.Name = "";
                document.getElementById("btnSave").setAttribute("value","Submit");
            })
        }
    }
    $scope.UpdateData = function(Product){
        document.getElementById("ID_").value = Product.ID;
        $scope.Name_ = Product.Name;
        $scope.Details_ = Product.Defaults;
        $scope.Image_ = Product.Image;
        $scope.Cost_ = Product.Cost;
        $scope.IDCategory_ = Product.IDCategory;
        document.getElementById("btnSave").setAttribute("value","Update");
    }
    $scope.DeleteData = function(Product){
        $http({
            method:"post",
            url: "/Admin/Product/DeleteData",
            dataType:"json",
            data:JSON.stringify(Product)
        }).then(function(response){
            alert(response.data);
            $scope.GetAllData('');
        })
    }
})
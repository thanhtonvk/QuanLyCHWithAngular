var app = angular.module("Category",[]);
app.controller("CategoryController",function($scope,$http){
    debugger;
    $scope.GetAllData = function(searchString){
        searchString = document.getElementById("txtSearch").value.toString();
        $http({
            method:"get",
            url:"/Admin/Category/GetAllData/?searchString="+searchString,
        }).then(function(response){
            $scope.CategoryList = response.data;
        },function(){
            alert("Lỗi lấy dữ liệu");
        })
    }
    $scope.InsertData = function(){
        var Action = document.getElementById("btnSave").getAttribute("value");
        if(Action=="Submit"){
            $scope.Category = {};
            $scope.Category.Name = $scope.Name_;
            $http({
                method: "post",
                url: "/Admin/Category/InsertData",
                dataType:"json",
                data:JSON.stringify($scope.Category)
            }).then(function(response){
                alert(response.data);
                $scope.GetAllData('');
                $scope.Name = "";
            })
        }else{
            $scope.Category = {};
            $scope.Category.Name = $scope.Name_;
            $scope.Category.ID = document.getElementById("ID_").value;
            $http({
                method:"post",
                url: "/Admin/Category/UpdateData",
                dataType:"json",
                data:JSON.stringify($scope.Category)
            }).then(function(response){
                alert(response.data);
                $scope.GetAllData('');
                $scope.Name = "";
                document.getElementById("btnSave").setAttribute("value","Submit");
            })
        }
    }
    $scope.UpdateData = function(Category){
        document.getElementById("ID_").value = Category.ID;
        $scope.Name_ = Category.Name;
        document.getElementById("btnSave").setAttribute("value","Update");
    }
    $scope.DeleteData = function(Category){
        $http({
            method:"post",
            url: "/Admin/Category/DeleteData",
            dataType:"json",
            data:JSON.stringify(Category)
        }).then(function(response){
            alert(response.data);
            $scope.GetAllData('');
        })
    }
})
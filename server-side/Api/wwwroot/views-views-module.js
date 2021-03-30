(window["webpackJsonp"] = window["webpackJsonp"] || []).push([["views-views-module"],{

/***/ "Iwmp":
/*!******************************************!*\
  !*** ./src/app/views/views.component.ts ***!
  \******************************************/
/*! exports provided: ViewsComponent */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "ViewsComponent", function() { return ViewsComponent; });
/* harmony import */ var _angular_core__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! @angular/core */ "fXoL");
/* harmony import */ var _angular_router__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! @angular/router */ "tyNb");


class ViewsComponent {
    constructor() { }
    ngOnInit() {
    }
}
ViewsComponent.ɵfac = function ViewsComponent_Factory(t) { return new (t || ViewsComponent)(); };
ViewsComponent.ɵcmp = _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵdefineComponent"]({ type: ViewsComponent, selectors: [["app-views"]], decls: 1, vars: 0, template: function ViewsComponent_Template(rf, ctx) { if (rf & 1) {
        _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵɵelement"](0, "router-outlet");
    } }, directives: [_angular_router__WEBPACK_IMPORTED_MODULE_1__["RouterOutlet"]], encapsulation: 2 });


/***/ }),

/***/ "S+CQ":
/*!***********************************************!*\
  !*** ./src/app/views/views-routing.module.ts ***!
  \***********************************************/
/*! exports provided: ViewsRoutingModule */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "ViewsRoutingModule", function() { return ViewsRoutingModule; });
/* harmony import */ var _angular_router__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! @angular/router */ "tyNb");
/* harmony import */ var _views_component__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! ./views.component */ "Iwmp");
/* harmony import */ var _angular_core__WEBPACK_IMPORTED_MODULE_2__ = __webpack_require__(/*! @angular/core */ "fXoL");




const routes = [
    {
        path: '', component: _views_component__WEBPACK_IMPORTED_MODULE_1__["ViewsComponent"],
        children: [
            { path: '', loadChildren: () => Promise.all(/*! import() | main-main-module */[__webpack_require__.e("default~auth-auth-module~main-main-module"), __webpack_require__.e("main-main-module")]).then(__webpack_require__.bind(null, /*! ./main/main.module */ "6Fix")).then(x => x.MainModule) },
            { path: 'main', loadChildren: () => Promise.all(/*! import() | main-main-module */[__webpack_require__.e("default~auth-auth-module~main-main-module"), __webpack_require__.e("main-main-module")]).then(__webpack_require__.bind(null, /*! ./main/main.module */ "6Fix")).then(x => x.MainModule) },
            { path: 'auth', loadChildren: () => Promise.all(/*! import() | auth-auth-module */[__webpack_require__.e("default~auth-auth-module~main-main-module"), __webpack_require__.e("auth-auth-module")]).then(__webpack_require__.bind(null, /*! ./auth/auth.module */ "FU3J")).then(x => x.AuthModule) },
            { path: 'admin', loadChildren: () => __webpack_require__.e(/*! import() | admin-admin-module */ "admin-admin-module").then(__webpack_require__.bind(null, /*! ./admin/admin.module */ "Kb0Y")).then(x => x.AdminModule) },
            { path: 'errors', loadChildren: () => __webpack_require__.e(/*! import() | errors-errors-module */ "errors-errors-module").then(__webpack_require__.bind(null, /*! ./errors/errors.module */ "m/1P")).then(x => x.ErrorsModule) },
            { path: '**', redirectTo: '/errors/not-found' }
        ]
    }
];
class ViewsRoutingModule {
}
ViewsRoutingModule.ɵfac = function ViewsRoutingModule_Factory(t) { return new (t || ViewsRoutingModule)(); };
ViewsRoutingModule.ɵmod = _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵdefineNgModule"]({ type: ViewsRoutingModule });
ViewsRoutingModule.ɵinj = _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵdefineInjector"]({ imports: [[_angular_router__WEBPACK_IMPORTED_MODULE_0__["RouterModule"].forChild(routes)], _angular_router__WEBPACK_IMPORTED_MODULE_0__["RouterModule"]] });
(function () { (typeof ngJitMode === "undefined" || ngJitMode) && _angular_core__WEBPACK_IMPORTED_MODULE_2__["ɵɵsetNgModuleScope"](ViewsRoutingModule, { imports: [_angular_router__WEBPACK_IMPORTED_MODULE_0__["RouterModule"]], exports: [_angular_router__WEBPACK_IMPORTED_MODULE_0__["RouterModule"]] }); })();


/***/ }),

/***/ "xzpJ":
/*!***************************************!*\
  !*** ./src/app/views/views.module.ts ***!
  \***************************************/
/*! exports provided: ViewsModule */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "ViewsModule", function() { return ViewsModule; });
/* harmony import */ var _angular_common__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! @angular/common */ "ofXK");
/* harmony import */ var _views_routing_module__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! ./views-routing.module */ "S+CQ");
/* harmony import */ var _views_component__WEBPACK_IMPORTED_MODULE_2__ = __webpack_require__(/*! ./views.component */ "Iwmp");
/* harmony import */ var _angular_core__WEBPACK_IMPORTED_MODULE_3__ = __webpack_require__(/*! @angular/core */ "fXoL");




class ViewsModule {
}
ViewsModule.ɵfac = function ViewsModule_Factory(t) { return new (t || ViewsModule)(); };
ViewsModule.ɵmod = _angular_core__WEBPACK_IMPORTED_MODULE_3__["ɵɵdefineNgModule"]({ type: ViewsModule });
ViewsModule.ɵinj = _angular_core__WEBPACK_IMPORTED_MODULE_3__["ɵɵdefineInjector"]({ imports: [[
            _angular_common__WEBPACK_IMPORTED_MODULE_0__["CommonModule"],
            _views_routing_module__WEBPACK_IMPORTED_MODULE_1__["ViewsRoutingModule"]
        ]] });
(function () { (typeof ngJitMode === "undefined" || ngJitMode) && _angular_core__WEBPACK_IMPORTED_MODULE_3__["ɵɵsetNgModuleScope"](ViewsModule, { declarations: [_views_component__WEBPACK_IMPORTED_MODULE_2__["ViewsComponent"]], imports: [_angular_common__WEBPACK_IMPORTED_MODULE_0__["CommonModule"],
        _views_routing_module__WEBPACK_IMPORTED_MODULE_1__["ViewsRoutingModule"]] }); })();


/***/ })

}]);
//# sourceMappingURL=views-views-module.js.map
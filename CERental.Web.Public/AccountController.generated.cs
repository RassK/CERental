// <auto-generated />
// This file was generated by a T4 template.
// Don't change it directly as your change would get overwritten.  Instead, make changes
// to the .tt file (i.e. the T4 template) and save it to regenerate this file.

// Make sure the compiler doesn't complain about missing Xml comments and CLS compliance
// 0108: suppress "Foo hides inherited member Foo. Use the new keyword if hiding was intended." when a controller and its abstract parent are both processed
// 0114: suppress "Foo.BarController.Baz()' hides inherited member 'Qux.BarController.Baz()'. To make the current member override that implementation, add the override keyword. Otherwise add the new keyword." when an action (with an argument) overrides an action in a parent controller
#pragma warning disable 1591, 3008, 3009, 0108, 0114
#region T4MVC

using System;
using System.Diagnostics;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Web;
using System.Web.Hosting;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using System.Web.Mvc.Html;
using System.Web.Routing;
using T4MVC;
namespace CERental.Web.Public.Controllers.Mvc
{
    public partial class AccountController
    {
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public AccountController() { }

        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        protected AccountController(Dummy d) { }

        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        protected RedirectToRouteResult RedirectToAction(ActionResult result)
        {
            var callInfo = result.GetT4MVCResult();
            return RedirectToRoute(callInfo.RouteValueDictionary);
        }

        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        protected RedirectToRouteResult RedirectToAction(Task<ActionResult> taskResult)
        {
            return RedirectToAction(taskResult.Result);
        }

        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        protected RedirectToRouteResult RedirectToActionPermanent(ActionResult result)
        {
            var callInfo = result.GetT4MVCResult();
            return RedirectToRoutePermanent(callInfo.RouteValueDictionary);
        }

        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        protected RedirectToRouteResult RedirectToActionPermanent(Task<ActionResult> taskResult)
        {
            return RedirectToActionPermanent(taskResult.Result);
        }

        [NonAction]
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public virtual System.Web.Mvc.ActionResult Login()
        {
            return new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.Login);
        }
        [NonAction]
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public virtual System.Web.Mvc.ActionResult ResetPassword()
        {
            return new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.ResetPassword);
        }

        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public AccountController Actions { get { return MVC.Account; } }
        [GeneratedCode("T4MVC", "2.0")]
        public readonly string Area = "";
        [GeneratedCode("T4MVC", "2.0")]
        public readonly string Name = "Account";
        [GeneratedCode("T4MVC", "2.0")]
        public const string NameConst = "Account";

        static readonly ActionNamesClass s_actions = new ActionNamesClass();
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ActionNamesClass ActionNames { get { return s_actions; } }
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ActionNamesClass
        {
            public readonly string Login = "Login";
            public readonly string Register = "Register";
            public readonly string ForgotPassword = "ForgotPassword";
            public readonly string ForgotPasswordConfirmation = "ForgotPasswordConfirmation";
            public readonly string ResetPassword = "ResetPassword";
            public readonly string ResetPasswordConfirmation = "ResetPasswordConfirmation";
            public readonly string LogOff = "LogOff";
        }

        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ActionNameConstants
        {
            public const string Login = "Login";
            public const string Register = "Register";
            public const string ForgotPassword = "ForgotPassword";
            public const string ForgotPasswordConfirmation = "ForgotPasswordConfirmation";
            public const string ResetPassword = "ResetPassword";
            public const string ResetPasswordConfirmation = "ResetPasswordConfirmation";
            public const string LogOff = "LogOff";
        }


        static readonly ActionParamsClass_Login s_params_Login = new ActionParamsClass_Login();
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ActionParamsClass_Login LoginParams { get { return s_params_Login; } }
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ActionParamsClass_Login
        {
            public readonly string returnUrl = "returnUrl";
            public readonly string model = "model";
        }
        static readonly ActionParamsClass_Register s_params_Register = new ActionParamsClass_Register();
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ActionParamsClass_Register RegisterParams { get { return s_params_Register; } }
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ActionParamsClass_Register
        {
            public readonly string model = "model";
        }
        static readonly ActionParamsClass_ForgotPassword s_params_ForgotPassword = new ActionParamsClass_ForgotPassword();
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ActionParamsClass_ForgotPassword ForgotPasswordParams { get { return s_params_ForgotPassword; } }
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ActionParamsClass_ForgotPassword
        {
            public readonly string model = "model";
        }
        static readonly ActionParamsClass_ResetPassword s_params_ResetPassword = new ActionParamsClass_ResetPassword();
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ActionParamsClass_ResetPassword ResetPasswordParams { get { return s_params_ResetPassword; } }
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ActionParamsClass_ResetPassword
        {
            public readonly string code = "code";
            public readonly string model = "model";
        }
        static readonly ViewsClass s_views = new ViewsClass();
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ViewsClass Views { get { return s_views; } }
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ViewsClass
        {
            static readonly _ViewNamesClass s_ViewNames = new _ViewNamesClass();
            public _ViewNamesClass ViewNames { get { return s_ViewNames; } }
            public class _ViewNamesClass
            {
                public readonly string ForgotPassword = "ForgotPassword";
                public readonly string ForgotPasswordConfirmation = "ForgotPasswordConfirmation";
                public readonly string Login = "Login";
                public readonly string Register = "Register";
                public readonly string ResetPassword = "ResetPassword";
                public readonly string ResetPasswordConfirmation = "ResetPasswordConfirmation";
            }
            public readonly string ForgotPassword = "~/Views/Account/ForgotPassword.cshtml";
            public readonly string ForgotPasswordConfirmation = "~/Views/Account/ForgotPasswordConfirmation.cshtml";
            public readonly string Login = "~/Views/Account/Login.cshtml";
            public readonly string Register = "~/Views/Account/Register.cshtml";
            public readonly string ResetPassword = "~/Views/Account/ResetPassword.cshtml";
            public readonly string ResetPasswordConfirmation = "~/Views/Account/ResetPasswordConfirmation.cshtml";
        }
    }

    [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
    public partial class T4MVC_AccountController : CERental.Web.Public.Controllers.Mvc.AccountController
    {
        public T4MVC_AccountController() : base(Dummy.Instance) { }

        [NonAction]
        partial void LoginOverride(T4MVC_System_Web_Mvc_ActionResult callInfo, string returnUrl);

        [NonAction]
        public override System.Web.Mvc.ActionResult Login(string returnUrl)
        {
            var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.Login);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "returnUrl", returnUrl);
            LoginOverride(callInfo, returnUrl);
            return callInfo;
        }

        [NonAction]
        partial void LoginOverride(T4MVC_System_Web_Mvc_ActionResult callInfo, CERental.Web.Public.Models.LoginViewModel model, string returnUrl);

        [NonAction]
        public override System.Threading.Tasks.Task<System.Web.Mvc.ActionResult> Login(CERental.Web.Public.Models.LoginViewModel model, string returnUrl)
        {
            var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.Login);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "model", model);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "returnUrl", returnUrl);
            LoginOverride(callInfo, model, returnUrl);
            return System.Threading.Tasks.Task.FromResult(callInfo as ActionResult);
        }

        [NonAction]
        partial void RegisterOverride(T4MVC_System_Web_Mvc_ActionResult callInfo);

        [NonAction]
        public override System.Web.Mvc.ActionResult Register()
        {
            var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.Register);
            RegisterOverride(callInfo);
            return callInfo;
        }

        [NonAction]
        partial void RegisterOverride(T4MVC_System_Web_Mvc_ActionResult callInfo, CERental.Web.Public.Models.RegisterViewModel model);

        [NonAction]
        public override System.Threading.Tasks.Task<System.Web.Mvc.ActionResult> Register(CERental.Web.Public.Models.RegisterViewModel model)
        {
            var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.Register);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "model", model);
            RegisterOverride(callInfo, model);
            return System.Threading.Tasks.Task.FromResult(callInfo as ActionResult);
        }

        [NonAction]
        partial void ForgotPasswordOverride(T4MVC_System_Web_Mvc_ActionResult callInfo);

        [NonAction]
        public override System.Web.Mvc.ActionResult ForgotPassword()
        {
            var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.ForgotPassword);
            ForgotPasswordOverride(callInfo);
            return callInfo;
        }

        [NonAction]
        partial void ForgotPasswordOverride(T4MVC_System_Web_Mvc_ActionResult callInfo, CERental.Web.Public.Models.ForgotPasswordViewModel model);

        [NonAction]
        public override System.Threading.Tasks.Task<System.Web.Mvc.ActionResult> ForgotPassword(CERental.Web.Public.Models.ForgotPasswordViewModel model)
        {
            var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.ForgotPassword);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "model", model);
            ForgotPasswordOverride(callInfo, model);
            return System.Threading.Tasks.Task.FromResult(callInfo as ActionResult);
        }

        [NonAction]
        partial void ForgotPasswordConfirmationOverride(T4MVC_System_Web_Mvc_ActionResult callInfo);

        [NonAction]
        public override System.Web.Mvc.ActionResult ForgotPasswordConfirmation()
        {
            var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.ForgotPasswordConfirmation);
            ForgotPasswordConfirmationOverride(callInfo);
            return callInfo;
        }

        [NonAction]
        partial void ResetPasswordOverride(T4MVC_System_Web_Mvc_ActionResult callInfo, string code);

        [NonAction]
        public override System.Web.Mvc.ActionResult ResetPassword(string code)
        {
            var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.ResetPassword);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "code", code);
            ResetPasswordOverride(callInfo, code);
            return callInfo;
        }

        [NonAction]
        partial void ResetPasswordOverride(T4MVC_System_Web_Mvc_ActionResult callInfo, CERental.Web.Public.Models.ResetPasswordViewModel model);

        [NonAction]
        public override System.Threading.Tasks.Task<System.Web.Mvc.ActionResult> ResetPassword(CERental.Web.Public.Models.ResetPasswordViewModel model)
        {
            var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.ResetPassword);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "model", model);
            ResetPasswordOverride(callInfo, model);
            return System.Threading.Tasks.Task.FromResult(callInfo as ActionResult);
        }

        [NonAction]
        partial void ResetPasswordConfirmationOverride(T4MVC_System_Web_Mvc_ActionResult callInfo);

        [NonAction]
        public override System.Web.Mvc.ActionResult ResetPasswordConfirmation()
        {
            var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.ResetPasswordConfirmation);
            ResetPasswordConfirmationOverride(callInfo);
            return callInfo;
        }

        [NonAction]
        partial void LogOffOverride(T4MVC_System_Web_Mvc_ActionResult callInfo);

        [NonAction]
        public override System.Web.Mvc.ActionResult LogOff()
        {
            var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.LogOff);
            LogOffOverride(callInfo);
            return callInfo;
        }

    }
}

#endregion T4MVC
#pragma warning restore 1591, 3008, 3009, 0108, 0114

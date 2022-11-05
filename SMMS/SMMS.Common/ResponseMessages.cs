using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMMS.Common
{
    public class ResponseMessages
    {
        public const string Info = "Info";
        public const string Success = "Success";
        public const string Error = "Error";
        public const string Confirm = "Confirm";
        public const string Warning = "Warning";
        public const string Stop = "Stop";
        public const string Retry = "Retry";
        public const string Alert = "Alert";



        public const string InsertSuccess = "Record has been saved successfully !.";
        public const string InsertError = "Oops! Unable to process your request !.";

        public const string DeleteSuccess = "Record has been successfully deleted !";
        public const string DeleteError = "Oops! Unable to process your request !.";
        public const string DeleteQuestion = "Do you want to delete this record ?.";
        public const string DeleteSelectedQuestion = "Do you want to delete the selected records ?.";
        public const string DeleteAllQuestion = "Do you want to delete all the records ?.";
        public const string UnableToDelete = "Unable to delete this record due to dependencies !.";

        public const string UpdateSuccess = "Record has been updated successfully !.";
        public const string UpdateError = "Oops! Unable to process your request !.";
        public const string UpdateQuestion = "Do you want to save this record ?.";

        public const string LeaveQuestion = "Do you want to Approve this Leave ?.";
        public const string LeaveApproved = "Leavs sucessfuly approved!.";
        #region  Employee module
        public const string RegisterSuccess = "Employee has been Registered successfully !.";
        public const string EmployeUpdateSuccess = "Employee has been Updated successfully !.";
        #endregion   Employee module

        #region Login
        public const string NoUserIdAvailable = "Please Enter Your User Id !.";
        public const string NoPasswordAvailable = "Please Enter Your Password";
        public const string RegisterSucsess = "User has been Registered successfully !.";
        public const string RegisterError = "Oops! Unable to process your request !.";
        #endregion Login

        #region Reset Password
        public const string NoVerificationCodeAvailable = "Please enter the verification Code !.";
        public const string CountryNameIsNotAvailable = "Please select a country !.";
        public const string NoPhoneNumberAvailable = "Please enter your phone number !.";
        public const string ValidUserId = "Valid User Id !.";
        public const string InvalidUserId = "Invalid User Id !.";
        public const string ValidEmail = "Valid Email Address !.";
        public const string InvalidEmail = "Invalid Email Address !.";
        public const string ValidPhoneNo = "Valid Phone Number !.";
        public const string InvalidPhoneNo = "Invalid Phone Number !.";
        public const string CorrectVerificationCode = "The verification code you entered is correct. !.";
        public const string IncorrectVerificationCode = "The verification code you entered does not match. Please try again. !.";
        public const string ResetPasswordSuccessfull = "Your password is succesfully reset. Please check your email for further instructions !.";
        public const string ResetPasswordUnsuccessfull = "Reset password failed. Please check your email address !.";
        public const string InternalServerError = "Oops! Unable to process your request !.";
        public const string CommonError = "Oops! Unable to process your request !.";
        # endregion Reset Password
    }
}

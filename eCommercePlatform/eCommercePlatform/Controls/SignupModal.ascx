<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="SignupModal.ascx.cs" Inherits="eCommercePlatform.Controls.SignupModal" %>
<!-- SignupModal -->
<div class="modal fade" id="signupModal" role="dialog">
    <div class="modal-dialog modal-sm">

        <!-- Modal content-->
        <div class="modal-content">
            <div class="modal-header">
                <button type="button" class="close" data-dismiss="modal">&times;</button>
                <h4 style="color: steelblue;">
                    <span class="glyphicon glyphicon-pencil"></span>
                    <span class="glyphicon glyphicon-arrow-up"></span>
                    &nbsp;&nbsp;Signup
                </h4>
            </div>
            <div class="modal-body">
                <form role="form">
                    <div class="form-group">
                        <label for="newUsrname"><span class="glyphicon glyphicon-user"></span>&nbsp;&nbsp;Username</label>
                        <input type="text" class="form-control" id="newUsrname" placeholder="Enter username" />
                    </div>
                    <div class="form-group">
                        <label for="email"><span class="glyphicon glyphicon-envelope"></span>&nbsp;&nbsp;Email</label>
                        <input type="text" class="form-control" id="email" placeholder="Enter email" />
                    </div>
                    <div class="form-group">
                        <label for="street"><span class="glyphicon glyphicon-home"></span>&nbsp;&nbsp;Address</label>
                        <input type="text" class="form-control" id="street" placeholder="Street" />
                        <input type="text" class="form-control" id="zip" placeholder="Postal Code" />
                        <input type="text" class="form-control" id="city" placeholder="City" />
                    </div>
                    <div class="form-group">
                        <label for="newPsw"><span class="glyphicon glyphicon-eye-open"></span>&nbsp;&nbsp;Password</label>
                        <input type="text" class="form-control" id="newPsw" placeholder="Enter password" />
                        <input type="text" class="form-control" id="newPswCon" placeholder="Confirm password" />
                    </div>
                </form>
            </div>
            <div class="modal-footer">
                <button type="submit" class="btn btn-default btn-info btn-block">Sign Up</button>
            </div>
        </div>
    </div>
</div>

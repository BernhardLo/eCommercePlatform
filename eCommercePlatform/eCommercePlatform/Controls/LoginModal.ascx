<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="LoginModal.ascx.cs" Inherits="eCommercePlatform.Controls.LoginModal" %>
<!-- LoginModal -->
<div class="modal fade" id="loginModal" role="dialog">
    <div class="modal-dialog modal-sm">

        <!-- Modal content-->
        <div class="modal-content">
            <div class="modal-header">
                <button type="button" class="close" data-dismiss="modal">&times;</button>
                <h4 style="color: red;"><span class="glyphicon glyphicon-lock"></span>&nbsp;&nbsp;Login</h4>
            </div>
            <div class="modal-body">
                <form role="form">
                    <div class="form-group">
                        <label for="usrname"><span class="glyphicon glyphicon-user"></span>&nbsp;&nbsp;Username</label>
                        <input type="text" class="form-control" id="usrname" placeholder="Enter username" />
                    </div>
                    <div class="form-group">
                        <label for="psw"><span class="glyphicon glyphicon-eye-open"></span>&nbsp;&nbsp;Password</label>
                        <input type="text" class="form-control" id="psw" placeholder="Enter password" />
                    </div>
                </form>
            </div>
            <div class="modal-footer">
                <button type="submit" class="btn btn-default btn-success btn-block"><span class="glyphicon glyphicon-off"></span>&nbsp;&nbsp;Login</button>
            </div>
        </div>
    </div>
</div>

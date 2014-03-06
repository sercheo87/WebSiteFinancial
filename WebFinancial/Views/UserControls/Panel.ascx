<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Panel.ascx.cs" Inherits="Views_UserControls_Panel" %>
<script>
    $(document).on('click', '.panel-heading span.clickable', function (e) {
        var $this = $(this);
        if (!$this.hasClass('panel-collapsed')) {
            $this.parents('.panel').find('.panel-body').slideUp();
            $this.addClass('panel-collapsed');
            $this.find('i').removeClass('fa-minus').addClass('fa-plus');
        } else {
            $this.parents('.panel').find('.panel-body').slideDown();
            $this.removeClass('panel-collapsed');
            $this.find('i').removeClass('fa-plus').addClass('fa-minus');
        }
    });
    $(document).on('click', '.panel div.clickable', function (e) {
        var $this = $(this);
        if (!$this.hasClass('panel-collapsed')) {
            $this.parents('.panel').find('.panel-body').slideUp();
            $this.addClass('panel-collapsed');
            $this.find('i').removeClass('fa-minus').addClass('fa-plus');
        } else {
            $this.parents('.panel').find('.panel-body').slideDown();
            $this.removeClass('panel-collapsed');
            $this.find('i').removeClass('fa-plus').addClass('fa-minus');
        }
    });
    $(document).ready(function () {
        $('.panel-heading span.clickable').click();
        $('.panel div.clickable').click();
    });
</script>
<style>
    .clickable {
        cursor: pointer;
    }

        .clickable .glyphicon {
            background: rgba(0, 0, 0, 0.15);
            display: inline-block;
            padding: 6px 12px;
            border-radius: 4px;
        }

    a.clickable {
        color: inherit;
    }

        a.clickable:hover {
            text-decoration: none;
        }
</style>
<asp:Panel ID="pnlCtrlPanel" runat="server" CssClass="panel">
    <div class="panel-heading">
        <h3 class="panel-title"><%=Title %><span class="pull-right clickable panel-collapsed"><i class="fa fa-minus"></i></span></h3>
    </div>
    <div class="panel-body">
        <asp:PlaceHolder ID="placeHolderContent" runat="server" />
    </div>
</asp:Panel>

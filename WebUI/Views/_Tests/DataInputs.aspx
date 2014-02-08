<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Site.master" AutoEventWireup="true" CodeFile="DataInputs.aspx.cs" Inherits="Views__Tests_DataInputs" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <script type="text/javascript">
        Sys.Application.add_load(function () {
            $(document).validate({ actionButton: '.actionButton' });
        });
    </script>
    <div class="section">
        <h2>Welcome to ASP.NET!</h2>
        <p>
            To learn more about ASP.NET visit <a href="http://www.asp.net" data-toggle="tooltip" data-placement="right" title="ASP.NET Website">www.asp.net</a>.
        </p>
        <div class="row">
            <div class="form-horizontal">
                <div class="form-group">
                    <label for="inputEmail3" class="col-sm-2 control-label">Numero con signo:</label>
                    <div class="col-sm-4">
                        <asp:TextBox ID="username" CssClass="form-control integer required" runat="server" min="100" unselectedvalue="0" data-toggle="tooltip" title="Este es un dato de prueba de números enteros, por favor ingrese un valor mayor o igual a 100" />
                    </div>
                    <div class="col-sm-4">
                        <asp:TextBox ID="TextBox1" CssClass="form-control spaced-integer required" runat="server" data-toggle="tooltip" title="<%$Resources: WebUIMessages, ToolTipUsername %>" />
                    </div>
                </div>
            </div>
        </div>
        <div class="row">
            <div class="form-horizontal">
                <div class="form-group">
                    <label for="inputEmail3" class="col-sm-2 control-label">Numeros sin signo:</label>
                    <div class="col-sm-4">
                        <asp:TextBox ID="TextBox2" CssClass="form-control unsigned-integer required" runat="server" />
                    </div>
                    <div class="col-sm-4">
                        <asp:TextBox ID="TextBox3" CssClass="form-control spaced-unsigned-integer" runat="server" />
                    </div>
                </div>
            </div>
        </div>
        <div class="row">
            <div class="form-horizontal">
                <div class="form-group">
                    <label for="inputEmail3" class="col-sm-2 control-label">Numeros con decimales:</label>
                    <div class="col-sm-4">
                        <asp:TextBox ID="TextBox4" CssClass="form-control numeric" runat="server" />
                    </div>
                    <div class="col-sm-4">
                        <asp:TextBox ID="TextBox5" CssClass="form-control spaced-numeric required" runat="server" min="-100" max="100" />
                    </div>
                </div>
            </div>
        </div>
        <div class="row">
            <div class="form-horizontal">
                <div class="form-group">
                    <label for="inputEmail3" class="col-sm-2 control-label">Numeros con decimales y signo:</label>
                    <div class="col-sm-4">
                        <asp:TextBox ID="TextBox6" CssClass="form-control unsigned-numeric" runat="server" />
                    </div>
                    <div class="col-sm-4">
                        <asp:TextBox ID="TextBox7" CssClass="form-control spaced-unsigned-numeric" runat="server" />
                    </div>
                </div>
            </div>
        </div>
        <div class="row">
            <div class="form-horizontal">
                <div class="form-group">
                    <label for="inputEmail3" class="col-sm-2 control-label">Moneda con signo</label>
                    <div class="col-sm-4">
                        <asp:TextBox ID="TextBox8" CssClass="form-control currency" runat="server" />
                    </div>
                    <div class="col-sm-4">
                        <asp:TextBox ID="TextBox9" CssClass="form-control spaced-currency" runat="server" />
                    </div>
                </div>
            </div>
        </div>
        <div class="row">
            <div class="form-horizontal">
                <div class="form-group">
                    <label for="inputEmail3" class="col-sm-2 control-label">Moneda</label>
                    <div class="col-sm-4">
                        <asp:TextBox ID="TextBox10" CssClass="form-control unsigned-currency" runat="server" />
                    </div>
                    <div class="col-sm-4">
                        <asp:TextBox ID="TextBox11" CssClass="form-control spaced-unsigned-currency" runat="server" />
                    </div>
                </div>
            </div>
        </div>
        <div class="row">
            <div class="form-horizontal">
                <div class="form-group">
                    <label for="inputEmail3" class="col-sm-2 control-label">Fecha</label>
                    <div class="col-sm-8">
                        <asp:TextBox ID="TextBox12" CssClass="form-control datepicker" runat="server" data-toggle="tooltip" title="Seleccione una fecha del calendario" tooltipposition="top" />
                    </div>
                </div>
            </div>
        </div>
        <div class="row">
            <div class="form-horizontal">
                <div class="form-group">
                    <label for="inputEmail3" class="col-sm-2 control-label">Telefono</label>
                    <div class="col-sm-8">
                        <asp:TextBox ID="TextBox13" CssClass="form-control phone" runat="server" data-toggle="tooltip" title="Por favor ingrese un número telefónico válido" />
                    </div>
                </div>
            </div>
        </div>
        <div class="row">
            <div class="form-horizontal">
                <div class="form-group">
                    <label for="inputEmail3" class="col-sm-2 control-label">Email</label>
                    <div class="col-sm-8">
                        <asp:TextBox ID="TextBox14" CssClass="form-control email" runat="server" data-toggle="tooltip" title="Por favor ingrese un email válido" />
                    </div>
                </div>
            </div>
        </div>
        <div class="row">
            <div class="form-horizontal">
                <div class="form-group">
                    <label for="inputEmail3" class="col-sm-2 control-label">Mascaras</label>
                    <div class="col-sm-8">
                        <asp:TextBox ID="TextBox15" CssClass="form-control masked" runat="server" mask="000-000-0000" data-toggle="tooltip" title="Por favor ingrese un valor según lo solicitado por la máscara" />
                    </div>
                </div>
            </div>
        </div>
        <div class="row">
            <div class="form-horizontal">
                <div class="form-group">
                    <label for="inputEmail3" class="col-sm-2 control-label">Subir Archivos</label>
                    <div class="col-sm-8">
                        <input type="file" class="" tooltiptext="Por favor seleccione un archivo" />
                    </div>
                </div>
            </div>
        </div>
        <div class="row">
            <div class="form-horizontal">
                <div class="form-group">
                    <label for="inputEmail3" class="col-sm-2 control-label">Expresiones Regulares</label>
                    <div class="col-sm-8">
                        <asp:TextBox ID="TextBox16" CssClass="form-control regex" runat="server" regex="^\w+@cobiscorp.com" data-toggle="tooltip" title="Por favor ingrese un email del dominio cobiscorp.com" />
                    </div>
                </div>
            </div>
        </div>
        <div class="row">
            <div class="form-horizontal">
                <div class="form-group">
                    <label for="inputEmail3" class="col-sm-2 control-label">Opciones</label>
                    <div class="col-sm-8">
                        <asp:DropDownList runat="server" CssClass="form-control required" unselectedvalue="-1" data-toggle="tooltip" title="Seleccione un valor">
                            <asp:ListItem Value="-1">Not Selected</asp:ListItem>
                            <asp:ListItem Value="0">Option0</asp:ListItem>
                            <asp:ListItem Value="1">Option1</asp:ListItem>
                            <asp:ListItem Value="2">Option2</asp:ListItem>
                            <asp:ListItem Value="3">Option3</asp:ListItem>
                            <asp:ListItem Value="4">Option4</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                </div>
            </div>
        </div>
        <p>
            You can also find <a href="http://go.microsoft.com/fwlink/?LinkID=152368&amp;clcid=0x409" data-toggle="tooltip" title="También funciona en links! jaja!" data-placement="top">documentation on ASP.NET at MSDN</a>.
        </p>
        <div class="buttonsBar">
            <asp:Button ID="messagesButton" class="actionButton default" ClientIDMode="Static" runat="server" Text="Accept" OnClick="messagesButton_OnClick" toolTipText="Presione aquí aceptar la transacción" toolTipPosition="bottom" />
            <asp:Button ID="messagesCancel" class="actionButton" runat="server" Text="Cancel" toolTipText="Presione aquí para cancelar la transacción" toolTipPosition="bottom" />
            <asp:Button ID="flowButton" class="actionButton" runat="server" Text="Flow" toolTipText="Presione aquí para prueba de flujos" toolTipPosition="bottom" OnClick="flowButton_OnClick" />
            <input type="button" class="actionButton help-button" value="Help" />
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="HelpContent" runat="Server">
    <h2>Help Title</h2>
    <p>Lorem ipsum dolor sit amet, consectetuer adipiscing elit, sed diam nonummy nibh euismod tincidunt ut laoreet dolore magna aliquam erat volutpat. Ut wisi enim ad minim veniam, quis nostrud exerci tation ullamcorper suscipit lobortis nisl ut aliquip ex ea commodo consequat. Duis autem vel eum iriure dolor in hendrerit in vulputate velit esse molestie consequat, vel illum dolore eu feugiat nulla facilisis at vero eros et accumsan et iusto odio dignissim qui blandit praesent luptatum zzril delenit augue duis dolore te feugait nulla facilisi. Nam liber tempor cum soluta nobis eleifend option congue nihil imperdiet doming id quod mazim placerat facer possim assum. Typi non habent claritatem insitam; est usus legentis in iis qui facit eorum claritatem. Investigationes demonstraverunt lectores legere me lius quod ii legunt saepius. Claritas est etiam processus dynamicus, qui sequitur mutationem consuetudium lectorum. Mirum est notare quam littera gothica, quam nunc putamus parum claram, anteposuerit litterarum formas humanitatis per seacula quarta decima et quinta decima. Eodem modo typi, qui nunc nobis videntur parum clari, fiant sollemnes in futurum.</p>
    <p>Lorem ipsum dolor sit amet, consectetuer adipiscing elit, sed diam nonummy nibh euismod tincidunt ut laoreet dolore magna aliquam erat volutpat. Ut wisi enim ad minim veniam, quis nostrud exerci tation ullamcorper suscipit lobortis nisl ut aliquip ex ea commodo consequat. Duis autem vel eum iriure dolor in hendrerit in vulputate velit esse molestie consequat, vel illum dolore eu feugiat nulla facilisis at vero eros et accumsan et iusto odio dignissim qui blandit praesent luptatum zzril delenit augue duis dolore te feugait nulla facilisi. Nam liber tempor cum soluta nobis eleifend option congue nihil imperdiet doming id quod mazim placerat facer possim assum. Typi non habent claritatem insitam; est usus legentis in iis qui facit eorum claritatem. Investigationes demonstraverunt lectores legere me lius quod ii legunt saepius. Claritas est etiam processus dynamicus, qui sequitur mutationem consuetudium lectorum. Mirum est notare quam littera gothica, quam nunc putamus parum claram, anteposuerit litterarum formas humanitatis per seacula quarta decima et quinta decima. Eodem modo typi, qui nunc nobis videntur parum clari, fiant sollemnes in futurum.</p>
    <p>Lorem ipsum dolor sit amet, consectetuer adipiscing elit, sed diam nonummy nibh euismod tincidunt ut laoreet dolore magna aliquam erat volutpat. Ut wisi enim ad minim veniam, quis nostrud exerci tation ullamcorper suscipit lobortis nisl ut aliquip ex ea commodo consequat. Duis autem vel eum iriure dolor in hendrerit in vulputate velit esse molestie consequat, vel illum dolore eu feugiat nulla facilisis at vero eros et accumsan et iusto odio dignissim qui blandit praesent luptatum zzril delenit augue duis dolore te feugait nulla facilisi. Nam liber tempor cum soluta nobis eleifend option congue nihil imperdiet doming id quod mazim placerat facer possim assum. Typi non habent claritatem insitam; est usus legentis in iis qui facit eorum claritatem. Investigationes demonstraverunt lectores legere me lius quod ii legunt saepius. Claritas est etiam processus dynamicus, qui sequitur mutationem consuetudium lectorum. Mirum est notare quam littera gothica, quam nunc putamus parum claram, anteposuerit litterarum formas humanitatis per seacula quarta decima et quinta decima. Eodem modo typi, qui nunc nobis videntur parum clari, fiant sollemnes in futurum.</p>
</asp:Content>


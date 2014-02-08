<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Site.master" AutoEventWireup="true" CodeFile="DataInputs.aspx.cs" Inherits="Views__Tests_DataInputs" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <script type="text/javascript">
        Sys.Application.add_load(function () {
            $(document).validate({ actionButton: '.actionButton' });
        });
    </script>
    <div class="section">
        <h2>Welcome to ASP.NET!</h2>
        <p>
            To learn more about ASP.NET visit <a href="http://www.asp.net" title="ASP.NET Website">www.asp.net</a>.
        </p>
        <table>
            <tr><td class="label">integer</td><td><input id="Text1" type="text" class="integer required" min="100" unselectedValue="0" runat="server" toolTipText="Este es un dato de prueba de números enteros, por favor ingrese un valor mayor o igual a 100" /></td><td><input type="text" class="spaced-integer required" /></td></tr>
            <tr><td class="label">unsigned-integer</td><td><input type="text" class="unsigned-integer required" /></td><td><input type="text" class="spaced-unsigned-integer" /></td></tr>
            <tr><td class="label">numeric</td><td><input type="text" class="numeric" /></td><td><input type="text" class="spaced-numeric required" min="-100" max="100" /></td></tr>
            <tr><td class="label">unsigned-numeric</td><td><input type="text" class="unsigned-numeric" /></td><td><input type="text" class="spaced-unsigned-numeric" /></td></tr>
            <tr><td class="label">currency</td><td><input type="text" class="currency" /></td><td><input type="text" class="spaced-currency" /></td></tr>
            <tr><td class="label">unsigned-currency</td><td><input type="text" class="unsigned-currency" /></td><td><input type="text" class="spaced-unsigned-currency" /></td></tr>
            <tr><td class="label">datepicker</td><td><input type="text" class="datepicker" toolTipText="Seleccione una fecha del calendario" toolTipPosition="top" /></td></tr>
            <tr><td class="label">phone</td><td><input id="Text2" type="text" runat="server" class="phone" toolTipText="Por favor ingrese un número telefónico válido" /></td><td></td></tr>
            <tr><td class="label">email</td><td><input id="Text3" type="text" runat="server" class="email" toolTipText="Por favor ingrese un email válido" /></td><td></td></tr>
            <tr><td class="label">mask</td><td><input id="Text4" type="text" runat="server" class="masked" mask="000-000-0000" toolTipText="Por favor ingrese un valor según lo solicitado por la máscara" /></td></tr>
            <tr><td class="label">FileUpload</td><td><input type="file" class="" toolTipText="Por favor seleccione un archivo" /></td></tr>
            <tr><td class="label">regex</td><td><input id="Text5" type="text" runat="server" class="regex required" regex="^\w+@cobiscorp.com" toolTipText="Por favor ingrese un email del dominio cobiscorp.com"  /></td></tr>
            <tr><td class="label">select</td>
                <td>
                    <select class="required" unselectedValue="-1" toolTipText="Seleccione un valor">
                        <option value="-1">Not Selected</option>
                        <option value="0">Option0</option>
                        <option value="1">Option1</option>
                        <option value="2">Option2</option>
                        <option value="3">Option3</option>
                        <option value="4">Option4</option>
                    </select>
                </td>
            </tr>
        </table>
        <p>
            You can also find <a href="http://go.microsoft.com/fwlink/?LinkID=152368&amp;clcid=0x409"
                title="MSDN ASP.NET Docs" toolTipText="También funciona en links! jaja!" toolTipPosition="top">documentation on ASP.NET at MSDN</a>.
        </p>
        <div class="buttonsBar">
            <asp:Button ID="messagesButton" class="actionButton default" ClientIDMode="Static" runat="server" Text="Accept" OnClick="messagesButton_OnClick" toolTipText="Presione aquí aceptar la transacción" toolTipPosition="bottom" />
            <asp:Button ID="messagesCancel" class="actionButton" runat="server" Text="Cancel" toolTipText="Presione aquí para cancelar la transacción" toolTipPosition="bottom" />
            <asp:Button ID="flowButton" class="actionButton" runat="server" Text="Flow" toolTipText="Presione aquí para prueba de flujos" toolTipPosition="bottom" OnClick="flowButton_OnClick" />
            <input type="button" class="actionButton help-button" value="Help" />
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="HelpContent" Runat="Server">
    <h2>Help Title</h2>
    <p>Lorem ipsum dolor sit amet, consectetuer adipiscing elit, sed diam nonummy nibh euismod tincidunt ut laoreet dolore magna aliquam erat volutpat. Ut wisi enim ad minim veniam, quis nostrud exerci tation ullamcorper suscipit lobortis nisl ut aliquip ex ea commodo consequat. Duis autem vel eum iriure dolor in hendrerit in vulputate velit esse molestie consequat, vel illum dolore eu feugiat nulla facilisis at vero eros et accumsan et iusto odio dignissim qui blandit praesent luptatum zzril delenit augue duis dolore te feugait nulla facilisi. Nam liber tempor cum soluta nobis eleifend option congue nihil imperdiet doming id quod mazim placerat facer possim assum. Typi non habent claritatem insitam; est usus legentis in iis qui facit eorum claritatem. Investigationes demonstraverunt lectores legere me lius quod ii legunt saepius. Claritas est etiam processus dynamicus, qui sequitur mutationem consuetudium lectorum. Mirum est notare quam littera gothica, quam nunc putamus parum claram, anteposuerit litterarum formas humanitatis per seacula quarta decima et quinta decima. Eodem modo typi, qui nunc nobis videntur parum clari, fiant sollemnes in futurum.</p>
    <p>Lorem ipsum dolor sit amet, consectetuer adipiscing elit, sed diam nonummy nibh euismod tincidunt ut laoreet dolore magna aliquam erat volutpat. Ut wisi enim ad minim veniam, quis nostrud exerci tation ullamcorper suscipit lobortis nisl ut aliquip ex ea commodo consequat. Duis autem vel eum iriure dolor in hendrerit in vulputate velit esse molestie consequat, vel illum dolore eu feugiat nulla facilisis at vero eros et accumsan et iusto odio dignissim qui blandit praesent luptatum zzril delenit augue duis dolore te feugait nulla facilisi. Nam liber tempor cum soluta nobis eleifend option congue nihil imperdiet doming id quod mazim placerat facer possim assum. Typi non habent claritatem insitam; est usus legentis in iis qui facit eorum claritatem. Investigationes demonstraverunt lectores legere me lius quod ii legunt saepius. Claritas est etiam processus dynamicus, qui sequitur mutationem consuetudium lectorum. Mirum est notare quam littera gothica, quam nunc putamus parum claram, anteposuerit litterarum formas humanitatis per seacula quarta decima et quinta decima. Eodem modo typi, qui nunc nobis videntur parum clari, fiant sollemnes in futurum.</p>
    <p>Lorem ipsum dolor sit amet, consectetuer adipiscing elit, sed diam nonummy nibh euismod tincidunt ut laoreet dolore magna aliquam erat volutpat. Ut wisi enim ad minim veniam, quis nostrud exerci tation ullamcorper suscipit lobortis nisl ut aliquip ex ea commodo consequat. Duis autem vel eum iriure dolor in hendrerit in vulputate velit esse molestie consequat, vel illum dolore eu feugiat nulla facilisis at vero eros et accumsan et iusto odio dignissim qui blandit praesent luptatum zzril delenit augue duis dolore te feugait nulla facilisi. Nam liber tempor cum soluta nobis eleifend option congue nihil imperdiet doming id quod mazim placerat facer possim assum. Typi non habent claritatem insitam; est usus legentis in iis qui facit eorum claritatem. Investigationes demonstraverunt lectores legere me lius quod ii legunt saepius. Claritas est etiam processus dynamicus, qui sequitur mutationem consuetudium lectorum. Mirum est notare quam littera gothica, quam nunc putamus parum claram, anteposuerit litterarum formas humanitatis per seacula quarta decima et quinta decima. Eodem modo typi, qui nunc nobis videntur parum clari, fiant sollemnes in futurum.</p>
</asp:Content>


<%@ Page Language="C#" MasterPageFile="~/MasterPages/View.master" AutoEventWireup="true" CodeFile="Registro1.aspx.cs" Inherits="Views__TestCondition_Registro1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <h2>Flujo 1 Condiciones - Registro</h2>
    <section>
        <table>
            <tr>
                <td>
                    <asp:Label runat="server" Text="Tipo :" />
                </td>
                <td>
                    <asp:DropDownList runat="server" ID="ddnTypePerson">
                        <asp:ListItem Text="Natural" Value="N"/>
                        <asp:ListItem Text="Empresa" Value="E"/>
                        <asp:ListItem Text="Grupo" Value="G"/>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label runat="server" Text="Flag :" />
                </td>
                <td>
                    <asp:TextBox runat="server" ID="txtFlag"></asp:TextBox>
                </td>
            </tr>
        </table>
        </section>
    <section>
        <asp:UpdatePanel UpdateMode="Conditional" runat="server">
            <ContentTemplate>
            <asp:GridView runat="server" AutoGenerateColumns="true" ID="grdProducts">
                <Columns>                
                    <asp:TemplateField>
                        <HeaderTemplate>
                            <asp:CheckBox ID="chkAll" runat="server" AutoPostBack="true"  OnCheckedChanged="chkAll_CheckedChanged"/>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <asp:CheckBox ID="CheckBox1" runat="server"  AutoPostBack="true" OnCheckedChanged="CheckBox1_CheckedChanged" />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
            </ContentTemplate>
        </asp:UpdatePanel>
    </section>
    <section>
        <ul>
            <li>Mas de 5 Productos [FLAG 100]</li>
            <li>Clientes Personas [FLAG 200]</li>
            <li>Clientes Juridicos ([C]EMPRESAS/[G]GRUPOS) [FLAG 300]</li>
            <li>Clientes Personas con mas de 2 Cuentas Ahorro [FLAG 400]</li>
            <li>Clientes Personas con mas de 1 Cuenta Coorriente [FLAG 500]</li>
            <li>Clientes Grupo con 2 Cuentas Ahorros con saldo mayor a 1000 [FLAG 600]</li>
            <li>Caso de que las condiciones anteriores no se cumpla [FLAG 700]</li>
        </ul>
    </section>
    <section>            
        <asp:Button ID="buttonNext" runat="server" Text="Siguiente" OnClick="buttonNext_Click" />
    </section>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="HelpContent" runat="Server">
</asp:Content>

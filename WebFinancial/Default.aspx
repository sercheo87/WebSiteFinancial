﻿<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/MasterPages/Site.master" CodeFile="Default.aspx.cs" Inherits="Default" %>


<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>

<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <!-- Carousel-->
    <div class="well well-lg">
        <div class="page-header">
            <h1>Financy Corp </h1>
            <small>The New Web Financial.</small>
        </div>
        <div id="myCarousel" class="carousel slide" data-ride="carousel">
            <!-- Indicators -->
            <ol class="carousel-indicators">
                <li data-target="#myCarousel" data-slide-to="0" class="active"></li>
                <li data-target="#myCarousel" data-slide-to="1"></li>
                <li data-target="#myCarousel" data-slide-to="2"></li>
            </ol>
            <div class="carousel-inner">
                <div class="item active">
                    <img data-src="holder.js/900x300/auto/#666:#6a6a6a/text:Second slide" alt="Second slide">
                    <div class="container">
                        <div class="carousel-caption">
                            <h1>Example headline.</h1>
                            <p>Note: If you're viewing this page via a <code>file://</code> URL, the "next" and "previous" Glyphicon buttons on the left and right might not load/display properly due to web browser security rules.</p>
                            <p><a class="btn btn-lg btn-primary" href="#" role="button">Sign up today</a></p>
                        </div>
                    </div>
                </div>
                <div class="item">
                    <img data-src="holder.js/900x300/auto/#666:#6a6a6a/text:Second slide" alt="Second slide">
                    <div class="container">
                        <div class="carousel-caption">
                            <h1>Another example headline.</h1>
                            <p>Cras justo odio, dapibus ac facilisis in, egestas eget quam. Donec id elit non mi porta gravida at eget metus. Nullam id dolor id nibh ultricies vehicula ut id elit.</p>
                            <p><a class="btn btn-lg btn-primary" href="#" role="button">Learn more</a></p>
                        </div>
                    </div>
                </div>
                <div class="item">
                    <img data-src="holder.js/900x300/auto/#555:#5a5a5a/text:Third slide" alt="Third slide">
                    <div class="container">
                        <div class="carousel-caption">
                            <h1>One more for good measure.</h1>
                            <p>Cras justo odio, dapibus ac facilisis in, egestas eget quam. Donec id elit non mi porta gravida at eget metus. Nullam id dolor id nibh ultricies vehicula ut id elit.</p>
                            <p><a class="btn btn-lg btn-primary" href="#" role="button">Browse gallery</a></p>
                        </div>
                    </div>
                </div>
            </div>
            <a class="left carousel-control" href="#myCarousel" data-slide="prev"><span class="glyphicon glyphicon-chevron-left"></span></a>
            <a class="right carousel-control" href="#myCarousel" data-slide="next"><span class="glyphicon glyphicon-chevron-right"></span></a>
        </div>
    </div>
    <!-- /.carousel -->
    <section>
        <!-- Nav tabs -->
        <ul id="mytab" class="nav nav-tabs">
            <li class="active"><a href="#pnlIdHome" data-toggle="tab">Consolidado</a></li>
            <li><a href="#pnlIdProfile" data-toggle="tab">Movimientos de Cuenta</a></li>
            <li><a href="#messages" data-toggle="tab">Messages</a></li>
            <li><a href="#settings" data-toggle="tab">Settings</a></li>
        </ul>
        <!-- Tab panels -->
        <div class="tab-content">
            <div class="tab-pane active" id="pnlIdHome">
                <%-- Posicion Consolidada --%>
                <uc:PanelControl runat="server" ShowHeader="false">
                    <ContentBody>
                        <div class="col-md-12">
                            <div id="demochart"></div>
                        </div>
                    </ContentBody>
                </uc:PanelControl>
            </div>
            <div class="tab-pane" id="pnlIdProfile">
                <%-- Movimientos por Cuenta --%>
                <uc:PanelControl runat="server" ShowHeader="false">
                    <ContentBody>
                        <div class="form-horizontal">
                            <div class="col-md-6">
                                <div class="form-group">
                                    <label for="inputPassword3" class="col-md-2 control-label">Cuenta: </label>
                                    <div class="col-sm-10">
                                        <uc:Products ID="Products1" runat="server" ShowProducts="Actives" />
                                    </div>
                                </div>
                            </div>
                            <div class="col-md-6">
                                <div class="form-group">
                                    <label for="inputPassword3" class="col-md-2 control-label">Moneda: </label>
                                    <div class="col-sm-10">
                                        <uc:Products ID="Products2" runat="server" ShowProducts="Pasives" />
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="col-md-12">
                            <div id="demochart1"></div>
                        </div>
                    </ContentBody>
                </uc:PanelControl>
            </div>
            <div class="tab-pane" id="messages">
                <%-- Posicion Consolidada --%>
                <uc:PanelControl runat="server" ShowHeader="false">
                    <ContentBody>
                        <div id="demochart2" class="col-md-12"></div>
                    </ContentBody>
                </uc:PanelControl>
            </div>
            <div class="tab-pane" id="settings">
                <%-- Posicion Consolidada --%>
                <uc:PanelControl runat="server" ShowHeader="false">
                    <ContentBody>
                        <div class="col-md-12">
                            <div id="demochart3" class="col-md-12"></div>
                        </div>
                    </ContentBody>
                </uc:PanelControl>
            </div>
        </div>
    </section>
    <uc:PanelControl runat="server" ID="pnlConsolidate" Title="Consolidado" TypePanel="primary">
        <ContentBody>
            <p>sdsdsds</p>
        </ContentBody>
    </uc:PanelControl>
</asp:Content>

<asp:Content ID="LateralContent" runat="server" ContentPlaceHolderID="LateralContent">
    <uc:ConsolidateProduct runat="server" ID="consolidateProduct"></uc:ConsolidateProduct>
    <script>
        $(function () {

            var series = JSON.parse('<%=dtSeries%>');
            var drill = JSON.parse('<%=dtDrillDownSeries%>');
            var movents = JSON.parse('<%=GetDataProductsMovements()%>');
            var testdata =  <%=testarray%>;

            var optionsMovents = {
                chart: { type: 'line', },
                title: { text: 'Movimientos de Cuentas' },
                subtitle: { text: 'Detalle por rango de Fechas' },
                plotOptions: {
                    series: { dataLabels: { enabled: false } }
                }
            };
            var optionsConsolidate = {
                chart: { type: 'column' },
                title: { text: 'Posicion Consolidada' },
                subtitle: { text: 'Consolidado de las Cuentas' },
                plotOptions: {
                    series: { dataLabels: { enabled: true } }
                }
            };

            var testarea = {                
                rangeSelector: {enabled: true},
                xAxis: { type: 'datetime' },        
                scrollbar: { enabled: true },        
                navigator: { enabled: true },
                plotOptions: {
                    series: {
                        pointInterval:30 * 24 * 3600 * 1000 // one month
                    }
                }
            };

            $('a[data-toggle="tab"]').on('shown.bs.tab', function (e) {
                console.log('tab');
                var tabHref = $(e.target).attr('href');

                if (tabHref == '#pnlIdHome')
                    customChart(series, drill, 'demochart', optionsConsolidate);
                if (tabHref == '#pnlIdProfile')
                    customChart(movents, '{}', 'demochart1', optionsMovents);
                if (tabHref == '#messages')
                    customChart(testdata, '{}', 'demochart2', testarea);
                if (tabHref == '#settings')
                    customChart(series, drill, 'demochart3', options);
            });

            $('#myTab a[href="#pnlIdHome"]').tab('show');
            customChart(series, drill, 'demochart', optionsConsolidate);
        });
    </script>
</asp:Content>

<asp:Content ID="HelpContent" runat="server" ContentPlaceHolderID="HelpContent">
</asp:Content>

<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ConsolidateProductChart.ascx.cs" Inherits="Views_UserControls_Consolidate_Product_Chart" %>
<%@ Register Assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" Namespace="System.Web.UI.DataVisualization.Charting" TagPrefix="asp" %>

<script type="text/javascript">
    Sys.Application.add_load(function () {
        $(function () {
            var optionper = JSON.parse('');
            createChart();
        });
        
    });
</script>
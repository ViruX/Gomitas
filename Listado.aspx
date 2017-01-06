<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Listado.aspx.cs" Inherits="Listado" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<div class="main">
    <div class="header_slide">
		<div class="header_bottom_left" style="width:24%;">				
			<div class="categories">
				<ul>
				<h3>Categorias</h3>
				   <%= HTML_Categorias%>
				</ul>
			</div>					
	  	</div>
		<div class="header_bottom_right" style="float:right;width:75%">
            <div class="content_top">
    	        <div class="heading">
    	            <h3>Productos</h3>
    	        </div>
    	        <div class="clear"></div>
            </div>
	            <div class="section group">
			                
                    <%= HTML_ProductosInicio%>
			                
		        </div>
		    </div>
		<div class="clear"></div>
	</div>
</div>
</asp:Content>


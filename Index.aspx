<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="index.aspx.cs" Inherits="Index" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="header_slide">
		<div class="header_bottom_left">				
			<div class="categories">
				<ul>
				<h3>Categorias</h3>
				   <%-- <%= HTML_Categorias %>--%>
				</ul>
			</div>					
	  	    </div>
				<div class="header_bottom_right">					 
					<div class="slider">					     
						<div id="slider">
			            <div id="mover">
			                <div id="slide-1" class="slide">			                    
								<div class="slider-img">
									<a href="preview.aspx"><img src="images/slide-1-image.png" alt="learn more" /></a>									    
								</div>
						        <div class="slider-text">
		                            <h1>Clearance<br/><span>SALE</span></h1>
		                            <h2>UPTo 20% OFF</h2>
								<div class="features_list">
								<h4>Get to Know More About Our Memorable Services Lorem Ipsum is simply dummy text</h4>							               
							    </div>
							        <a href="preview.aspx" class="button">Shop Now</a>
					            </div>			               
								<div class="clear"></div>				
				            </div>	
						        <div class="slide">
						            <div class="slider-text">
		                            <h1>Clearance<br/><span>SALE</span></h1>
		                            <h2>UPTo 40% OFF</h2>
								<div class="features_list">
								<h4>Get to Know More About Our Memorable Services</h4>							               
							    </div>
							        <a href="preview.aspx" class="button">Shop Now</a>
					            </div>		
						            <div class="slider-img">
									<a href="preview.aspx"><img src="images/slide-3-image.jpg" alt="learn more" /></a>
								</div>						             					                 
								<div class="clear"></div>				
				            </div>
				            <div class="slide">						             	
					            <div class="slider-img">
									<a href="preview.aspx"><img src="images/slide-2-image.jpg" alt="learn more" /></a>
								</div>
								<div class="slider-text">
		                            <h1>Clearance<br/><span>SALE</span></h1>
		                            <h2>UPTo 10% OFF</h2>
								<div class="features_list">
								<h4>Get to Know More About Our Memorable Services Lorem Ipsum is simply dummy text</h4>							               
							    </div>
							        <a href="preview.aspx" class="button">Shop Now</a>
					            </div>	
								<div class="clear"></div>				
				            </div>												
			            </div>		
		            </div>
					<div class="clear"></div>					       
		        </div>
		    </div>
		<div class="clear"></div>
	</div>
    <div class="main">
        <div class="content">
            <div class="content_top">
    	        <div class="heading">
    	        <h3>New Products</h3>
    	        </div>
    	        <div class="see">
    		        <p><a href="#">See all Products</a></p>
    	        </div>
    	        <div class="clear"></div>
            </div>
	            <div class="section group">
			        <div class="grid_1_of_4 images_1_of_4">
					        <a href="Preview.aspx"><img src="images/feature-pic1.jpg" alt="" /></a>
					        <h2>Lorem Ipsum is simply </h2>
				        <div class="price-details">
				            <div class="price-number">
						        <p><span class="rupees">$620.87</span></p>
					        </div>
					       	        <div class="add-cart">								
								        <h4><a href="Preview.aspx">Add to Cart</a></h4>
							            </div>
							        <div class="clear"></div>
				        </div>
					 
			        </div>
			        <div class="grid_1_of_4 images_1_of_4">
				        <a href="Preview.aspx"><img src="images/feature-pic2.jpg" alt="" /></a>
					        <h2>Lorem Ipsum is simply </h2>
				        <div class="price-details">
				            <div class="price-number">
						        <p><span class="rupees">$899.75</span></p>
					        </div>
					       	        <div class="add-cart">								
								        <h4><a href="Preview.aspx">Add to Cart</a></h4>
							            </div>
							        <div class="clear"></div>
				        </div>
				    
			        </div>
			        <div class="grid_1_of_4 images_1_of_4">
				        <a href="Preview.aspx"><img src="images/feature-pic3.jpg" alt="" /></a>
					        <h2>Lorem Ipsum is simply </h2>
					        <div class="price-details">
				            <div class="price-number">
						        <p><span class="rupees">$599.00</span></p>
					        </div>
					       	        <div class="add-cart">								
								        <h4><a href="Preview.aspx">Add to Cart</a></h4>
							            </div>
							        <div class="clear"></div>
				        </div>
			        </div>
			        <div class="grid_1_of_4 images_1_of_4">
				        <a href="Preview.aspx"><img src="images/feature-pic4.jpg" alt="" /></a>
					        <h2>Lorem Ipsum is simply </h2>
				        <div class="price-details">
				            <div class="price-number">
						        <p><span class="rupees">$679.87</span></p>
					        </div>
					       	        <div class="add-cart">								
								        <h4><a href="Preview.aspx">Add to Cart</a></h4>
							            </div>
							        <div class="clear"></div>
				        </div>				     
			        </div>
		        </div>
		        <div class="content_bottom">
    	        <div class="heading">
    	        <h3>Feature Products</h3>
    	        </div>
    	        <div class="see">
    		        <p><a href="#">See all Products</a></p>
    	        </div>
    	        <div class="clear"></div>
            </div>
		        <div class="section group">
			        <div class="grid_1_of_4 images_1_of_4">
					        <a href="Preview.aspx"><img src="images/new-pic1.jpg" alt="" /></a>					
					        <h2>Lorem Ipsum is simply </h2>
				        <div class="price-details">
				            <div class="price-number">
						        <p><span class="rupees">$849.99</span></p>
					        </div>
					       	        <div class="add-cart">								
								        <h4><a href="Preview.aspx">Add to Cart</a></h4>
							            </div>
							        <div class="clear"></div>
				        </div>
			        </div>
			        <div class="grid_1_of_4 images_1_of_4">
				        <a href="Preview.aspx"><img src="images/new-pic2.jpg" alt="" /></a>
					        <h2>Lorem Ipsum is simply </h2>
					        <div class="price-details">
				            <div class="price-number">
						        <p><span class="rupees">$599.99</span></p>
					        </div>
					       	        <div class="add-cart">								
								        <h4><a href="Preview.aspx">Add to Cart</a></h4>
							            </div>
							        <div class="clear"></div>
				        </div>
			        </div>
			        <div class="grid_1_of_4 images_1_of_4">
				        <a href="Preview.aspx"><img src="images/new-pic4.jpg" alt="" /></a>
					        <h2>Lorem Ipsum is simply </h2>
				        <div class="price-details">
				            <div class="price-number">
						        <p><span class="rupees">$799.99</span></p>
					        </div>
					       	        <div class="add-cart">								
								        <h4><a href="Preview.aspx">Add to Cart</a></h4>
							            </div>
							        <div class="clear"></div>
				        </div>
			        </div>
			        <div class="grid_1_of_4 images_1_of_4">
				        <a href="Preview.aspx"><img src="images/new-pic3.jpg" alt="" /></a>
					        <h2>Lorem Ipsum is simply </h2>					 
					        <div class="price-details">
				            <div class="price-number">
						        <p><span class="rupees">$899.99</span></p>
					        </div>
					       	        <div class="add-cart">								
								        <h4><a href="Preview.aspx">Add to Cart</a></h4>
							            </div>
							        <div class="clear"></div>
				        </div>
			        </div>
		        </div>
        </div>
    </div>
</asp:Content>



// Responsive Menu

$(function(){
	$('#full-menu').on('hide.bs.collapse', function () {
	  $(".card").on("click" ,function(){
			$("#down").removeClass('text-hide').css({
				position: 'absolute',
				right: '20px'
			});
			$("#left").addClass('text-hide').css({
				position: 'absolute',
				right: '20px'
			});	
		});
	});

				$("#full-menu").on("show.bs.collapse",function(){
					$(".card").click(function(event) {
						$("#down").addClass('text-hide');
						$("#left").removeClass('text-hide');	
				});
			});
})


$(document).ready(function(){
	$('#full-menu').on('hide.bs.collapse', function () {
	  $(".card").on("click" ,function(){
			$("#inside-down").removeClass('text-hide').css({
				position: 'absolute',
				right: '20px'
			});;
			$("#inside-left").addClass('text-hide').css({
				position: 'absolute',
				right: '20px'
			});;	
		});
	});

				$("#full-menu").on("show.bs.collapse",function(){
					$(".card").click(function(event) {
						$("#inside-down").addClass('text-hide');
						$("#inside-left").removeClass('text-hide');	
				});
			});
});

			
	


// Exit Button

$(document).ready(function(){
	$("#add_food").click(function(){
		$("#input_group").append('<div class="input-group-append clearfix mb-2 col-12" id="input_group_append"><input type="text" class="form-control col-10 float-left ml-auto " aria-label="Item" autocomplete="Item" style="border-top-right-radius: 0px;border-bottom-right-radius: 0px; clear:right" id="item_name"><button class="btn btn-danger btn-sm input-group-append" type="button" style="border: 1px solid #ced4da;border-top-right-radius:0.25rem;border-bottom-right-radius:0.25rem;" id="btn_exit"><i class="fa fa-times" aria-hidden="true" id="exit-icon"></i></button></div>');

	});
	
});

$(document).ready(function(){
	$("#btn_exit").on("click",function(){
		$('#input_group_append').remove();

	});
});


$(function () {
  $('[data-toggle="popover"]').popover({
  	trigger:"hover",
  	placement:"bottom",
  	content:' <div class="popover " role="tooltip" ><div class="arrow"></div><h3 class="popover-title"></h3><div class="popover-content"><a class="dropdown-item" href="#change_password" data-toggle="modal"><i class="fa fa-cog" id="icon-change"></i>Change Password</a><a class="dropdown-item" href="admin_login.html"><i class="fa fa-sign-out" id="icon-logout"></i>Log Out</a></div></div>',
  	container:"body"
  
  	
  })
})


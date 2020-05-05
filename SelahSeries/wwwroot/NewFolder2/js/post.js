/* JS Document */

/******************************

[Table of Contents]

1. Vars and Inits
2. Set Header
3. Init Menu
4. Init Top Slider
5. Init Vid Slider
6. Init Events Slider
7. Init Grid


******************************/

$(document).ready(function()
{
	"use strict";

	/* 

	1. Vars and Inits

	*/

	var header = $('.header');
	var menuActive = false;
	var menu = $('.menu');
	var burger = $('.hamburger');

	setHeader();

	$(window).on('resize', function()
	{
		setHeader();
	});

	$(document).on('scroll', function()
	{
		setHeader();
	});

	initMenu();
	initTopSlider();
	initVidSlider();
	initEventsSlider();
	initGrid();

	/* 

	2. Set Header

	*/

	function setHeader()
	{
		if($(window).scrollTop() > 100)
		{
			header.addClass('scrolled');
		}
		else
		{
			header.removeClass('scrolled');
		}
	}

	/* 

	3. Init Menu

	*/

	function initMenu()
	{
		if($('.menu').length)
		{
			var menu = $('.menu');
			if($('.hamburger').length)
			{
				burger.on('click', function()
				{
					if(menuActive)
					{
						closeMenu();
					}
					else
					{
						openMenu();

						$(document).one('click', function cls(e)
						{
							if($(e.target).hasClass('menu_mm'))
							{
								$(document).one('click', cls);
							}
							else
							{
								closeMenu();
							}
						});
					}
				});
			}
		}
	}

	function openMenu()
	{
		menu.addClass('active');
		menuActive = true;
	}

	function closeMenu()
	{
		menu.removeClass('active');
		menuActive = false;
	}

	/* 

	4. Init Top Slider

	*/

	function initTopSlider()
	{
		if($('.sidebar_slider_top').length)
		{
			var topSlider = $('.sidebar_slider_top');
			
			topSlider.owlCarousel(
			{
				items:1,
				loop:true,
				autoplay:false,
				smartSpeed:1200,
				dots:true,
				dotsContainer:'.custom_dots_top',
				nav:false
			});

			if($('.custom_prev_top').length)
			{
				$('.custom_prev_top').on('click', function()
				{
					topSlider.trigger('prev.owl.carousel');
				});
			}

			if($('.custom_next_top').length)
			{
				$('.custom_next_top').on('click', function()
				{
					topSlider.trigger('next.owl.carousel');
				});
			}

			/* Custom dots events */
			if($('.custom_dot_top').length)
			{
				$('.custom_dot_top').on('click', function(ev)
				{	
					var dot = $(ev.target);
					$('.custom_dot_top').removeClass('active');
					dot.addClass('active');
					topSlider.trigger('to.owl.carousel', [$(this).index(), 300]);
				});
			}

			/* Change active class for dots when slide changes by nav or touch */
			topSlider.on('changed.owl.carousel', function(event)
			{
				$('.custom_dot_top').removeClass('active');
				$('.custom_dots_top li').eq(event.page.index).addClass('active');
			});	
		}
	}

	/* 

	5. Init Vid Slider

	*/

	function initVidSlider()
	{
		if($('.sidebar_slider_vid').length)
		{
			var vidSlider = $('.sidebar_slider_vid');
			
			vidSlider.owlCarousel(
			{
				items:1,
				loop:true,
				autoplay:false,
				smartSpeed:1200,
				dots:true,
				dotsContainer:'.custom_dots_vid',
				nav:false
			});

			if($('.custom_prev_vid').length)
			{
				$('.custom_prev_vid').on('click', function()
				{
					vidSlider.trigger('prev.owl.carousel');
				});
			}

			if($('.custom_next_vid').length)
			{
				$('.custom_next_vid').on('click', function()
				{
					vidSlider.trigger('next.owl.carousel');
				});
			}

			/* Custom dots events */
			if($('.custom_dot_vid').length)
			{
				$('.custom_dot_vid').on('click', function(ev)
				{	
					var dot = $(ev.target);
					$('.custom_dot_vid').removeClass('active');
					dot.addClass('active');
					vidSlider.trigger('to.owl.carousel', [$(this).index(), 300]);
				});
			}

			/* Change active class for dots when slide changes by nav or touch */
			vidSlider.on('changed.owl.carousel', function(event)
			{
				$('.custom_dot_vid').removeClass('active');
				$('.custom_dots_vid li').eq(event.page.index).addClass('active');
			});	
		}
	}

	/* 

	6. Init Events Slider

	*/

	function initEventsSlider()
	{
		if($('.sidebar_slider_events').length)
		{
			var vidSlider = $('.sidebar_slider_events');
			
			vidSlider.owlCarousel(
			{
				items:1,
				loop:true,
				autoplay:false,
				smartSpeed:1200,
				dots:true,
				dotsContainer:'.custom_dots_events',
				nav:false
			});

			if($('.custom_prev_events').length)
			{
				$('.custom_prev_events').on('click', function()
				{
					vidSlider.trigger('prev.owl.carousel');
				});
			}

			if($('.custom_next_events').length)
			{
				$('.custom_next_events').on('click', function()
				{
					vidSlider.trigger('next.owl.carousel');
				});
			}

			/* Custom dots events */
			if($('.custom_dot_events').length)
			{
				$('.custom_dot_events').on('click', function(ev)
				{	
					var dot = $(ev.target);
					$('.custom_dot_events').removeClass('active');
					dot.addClass('active');
					vidSlider.trigger('to.owl.carousel', [$(this).index(), 300]);
				});
			}

			/* Change active class for dots when slide changes by nav or touch */
			vidSlider.on('changed.owl.carousel', function(event)
			{
				$('.custom_dot_events').removeClass('active');
				$('.custom_dots_events li').eq(event.page.index).addClass('active');
			});	
		}
	}

	/* 

	7. Init Grid

	*/

	function initGrid()
	{
		setTimeout(function()
		{
			$('.grid').masonry(
			{
				itemSelector:'.grid-item',
				columnWidth: '.card_small_with_image',
				gutter:30
			});
		}, 500);
			
    }

    function showReplyForm() {
        $("reply_button").click(function () {
            $("#comment_reply_form").show("1000");
        });
    }
    $(".share-popup").click(function () {
        var window_size = "width=585,height=511";
        var url = this.href;
        var domain = url.split("/")[2];
        switch (domain) {
            case "www.facebook.com":
                window_size = "width=585,height=368";
                break;
            case "www.twitter.com":
                window_size = "width=585,height=261";
                break;
            case "plus.google.com":
                window_size = "width=517,height=511";
                break;
        }
        window.open(url, '', 'menubar=no,toolbar=no,resizable=yes,scrollbars=yes,' + window_size);
        return false;
    });
});
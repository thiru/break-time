// Backwards compatibility for section HTML element.
document.createElement('section');

// Centres element in window.
jQuery.fn.centre = function (horizontal, vertical)
{
  this.css("position","absolute");
  if (horizontal || horizontal === undefined)
    this.css("left", Math.max(0, (($(window).width() - $(this).outerWidth()) / 2)
                                  + $(window).scrollLeft()) + "px");
  if (vertical || vertical === undefined)
    this.css("top", Math.max(0, (($(window).height() - $(this).outerHeight()) / 2)
                                 + $(window).scrollTop()) + "px");
  return this;
}


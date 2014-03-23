/*
 * GET start-up splash page.
 */
module.exports = function(req, res)
{
  res.render('splash', {pretty: true});
};

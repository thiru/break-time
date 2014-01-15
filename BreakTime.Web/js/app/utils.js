define(function() {
  // HTML5 backwards compatibility:
  document.createElement('section');

  return {
    dummyFunc: function(input) {
      return input;
    },
  };
});

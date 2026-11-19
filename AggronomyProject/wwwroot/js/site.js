(function () {
  // Mostrar los toasts generados desde TempData
  document.querySelectorAll('.toast').forEach(function (el) {
    if (window.bootstrap) new bootstrap.Toast(el, { autohide: false }).show();
  });

  // Menú lateral en pantallas pequeñas
  var toggle = document.getElementById('sidebarToggle');
  var sidebar = document.getElementById('sidebar');
  var smallScreen = window.matchMedia('(max-width: 991px)');
  function setMenu(open, returnFocus) {
    document.body.classList.toggle('sidebar-open', open);
    if (toggle) {
      toggle.setAttribute('aria-expanded', String(open));
      toggle.setAttribute('aria-label', open ? 'Cerrar menú' : 'Abrir menú');
    }
    if (sidebar) sidebar.inert = smallScreen.matches && !open;
    if (returnFocus && toggle) toggle.focus();
  }
  if (toggle && sidebar) {
    setMenu(false, false);
    smallScreen.addEventListener('change', function () { setMenu(false, false); });
    toggle.addEventListener('click', function () {
      var open = !document.body.classList.contains('sidebar-open');
      setMenu(open, false);
      if (open) sidebar.querySelector('a').focus();
    });
    document.addEventListener('keydown', function (e) {
      if (e.key === 'Escape' && document.body.classList.contains('sidebar-open')) setMenu(false, true);
    });
  }
  document.addEventListener('click', function (e) {
    if (document.body.classList.contains('sidebar-open') && !e.target.closest('#sidebar') && !e.target.closest('#sidebarToggle'))
      setMenu(false, false);
  });

  // Confirmación en formularios con data-confirm
  document.addEventListener('submit', function (e) {
    var msg = e.target.getAttribute && e.target.getAttribute('data-confirm');
    if (msg && !window.confirm(msg)) e.preventDefault();
  });
})();

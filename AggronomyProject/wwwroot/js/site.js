(function () {
  // Mostrar los toasts generados desde TempData
  document.querySelectorAll('.toast').forEach(function (el) {
    if (window.bootstrap) new bootstrap.Toast(el, { delay: 4500 }).show();
  });

  // Menú lateral en pantallas pequeñas
  var toggle = document.getElementById('sidebarToggle');
  if (toggle) toggle.addEventListener('click', function () { document.body.classList.toggle('sidebar-open'); });
  document.addEventListener('click', function (e) {
    if (document.body.classList.contains('sidebar-open') && !e.target.closest('#sidebar') && !e.target.closest('#sidebarToggle'))
      document.body.classList.remove('sidebar-open');
  });

  // Confirmación en formularios con data-confirm
  document.addEventListener('submit', function (e) {
    var msg = e.target.getAttribute && e.target.getAttribute('data-confirm');
    if (msg && !window.confirm(msg)) e.preventDefault();
  });
})();

(function () {
  var btn = document.getElementById('verContrasena');
  var input = document.getElementById('Contrasena');
  if (!btn || !input) return;
  btn.addEventListener('click', function () {
    var oculto = input.type === 'password';
    input.type = oculto ? 'text' : 'password';
    btn.textContent = oculto ? 'Ocultar' : 'Mostrar';
    btn.setAttribute('aria-pressed', oculto ? 'true' : 'false');
  });
})();

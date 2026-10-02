(function () {
  // Búsqueda instantánea sobre la tabla ya cargada
  var input = document.getElementById('buscarInstantaneo');
  var rows = document.querySelectorAll('#tablaInventario tbody tr[data-nombre]');
  if (input) {
    input.addEventListener('input', function () {
      var q = input.value.trim().toLowerCase();
      rows.forEach(function (r) { r.hidden = q && r.dataset.nombre.indexOf(q) === -1; });
    });
  }

  // Rellenar el modal de ajuste de stock
  var modal = document.getElementById('ajusteStockModal');
  if (modal) {
    modal.addEventListener('show.bs.modal', function (ev) {
      var b = ev.relatedTarget;
      if (!b) return;
      modal.querySelector('[name=id]').value = b.dataset.id;
      modal.querySelector('#ajusteNombre').textContent = b.dataset.nombre;
      modal.querySelector('#ajusteStock').textContent = b.dataset.stock + ' ' + b.dataset.unidad;
      modal.querySelector('[name=cantidad]').value = '';
    });
    modal.addEventListener('shown.bs.modal', function () { modal.querySelector('[name=cantidad]').focus(); });
  }
})();

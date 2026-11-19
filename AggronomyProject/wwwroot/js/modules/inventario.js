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
    var form = modal.querySelector('form');
    var quantity = modal.querySelector('[name=cantidad]');
    var confirmed = modal.querySelector('[name=confirmado]');
    var error = modal.querySelector('#ajusteError');
    var stock = 0;
    var unit = '';
    var product = '';
    function editMovement() {
      confirmed.value = 'false';
      modal.querySelector('#ajusteDatos').hidden = false;
      modal.querySelector('#ajusteConfirmacion').hidden = true;
      modal.querySelector('#ajusteVolver').hidden = true;
      modal.querySelector('#ajusteGuardar').textContent = 'Revisar movimiento';
      error.textContent = '';
      quantity.setAttribute('aria-invalid', 'false');
    }
    modal.addEventListener('show.bs.modal', function (ev) {
      var b = ev.relatedTarget;
      if (!b) return;
      modal.querySelector('[name=id]').value = b.dataset.id;
      product = b.dataset.nombre;
      stock = Number(b.dataset.stock);
      unit = b.dataset.unidad;
      editMovement();
      modal.querySelector('[name=tipo][value=entrada]').checked = true;
      modal.querySelector('#ajusteNombre').textContent = product;
      modal.querySelector('#ajusteStock').textContent = b.dataset.stock + ' ' + b.dataset.unidad;
      modal.querySelector('[name=cantidad]').value = '';
    });
    modal.addEventListener('shown.bs.modal', function () { modal.querySelector('[name=cantidad]').focus(); });
    modal.addEventListener('keydown', function (event) {
      if (event.key !== 'Tab') return;
      var controls = Array.from(modal.querySelectorAll('button:not([disabled]), input:not([type=hidden]):not([disabled]), select:not([disabled]), a[href]'))
        .filter(function (element) { return element.getClientRects().length; });
      var first = controls[0];
      var last = controls[controls.length - 1];
      if (!event.shiftKey && document.activeElement === last) { event.preventDefault(); first.focus(); }
      else if (event.shiftKey && document.activeElement === first) { event.preventDefault(); last.focus(); }
    });
    modal.querySelector('#ajusteVolver').addEventListener('click', function () { editMovement(); quantity.focus(); });
    form.addEventListener('submit', function (event) {
      if (confirmed.value === 'true') return;
      event.preventDefault();
      var amount = Number(quantity.value);
      var type = form.querySelector('[name=tipo]:checked').value;
      var next = type === 'entrada' ? stock + amount : stock - amount;
      if (!Number.isInteger(amount) || amount <= 0 || next < 0 || next > 2147483647) {
        error.textContent = next < 0 ? 'La salida supera el stock disponible. Escribe una cantidad menor.' : 'Escribe una cantidad entera mayor que cero que no supere la capacidad del inventario.';
        quantity.setAttribute('aria-invalid', 'true');
        quantity.focus();
        return;
      }
      error.textContent = '';
      quantity.setAttribute('aria-invalid', 'false');
      modal.querySelector('#ajusteResumen').textContent = (type === 'entrada' ? 'Vas a agregar ' : 'Vas a retirar ') + amount + ' ' + unit + ' de ' + product + '.';
      modal.querySelector('#ajustePrevisto').textContent = next + ' ' + unit;
      modal.querySelector('#ajusteDatos').hidden = true;
      modal.querySelector('#ajusteConfirmacion').hidden = false;
      modal.querySelector('#ajusteVolver').hidden = false;
      modal.querySelector('#ajusteGuardar').textContent = 'Confirmar y guardar';
      confirmed.value = 'true';
      modal.querySelector('#ajusteResumenTitulo').focus();
    });
  }
})();

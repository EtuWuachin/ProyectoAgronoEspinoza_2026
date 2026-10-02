(function () {
  // Muestra el costo total estimado (cantidad x costo unitario) del lote de insumo
  var cant = document.getElementById('cantidad_inicial');
  var costo = document.getElementById('costo_unitario');
  var out = document.getElementById('costoTotal');
  if (!cant || !costo || !out) return;
  function calcular() {
    var total = (parseFloat(cant.value) || 0) * (parseFloat(costo.value) || 0);
    out.textContent = 'S/ ' + total.toLocaleString('es-PE', { minimumFractionDigits: 2, maximumFractionDigits: 2 });
  }
  cant.addEventListener('input', calcular);
  costo.addEventListener('input', calcular);
  calcular();
})();

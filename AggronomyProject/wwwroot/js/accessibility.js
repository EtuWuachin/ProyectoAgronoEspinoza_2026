(function () {
  'use strict';
  if (window.jQuery && window.jQuery.validator) {
    Object.assign(window.jQuery.validator.messages, {
      required: 'Completa este campo obligatorio.',
      email: 'Escribe un correo válido, como contacto@proveedor.com.',
      number: 'Escribe un número válido.',
      digits: 'Escribe solo números enteros.',
      min: 'Escribe un número igual o mayor que {0}.',
      max: 'Escribe un número igual o menor que {0}.',
      range: 'Escribe un número entre {0} y {1}.',
      step: 'Usa una cantidad compatible con el paso {0}.',
      maxlength: 'Escribe como máximo {0} caracteres.'
    });
  }
  var root = document.documentElement;
  var key = 'agro-accessibility';
  var preferences = { textSize: 'normal', contrast: false };
  try {
    var saved = JSON.parse(localStorage.getItem(key) || 'null');
    if (saved) {
      preferences.textSize = saved.textSize === 'large' ? 'large' : 'normal';
      preferences.contrast = saved.contrast === true;
    }
  } catch (_) { /* Las preferencias no son necesarias para usar el sistema. */ }

  function applyPreferences() {
    root.dataset.textSize = preferences.textSize;
    root.dataset.contrast = preferences.contrast ? 'high' : 'normal';
    document.querySelectorAll('button[data-text-size]').forEach(function (button) {
      button.setAttribute('aria-pressed', String(button.dataset.textSize === preferences.textSize));
    });
    var contrast = document.getElementById('altoContraste');
    if (contrast) contrast.setAttribute('aria-pressed', String(preferences.contrast));
    try { localStorage.setItem(key, JSON.stringify(preferences)); } catch (_) { }
  }
  document.querySelectorAll('button[data-text-size]').forEach(function (button) {
    button.addEventListener('click', function () {
      preferences.textSize = button.dataset.textSize;
      applyPreferences();
    });
  });
  var contrast = document.getElementById('altoContraste');
  if (contrast) contrast.addEventListener('click', function () {
    preferences.contrast = !preferences.contrast;
    applyPreferences();
  });
  applyPreferences();

  // Lista explícita de instrucciones: nunca se leen valores de campos ni datos del negocio.
  var listen = document.getElementById('escucharAyuda');
  var stop = document.getElementById('detenerAyuda');
  var status = document.getElementById('estadoAudio');
  var speech = window.speechSynthesis;
  function stopAudio() {
    if (speech) speech.cancel();
    if (stop) stop.disabled = true;
    if (status) status.textContent = 'Audio detenido. Las instrucciones siguen en pantalla.';
  }
  if (listen && stop && status) {
    if (!speech || !window.SpeechSynthesisUtterance) {
      listen.disabled = true;
      status.textContent = 'Este navegador no ofrece lectura por voz. Puedes seguir todas las instrucciones en pantalla.';
    } else {
      listen.addEventListener('click', function () {
        speech.cancel();
        var scope = document.querySelector('.modal.show') || document.getElementById('contenido');
        var texts = scope ? Array.from(scope.querySelectorAll('.a11y-instruction, [data-a11y-read]'))
          .filter(function (element) { return element.getClientRects().length && !element.closest('[hidden]'); })
          .map(function (element) { return element.textContent.trim(); }).filter(Boolean) : [];
        if (document.querySelector('.field-validation-error, .validation-summary-errors, #ajusteError:not(:empty)'))
          texts.push('Hay errores. Revisa el mensaje escrito junto al campo indicado.');
        if (document.querySelector('.toast.text-bg-success')) texts.push('La operación se guardó correctamente.');
        if (document.querySelector('.toast.text-bg-danger')) texts.push('No se guardó la operación. Revisa el aviso escrito.');
        if (!texts.length) texts = ['Usa el menú para elegir una sección. Los botones tienen etiquetas de texto.'];
        var utterance = new SpeechSynthesisUtterance(texts.join('. '));
        utterance.lang = 'es-PE';
        utterance.rate = 0.9;
        var voice = speech.getVoices().find(function (item) { return /^es(?:-|$)/i.test(item.lang); });
        if (voice) utterance.voice = voice;
        utterance.onend = function () { stop.disabled = true; status.textContent = 'Lectura terminada.'; };
        utterance.onerror = function () {
          stop.disabled = true;
          status.textContent = 'No se pudo reproducir la voz. Las instrucciones siguen disponibles en pantalla.';
        };
        stop.disabled = false;
        status.textContent = 'Leyendo instrucciones en español. Puedes detener el audio.';
        speech.speak(utterance);
      });
      stop.addEventListener('click', stopAudio);
      window.addEventListener('pagehide', function () { speech.cancel(); });
    }
  }

  function associateErrors(form) {
    var messages = Array.from(form.querySelectorAll('[data-valmsg-for]'));
    var firstInvalid = null;
    form.querySelectorAll('input:not([type="hidden"]), select, textarea').forEach(function (field) {
      var message = messages.find(function (item) { return item.dataset.valmsgFor === field.name; });
      var ids = (field.getAttribute('aria-describedby') || '').split(/\s+/)
        .filter(function (id) { return id && document.getElementById(id); });
      if (message) {
        if (!message.id) message.id = (field.id || field.name) + '-validation';
        ids = ids.filter(function (id) { return id === message.id || !message.contains(document.getElementById(id)); });
        ids.push(message.id);
        var invalid = message.classList.contains('field-validation-error') && message.textContent.trim().length > 0;
        field.setAttribute('aria-invalid', String(invalid));
        if (invalid && !firstInvalid) firstInvalid = field;
      }
      if (field.dataset.valRequired && field.type !== 'checkbox') field.setAttribute('aria-required', 'true');
      if (ids.length) field.setAttribute('aria-describedby', Array.from(new Set(ids)).join(' '));
      else field.removeAttribute('aria-describedby');
    });
    return firstInvalid;
  }
  document.querySelectorAll('form').forEach(function (form) {
    form.querySelectorAll('[data-valmsg-for], [data-valmsg-summary]').forEach(function (message) {
      message.setAttribute('aria-live', 'polite');
    });
    var initialInvalid = associateErrors(form);
    if (initialInvalid) initialInvalid.focus();
    form.addEventListener('submit', function () {
      setTimeout(function () {
        var invalid = associateErrors(form);
        if (invalid) invalid.focus();
      }, 0);
    });
    form.addEventListener('focusout', function () { setTimeout(function () { associateErrors(form); }, 0); });
  });
})();

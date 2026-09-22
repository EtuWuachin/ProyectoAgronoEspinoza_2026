document.addEventListener('DOMContentLoaded', function () {

    const btnMenu = document.getElementById('btnMenu');
    const sidebar = document.getElementById('sidebar');
    const overlay = document.getElementById('sidebarOverlay');
    const topbar = document.querySelector('.topbar');

    if (!btnMenu || !sidebar || !overlay) return;

    // Debe coincidir SIEMPRE con el @media (max-width: ...) de layout.css
    const BREAKPOINT_MOBILE = 1001;

    function isMobile() {
        return window.innerWidth <= BREAKPOINT_MOBILE;
    }

    // Calcula el padding-top del sidebar según la altura real del topbar,
    // así no dependemos de un número fijo que puede variar entre navegadores
    function ajustarPaddingSidebar() {
        if (!topbar) return;
        const topbarHeight = topbar.offsetHeight;
        if (isMobile()) {
            sidebar.style.paddingTop = (topbarHeight + 16) + 'px';
        } else {
            sidebar.style.paddingTop = '';
        }
    }

    btnMenu.addEventListener('click', () => {
        if (isMobile()) {
            // En mobile: abre/cierra como cajón (drawer) con overlay
            sidebar.classList.toggle('open');
            overlay.classList.toggle('active');
        } else {
            // En desktop: colapsa/expande el ancho del sidebar
            sidebar.classList.toggle('collapsed');
        }
    });

    overlay.addEventListener('click', () => {
        sidebar.classList.remove('open');
        overlay.classList.remove('active');
    });

    sidebar.querySelectorAll('a').forEach(link => {
        link.addEventListener('click', () => {
            if (isMobile()) {
                sidebar.classList.remove('open');
                overlay.classList.remove('active');
            }
        });
    });

    // Si cambian de mobile a desktop (o viceversa) reseteamos clases
    // para que no se quede en un estado raro
    window.addEventListener('resize', () => {
        if (!isMobile()) {
            sidebar.classList.remove('open');
            overlay.classList.remove('active');
        } else {
            sidebar.classList.remove('collapsed');
        }
        ajustarPaddingSidebar();
    });

    ajustarPaddingSidebar();
});
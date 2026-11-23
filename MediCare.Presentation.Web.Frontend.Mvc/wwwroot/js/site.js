(() => {
    const loader = document.getElementById('pageLoader');
    if (!loader) return;

    const delay = 180;
    let pending = 0;
    let showTimer;

    const show = (immediate = false) => {
        pending += 1;
        window.clearTimeout(showTimer);
        if (immediate) {
            loader.classList.add('is-visible');
            loader.setAttribute('aria-hidden', 'false');
        } else {
            showTimer = window.setTimeout(() => {
                if (pending > 0) {
                    loader.classList.add('is-visible');
                    loader.setAttribute('aria-hidden', 'false');
                }
            }, delay);
        }
        let complete = false;
        return () => {
            if (complete) return;
            complete = true;
            pending = Math.max(0, pending - 1);
            if (pending === 0) {
                window.clearTimeout(showTimer);
                loader.classList.remove('is-visible');
                loader.setAttribute('aria-hidden', 'true');
            }
        };
    };

    window.MediCareLoader = {
        show: () => show(true),
        hide: () => {
            pending = 0;
            window.clearTimeout(showTimer);
            loader.classList.remove('is-visible');
            loader.setAttribute('aria-hidden', 'true');
        }
    };

    document.addEventListener('click', event => {
        const link = event.target instanceof Element ? event.target.closest('a[href]') : null;
        if (!link || event.defaultPrevented || event.button !== 0 || event.metaKey || event.ctrlKey || event.shiftKey || event.altKey) return;
        if (link.hasAttribute('download') || link.target === '_blank' || link.hasAttribute('data-no-loader') || link.hasAttribute('data-bs-toggle')) return;
        const href = link.getAttribute('href')?.trim();
        if (!href || href.startsWith('#') || href.startsWith('javascript:')) return;
        const destination = new URL(link.href, window.location.href);
        if (destination.href === window.location.href) return;
        window.setTimeout(() => {
            if (!event.defaultPrevented) show();
        }, 0);
    });

    document.addEventListener('submit', event => {
        const form = event.target;
        if (!(form instanceof HTMLFormElement) || form.hasAttribute('data-no-loader')) return;
        if (form.target && form.target !== '_self') return;
        if (form.method.toLowerCase() === 'dialog') return;
        window.setTimeout(() => {
            if (!event.defaultPrevented) show();
        }, 0);
    }, true);
    if (typeof window.fetch === 'function') {
        const originalFetch = window.fetch.bind(window);
        window.fetch = (...args) => {
            const finish = show();
            return originalFetch(...args).finally(finish);
        };
    }

    if (window.jQuery) {
        window.jQuery(document).on('ajaxStart', () => show()).on('ajaxStop', () => window.MediCareLoader.hide());
    }

    const finishInitialLoad = () => window.MediCareLoader.hide();
    if (document.readyState === 'complete') finishInitialLoad();
    else window.addEventListener('load', finishInitialLoad, { once: true });
    window.addEventListener('pageshow', finishInitialLoad);
})();

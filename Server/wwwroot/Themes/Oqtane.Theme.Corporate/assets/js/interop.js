var Oqtane = Oqtane || {};

Oqtane.Theme = {
    load: async function () {
        "use strict";

        /**
         * Apply .scrolled class to the body as the page is scrolled down
         */
        function toggleScrolled() {
            const selectBody = document.querySelector('body');
            const selectHeader = document.querySelector('#header');
            if (!selectHeader.classList.contains('scroll-up-sticky') && !selectHeader.classList.contains('sticky-top') && !selectHeader.classList.contains('fixed-top')) return;
            window.scrollY > 100 ? selectBody.classList.add('scrolled') : selectBody.classList.remove('scrolled');
        }
        document.addEventListener('scroll', toggleScrolled);
        toggleScrolled();

        /**
         * Mobile nav toggle
         */
        const mobileNavToggleBtn = document.querySelector('.mobile-nav-toggle');

        if (mobileNavToggleBtn) {
            // Use a more robust approach to handle event listener re-initialization
            // Clone the element to completely remove all event listeners
            const newToggleBtn = mobileNavToggleBtn.cloneNode(true);
            mobileNavToggleBtn.parentNode.replaceChild(newToggleBtn, mobileNavToggleBtn);

            // Add the event listener to the fresh element
            newToggleBtn.addEventListener('click', function mobileNavToogle() {
                document.querySelector('body').classList.toggle('mobile-nav-active');
                this.classList.toggle('bi-list');
                this.classList.toggle('bi-x');
            });
        }

        /**
         * Hide mobile nav on same-page/hash links
         */
        // Clear existing event listeners first to prevent duplicates
        document.querySelectorAll('#navmenu a').forEach(navmenu => {
            // Clone the element to remove all event listeners
            const newNavmenu = navmenu.cloneNode(true);
            navmenu.parentNode.replaceChild(newNavmenu, navmenu);
        });

        // Add fresh event listeners
        document.querySelectorAll('#navmenu a').forEach(navmenu => {
            navmenu.addEventListener('click', () => {
                if (document.querySelector('.mobile-nav-active')) {
                    const mobileNavToggleBtn = document.querySelector('.mobile-nav-toggle');
                    if (mobileNavToggleBtn) {
                        document.querySelector('body').classList.remove('mobile-nav-active');
                        mobileNavToggleBtn.classList.remove('bi-x');
                        mobileNavToggleBtn.classList.add('bi-list');
                    }
                }
            });
        });

        /**
         * Toggle mobile nav dropdowns
         */
        // Clear existing dropdown event listeners first
        document.querySelectorAll('.navmenu .toggle-dropdown').forEach(navmenu => {
            const newNavmenu = navmenu.cloneNode(true);
            navmenu.parentNode.replaceChild(newNavmenu, navmenu);
        });

        // Add fresh dropdown event listeners
        document.querySelectorAll('.navmenu .toggle-dropdown').forEach(navmenu => {
            navmenu.addEventListener('click', function (e) {
                e.preventDefault();
                this.parentNode.classList.toggle('active');
                this.parentNode.nextElementSibling.classList.toggle('dropdown-active');
                e.stopImmediatePropagation();
            });
        });

        /**
         * Scroll top button
         */
        let scrollTop = document.querySelector('.scroll-top');

        function toggleScrollTop() {
            if (scrollTop) {
                window.scrollY > 100 ? scrollTop.classList.add('active') : scrollTop.classList.remove('active');
            }
        }
        scrollTop.addEventListener('click', (e) => {
            e.preventDefault();
            window.scrollTo({
                top: 0,
                behavior: 'smooth'
            });
        });

        document.addEventListener('scroll', toggleScrollTop);
        toggleScrollTop();

        /**
         * Animation on scroll function and init
         */
        function aosInit() {
            AOS.init({
                duration: 600,
                easing: 'ease-in-out',
                once: true,
                mirror: false
            });
        }
        aosInit();

        /**
         * Initiate glightbox
         */
        const glightbox = GLightbox({
            selector: '.glightbox'
        });

        /**
         * Init swiper sliders
         */
        function initSwiper() {
            document.querySelectorAll(".init-swiper").forEach(function (swiperElement) {
                let config = JSON.parse(
                    swiperElement.querySelector(".swiper-config").innerHTML.trim()
                );

                if (swiperElement.classList.contains("swiper-tab")) {
                    initSwiperWithCustomPagination(swiperElement, config);
                } else {
                    new Swiper(swiperElement, config);
                }
            });
        }
        initSwiper();

        /**
         * Frequently Asked Questions Toggle
         */
        document.querySelectorAll('.faq-item h3, .faq-item .faq-toggle').forEach((faqItem) => {
            faqItem.addEventListener('click', () => {
                faqItem.parentNode.classList.toggle('faq-active');
            });
        });

        /**
         * Animate the skills items on reveal
         */
        let skillsAnimation = document.querySelectorAll('.skills-animation');
        skillsAnimation.forEach((item) => {
            new Waypoint({
                element: item,
                offset: '80%',
                handler: function (direction) {
                    let progress = item.querySelectorAll('.progress .progress-bar');
                    progress.forEach(el => {
                        el.style.width = el.getAttribute('aria-valuenow') + '%';
                    });
                }
            });
        });

        /**
         * Init isotope layout and filters
         */
        document.querySelectorAll('.isotope-layout').forEach(function (isotopeItem) {
            let layout = isotopeItem.getAttribute('data-layout') ?? 'masonry';
            let filter = isotopeItem.getAttribute('data-default-filter') ?? '*';
            let sort = isotopeItem.getAttribute('data-sort') ?? 'original-order';

            let initIsotope;
            imagesLoaded(isotopeItem.querySelector('.isotope-container'), function () {
                initIsotope = new Isotope(isotopeItem.querySelector('.isotope-container'), {
                    itemSelector: '.isotope-item',
                    layoutMode: layout,
                    filter: filter,
                    sortBy: sort
                });
            });

            isotopeItem.querySelectorAll('.isotope-filters li').forEach(function (filters) {
                filters.addEventListener('click', function () {
                    isotopeItem.querySelector('.isotope-filters .filter-active').classList.remove('filter-active');
                    this.classList.add('filter-active');
                    initIsotope.arrange({
                        filter: this.getAttribute('data-filter')
                    });
                    if (typeof aosInit === 'function') {
                        aosInit();
                    }
                }, false);
            });

        });

        /**
         * Correct scrolling position upon page load for URLs containing hash links.
         */
        if (window.location.hash) {
            if (document.querySelector(window.location.hash)) {
                setTimeout(() => {
                    let section = document.querySelector(window.location.hash);
                    let scrollMarginTop = getComputedStyle(section).scrollMarginTop;
                    window.scrollTo({
                        top: section.offsetTop - parseInt(scrollMarginTop),
                        behavior: 'smooth'
                    });
                }, 100);
            }
        };

        /**
         * Navmenu Scrollspy
         */
        let navmenulinks = document.querySelectorAll('.navmenu a');

        function navmenuScrollspy() {
            navmenulinks.forEach(navmenulink => {
                if (!navmenulink.hash) return;
                let section = document.querySelector(navmenulink.hash);
                if (!section) return;
                let position = window.scrollY + 200;
                if (position >= section.offsetTop && position <= (section.offsetTop + section.offsetHeight)) {
                    document.querySelectorAll('.navmenu a.active').forEach(link => link.classList.remove('active'));
                    navmenulink.classList.add('active');
                } else {
                    navmenulink.classList.remove('active');
                }
            })
        }
        document.addEventListener('scroll', navmenuScrollspy);
        navmenuScrollspy();

        /**
        * Init Pure Counter 
        */
        new PureCounter();

        /**
        * Init Countdown 
        */
        Countdown();
    }
}
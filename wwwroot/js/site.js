// Small enhancements for the search pages and details pages.
document.addEventListener('DOMContentLoaded', function () {

    // 1. Changing the "Sort by" list re-runs the search straight away.
    document.querySelectorAll('select[data-autosubmit]').forEach(function (select) {
        select.addEventListener('change', function () {
            select.form.submit();
        });
    });

    // 2. Checks the price range before the form is sent:
    //    the minimum cannot be higher than the maximum.
    document.querySelectorAll('form[data-validate-prices]').forEach(function (form) {
        form.addEventListener('submit', function (event) {
            var minInput = form.querySelector('[name="MinPrice"]');
            var maxInput = form.querySelector('[name="MaxPrice"]');
            var message = form.querySelector('#priceError');
            if (!minInput || !maxInput || !message) {
                return;
            }

            var min = parseFloat(minInput.value);
            var max = parseFloat(maxInput.value);

            if (!isNaN(min) && !isNaN(max) && min > max) {
                event.preventDefault();
                message.classList.remove('d-none');
                minInput.focus();
            } else {
                message.classList.add('d-none');
            }
        });
    });

    // 3. "Back to Search Results" returns to the exact search the visitor made
    //    (with their parameters), if they came from a search page.
    document.querySelectorAll('a[data-back-link]').forEach(function (link) {
        link.addEventListener('click', function (event) {
            var cameFromSearch = document.referrer &&
                document.referrer.indexOf(window.location.origin) === 0 &&
                document.referrer.indexOf('/Search') !== -1;

            if (cameFromSearch) {
                event.preventDefault();
                window.history.back();
            }
        });
    });
});

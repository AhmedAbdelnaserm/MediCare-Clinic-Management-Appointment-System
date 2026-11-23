(() => {
    const openButton = document.getElementById('doctorProfileOpen');
    const closeButton = document.getElementById('doctorProfileClose');
    const scrim = document.getElementById('doctorProfileScrim');
    const drawer = document.getElementById('doctorProfileDrawer');
    const form = document.getElementById('doctorProfileForm');
    const editButton = document.getElementById('doctorProfileEditToggle');
    const cancelButton = document.getElementById('doctorProfileCancel');
    const photoInput = document.getElementById('doctorPhotoInput');
    const photoPreview = document.getElementById('doctorPhotoPreview');
    const originalPhoto = photoPreview?.src;
    if (!openButton || !drawer || !form) return;

    const fields = [...form.querySelectorAll('.doctor-profile-field input, .doctor-profile-field select, .doctor-profile-field textarea')];
    const setDrawer = (show) => {
        document.body.classList.toggle('doctor-profile-open', show);
        drawer.setAttribute('aria-hidden', String(!show));
        openButton.setAttribute('aria-expanded', String(show));
        if (show) closeButton?.focus(); else openButton.focus();
    };
    const setEditing = (editing) => {
        form.classList.toggle('doctor-profile-form-edit', editing);
        fields.forEach(field => {
            if (field.name === 'FullName') return;
            if (field instanceof HTMLSelectElement) field.disabled = !editing;
            else field.readOnly = !editing;
        });
        if (photoInput) photoInput.disabled = !editing;
        if (editing) form.dataset.original = JSON.stringify(fields.map(field => field.value));
    };

    openButton.addEventListener('click', () => setDrawer(true));
    closeButton?.addEventListener('click', () => setDrawer(false));
    scrim?.addEventListener('click', () => setDrawer(false));
    document.addEventListener('keydown', event => { if (event.key === 'Escape' && document.body.classList.contains('doctor-profile-open')) setDrawer(false); });
    editButton?.addEventListener('click', () => setEditing(true));
    cancelButton?.addEventListener('click', () => {
        const original = JSON.parse(form.dataset.original || '[]');
        fields.forEach((field, index) => { if (original[index] !== undefined) field.value = original[index]; });
        if (photoInput) photoInput.value = '';
        if (photoPreview && originalPhoto) photoPreview.src = originalPhoto;
        setEditing(false);
    });
    photoInput?.addEventListener('change', () => {
        const file = photoInput.files?.[0];
        if (!file) return;
        if (!['image/jpeg', 'image/png', 'image/webp'].includes(file.type) || file.size > 5 * 1024 * 1024) {
            photoInput.value = '';
            window.alert('Choose a JPG, PNG, or WEBP image smaller than 5 MB.');
            return;
        }
        photoPreview.src = URL.createObjectURL(file);
        photoPreview.classList.remove('is-hidden');
    });
    setEditing(false);
    if (drawer.querySelector('.doctor-profile-alert')) setDrawer(true);
})();

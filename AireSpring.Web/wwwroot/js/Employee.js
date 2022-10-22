

const btnCreateEmployee = document.querySelector('#btnCreateEmployee');
if (btnCreateEmployee) {
    btnCreateEmployee.addEventListener('click', async function (e) {
        e.preventDefault();
        setBtnLoading(e.target);
        const url = e.target.href;
        await getAddOrEditEmployeeForm(url);
        $('#modalAddOrEditEmployee').modal('show');
        unsetBtnLoading(e.target);
    });
}

const employeeTable = document.querySelector('#employeeTable');
if (employeeTable) {
    employeeTable.addEventListener('click', async function (e) {
        e.preventDefault();
        if (e.target && e.target.tagName === 'A' && e.target.classList.contains('editEmployee')) {
            const url = e.target.href;
            setBtnLoading(e.target);
            await getAddOrEditEmployeeForm(url);
            $('#modalAddOrEditEmployee').modal('show');
            unsetBtnLoading(e.target);
        }
        if (e.target && e.target.tagName === 'A' && e.target.classList.contains('deleteEmployee')) {
            const url = e.target.href;
            setBtnLoading(e.target);
            addEventToBtnDeleteEmployee(url);
            $('#modalConfirmDeleteEmployee').modal('show');
            unsetBtnLoading(e.target);
        }
    });
}

/**
 * 
 * @param {String} url
 */
function addEventToBtnDeleteEmployee(url) {
    const btn = document.querySelector('#btnDeleteEmployee');
    btn.addEventListener('click', async function (e) {
        setBtnLoading(e.target);
        const response = await fetch(url, { method: 'POST' });
        const data = await response.json();
        if (data.ok) {
            window.location.href = '/Employee';
        } else {
            alert(data.message);
        }
    });
}

/**
 * 
 * @param {String} url
 */
async function getAddOrEditEmployeeForm(url) {
    const response = await fetch(url, { method: 'GET' });
    const data = await response.json();

    if (data.ok) {
        const body = document.querySelector('#modalAddOrEditEmployeeBody');
        body.innerHTML = data.html;
        $('#EmployeePhone').mask('(000) 000-0000');
        const addOrEditEmployeeForm = document.querySelector('#addOrEditEmployeeForm');
        if (addOrEditEmployeeForm) {
            addOrEditEmployeeForm.addEventListener('submit', async function (e) {
                e.preventDefault();
                const form = $(addOrEditEmployeeForm);
                form.unbind();
                form.data("validator", null);
                $.validator.unobtrusive.parse(form);
                form.validate(form.data("unobtrusiveValidation").options);
                if (form.valid()) {
                    const url = e.target.action;
                    const formData = new FormData(addOrEditEmployeeForm);
                    const response = await fetch(url, { method: 'POST', body: formData });
                    const data = await response.json();
                    if (data.ok) {
                        window.location.href = '/Employee';
                    } else {
                        alert(data.message);
                    }
                }
                
            });
        }
    } else {
        alert(data.message);
    }
}

/**
 * @param {Element} element
 * */
function setBtnLoading(element) {
    const currentContent = element.innerHTML;
    element.setAttribute('data-initcontent', currentContent);
    element.innerHTML = `<span class="spinner-border spinner-border-sm mr-2" role="status" aria-hidden="true"></span> ${currentContent}`;
}

/**
 * @param {Element} element
 * */
function unsetBtnLoading(element) {
    if (element.hasAttribute('data-initcontent')) {
        element.innerHTML = element.getAttribute('data-initcontent');
    }
}
let notification = document.querySelector(".notifacations");

function createToast(type, icon, title, text) {
    let newToast = document.createElement("div");
    newToast.innerHTML = `
   <div class="toasts ${type}">
        <i class="${icon}"></i>
        <div class="content">
          <div class="title">${title}</div>
          <span>${text}</span>
        </div>
        <i class="fa-solid fa-xmark" 
        onclick="(this.parentElement).remove()"
        ></i>
    </div>`;
    notification.appendChild(newToast);
    newToast.timeOut = setTimeout(() => newToast.remove(), 5000);
}
function createToastSuccess( title, text) {
    let newToast = document.createElement("div");
    newToast.innerHTML = `
   <div class="toasts success">
        <i class="fa-solid fa-circle-check"></i>
        <div class="content">
          <div class="title">${title}</div>
          <span>${text}</span>
        </div>
        <i class="fa-solid fa-xmark" 
        onclick="(this.parentElement).remove()"
        ></i>
    </div>`;
    notification.appendChild(newToast);
    newToast.timeOut = setTimeout(() => newToast.remove(), 5000);
}

function createToastError(title, text) {
    let newToast = document.createElement("div");
    newToast.innerHTML = `
   <div class="toasts error">
        <i class="fa-solid fa-circle-exclamation"></i>
        <div class="content">
          <div class="title">${title}</div>
          <span>${text}</span>
        </div>
        <i class="fa-solid fa-xmark" 
        onclick="(this.parentElement).remove()"
        ></i>
    </div>`;
    notification.appendChild(newToast);
    newToast.timeOut = setTimeout(() => newToast.remove(), 5000);
}
function createToastWarning(title, text) {
    let newToast = document.createElement("div");
    newToast.innerHTML = `
   <div class="toasts warning">
        <i class="fa-solid fa-triangle-exclamation"></i>
        <div class="content">
          <div class="title">${title}</div>
          <span>${text}</span>
        </div>
        <i class="fa-solid fa-xmark" 
        onclick="(this.parentElement).remove()"
        ></i>
    </div>`;
    notification.appendChild(newToast);
    newToast.timeOut = setTimeout(() => newToast.remove(), 5000);
}
function createToastInfo(title, text) {
    let newToast = document.createElement("div");
    newToast.innerHTML = `
   <div class="toasts info">
        <i class="fa-solid fa-circle-info"></i>
        <div class="content">
          <div class="title">${title}</div>
          <span>${text}</span>
        </div>
        <i class="fa-solid fa-xmark" 
        onclick="(this.parentElement).remove()"
        ></i>
    </div>`;
    notification.appendChild(newToast);
    newToast.timeOut = setTimeout(() => newToast.remove(), 5000);
}

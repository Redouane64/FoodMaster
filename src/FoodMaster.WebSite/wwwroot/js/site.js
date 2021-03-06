﻿// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your Javascript code.

const CART_URL = "/api/cart/";

async function addToCart(element, data) {

    let url = `${CART_URL}${data.id}`;

    await runCartRequest(url, "POST", {
        onResponse: (response) => {

            if (!response.ok)
                return;

            element.innerHTML = "Deselect";

            element.removeAttribute("onclick");
            element.setAttribute("onclick", `removeFromCart(this, ${JSON.stringify(data)})`);

            element.classList.remove("text-success");
            element.classList.add("text-danger");
        },
        onError: (error) => {
            console.log(error);
        }
    });
}

async function removeFromCart(element, data) {

    let url = `${CART_URL}${data.id}`;

    await runCartRequest(url, "DELETE", {
        onResponse: (response) => {

            if (!response.ok)
                return;

            element.innerHTML = "Select";

            element.removeAttribute("onclick");
            element.setAttribute("onclick", `addToCart(this, ${JSON.stringify(data)})`);

            element.classList.remove("text-danger");
            element.classList.add("text-success");
        },
        onError: (e) => {
            console.log(e);
        }
    });
}

async function updateItemQuantity(element, data) {
    let quantity = element.valueAsNumber;
    let itemId = data;
    let url = `${CART_URL}${itemId}?quantity=${quantity}`;

    await runCartRequest(url, "PUT", {
        onResponse: async (response) => {
            if (!response.ok) {
                element.setAttribute("value", quantity);
                return;
            }

            let totalPriceElement = document.getElementById("totalPriceText");
            let totalDiscountPriceElement = document.getElementById("totalDiscountPriceText");

            let responseAsJson = await response.json();

            totalPriceElement.innerHTML = responseAsJson.total;
            totalDiscountPriceElement.innerHTML = responseAsJson.totalDiscount;
        },
        onError: (error) => {
            element.setAttribute("value", quantity);
            console.log(error);
        }
    });
}

function runCartRequest(url, method, data) {
    return fetch(url, { method: method, credentials: 'same-origin' })
        .then(data.onResponse)
        .catch(data.onError);
}

function confirmOrder(checkBox) {
    let sendOrderButton = document.getElementById("sendOrder");
    sendOrderButton.classList.toggle("disabled");
    
    if (checkBox.checked) sendOrderButton.disabled = "";
    else sendOrderButton.disabled = "disable";
}
// Initialize the counter
let cartCount = 0;

document.getElementById('cartButton').onclick = function () {
    // 1. Increment the count
    cartCount++;

    // 2. Update the UI (innerText for span/badge)
    const display = document.getElementById('cartValue');
    display.innerText = cartCount;

    // 3. Optional: Add a little 'pop' effect for better UX
    display.style.transform = "scale(1.2)";
    setTimeout(() => { display.style.transform = "scale(1)"; }, 100);

    console.log("Items in cart:", cartCount);
};